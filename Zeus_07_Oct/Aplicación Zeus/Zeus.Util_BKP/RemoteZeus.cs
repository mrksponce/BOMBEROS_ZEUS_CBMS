using System;
using System.Runtime.InteropServices;
using System.Threading;
using Zeus.Interfaces;

namespace Zeus.Util
{
    [Serializable, ComVisible(true)]
    public delegate void IdHandler(int id);

    public class RemoteZeus : MarshalByRefObject
    {
        public static IZeusWin ZeusWin;

        private static event IdHandler IdChanged;

        public int get_IdExpediente()
        {
            if (ZeusWin == null)
            {
                return 0;
            }
            return ZeusWin.IdExpediente;
        }

        public static void OnIdChanged()
        {
            if (IdChanged != null)
            {
                IdHandler messageDelegate = null;
                Delegate[] invocationList_ = IdChanged.GetInvocationList();
                    lock (typeof (RemoteZeus))
                    {
                        foreach (Delegate del in invocationList_)
                        {
                            try
                            {
                                messageDelegate = (IdHandler) del;
                                // levantar nuevo hilo para manejar la llamada de vuelta
                                new Thread(
                                    () => RunDelegate(messageDelegate, ZeusWin.IdExpediente)).
                                    Start();
                            }
                            catch
                            {
                                IdChanged -= messageDelegate;
                            }
                    }
                }
            }
        }

        private static void RunDelegate(IdHandler del, int param)
        {
            try
            {
                del(param);
            }
            catch
            {
                lock (typeof (RemoteZeus))
                {
                    IdChanged -= del;
                }
            }
        }

        public void AddIdChanged(IdHandler handler)
        {
            IdChanged += handler;
        }

        public void RemoveIdChanged(IdHandler handler)
        {
            IdChanged -= handler;
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}