using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace Recados
{
    public class RecadosPlugin : IPlugin
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
            get { return "Se utiliza para registrar los recados de las operadoras"; }
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
            ts = new ToolStripMenuItem("Recados", null, new EventHandler(MenuClick));
            ts.Name = "config";
            ZeusWin.AgregarConfig(ts);
            // boton
            tb = new ToolStripButton("Recados", Resources.ico1, new EventHandler(ButtonClick));
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
                    FrmRecadosPrincipal config = new FrmRecadosPrincipal();
                    config.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            FrmRecadosPrincipal config = new FrmRecadosPrincipal();
            config.ShowDialog();
        }

        private void RunExe()
        {

        }

        public string Licencia
        {
            get { return "C. de B. Santiago"; }
        }

        public string Name
        {
            get { return "Módulo de Recados"; }
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
