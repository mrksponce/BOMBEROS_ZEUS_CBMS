using System;
using System.Collections.Generic;
using System.Text;
using ZEUS.Interfaces;
using System.Windows.Forms;

namespace dummy
{
    public class Class1:IPlugin
    {
        #region IPlugin Members

        public string Autor
        {
            get { return "burrix"; }
        }

        public string BuildDate
        {
            get { return System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToShortDateString(); }
        }

        public string Descripcion
        {
            get { return "Super mega hiper plugin!"; }
        }

        public string Licencia
        {
            get { return "Cuerpo de Bomberos Metropolitano Sur"; }
        }

        public void Initialize(ISgcData Isg)
        {
            //throw new Exception("The method or operation is not implemented.");
            //System.Windows.Forms.MessageBox.Show("Iniciado");
            isg = Isg;
            ts = new ToolStripMenuItem("Dummy", null, (EventHandler)null);
            ts.DropDownItems.Add("dummy1", null, new EventHandler(MenuClick));
            ts.DropDownItems.Add("dummy2", null, new EventHandler(MenuClick));
            Isg.AgregarMenu(ts);
            Isg.AgregarSeparador("dum1");
            tb = new ToolStripButton("Hola", Resources.calamardo_189x189, new EventHandler(ButtonClick));
            Isg.AgregarBoton(tb);
        }

        private void MenuClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem)sender).Text)
            {
                case "dummy1":
                    ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
                    break;
                case "dummy2":
                    MessageBox.Show("Otro menú");
                    break;
                default:
                    break;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem)sender).Text)
            {
                case "Hola":
                    MessageBox.Show("Holaaa");
                    break;
                default:
                    break;
            }
        }

        public string Name
        {
            get { return "Dummy"; }
        }

        public string SerialNumber
        {
            get { return "00000"; }
        }

        public void Terminate()
        {
            isg.EliminarMenu(ts);
            isg.EliminarBoton(tb);
            isg.EliminarSeparador("dum1");
            System.Windows.Forms.MessageBox.Show("terminado");
        }

        public string Version
        {
            get { return "dummy 0.0.1"; }
        }

        #endregion

        ToolStripMenuItem ts;
        ToolStripButton tb;
        ISgcData isg;
    }
}
