using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace AgendaDepartamentos
{
    public class AgendaDepartamentosPlugin : IPlugin
    {
        private ToolStripButton button;
        private ToolStripMenuItem config;
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
                    "Muestra los teléfonos de contacto correspondiente a los Inspectores y Ayudantes Generales de los diversos Departamentos de la institución. ";
            }
        }

        public string Licencia
        {
            get { return "C. de B. Metropolitano Sur"; }
        }

        public string Name
        {
            get { return "Solicitud de Inspectores y Ayudantes Generales"; }
        }

        public string Version
        {
            get { return GetType().Assembly.GetName().Version.ToString(); }
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

            // menú
            if (ZeusWin.TipoOperadora == TipoOperadora.Administrador)
            {
                config = new ToolStripMenuItem("Configurar Agenda Inspectores...", null, new EventHandler(MenuClick))
                             {Name = "configAgendaDepto"};
                ZeusWin.AgregarConfig(config);
            }
            // botón
            button = new ToolStripButton("A. Inspectores", Resources.agenda_inspectores_32, ButtonClick)
                         {
                             Name = "AgendaDepartamentosBtn",
                             ToolTipText = "Agenda Inspectores",
                             TextImageRelation = TextImageRelation.ImageAboveText,
                             ImageTransparentColor = Color.Magenta,
                             AutoSize = false,
                             Width = 90,
                             Height = 50
                         };
            //button.Visible = false;
            ZeusWin.AgregarBoton(button);
        }

        public void Terminate()
        {
            ZeusWin.EliminarBoton(button);
            ZeusWin.EliminarConfig(config);
        }

        public ToolStripItem GetButton()
        {
            return button;
        }

        #endregion

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "AgendaDepartamentosBtn":
                    var ad = new AgendaDepartamentosForm {ZeusWin = ZeusWin};
                    ad.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private static void MenuClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "configAgendaDepto":
                    new AgendaDepartamentosAdminForm().ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}