using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Forms;
using MapWindow.Interfaces;
using Zeus.Data;
using Zeus.PluginGeocodificacion.Forms;
using Zeus.Util;
using System.Reflection;

namespace Zeus.PluginGeocodificacion
{
    public class MWGeoCodPlugin : MapWindow.Interfaces.IPlugin
    {
        #region PROPIEDADES

        

        public string Author
        {
            get { return "GEObit Ltda. www.geobit.cl"; }
        }

        public string BuildDate
        {
            get { return System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToShortDateString(); }
        }

        public string Description
        {
            get
            {
                return "Implementa un buscador de direcciones avanzado, generador y administrador de expedientes, selección de grifos por distancia, agenda con vinculación geográfica, selección de puntos de interés y georreferenciación directa para establecer el origen de las urgencias.";


            }
        }

        public string Name
        {
            get { return "Localización de Urgencias"; }
        }

        public string SerialNumber
        {
            get { return ""; }
        }

        public string Version
        {
            get { return this.GetType().Assembly.GetName().Version.ToString(); }
        }

        #endregion

        #region FUNCIONES DE INICIO/FIN
        public void Initialize(MapWindow.Interfaces.IMapWin MapWin, int ParentHandle)
        {
            try
            {
                // testear 
                //PostgresDataAccess.DataAccess da = new PostgresDataAccess.DataAccess();
                //#if USBKEY
                //utilizando llave USB
                //USBKey key = new USBKey();
                //if (!key.IniciarConexion("00"))
                //{
                //MessageBox.Show("Ha fallado la protección anticopia. Abortando inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
                //}
                //#endif
                // archivo
                FileInfo fi = new FileInfo(this.GetType().Assembly.Location);
                MapWin.Menus.AddMenu("mMain", (object)null, "Localización");

                // RPC
                
                try
                {
                    RemotingConfiguration.Configure(GetConfigFile(), false);
                    remoteZeus = (RemoteZeus)Activator.GetObject(typeof(RemoteZeus), "http://localhost:9254/RemoteZeus");
                    remoteWrapper = new RemoteWrapper();

                    remoteZeus.AddIdChanged(new IdHandler(remoteWrapper.WrapperMessageReceivedHandler));
                    remoteWrapper.WrapperMessageReceived += new IdHandler(OnIdChange);
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message + " (¿Se está ejecutando el Sistema Zeus?)", "Mensaje de Zeus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                 

                //if (!da.Test())
                //{
                //MessageBox.Show("No se encuentra el servidor de bases de datos.\nLa funcionalidad habitual no estará disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                //else
                //{
                InitOk = true;
                this.MapWin = MapWin;

                // Añadir toolbar y botones
                MapWin.Toolbar.AddToolbar("MWGeoCod");
                MapWindow.Interfaces.ToolbarButton tb = MapWin.Toolbar.AddButton("Geocodificar", "MWGeoCod", "", "");
                tb.Picture = Iconos.direccion;
                tb.Tooltip = "Localizar Dirección";
                tb.Text = "Geocodificar";
                Botones[0] = tb;

                MapWin.Toolbar.AddButton("-", "MWGeoCod", false);
                tb = MapWin.Toolbar.AddButton("VerExpediente", "MWGeoCod", "", "");
                tb.Picture = Iconos.expedientes;
                tb.Tooltip = "Ver Expedientes Activos";
                tb.Text = "Expedientes";
                Botones[1] = tb;

                tb = MapWin.Toolbar.AddButton("Grifos", "MWGeoCod", "", "");
                tb.Picture = Iconos.grifos;
                tb.Tooltip = "Listado de grifos";
                tb.Text = "Grifos";
                Botones[2] = tb;


                MapWin.Toolbar.AddButton("-", "MWGeoCod", false);
                tb = MapWin.Toolbar.AddButton("SelMapa", "MWGeoCod", "", "");
                tb.Picture = Iconos.punto_mapa;
                tb.Tooltip = "Seleccionar un punto desde el mapa";
                tb.Text = "Elegir Punto";
                Botones[4] = tb;

                tb = MapWin.Toolbar.AddButton("SelInteres", "MWGeoCod", "", "");
                tb.Picture = Iconos.p_interes;
                tb.Tooltip = "Seleccionar puntos de interés";
                tb.Text = "Puntos Interés";
                Botones[5] = tb;

                tb = MapWin.Toolbar.AddButton("Limpiar", "MWGeoCod", "", "");
                tb.Picture = Iconos.limpiar1;
                tb.Tooltip = "Limpiar Mapa";
                tb.Text = "Limpiar";
                Botones[6] = tb;

                tb = MapWin.Toolbar.AddButton("Localizar", "MWGeoCod", "", "");
                tb.Picture = Iconos.gps_32;
                tb.Tooltip = "Localizar Carros";
                tb.Text = "Localizar";
                Botones[7] = tb;


                tb = MapWin.Toolbar.AddButton("SelCarr", "MWGeoCod", "", "");
                tb.Picture = Iconos.p_interes;
                tb.Tooltip = "Seleccionar Carretera";
                tb.Text = "Carretera";
                Botones[8] = tb;
                //#if CBQN
                //                tb.Enabled = false;
                //#endif

                Menues[0] = MapWin.Menus.AddMenu("mGeocodificar", "mMain", Iconos.Geocodificar.ToBitmap(), "Localizar Dirección...");
                MapWin.Menus.AddMenu("s1", "mMain", (object)null, "-");
                Menues[1] = MapWin.Menus.AddMenu("mExpediente", "mMain", Iconos.Expediente.ToBitmap(), "Ver Expedientes Activos...");
                Menues[2] = MapWin.Menus.AddMenu("mGrifos", "mMain", Iconos.Grifo.ToBitmap(), "Listado de grifos...");
                //Menues[3] = MapWin.Menus.AddMenu("mAgenda", "mMain", Iconos.agenda.ToBitmap(), "Agenda con vinculación geográfica...");
                MapWin.Menus.AddMenu("s2", "mMain", (object)null, "-");
                Menues[4] = MapWin.Menus.AddMenu("mSelMapa", "mMain", Iconos.SelMapa.ToBitmap(), "Seleccionar un punto desde el mapa");
                Menues[5] = MapWin.Menus.AddMenu("mSelInteres", "mMain", Iconos.SelInteres.ToBitmap(), "Seleccionar puntos de interés...");
                Menues[6] = MapWin.Menus.AddMenu("mLimpiar", "mMain", Iconos.Limpiar.ToBitmap(), "Limpiar Mapa");
                Menues[7] = MapWin.Menus.AddMenu("mCarretera", "mMain", Iconos.Limpiar.ToBitmap(), "Sel. Carretera");
                MapWin.Menus.AddMenu("s3", "mMain", (object)null, "-");

                // ventanas
                Dirs = new Zeus.PluginGeocodificacion.Forms.Direcciones(MapWin);
                MapWin.ApplicationInfo.ApplicationName = "Sistema ZEUS";

                MapWin.SetCustomWindowTitle("Cuerpo de Bomberos de Santiago");

                // capas de dibujo
                PlugData.MapWin = MapWin;
                PlugData.DrGrifos = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
                PlugData.DrDireccion = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
                PlugData.DrPuntoInteres = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
                PlugData.DrCarros = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
                //}
                Menues[7] = MapWin.Menus.AddMenu("mConfig", "mMain", Iconos.Config.ToBitmap(), "Configurar...");
            }
            catch (Exception exe)
            {
                this.MapWin.ShowErrorDialog(exe, "mponce@gmail.com");
            }
        }

        private string GetConfigFile()
        {
            // obtener archivo de configuración desde assembly hasta carpeta temp
            string tempfile = Path.GetTempFileName();
            Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Zeus.PluginGeocodificacion.remoting.xml");
            byte[] data = new byte[s.Length];
            s.Read(data, 0, (int)s.Length);
            File.WriteAllBytes(tempfile, data);
            return tempfile;
        }

        public void Terminate()
        {
            try
            {
                // eliminar todo
                MapWin.Toolbar.RemoveButton("Geocodificar");
                MapWin.Toolbar.RemoveButton("VerExpediente");
                MapWin.Toolbar.RemoveButton("Grifos");
                MapWin.Toolbar.RemoveButton("SelMapa");
                MapWin.Toolbar.RemoveButton("SelInteres");
                MapWin.Toolbar.RemoveButton("Limpiar");
                MapWin.Toolbar.RemoveButton("Localizar");

                MapWin.Toolbar.RemoveButton("-");
                MapWin.Toolbar.RemoveButton("-");
                MapWin.Toolbar.RemoveToolbar("MWGeoCod");


                MapWin.Menus.Remove("mMain");
                MapWin.Project.Modified = false;
                //Trace.Listeners.Remove(TListener);

                // RPC
                ChannelServices.UnregisterChannel(ChannelServices.GetChannel("client_remotezeus_mw"));
            }
            catch
            {
                //MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region EVENTOS UTILIZADOS
        public void ItemClicked(string ItemName, ref bool Handled)
        {
            if (ItemName == "mConfig")
            {
                Forms.Configuracion config = new Configuracion();
                config.ShowDialog();
                Handled = true;
            }

            if (!InitOk)
                return;
            // mostrar ventana de geocod
            if (ItemName == "Geocodificar" || ItemName == "mGeocodificar")
            {
                if (Screen.AllScreens.Length > 1)
                {
                    Dirs.SetDesktopLocation(Screen.AllScreens[1].Bounds.Left + 10, Screen.AllScreens[1].Bounds.Top + 100);
                }
                else
                {
                    Dirs.SetDesktopLocation(10, 100);
                }

                DialogResult dr = Dirs.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // tenemos direccion
                    direccion = Dirs.Direccion;
                    PlugData.Direccion = direccion;
                    //Menues[1].Enabled = true;
                    //Botones[1].Enabled = true;
                }
                Handled = true;
            }

            if (ItemName == "VerExpediente" || ItemName == "mExpediente")
            {
                Forms.ListadoExpedientes Expediente = new Zeus.PluginGeocodificacion.Forms.ListadoExpedientes();
                Expediente.ShowDialog();
                Handled = true;
            }

            if (ItemName == "Grifos" || ItemName == "mGrifos")
            {
                Forms.ListadoGrifos Grifos = new Zeus.PluginGeocodificacion.Forms.ListadoGrifos();
                Grifos.ShowDialog();
                Handled = true;
            }

            if (ItemName == "Agenda" || ItemName == "mAgenda")
            {
                Forms.Agenda Agenda = new Zeus.PluginGeocodificacion.Forms.Agenda();
                Agenda.ShowDialog();
                Handled = true;
            }


            if (ItemName == "Limpiar" || ItemName == "mLimpiar")
            {
                MapWin.View.Draw.ClearDrawings();
                Handled = true;
            }

            // seleccionar
            if (ItemName == "SelMapa" || ItemName == "mSelMapa")
            {
                if (Botones[4].Pressed == true)
                {
                    Botones[4].Pressed = false;
                    MapWin.View.MapCursor = _prevCursor;
                    MapWin.View.CursorMode = _prevMode;
                }
                else
                {
                    Botones[4].Pressed = true;
                    _prevCursor = MapWin.View.MapCursor;
                    _prevMode = MapWin.View.CursorMode;
                    MapWin.View.UserCursorHandle = (int)LoadColorCursor(Iconos.CursorPunto).Handle;
                    MapWin.View.MapCursor = MapWinGIS.tkCursor.crsrUserDefined;
                    MapWin.View.CursorMode = MapWinGIS.tkCursorMode.cmNone;
                    //MapWin.View.Draw.ClearDrawing(PlugData.DrDireccion);
                }
                Handled = true;
            }

            // puntos de interes
            if (ItemName == "SelInteres" || ItemName == "mSelInteres")
            {
                Forms.PuntosInteres Interes = new Zeus.PluginGeocodificacion.Forms.PuntosInteres();
                if (Screen.AllScreens.Length > 1)
                {
                    Interes.SetDesktopLocation(Interes.Left + Screen.AllScreens[1].Bounds.Left + 10, Interes.Location.Y);
                }

                Interes.ShowDialog();
                Handled = true;
            }

            // localizacion de carros
            if (ItemName == "Localizar" || ItemName == "mLocalizar")
            {
                Forms.RepresentacionGPS Rep = new Zeus.PluginGeocodificacion.Forms.RepresentacionGPS();
                if (Screen.AllScreens.Length > 1)
                {
                    Rep.SetDesktopLocation(Rep.Left + Screen.AllScreens[1].Bounds.Left + 10, Rep.Location.Y);
                }

                Rep.ShowDialog();
                Handled = true;
            }

            // localizacion de carros
            if (ItemName == "SelCarr" || ItemName == "mCarretera")
            {
                Forms.Carreteras carr = new Zeus.PluginGeocodificacion.Forms.Carreteras();
                if (Screen.AllScreens.Length > 1)
                {
                    carr.SetDesktopLocation(carr.Left + Screen.AllScreens[1].Bounds.Left + 10, carr.Location.Y);
                }

                carr.ShowDialog();
                Handled = true;
            }

        }

        public void MapMouseUp(int Button, int Shift, int x, int y, ref bool Handled)
        {
            if (!InitOk)
                return;
            if (Button == 1 && Botones[4].Pressed == true)
            {
                SeleccionarPunto(x, y);
                Handled = true;
            }
        }

        /// <summary>
        /// Maneja el cambio de extensión (área visible) del mapa
        /// </summary>
        public void MapExtentsChanged()
        {
            if (!InitOk || PlugData.LMapa == null)
                return;

            MapWinGIS.Extents ex = MapWin.View.Extents;
            //MapWinGIS.Shapefile sf;
            //object result = null;
            //int[] shapes;
            //int LC, rC, MidPointIndex;
            //double angle = 0, x1, x2, y1, y2;

            MapWindow.Interfaces.Layer Mapa = PlugData.LMapa;

#if CBMS
            //// determinar si se muestran layers
            //if ((ex.xMax - ex.xMin) < 1300)
            //{
            //    //Mapa.UseLabelCollision = true;
                
            //    //sf = (MapWinGIS.Shapefile)Mapa.GetObject();
            //    //// seleccionar
            //    //if (sf.SelectShapes(ex, 0, MapWinGIS.SelectMode.INCLUSION, ref result) == false)
            //    //    return;
            //    //else
            //    //{
            //    //    // mostrar
            //    //    shapes = (int[])result;
            //    //    MapWin.View.LockMap();
            //    //    Mapa.ClearLabels();
            //    //    for (int i = 0; i < shapes.GetUpperBound(0); i++)
            //    //    {
            //    //        MidPointIndex = (int)sf.get_Shape(shapes[i]).numPoints / 2;
            //    //        LC = MidPointIndex * 2 / 3;
            //    //        rC = MidPointIndex * 4 / 3;
            //    //        x1 = sf.get_Shape(shapes[i]).get_Point(MidPointIndex - 1).x;
            //    //        x2 = sf.get_Shape(shapes[i]).get_Point(MidPointIndex).x;
            //    //        y1 = sf.get_Shape(shapes[i]).get_Point(MidPointIndex - 1).y;
            //    //        y2 = sf.get_Shape(shapes[i]).get_Point(MidPointIndex).y;
            //    //        angle = 0;
            //    //        if ((x2 - x1) != 0)
            //    //        {
            //    //            angle = (y2 - y1) / (x2 - x1);
            //    //            angle = Math.Atan(angle);
            //    //            angle = (angle * 180) / Math.PI;
            //    //        }
                       
            //    //        Mapa.AddLabelEx(sf.get_CellValue(PlugData.IndexNombre, shapes[i]).ToString(), Color.Black, x1, y1, MapWinGIS.tkHJustification.hjCenter, angle);
            //    //    }
            //    //    MapWin.View.UnlockMap();
            //    //}

            //    // obtener hojas
            //    PostgresDataAccess.DataAccess da=new PostgresDataAccess.DataAccess();
            //    List<string> hojas = da.ObtenerHojas(new PointD(ex.xMin, ex.yMin), new PointD(ex.xMax, ex.yMax));

            //    // descargar anteriores, solo si no se necesitan
            //    for (int i = 0; i < 4; i++)
            //    {
            //        if (PlugData.Hojas[i]!=null)
            //        {
            //            if (!hojas.Contains(PlugData.Hojas[i].Name))
            //            {
            //                MapWin.Layers.Remove(PlugData.Hojas[i].Handle);                          
            //                PlugData.Hojas[i]=null;
            //            }
            //            else
            //            {
            //                hojas.Remove(PlugData.Hojas[i].Name);
            //            }
            //        }
            //    }

            //    // cargar!
            //    foreach (string s in hojas)
            //    {
            //        int j = 0;
            //        // buscar vacío
            //        while (j<4 && PlugData.Hojas[j]!=null)
            //        {
            //            j++;
            //        }
            //        if (j==4)
            //        {
            //            return;
            //        }
            //        // agregar
            //        PlugData.Hojas[j] = MapWin.Layers.Add(Application.StartupPath + @"\plugins\sgc-132\hojas\" + s);
            //        PlugData.Hojas[j].Name = s;
            //        PlugData.Hojas[j].GlobalPosition = 0;
            //        PlugData.Hojas[j].SkipOverDuringSave = true;
                   
            //    }
            //}
            //else
            //{
            //    //if (Mapa != null)
            //    //    Mapa.ClearLabels();
            //    // descargar anteriores
            //    for (int i = 0; i < 4; i++)
            //    {
            //        if (PlugData.Hojas[i] != null)
            //        {
            //            MapWin.Layers.Remove(PlugData.Hojas[i].Handle);
            //            //((MapWinGIS.Image)PlugData.Hojas[i].GetObject()).Close();
            //            PlugData.Hojas[i] = null;
            //        }
            //    }
            //}
#endif
        }

        public void LayersAdded(MapWindow.Interfaces.Layer[] Layers)
        {
            //if (!InitOk)
            //    return;

            //foreach (Layer l in Layers)
            //{
            //    if (l.Name == "Mapa")
            //        PlugData.LMapa = l;
            //}
        }

        public void LayerRemoved(int Handle)
        {
            //if (!InitOk)
            //    return;

            //if (PlugData.LMapa != null && PlugData.LMapa.Handle == Handle)
            //{
            //    PlugData.LMapa = null;
            //}
        }
        #endregion

        #region EVENTOS NO UTILIZADOS

        public void LayerSelected(int Handle)
        {
        }

        public void LayersCleared()
        {
        }

        public void LegendDoubleClick(int Handle, MapWindow.Interfaces.ClickLocation Location, ref bool Handled)
        {
        }

        public void LegendMouseDown(int Handle, int Button, MapWindow.Interfaces.ClickLocation Location, ref bool Handled)
        {
        }

        public void LegendMouseUp(int Handle, int Button, MapWindow.Interfaces.ClickLocation Location, ref bool Handled)
        {
        }

        public void MapDragFinished(System.Drawing.Rectangle Bounds, ref bool Handled)
        {
        }



        public void MapMouseDown(int Button, int Shift, int x, int y, ref bool Handled)
        {
        }

        public void MapMouseMove(int ScreenX, int ScreenY, ref bool Handled)
        {
        }



        public void Message(string msg, ref bool Handled)
        {
        }


        public void ProjectLoading(string ProjectFile, string SettingsString)
        {
        }

        public void ProjectSaving(string ProjectFile, ref string SettingsString)
        {
        }


        public void ShapesSelected(int Handle, MapWindow.Interfaces.SelectInfo SelectInfo)
        {
        }
        #endregion

        #region METODOS PROPIOS
        private void SeleccionarPunto(int x, int y)
        {

            double px = 0, py = 0;
            MapWin.View.PixelToProj(x, y, ref px, ref py);

            direccion = new Direccion();
            direccion.Ubicacion = new PointD(px, py);

            PostgresDataAccess.DataAccess da = new PostgresDataAccess.DataAccess();
            direccion.Geoz = da.ObtenerGeoz(direccion.Ubicacion.Value.ToString());
            // dibujar
            if (PlugData.DrDireccion.HasValue)
                MapWin.View.Draw.ClearDrawing(PlugData.DrDireccion.Value);
            PlugData.DrDireccion = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
            MapWin.View.Draw.DrawCircle(px, py, 20, Color.Red, true);
            // deshabilitar
            Botones[4].Pressed = false;
            MapWin.View.MapCursor = _prevCursor;
            MapWin.View.CursorMode = _prevMode;
            // generar expediente
            PlugData.Direccion = direccion;
            Forms.Expediente2 expediente2 = new Forms.Expediente2();
            expediente2.ShowDialog();
        }

        private Cursor LoadColorCursor(byte[] cursor)
        {
            string path = Path.GetTempFileName();
            File.WriteAllBytes(path, cursor);
            Cursor hand = new Cursor(LoadCursorFromFile(path));
            File.Delete(path);
            return hand;
        }
        private void OnIdChange(int id)
        {
            Thread t = new Thread(new ThreadStart(delegate { MostrarEnMapa(id); }));
            t.Start();
        }

        private object lockIdExpediente = 0;
        private void MostrarEnMapa(int id)
        {
            lock (lockIdExpediente)
            {
                if ((int)lockIdExpediente == id)
                {
                    return;
                }
                Cursor current = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                e_expedientes exp = new e_expedientes().getObjecte_expedientes(id);
                PlugData.ZoomToPoint(new PointD(exp.puntoX, exp.puntoY));
                PlugData.DrDireccion = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
                MapWin.View.Draw.DrawCircle(exp.puntoX, exp.puntoY, 10, Color.Red, true);
                lockIdExpediente = id;
                Cursor.Current = current;
            }
        }

        #endregion

        #region VARIABLES
        private IMapWin MapWin;
        private Forms.Direcciones Dirs;
        private Direccion direccion = null;
        private MapWindow.Interfaces.MenuItem[] Menues = new MapWindow.Interfaces.MenuItem[10];
        private MapWindow.Interfaces.ToolbarButton[] Botones = new ToolbarButton[9];
        private MapWinGIS.tkCursor _prevCursor;
        private MapWinGIS.tkCursorMode _prevMode;
        private bool InitOk = false;
        //private TextWriterTraceListener TListener = null;
        private RemoteWrapper remoteWrapper;
        private RemoteZeus remoteZeus;

        #endregion
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursorFromFile(string lpFileName);

        public MWGeoCodPlugin()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
        }

        /// <summary>
        /// Resuelve assemblies "mirando hacia atrás"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            // parados en Zeus/Mapwindow/
            string asmPath = "../";
            Assembly asm = null;
            if (File.Exists(Path.Combine(asmPath, args.Name)))
            {
                asm = Assembly.LoadFrom(Path.Combine(asmPath, args.Name));
            }
            return asm;
        }
    }
}
