using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Zeus.Application.Properties;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.UIElements;
using Zeus.UIElements.AdminForms;
using Zeus.Util;
using System.Collections.Generic;

namespace Zeus.Application
{
    public partial class MainForm : Form, IZeusWin
    {
        public static bool estadoWek = true;
        private e_expedientes exp = new e_expedientes();


        public MainForm()
        {
            InitializeComponent();

            // inicializar sistema de logs

            Log.Init(Path.Combine(System.Windows.Forms.Application.UserAppDataPath,
                                  "Log " + DateTime.Now.ToString("dd-MM-yy") + ".txt"));

            plugins = new PluginsManager(this);
            usbKey = new USBKey();

            // agregar referencias
            mainTabs1.ZeusWin = this;
            mainLlamadosCarros1.ZeusWin = this;
            mainTree1.ZeusWin = this;
        }

        #region MANEJADORES DE EVENTOS

        private void Hora_Tick(object sender, EventArgs e)
        {
            // actualizar hora
            tsHora.Text = DateTime.Now.ToString();
            if (DateTime.Now.Hour.ToString() == "0" && estadoWek == true)
            {
                CeroHoras.Enabled = true;
                estadoWek = false;
            }

            if (DateTime.Now.Hour.ToString() == "1" && estadoWek == true)
            {
                estadoWek = true;
            }

            // verificar llave
#if USBKEY
            if (!llavePresente)
            {
                VerificacionLlave.Stop();
                if (FormHelper.IsActive(this))
                {
                    DialogResult dr;
                    do
                    {
                        dr = usbKey.MensajeFalloProteccion(usbKey.Estado);
                        if (dr == DialogResult.Retry)
                        {
                            llavePresente = usbKey.VerificarLlaveUSB();
                        }
                    } while (dr == DialogResult.Retry && !llavePresente);
                    // verificar que hacer
                    if (!llavePresente)
                    {
                        //salir!
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        VerificacionLlave.Start();
                    }
                }
            }
#endif
        }

        private void mainTree1_OnSeleccion(object sender, DataEventArgs e)
        {
            if (e != null && (e.TipoElemento == TipoElemento.Expediente || e.TipoElemento == TipoElemento.Servicio))
            {
                id_expediente = e.Id;
                Cursor = Cursors.WaitCursor;
                RemoteZeus.OnIdChanged();
                Cursor = Cursors.Default;
            }
        }

        private void administrarMódulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var am = new AdminModulos(plugins) { Icon = Icon.FromHandle(Resources.modulos.GetHicon()) };
            am.ShowDialog();

            // actualizar menú
            mnuMostrar.DropDown.Items.Clear();
            foreach (PluginStatus p in plugins.GetPlugins())
            {
                if (p.Activado)
                {
                    ToolStripItem b = p.Plugin.GetButton();
                    if (b != null)
                    {
                        var m = new ToolStripMenuItem(p.Plugin.Name, null, verPlugin_Click) { CheckOnClick = true, Checked = b.Visible, Tag = p.Archivo };
                        mnuMostrar.DropDown.Items.Add(m);
                    }
                }
            }
        }

        private void verPlugin_Click(object sender, EventArgs e)
        {
            var tMenu = (ToolStripMenuItem)sender;
            if (tMenu.Checked)
            {
                plugins.MostrarPlugin((string)tMenu.Tag, true);
            }
            else
            {
                plugins.MostrarPlugin((string)tMenu.Tag, false);
            }
        }

