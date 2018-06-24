using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace BoletinInformativo
{
    public class BoletinInformativoPlugin : IPlugin
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
                    "Genera de manera automática el boletín informativo de las últimas 24 horas con las novedades del servicio. Contabiliza los actos de servicio, indica el material mayor fuera de servicio y el comandante de guardia.";
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
                ts = new ToolStripMenuItem("Configurar Boletín...", null, new EventHandler(MenuClick))
                         {Name = "boletinConfig"};
                ZeusWin.AgregarConfig(ts);
            }

            // boton
            tb = new ToolStripButton("Boletín", null, ButtonClick)
                     {
                         Name = "BoletinBtn",
                         TextImageRelation = TextImageRelation.ImageAboveText,
                         ImageAlign = ContentAlignment.TopCenter,
                         Image = Resources.boletin_informativo_32,
                         AutoSize = false,
                         Width = 90,
                         Height = 50
                     };
            //tb.ImageTransparentColor = System.Drawing.Color.Magenta;
            ZeusWin.AgregarBoton(tb);

            // precargar assemblies
            //DateTime date = new DateTime(); DateTime ts1 = new DateTime(); DateTime ts2 = new DateTime();
#if CBMS
            BoletinCBMS bc = new BoletinCBMS();
            bc.Load();
#elif CBQN
            //date = DateTime.Now;
            //BoletinCBQN bc = new BoletinCBQN();
            //ts1 = DateTime.Now;
            //bc.Load();
            //ts2 = DateTime.Now;
            //MessageBox.Show("Tiempo new:"+(ts1-date).ToString()+" tiempo load:"+(ts2-ts1).ToString());
#endif
        }

        public string Licencia
        {
            get { return "C. de B. Metropolitano Sur"; }
        }

        public string Name
        {
            get { return "Boletín Informativo"; }
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
                case "boletinConfig":
                    new BoletinInformativoConfigForm().ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "BoletinBtn":
                    Cursor.Current = Cursors.WaitCursor;
                    new BoletinInformativoForm().ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}