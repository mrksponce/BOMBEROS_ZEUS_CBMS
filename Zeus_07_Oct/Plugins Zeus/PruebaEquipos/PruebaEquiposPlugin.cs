using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace PruebaEquipos
{
    public class PruebaEquiposPlugin : IPlugin
    {
        private ToolStripButton tb;
        private ToolStripMenuItem ts2;
        private IZeusWin ZeusWin;

        #region IPlugin Members

        public string Autor
        {
            get { return "GEObit Ltda.    www.geobit.cl"; }
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
                    "Muestra un listado del material mayor actualmente en servicio para la realización de un checklist diario sobre el estado de funcionamiento de los equipos de radiocomunicaciones, y almacena la información para un posterior análisis estadístico.";
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
            //ts = new ToolStripMenuItem("Prueba de Equipos...", null, new EventHandler(MenuClick));
            //ts.Name = "prueba";
            //ZeusWin.AgregarConfig(ts);
            if (ZeusWin.TipoOperadora == TipoOperadora.Administrador)
            {
                ts2 = new ToolStripMenuItem("Configurar Prueba de Equipos...", null, new EventHandler(MenuClick))
                          {Name = "config_prueba"};
                ZeusWin.AgregarConfig(ts2);
            }

            // boton
            tb = new ToolStripButton("Prueba Equipos", Resources.prueba_equipos_32, ButtonClick)
                     {
                         Name = "PruebaEquiposBtn",
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
            get { return "Prueba de Equipos"; }
        }

        public void Terminate()
        {
            ZeusWin.EliminarBoton(tb);
            //ZeusWin.EliminarConfig(ts);
            ZeusWin.EliminarConfig(ts2);
        }

        public string Version
        {
            get { return GetType().Assembly.GetName().Version.ToString(); }
        }

        #endregion

        private static void MenuClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "prueba":
                    new PruebaEquiposForm().ShowDialog();
                    break;
                case "config_prueba":
                    new PruebaEquiposConfigForm().ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "PruebaEquiposBtn":
                    new PruebaEquiposForm().ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}