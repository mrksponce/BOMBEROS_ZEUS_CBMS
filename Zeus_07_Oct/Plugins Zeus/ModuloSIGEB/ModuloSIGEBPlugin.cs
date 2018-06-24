using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using Zeus.Interfaces;
using Zeus.Data;
using Zeus.Util;


namespace ModuloSIGEB
{
    public class PreparaMaterialPlugin : IPlugin
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
            //get { return System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToShortDateString(); }
            get { return File.GetLastWriteTime(GetType().Assembly.Location).ToShortDateString(); }
        }

        public string Descripcion
        {
            get
            {
                return
                    "Módulo SIGEB";
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
            ts = new ToolStripMenuItem("SIGEB", null, new EventHandler(MenuClick)) { Name = "config" };
            ZeusWin.AgregarConfig(ts);

            // boton
            tb = new ToolStripButton("SIGEB", RecursosSIGEB.ico1, ButtonClick)
            {
                Name = "SigebBtn",
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
            get { return "SIGEB"; }
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


        private void MenuClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem)sender).Name)
            {
                case "config":
                    //MaterialMayor config = new MaterialMayor();
                    //config.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem)sender).Name)
            {
                case "SigebBtn":
                    FormularioSIGEB sigeb = new FormularioSIGEB();
                    sigeb.ShowDialog();

                    break;
                default:
                    break;
            }

        }

        private void RunExe()
        {

        }






        //IZeusWin ZeusWin;



        //#region Miembros de IZeusWin

        //string IZeusWin.Usuario
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //TipoOperadora IZeusWin.TipoOperadora
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //int IZeusWin.IdOperadora
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //int IZeusWin.IdAval
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //int IZeusWin.IdExpediente
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //PointD IZeusWin.LastGeo
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //void IZeusWin.AgregarMenu(ToolStripMenuItem item)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.AgregarBoton(ToolStripItem button)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.AgregarSeparador(string nombre)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.AgregarConfig(ToolStripMenuItem item)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.EliminarMenu(ToolStripMenuItem item)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.EliminarBoton(ToolStripItem button)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.EliminarSeparador(string nombre)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.EliminarConfig(ToolStripMenuItem item)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.BarraEstado(string msj)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.Ocupado(bool estado)
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.Actualizar()
        //{
        //    throw new NotImplementedException();
        //}

        //void IZeusWin.AddActualizarHandler(EventHandler handler)
        //{
        //    throw new NotImplementedException();
        //}

        //IPlugin IZeusWin.GetPluginActivo(string nombre)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion
    }
}