        private void toolMódulos_Click(object sender, EventArgs e)
        {
            administrarMódulosToolStripMenuItem_Click(sender, e);
        }

        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var config = new Configuracion();
            config.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBNotifyListeners.CloseListeners();
            CerrarPlugins();
            if (mapwindow != null && !mapwindow.HasExited)
            {
                while (!mapwindow.HasExited)
                {
                    // try to close main window and wait 2 seconds
                    mapwindow.CloseMainWindow();
                    mapwindow.WaitForExit(2000);
                    if (!mapwindow.HasExited)
                    {
                        MessageBox.Show(
                            "No se puede cerrar MapWindow. Compruebe que todos los diálogos estén cerrados, y presione aceptar para volver a intentarlo.",
                            "Cerrando MapWindow", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            Log.Finish();
        }

        private void CerrarPlugins()
        {
            try
            {
                Settings.Default.Plugins = plugins.GuardarConfig(Settings.Default.Plugins, usuario,
                                                                 ToolStripHelper.GetItemOrder(ToolBox));
                Settings.Default.Save();
                plugins.DescargarPlugins();
            }
            catch (NullReferenceException)
            {
            }
        }

        private void toolMaterialMayor_Click(object sender, EventArgs e)
        {
            var mm = new MaterialMayor { Icon = Icon.FromHandle(Resources.material_mayor_32.GetHicon()), ZeusWin = this };
            //mm.Show();        //### Ventana Independiente
            mm.ShowDialog();    //### Ventana Dependiente

            //System.Diagnostics.Process proceso = new System.Diagnostics.Process();
            ////proceso.StartInfo.FileName = @"C:\Program Files (x86)\PostgreSQL\8.4\bin\psql.exe";
            //proceso.StartInfo.FileName = @"C:\comander\minPathWin32_zeus02.exe";
            //proceso.StartInfo.Arguments = "-K 12356";
            //proceso.Start();

            //MessageBox.Show("Se ha ejecutado el Archivo   :)",
            //                "Módulo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void puestaEnServicioDeCarrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ps = new PuestaServicio { IZeusWin = this };
            ps.ShowDialog();
        }

        private void voluntariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminVoluntarios().ShowDialog();
        }

        private void cuartelerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminCuarteleros().ShowDialog();
        }

        private void carrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminCarros().ShowDialog();
        }

