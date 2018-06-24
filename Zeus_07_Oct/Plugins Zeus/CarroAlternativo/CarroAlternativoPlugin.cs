using System;
using System.IO;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace Carros
{
    public class CarroAlternativoPlugin : IPlugin
    {
        //ToolStripMenuItem main;
        private ToolStripButton boton;
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
                    "Asigna las prioridades de despacho a un segundo carro, cuando son transbordados los principales equipos y herramientas desde un carro equipado para atender urgencias de una determinada especialidad, debido a que permanecerá fuera de servicio por un tiempo prolongado.";
            }
        }

        public string Licencia
        {
            get { return "C. de B. Metropolitano Sur"; }
        }

        public string Name
        {
            get { return "Asignación de Carro Alternativo"; }
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

            // boton
            boton = new ToolStripButton("C. Alternativo", Resources.carro_alternativo_32, ButtonClick)
                        {
                            Name = "CarroAltBtn",
                            ToolTipText = "Carro Alternativo",
                            TextImageRelation = TextImageRelation.ImageAboveText,
                            AutoSize = false,
                            Width = 90,
                            Height = 50
                        };
            //boton.ImageTransparentColor = System.Drawing.Color.White;
            ZeusWin.AgregarBoton(boton);

            // menu
            //main = new ToolStripMenuItem("Carros", null, (EventHandler)null);
            //ToolStripMenuItem mc = new ToolStripMenuItem("Carro Alternativo...", null, new EventHandler(MenuClick));
            //mc.Name = "alternativo";
            //main.DropDownItems.Add(mc);
            //ZeusWin.AgregarMenu(main);
        }

        public void Terminate()
        {
            //ZeusWin.EliminarMenu(main);
            ZeusWin.EliminarBoton(boton);
        }

        public ToolStripItem GetButton()
        {
            return boton;
        }

        #endregion

/*
        private void MenuClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "alternativo":
                    CarroAlternativo ca = new CarroAlternativo();
                    ca.ShowDialog();
                    break;
                default:
                    break;
            }
        }
*/

        private static void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "CarroAltBtn":
                    var ca = new CarroAlternativo();
                    ca.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}