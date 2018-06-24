using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace Tonos
{
    public class TonosPlugin:IPlugin
    {
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
            get { return "Accede a la consola de tonos utilizada por el correspondiente Cuerpo de Bomberos. El módulo sólo se encarga de configurar y abrir el archivo en formato flash que es utilizado para emitir los diversos tonos. El sistema ZEUS no es responsable del funcionamiento y sonidos emitidos por la aplicación flash. "; }
        }
        ToolStripMenuItem ts;
        ToolStripButton tb;
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
            ts = new ToolStripMenuItem("Configurar Consola Tonos...", null, new EventHandler(MenuClick));
            ts.Name = "config";
            ZeusWin.AgregarConfig(ts);
            // boton
            tb = new ToolStripButton("Consola Tonos", Resources.consola_tonos_32, new EventHandler(ButtonClick));
            tb.Name = "TonosBtn";
            tb.TextImageRelation = TextImageRelation.ImageAboveText;
            tb.ImageTransparentColor = System.Drawing.Color.Magenta;
            tb.AutoSize = false;
            tb.Width = 90;
            tb.Height = 50;
            ZeusWin.AgregarBoton(tb);
        }

        private void MenuClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem)sender).Name)
            {
                case "config":
                    Configuracion config = new Configuracion();
                    config.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem)sender).Name)
            {
                case "TonosBtn":
                    if (TonosSettings.Default.Ejecutable != "")
                    {
                        RunExe();
                    }
                    else
                    {
                        MessageBox.Show("Debe configurar el ejecutable de tonos primero");
                    }
                    break;
                default:
                    break;
            }
        }

        private void RunExe()
        {
            FileInfo fi = new FileInfo(TonosSettings.Default.Ejecutable);
            if (fi.Exists)
            {
                ProcessStartInfo pi = new ProcessStartInfo(TonosSettings.Default.Ejecutable);
                pi.WorkingDirectory = fi.DirectoryName;
                Process.Start(pi);
            }
        }

        public string Licencia
        {
            get { return "C. de B. Metropolitano Sur"; }
        }

        public string Name
        {
            get { return "Consola de Tonos"; }
        }

        public void Terminate()
        {
            ZeusWin.EliminarBoton(tb);
            ZeusWin.EliminarConfig(ts);
        }

        public string Version
        {
            get { return this.GetType().Assembly.GetName().Version.ToString(); }
        }

        public ToolStripItem GetButton()
        {
            return tb;
        }
        #endregion

        IZeusWin ZeusWin;
    }
}
