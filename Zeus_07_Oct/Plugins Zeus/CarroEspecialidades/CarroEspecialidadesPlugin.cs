using System;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace CarroEspecialidades
{
    public class CarroEspecialidadesPlugin:IPlugin
    {
        IZeusWin ZeusWin;
        ToolStripButton button;
        ToolStripMenuItem config;

        #region IPlugin Members

        public string Autor
        {
            get { return "GEObit Ltda. www.geobit.cl"; }
        }

        public string BuildDate
        {
            get { return System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToShortDateString(); }
        }

        public string Descripcion
        {
            get { return "Establece las prioridades de solicitud de apoyo según el tipo de especialidad requerida y localización de la urgencia. Muestra el teléfono de la correspondiente Central de Alarma dónde debe ser solicitado el apoyo. "; }
        }

        public string Licencia
        {
            get { return "C. de B. Metropolitano Sur"; }
        }

        public string Name
        {
            get { return "Solicitud de Apoyo por Especialidad"; }
        }

        public string Version
        {
            get { return this.GetType().Assembly.GetName().Version.ToString(); }
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
            if (ZeusWin.TipoOperadora== TipoOperadora.Administrador)
            {
                config = new ToolStripMenuItem("Modificar Sectores...", null, new EventHandler(MenuClick));
                config.Name = "configSector";
            }
            // botón
            button = new ToolStripButton("Especialidades", Resources.asignacion_carro_especialidad_32, new EventHandler(ButtonClick));
            button.Name = "CEspecialidadesBtn";
            button.TextImageRelation = TextImageRelation.ImageAboveText;
            button.ImageTransparentColor = System.Drawing.Color.Magenta;
            button.AutoSize = false;
            button.Width = 90;
            button.Height = 50;
            ZeusWin.AgregarBoton(button);
        }

        public void Terminate()
        {
            ZeusWin.EliminarBoton(button);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem)sender).Name)
            {
                case "CEspecialidadesBtn":
                    CarroEspecialidad ce = new CarroEspecialidad();
                    ce.ZeusWin = ZeusWin;
                    ce.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void MenuClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem)sender).Name)
            {
                case "configSector":
                    AdminSector As = new AdminSector();
                    As.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        public ToolStripItem GetButton()
        {
            return button;
        }
        #endregion
    }
}
