using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace DespachoHerramientasEquipos
{
    public class DespachoHerramientasEquiposPlugin : IPlugin
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
            get { return "Módulo de Despacho por Solicitud de Herramientas y Equipos"; }
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
                ts = new ToolStripMenuItem("Configurar Despacho por Solicitud de Herramientas y Equipos...", null,
                                           new EventHandler(MenuClick)) {Name = "dheConfig"};
                ZeusWin.AgregarConfig(ts);
            }

            // boton
            tb = new ToolStripButton("Despacho H.E.", Resources.icon, ButtonClick)
                     {
                         ToolTipText = "Despacho por Solicitud de Herramientas y Equipos",
                         Name = "dheButton",
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
            get { return "Despacho por Solicitud de Herramientas y Equipos"; }
        }

        public void Terminate()
        {
            ZeusWin.EliminarBoton(tb);
            ZeusWin.EliminarConfig(ts);
        }

        public string Version
        {
            get { return GetType().Assembly.GetName().Version.ToString(); }
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
                case "dheConfig":
                    new AdminDespachoHerramientasEquiposForm().ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "dheButton":
                    var dhe = new DespachoHerramientasEquiposForm {ZeusWin = ZeusWin};
                    dhe.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}