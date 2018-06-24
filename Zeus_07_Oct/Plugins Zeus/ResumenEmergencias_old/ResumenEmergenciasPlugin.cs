using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace ResumenEmergencias
{
    public class ResumenEmergenciasPlugin : IPlugin
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
            get
            {
                return
                    "Genera de manera automática un reporte con las horas de salida y llegada de los carros a cada acto de servicio. La selección de información puede ser en relación a las últimas 24 horas o un periodo de tiempo especificado.";
            }
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
                ts = new ToolStripMenuItem("Configurar Resumen Actos...", null, new EventHandler(MenuClick))
                         {Name = "resumenConfig"};
                ZeusWin.AgregarConfig(ts);
            }

            // boton
            tb = new ToolStripButton("Resumen Actos", Resources.resumen_actos_servicios_32, ButtonClick)
                     {
                         Name = "ResumenBtn",
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
            get { return "Cuerpo de Bomberos de Santiago"; }
        }

        public string Name
        {
            get { return "Resumen Actos del Servicio"; }
        }

        public void Terminate()
        {
            ZeusWin.EliminarBoton(tb);
            //ZeusWin.EliminarConfig(ts);
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
                case "resumenConfig":
                    new ResumenEmergenciasConfigForm().ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "ResumenBtn":
                    new ResumenEmergenciasForm().ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}