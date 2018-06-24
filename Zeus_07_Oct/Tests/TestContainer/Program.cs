using System;
using System.Windows.Forms;
using ReportesGraficosEstadisticos;
using Zeus.PluginGeocodificacion;

namespace TestContainer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Zeus.Data.Config.Load();
            Application.Run(new Form1());
            //new Geocodificacion().BuscarEsquina("EL TORREON", "LAS TORRES", "", true);
           
        }
    }
}