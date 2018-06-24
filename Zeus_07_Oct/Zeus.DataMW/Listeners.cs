using System;
using Npgsql;

namespace Zeus.Data
{
    public static class DBNotifyListeners
    {
        public static void RegisterListener(EventHandler<ListenerEventArgs> Handler)
        {
            if (lConn == null)
            {
                CnxBase myBase = new CnxBase();
                lConn = myBase.OpenConnection(myBase.cnxString + ";SyncNotification=true;");
                lConn.Notification += new NotificationEventHandler(OnListener);
                NpgsqlCommand Comm = new NpgsqlCommand("Listen insertexpediente;Listen bitacora;Listen updateexpediente;Listen despacho; Listen cdespacho;listen z_guardia;listen z_carros", lConn);
                Comm.ExecuteNonQuery();
            }
            listeners += Handler;
        }

        public static void UnregisterListener(EventHandler<ListenerEventArgs> Handler)
        {
            listeners -= Handler;
        }

        private static void OnListener(object sender, NpgsqlNotificationEventArgs e)
        {
            if (listeners != null)
            {
                ListenerEventArgs ev = new ListenerEventArgs(e.Condition);
                listeners(sender, ev);
            }
        }

        public static void CloseListeners()
        {
            if (lConn != null && lConn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    lConn.Close();
                }
                catch { }
            }
        }

        public static void CheckBD()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select version()";
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
            myCommand.ExecuteNonQuery();
            myBase.CloseConnection(myConn);
        }

        private static NpgsqlConnection lConn = null;
        private static EventHandler<ListenerEventArgs> listeners;
    }
}
