using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace LibroNovedades
{
    public class LibroNovedadesPlugin : IPlugin
    {
        private ToolStripSplitButton tb;
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
                    "Genera de manera automática un reporte con las novedades del servicio. La información es ordenada de manera cronológica y puede ser seleccionada de manera diaria, semanal, mensual, trimestral, semestral y anual.";
            }
        }

        public ToolStripItem GetButton()
        {
            return tb;
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
            //ts = new ToolStripMenuItem("Libro de Novedades...", null, new EventHandler(MenuClick));
            //ts.Name = "novedades";
            //ZeusWin.AgregarConfig(ts);

            var tmi = new ToolStripMenuItem("Agregar nuevo evento...") {Name = "cms_novedades"};
            tmi.Click += MenuClick;
            tmi = new ToolStripMenuItem("Ver bitácoras...") {Name = "cms_ver"};
            tmi.Click += MenuClick;


            // boton
            tb = new ToolStripSplitButton("L. Novedades", Resources.libro_novedades_32, new EventHandler(ButtonClick))
                     {
                         Name = "NovedadesBtn",
                         ToolTipText = "Libro Novedades",
                         TextImageRelation = TextImageRelation.ImageAboveText,
                         ImageTransparentColor = Color.Magenta,
                         AutoSize = false,
                         Width = 90,
                         Height = 50
                     };
            tb.DropDown.Items.Add("Agregar Nuevo Evento...", null, MenuClick).Name = "cms_novedades";
            tb.DropDown.Items.Add("Ver Libro de Novedades...", null, MenuClick).Name = "cms_ver";

            ZeusWin.AgregarBoton(tb);
        }

        public string Licencia
        {
            get { return "C. de B. Metropolitano Sur"; }
        }

        public string Name
        {
            get { return "Libro de Novedades"; }
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

        #endregion

        private void MenuClick(object sender, EventArgs e)
        {
            var ti = sender as ToolStripItem;
            if (ti != null)
                switch (ti.Name)
                {
                    case "novedades":
                        var fn = new FormNovedades {ZeusWin = ZeusWin};
                        fn.ShowDialog();
                        break;
                    case "cms_novedades":
                        var fn2 = new FormNovedades {ZeusWin = ZeusWin};
                        fn2.ShowDialog();
                        break;
                    case "cms_ver":
                        //FormNovedades fn = new FormNovedades();
                        //fn.ZeusWin = ZeusWin;
                        //fn.ShowDialog();
                        break;

                    default:
                        break;
                }
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            var ti = sender as ToolStripSplitButton;
            if (ti != null)
                switch (ti.Name)
                {
                    case "NovedadesBtn":
                        //FormNovedades fn = new FormNovedades();
                        //fn.ZeusWin = ZeusWin;
                        //fn.ShowDialog();
                        //cms.Show(new Point());
                        ti.ShowDropDown();
                        break;
                    default:
                        break;
                }
        }
    }
}