using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace ReportesGraficosEstadisticos
{
    public class ReportesGraficosEstadisticosPlugin : IPlugin
    {
        private ToolStripButton tb;
        private IZeusWin ZeusWin;

        #region IPlugin Members

        public string Autor
        {
            get { return "GEObit Ltda. www.geobit.cl"; }
        }

        public string BuildDate
        {
            get { return File.GetLastWriteTime(GetType().Assembly.Location).ToShortDateString(); }
        }

        public string Descripcion
        {
            get { return "Módulo de Gráficos y Estadísticas."; }
        }

        public ToolStripItem GetButton()
        {
            return tb;
        }

        public void Initialize(IZeusWin Isg)
        {
            ZeusWin = Isg;

#if USBKEY
    // verificar llave
            USBKey usb = new USBKey();
            if (!usb.IniciarConexion("00"))
            {
                return;
            }
#endif
            // menu
            //ts = new ToolStripMenuItem("Prueba de Equipos...", null, new EventHandler(MenuClick));
            //ts.Name = "prueba";
            //ZeusWin.AgregarConfig(ts);
            //if (ZeusWin.TipoOperadora == TipoOperadora.Administrador)
            //{
            //    ts2 = new ToolStripMenuItem("Configurar Prueba de Equipos...", null, new EventHandler(MenuClick));
            //    ts2.Name = "config_prueba";
            //    ZeusWin.AgregarConfig(ts2);
            //}

            // boton
            tb = new ToolStripButton("Estadísticas", Resources.statistics_32x32, ButtonClick)
                     {
                         Name = "EstadisticasBtn",
                         TextImageRelation = TextImageRelation.ImageAboveText,
                         ImageTransparentColor = Color.Magenta,
                         AutoSize = false,
                         Width = 90,
                         Height = 50
                     };
            ZeusWin.AgregarBoton(tb);
        }

        public string Licencia
        {
            get { return "C. de B. Metropolitano Sur"; }
        }

        public string Name
        {
            get { return "Estadísticas"; }
        }

        public void Terminate()
        {
            ZeusWin.EliminarBoton(tb);
            //ZeusWin.EliminarConfig(ts);
            //ZeusWin.EliminarConfig(ts2);
        }

        public string Version
        {
            get { return GetType().Assembly.GetName().Version.ToString(); }
        }

        #endregion

        //private ToolStripMenuItem ts, ts2;

        //private void MenuClick(object sender, EventArgs e)
        //{
        //    switch (((ToolStripItem)sender).Name)
        //    {
        //        case "prueba":
        //            new FormPrueba().ShowDialog();
        //            break;
        //        case "config_prueba":
        //            new FormPruebaAdmin().ShowDialog();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "EstadisticasBtn":
                    var rg = new ReportesGraficosForm {ZeusWin = ZeusWin};
                    rg.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}