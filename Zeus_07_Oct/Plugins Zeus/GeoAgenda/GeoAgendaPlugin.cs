using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace GeoAgenda
{
    public class GeoAgendaPlugin : IPlugin
    {
        private ToolStripButton tb;
        private ToolStripMenuItem ts;
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
            get { return "Módulo de Agenda Geográfica"; }
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
            if (ZeusWin.TipoOperadora == TipoOperadora.Administrador)
            {
                ts = new ToolStripMenuItem("Configurar GeoAgenda...", null, new EventHandler(MenuClick))
                         {Name = "geoConfig"};
                ZeusWin.AgregarConfig(ts);
            }

            // boton
            tb = new ToolStripButton("GeoAgenda", Resources.Agenda, ButtonClick)
                     {
                         Name = "GeoAgendaBtn",
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
            get { return "Agenda Geográfica"; }
        }

        public void Terminate()
        {
            ZeusWin.EliminarBoton(tb);
            ZeusWin.EliminarConfig(ts);
        }

        public string Version
        {
            get { return "ASD"; }
        }

        public ToolStripItem GetButton()
        {
            return tb;
        }

        #endregion

        private static void MenuClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "geoConfig":
                    new GeoAdmin().ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "GeoAgendaBtn":
                    var a = new Agenda {ZeusWin = ZeusWin};
                    a.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}