        private void cantidadDeCarrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ad = new AdminDespacho { ZeusWin = this };
            ad.ShowDialog();
        }

        private void ordenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ao = new AdminOrden{ZeusWin=this} ;
            ao.ShowDialog();
        }

        private void prioridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ap = new AdminPrioridad { ZeusWin = this };
            ap.ShowDialog();
        }

        private void oficialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminOficiales().ShowDialog();
        }

        private void nuevoInterinajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if CBQN
            MessageBox.Show("Este módulo no se encuentra disponible en esta versión del Sistema Zeus",
                            "Módulo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
            new InterinajeForm().ShowDialog();
#endif
        }

        private void clavesYSubclavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminLlamados().ShowDialog();
        }

        private void preinformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminPreinforme().ShowDialog();
        }

        private void conductoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new AdminConductor().ShowDialog();
        }

        private void operadorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminOperadoras().ShowDialog();
        }

        private void locutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminLocutores().ShowDialog();
        }

        private void compañíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminCompania().ShowDialog();
        }

        private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
        {
            slidePanel1.MaxHeight = splitContainer1.Panel2.Height;
        }

        private void VerificacionLlave_Tick(object sender, EventArgs e)
        {
            // verificar llave
            try
            {
                llavePresente = usbKey.VerificarLlaveUSB();
                if (llavePresente)
                {
                    // reprogramar proxima verificacion
                    var r = new Random();
                    VerificacionLlave.Interval = r.Next(1200000) + 600000;
                }
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("Error fatal: no se ha encontrado la librería de protección, el sistema se cerrará.",
                                "Librería de Protección no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Desea cerrar la sesión del usuario '" + usuario + "'?", "Cierre de sesión",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DoLogout();
                BitacoraGestion.NuevoEvento(id_operadora, id_aval, "Cierre de sesión");
                DoLogOn();
            }
        }

        private void continuarExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ce = new ContinuarExpediente { ZeusWin = this };
            ce.ShowDialog();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cc = new CambiarContraseña { ZeusWin = this };
            cc.ShowDialog();
        }

        private void oficialDeGuardiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if CBQN
            MessageBox.Show("Este módulo no se encuentra disponible en esta versión del Sistema Zeus",
                            "Módulo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
            new AdminGuardia().ShowDialog();
#endif
        }

        #endregion

        #region IZeusWin Members

        public void AgregarMenu(ToolStripMenuItem item)
        {
            MenuPrincipal.Items.Insert(MenuPrincipal.Items.Count - 1, item);
        }

        public void AgregarBoton(ToolStripItem button)
        {
            ToolBox.Items.Add(button);
        }

        public void AgregarSeparador(string nombre)
        {
            var ts = new ToolStripSeparator { Name = nombre };
            ToolBox.Items.Add(ts);
        }

        public void AgregarConfig(ToolStripMenuItem item)
        {
            módulosToolStripMenuItem.DropDownItems.Add(item);
        }

        public void EliminarMenu(ToolStripMenuItem item)
        {
            MenuPrincipal.Items.Remove(item);
        }

        public void EliminarBoton(ToolStripItem button)
        {
            ToolBox.Items.Remove(button);
        }

        public void EliminarSeparador(string nombre)
        {
            for (int i = 0; i < ToolBox.Items.Count; i++)
            {
                var tss = ToolBox.Items[i] as ToolStripSeparator;
                if (tss != null && tss.Name == nombre)
                {
                    ToolBox.Items.Remove(tss);
                }
            }
        }

        public void EliminarConfig(ToolStripMenuItem item)
        {
            módulosToolStripMenuItem.DropDownItems.Remove(item);
        }

        public void BarraEstado(string msj)
        {
            lblBarraEstado.Text = msj;
        }

        public void Ocupado(bool estado)
        {
            UseWaitCursor = estado;
        }

        public void Actualizar()
        {
            if (actualizar != null)
            {
                actualizar(null, new EventArgs());
            }
        }

        public void AddActualizarHandler(EventHandler handler)
        {
            actualizar += handler;
        }

        public string Usuario
        {
            get { return usuario; }
        }

        public TipoOperadora TipoOperadora
        {
            get { return tipoOperadora; }
        }

        public int IdOperadora
        {
            get { return id_operadora; }
        }

        public int IdAval
        {
            get { return id_aval; }
        }

        public int IdExpediente
        {
            get { return id_expediente; }
        }

        public PointD LastGeo
        {
            get
            {
                try
                {
                    //FileStream s = new FileStream(System.Windows.Forms.Application.StartupPath + @"\MapWindow\Plugins\ubicacion.txt", FileMode.Open);
                    FileStream s = File.OpenRead(Path.Combine(Path.GetTempPath(), "ubicacion.txt"));
                    var b = new BinaryFormatter();
                    var p = (PointD)b.Deserialize(s);
                    return p;
                }
                catch
                {
                    return new PointD();
                }
            }
        }

        public IPlugin GetPluginActivo(string nombre)
        {
            if (plugins != null)
            {
                foreach (PluginStatus plug in plugins.GetPlugins())
                {
                    if (plug.Plugin.Name == nombre && plug.Activado)
                    {
                        return plug.Plugin;
                    }
                }
            }
            return null;
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            RecursosEstaticos.PrimeraCarga = 1;
            // proteccion anticopia
            // PASO 1: Se setean los carros en la tabla zs_estado_carros
            z_carros carros = new z_carros();
            carros.SetEstadoCarros();
#if USBKEY
            if (!IniciarAntiCopia())
            {
                System.Windows.Forms.Application.Exit();
                return;
            }
#endif
            // RPC
            StartRPCServer();
            // inicializar.
            Hora.Start();
            slidePanel1.MaxHeight = mainLlamadosCarros1.Height;
            slidePanel1.ZeusWin = this;
            // título de ventana
#if CBMS
            this.Text = "Sistema ZEUS - Cuerpo de Bomberos Metropolitano Sur";
#elif CBQN
            Text = "Sistema ZEUS - Cuerpo de Bomberos Metropolitano Sur - v2";
#endif
            // expedientes
            slidePanel1.OnAsignacion += mainTree1.OnAsignacionHandler;
            slidePanel1.OnAsignacion += mainLlamadosCarros1.OnAsignacionHandler;
            // treeview
            mainTree1.OnSeleccion += mainLlamadosCarros1.OnSeleccionHandler;
            mainTree1.OnSeleccion += mainTabs1.OnSeleccionHandler;
            mainTree1.OnSeleccion += mainTree1_OnSeleccion;

            // mapwindow
//#if !DEBUG
            RunMapWindow();
//#endif
            // tonos
        }

        private void DoLogOn()
        {
            // login
            var login = new LogOn();
            if (login.ShowDialog() != DialogResult.OK)
            {
                // cerrar todo
                System.Windows.Forms.Application.Exit();
                return;
            }
            usuario = login.Usuario;
            tipoOperadora = login.TipoOperadora;
            id_operadora = login.Id_operadora;
            BitacoraLlamado.IdOperadora = id_operadora;
            slidePanel1.Id_operadora = id_operadora;
            id_aval = login.Id_aval;
            BitacoraGestion.NuevoEvento(id_operadora, id_aval, "Inicio de sesión");
            // menú
            if(tipoOperadora== TipoOperadora.Administrador)
            {
                ModifyMenu(administraciónToolStripMenuItem,true);
            }
            else
            {
                ModifyMenu(administraciónToolStripMenuItem, false);
                administraciónToolStripMenuItem.Enabled = true;
                recursosHumanosToolStripMenuItem.Enabled = true;
                oficialesToolStripMenuItem.Enabled = true;
            }

            //### Cambio de Usuario
            DatosLogin.LoginUsuario = login.Id_operadora;
            DatosLogin.NomUsuario = login.Usuario;
            
            
            //administraciónToolStripMenuItem.Visible = tipoOperadora == TipoOperadora.Administrador;
            // barra
            lblUsuario.Text = "Operadora: " + usuario;
            lblBaseDatos.Text = "Base de Datos: " + Config.Database;
            lblServidor.Text = "Servidor: " + Config.Host;

            mainTree1.CargarExpedientes(id_operadora);

            // plugins
            if (Settings.Default.Plugins != null)
            {
                string itemOrder = plugins.CargarConfig(Settings.Default.Plugins, usuario);
                plugins.CargarPlugins(System.Windows.Forms.Application.StartupPath + @"\Modulos");
                ToolStripHelper.SetItemOrder(ToolBox, itemOrder);
            }
            else
            {
                plugins.CargarPlugins(System.Windows.Forms.Application.StartupPath + @"\Modulos");      
            }

            // actualizar menú
            mnuMostrar.DropDown.Items.Clear();
            foreach (PluginStatus p in plugins.GetPlugins())
            {
                if (p.Activado)
                {
                    ToolStripItem b = p.Plugin.GetButton();
                    if (b != null)
                    {
                        var m = new ToolStripMenuItem(p.Plugin.Name, null, verPlugin_Click) { CheckOnClick = true, Checked = b.Visible, Tag = p.Archivo };
                        mnuMostrar.DropDown.Items.Add(m);
                    }
                }
            }
        }

        private void ModifyMenu(ToolStripDropDownItem item, bool enable)
        {
            item.Enabled = enable;
            if (item.HasDropDownItems)
            {
                foreach (ToolStripDropDownItem subitem in item.DropDownItems)
                {
                    ModifyMenu(subitem,enable);
                }
            }   
        }

        private void DoLogout()
        {
            CerrarPlugins();
        }

        private bool IniciarAntiCopia()
        {
            bool res = false;
            // verificar llave
            try
            {
                if (!usbKey.IniciarConexion("00"))
                {
                    DialogResult dr;
                    do
                    {
                        dr = usbKey.MensajeFalloProteccion(usbKey.Estado);
                        if (dr == DialogResult.Retry)
                        {
                            res = usbKey.IniciarConexion("00");
                        }
                    } while (res == false && dr == DialogResult.Retry);
                    if (res == false || dr == DialogResult.Cancel)
                    {
                        //System.Windows.Forms.Application.Exit();
                        return false;
                    }
                    // iniciar timer de verificacion
                    var r = new Random();
                    llavePresente = true;
                    VerificacionLlave.Interval = r.Next(1200000) + 600000;
                    VerificacionLlave.Start();
                    return true;
                }
                else
                {
                    llavePresente = true;
                    // iniciar timer de verificacion
                    var r = new Random();
                    llavePresente = true;
                    VerificacionLlave.Interval = r.Next(1200000) + 600000;
                    VerificacionLlave.Start();
                    return true;
                }
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("Error fatal: no se ha encontrado la librería de protección, el sistema se cerrará.",
                                "Librería de Protección no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //System.Windows.Forms.Application.Exit();
                return false;
            }
        }



        public void StartRPCServer()
        {
            var serv = new SoapServerFormatterSinkProvider { TypeFilterLevel = TypeFilterLevel.Full };
            var channel = new HttpServerChannel("server_remotezeus", 9254, serv);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteZeus), "RemoteZeus",
                                                               WellKnownObjectMode.SingleCall);

            RemoteZeus.ZeusWin = this;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (
                    MessageBox.Show("¿Desea cerrar el sistema?", "Confirmar Cierre", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //login
            DoLogOn();
        }

        private void correlativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AdminCorrelativos().ShowDialog();
        }

        private void slidePanel1_StateChanged(object sender, SlidePanelEventArgs e)
        {
            // si está arriba, esconder tabs
            if (e.Collapsed)
            {
                mainTabs1.Visible = false;
            }
        }

        private void slidePanel1_StateChanging(object sender, SlidePanelEventArgs e)
        {
            // si está arriba y empieza a bajar, mostrar tabs
            if (e.Collapsed)
            {
                mainTabs1.Visible = true;
                // todo: desenchufar de tabs
                mainTabs1.CargarDatos();
            }
        }

        #region VARIABLES

        private readonly PluginsManager plugins;
        private readonly USBKey usbKey;
        private EventHandler actualizar;
        private int id_aval, id_expediente;
        private int id_operadora;
        private bool llavePresente;
        private Process mapwindow;
        private TipoOperadora tipoOperadora;
        private string usuario;

        public Process Mapwindow
        {
            get { return mapwindow; }
            set { mapwindow = value; }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            ReemplazoCarros a = new ReemplazoCarros();
            a.ShowDialog();
        }

        private void CeroHoras_Tick(object sender, EventArgs e)
        {
            CeroHoras.Enabled = false;
            if (System.DateTime.Now.Hour.ToString() == "0")
            {
                GetDay();
            }
        }

        public void GetDay()
        {
            //if (MessageBox.Show("¿La fecha " + System.DateTime.Now.ToString() + " es un día feriado?", "ALERTA!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //{
            //    int dia = DayOfWeek(Convert.ToInt32(System.DateTime.Now.Day.ToString()), Convert.ToInt32(System.DateTime.Now.Month.ToString()), Convert.ToInt32(System.DateTime.Now.Year.ToString()));
            //    switch (dia.ToString())
            //    {
            //        case "1":
            //            //chkFeriado.Checked = true;
            //            break;
            //        case "2":
            //            //chkFeriado.Checked = true;
            //            break;
            //        case "3":
            //            //chkFeriado.Checked = true;
            //            break;
            //        case "4":
            //            //chkFeriado.Checked = true;
            //            break;
            //        case "5":
            //            //chkFeriado.Checked = true;
            //            break;
            //        default:
            //            //MessageBox.Show("El día no es hábil, este se conciderará como día inabil");
            //            //chkFeriado.Checked = false;
            //        break;
            //    }
            //}
            //else
            //{
            //    int dia = DayOfWeek(Convert.ToInt32(System.DateTime.Now.Day.ToString()), Convert.ToInt32(System.DateTime.Now.Month.ToString()), Convert.ToInt32(System.DateTime.Now.Year.ToString()));
            //    switch (dia.ToString())
            //    {
            //        case "6":
            //            chkFeriado.Checked = false;
            //        break;
            //        case "7":
            //            chkFeriado.Checked = false;
            //        break;
            //    }
            //    chkFeriado.Checked = true;
            //}
        }

        public int DayOfWeek(int day, int month, int year)
        {
	        int[] mesCode = {0,6,2,2,5,0,3,5,1,4,6,2,4};
             int result = year%100 + (year%100)/4 + day + mesCode[month];
         
	        if(year/100==17) result += 5;
	        else if(year/100==18) result += 3;
	        else if(year/100==19) result += 1;
	        else if(year/100==20) result += 0;
	        else if(year/100==21) result += -2;
	        else if(year/100==22)  result += -4;
         
                //Vemos si es bisiesto y quitamos un día si
                //el mes es enero o febrero
	        if(EsBisiesto(year) && (month==1 || month==2))
	            result += -1;	
         
                //Esto devuelve un número entre 0 y 7
                //que nos dá el día de la semana
	        return result%7;
        }

        private bool EsBisiesto(int a)
        {
	        return (a%4==0 && a%100!=0) || a%400==0;
        }

        //chkFeriado
        private void chkFeriado_CheckedChanged(object sender, EventArgs e)
        {
            //var exp = new e_expedientes();
            if (chkFeriado.Checked == true)
            {
                exp.ActualizarFeriado(true);
                //MessageBox.Show("Estado  VERDADERO...", "GEObit");
            }
            else
            {
                exp.ActualizarFeriado(false);
                //MessageBox.Show("Estado  FALSO...", "GEObit");
            }
        }

        private void prioridad2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminOrdenTipo aot = new AdminOrdenTipo();
            aot.ShowDialog();
        }

        //### Ejecutar MapWindows
        private void RunMapWindow()
        {
            var fi = new FileInfo(System.Windows.Forms.Application.StartupPath + @"\MapWindow\MapWindow.exe");
            if (fi.Exists)
            {
                //ProcessStartInfo pi = new ProcessStartInfo(fi.FullName, fi.DirectoryName + @"\New.mwprj")
                ProcessStartInfo pi = new ProcessStartInfo(fi.FullName, fi.DirectoryName + @"\v3.mwprj") { WorkingDirectory = fi.DirectoryName };
                mapwindow = Process.Start(pi);
            }
        }

    }
}