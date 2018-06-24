using System;
using Zeus.Data;
using Zeus.Util;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Zeus.Application
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //// verificar red
            Process mapwindow;
            Config.Load();
            try
            {
                DBNotifyListeners.CheckBD();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Ha ocurrido el siguiente error al intentar conectar con la base de datos:\n"+e.Message+"\nLa aplicación se cerrará.","Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.ShowAndLog(e);
                return;
            }

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainForm());
            //var fi = new FileInfo(System.Windows.Forms.Application.StartupPath + @"\MapWindow\MapWindow.exe");
            //if (fi.Exists)
            //{
                //ProcessStartInfo pi = new ProcessStartInfo(fi.FullName, fi.DirectoryName + @"\New.mwprj") { WorkingDirectory = fi.DirectoryName };
                //mapwindow = Process.Start(pi);
            //}
        }
    }
}