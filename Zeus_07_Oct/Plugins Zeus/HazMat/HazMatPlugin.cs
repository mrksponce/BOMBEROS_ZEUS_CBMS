using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace HazMat
{
    public class HazMatPlugin : IPlugin
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
                    "Accede a la guía ERGOS para conocer mayores antecedentes sobre las diversas sustancias peligrosas. El módulo sólo se encarga de configurar y abrir el archivo ejecutable que se encuentra instalado en la correspondiente estación de trabajo. El sistema ZEUS no es responsable del funcionamiento e información contenida en ese programa. ";
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
            ts = new ToolStripMenuItem("Configurar HazMat...", null, new EventHandler(MenuClick)) {Name = "config"};
            ZeusWin.AgregarConfig(ts);
            // boton
            tb = new ToolStripButton("Guía ERGOS", Resources.ergo_32, ButtonClick)
                     {
                         Name = "HazMatBtn",
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
            get { return "Guía ERGOS"; }
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
                case "config":
                    var config = new Configuracion();
                    config.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "HazMatBtn":
                    if (HazMatSettings.Default.Ejecutable != "")
                        RunExe();
                    else
                    {
                        MessageBox.Show("Debe configurar el ejecutable HazMat primero");
                    }
                    break;
                default:
                    break;
            }
        }

        private static void RunExe()
        {
            var fi = new FileInfo(HazMatSettings.Default.Ejecutable);
            if (fi.Exists)
            {
                var pi = new ProcessStartInfo(HazMatSettings.Default.Ejecutable) {WorkingDirectory = fi.DirectoryName};
                Process.Start(pi);
            }
        }
    }
}