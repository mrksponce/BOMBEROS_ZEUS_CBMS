using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

using Zeus.UIElements;
//### Nueva referencia  using Zeus.UIElements;




namespace AlertaFerias
{
    public class AlertaFeriasPlugin : IPlugin
    {
        private Alerta alerta;
        private ToolStripMenuItem config;
        private int count;
        private bool f1;
        private ToolStripButton tb;
        private Timer timer;
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
                    "Genera una alerta que muestra un listado de calles obstruidas debido a la instalación de ferias libres. La alerta se genera cuando coincide el despacho con el día y el horario de funcionamiento de las ferias, y se encuentran estas ubicadas en el radio de selección con respecto al lugar de la emergencia.";
            }
        }

        public string Licencia
        {
            get { return "Cuerpo de Bomberos de Linares"; }
        }

        public string Name
        {
            get { return "Alerta de Ferias"; }
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

            timer = new Timer {Interval = 1000};
            timer.Tick += timer_Tick;
            // menú
            config = new ToolStripMenuItem("Configurar Alerta de Ferias...", null, new EventHandler(MenuClick))
                         {Name = "config"};
            ZeusWin.AgregarConfig(config);
            
            Despacho.OnDespacho += DespachoHandler;

            // botón
            tb = new ToolStripButton("Alerta Ferias", /*Resources.feria1.ToBitmap()*/Resources.ferias_32_1, ButtonClick)
                     {
                         Name = "FeriaBtn",
                         Enabled = false,
                         TextImageRelation = TextImageRelation.ImageAboveText,
                         AutoSize = false,
                         Width = 90,
                         Height = 50
                     };
            //tb.ImageTransparentColor = System.Drawing.Color.Magenta;
            ZeusWin.AgregarBoton(tb);
        }

        public void Terminate()
        {
            ZeusWin.EliminarConfig(config);
            ZeusWin.EliminarBoton(tb);
            Despacho.OnDespacho -= DespachoHandler;
        }

        public ToolStripItem GetButton()
        {
            return tb;
        }

        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == AlertaSettings.Default.Tiempo)
            {
                timer.Stop();
                tb.Enabled = false;
                return;
            }
            tb.Image = f1 ? Resources.ferias_32_2 : Resources.ferias_32_1;
            f1 = !f1;
        }

        private void DespachoHandler(object sender, DespachoEventArgs e)
        {


            //MessageBox.Show("Alerta de 10-3", "ZEUS");


            bool hayFeria = false;
            var exp = new e_expedientes().getObjecte_expedientes(e.IdExpediente);
            var centro = new PointD(exp.puntoX, exp.puntoY);
            var feria = new f_ferias();
            DataSet ds = feria.Getf_ferias_punto(centro, AlertaSettings.Default.Radio);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (((int)dr["d1"] == (int)DateTime.Now.DayOfWeek || (int)dr["d2"] == (int)DateTime.Now.DayOfWeek) &&
                    DateTime.Now.TimeOfDay >= ((DateTime)dr["hora_inicio"]).TimeOfDay &&
                    DateTime.Now.TimeOfDay <= ((DateTime)dr["hora_termino"]).TimeOfDay)
                {
                    hayFeria = true;
                    break;
                }
            }

            if (hayFeria)
            {
                alerta = new Alerta { DataSet = ds, Radio = AlertaSettings.Default.Radio };
                count = 0;
                f1 = true;
                tb.Enabled = true;
                timer.Start();
            }
            // verificar dia

            // verificar hora

            // leer!

            // mostrar
            //MessageBox.Show("WAAA");
        }


        private static void MenuClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "config":
                    var cf = new ConfigFerias();
                    cf.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            switch (((ToolStripItem) sender).Name)
            {
                case "FeriaBtn":
                    alerta.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}