using System;
using System.Threading;
using Zeus.Data;
using Zeus.Util;


namespace DatabaseUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            // cargar config local
            Config.LoadLocal();

            // hilo actualizador
            Thread t1 = new Thread(new ThreadStart(ActualizarDatos));
            t1.Start();

            // hilo servidor localizacion
            Thread t2 = new Thread(new ThreadStart(ServidorLocalizacion));
            t2.Start();
        }

        private static void ActualizarDatos()
        {
            Thread.Sleep((60 - DateTime.Now.Second) * 1000);
            while (true)
            {
                Funciones.VerificarServicio();
                Thread.Sleep(60000);
            }
        }

        private static void ServidorLocalizacion()
        {
            AutoResetEvent e = new AutoResetEvent(false);
            LocalizacionGPS.StartServer();
            e.WaitOne();
        }
    }
}
