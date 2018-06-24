using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;


namespace Reemplazos
{
    public class ReemplazosPlugin : IPlugin
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
            get { return "Habilita una especialidad en el Material Mayor Seleccionado"; }
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
            //// menu
            //ts = new ToolStripMenuItem("Reemplazos", null, new EventHandler(MenuClick));
            //ts.Name = "config";
            //ZeusWin.AgregarConfig(ts);
            
            // boton
            tb = new ToolStripButton("Reemplazo", Properties.Resources.icono_reemplazo, new EventHandler(ButtonClick));
            tb.Name = "TonosBtn";
            tb.TextImageRelation = TextImageRelation.ImageAboveText;
            tb.ImageTransparentColor = System.Drawing.Color.Magenta;
            tb.AutoSize = false;
            tb.Width = 90;
            tb.Height = 50;
            ZeusWin.AgregarBoton(tb);
        }

        /*
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
        */

        private void ButtonClick(object sender, EventArgs e)
        {
            //ReemplazoCarros reem = new ReemplazoCarros();
            var reem = new ReemplazoCarros { ZeusWin = ZeusWin };
            reem.ShowDialog();

        }

        private void RunExe()
        {

        }

        public string Licencia
        {
            get { return "C. de B. Metropolitano Sur"; }
        }

        public string Name
        {
            get { return "Módulo Habilita Reemplazos"; }
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
