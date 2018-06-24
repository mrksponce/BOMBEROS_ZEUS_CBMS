using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters.Binary;
using Zeus.Data;
using Zeus.Util;
using MapWindow.Interfaces;

namespace Zeus.PluginGeocodificacion
{
    
    public static class PlugData
    {
        public static MapWindow.Interfaces.IMapWin MapWin = null;
        public static MapWindow.Interfaces.Layer LMapa
        {
            get { return FindLayer("Mapa"); }
        }
        public static MapWindow.Interfaces.Layer[] Hojas = new MapWindow.Interfaces.Layer[4];
        public static MapWindow.Interfaces.Layer LDireccion = null;
        public static MapWinGIS.Shapefile SFDireccion = null;
        public static MapWindow.Interfaces.Layer LGrifos = null;
        public static MapWindow.Interfaces.Layer LCarros = null;
        private static Direccion _Direccion = null;

private static Layer FindLayer(string name)
        {
            try
            {
                foreach (Layer l in MapWin.Layers)
                {
                    if (l.Name == name)
                    {
                        return l;
                    }
                }
            }
            catch
            {
                return null;
            }
            
            return null;
        }

        public static Direccion Direccion
        {
            get { return PlugData._Direccion; }
            set { PlugData._Direccion = value;
            //if (PlugData.Direccion.Ubicacion.HasValue)
            //{
            //    Serializar(new PointD(Direccion.Ubicacion.Value.X, Direccion.Ubicacion.Value.Y));
            //}
            //else
            //{
            //    Serializar(new PointD(0, 0));
            //}
            }
        }
        public static int? DrDireccion = null;
        public static int? DrGrifos = null;
        public static int? DrCarros = null;
        public static int DrPuntoInteres;
        public static int[] CalleSeleccionada = null;
        public static string Ruta=null;
        public static RemoteZeus RemoteZeus;// = Client();
        //public static LocalizacionGPS LocalizacionGPS = LocalizacionGPS.StartClient();

        public static RemoteZeus Client()
        {
            try
            {
                ChannelServices.RegisterChannel(new TcpClientChannel("client_remotezeus", new BinaryClientFormatterSinkProvider()), true);
                RemoteZeus rz = (RemoteZeus)Activator.GetObject(typeof(RemoteZeus), "tcp://localhost:9254/RemoteZeus");
                return rz;
            }
            catch
            {
                return new RemoteZeus();
            }
        }

        private static int _indexNombre = -1;

        public static int IndexNombre
        {
            get 
            {
                if (_indexNombre==-1)
                {
                    // obtener indice a partir de mapa
                    MapWinGIS.Shapefile sf = (MapWinGIS.Shapefile)LMapa.GetObject();
                    for (int i = 0; i < sf.NumFields; i++)
                    {
                        if (sf.get_Field(i).Name.ToUpper()=="NOMBRE")
                        {
                            _indexNombre = i;
                            return i;
                        }
                    }
                    throw new Exception("No existe el campo NOMBRE en el shape");
                }
                else
                {
                    return PlugData._indexNombre;
                }
            }
            set { PlugData._indexNombre = value; }
        }
        private static int _indexTipo = -1;

        public static int IndexTipo
        {
            get
            {
                if (_indexTipo == -1)
                {
                    // obtener indice a partir de mapa
                    MapWinGIS.Shapefile sf = (MapWinGIS.Shapefile)LMapa.GetObject();
                    for (int i = 0; i < sf.NumFields; i++)
                    {
                        if (sf.get_Field(i).Name.ToUpper() == "CLASE")
                        {
                            _indexTipo = i;
                            return i;
                        }
                    }
                    throw new Exception("No existe el campo CLASE en el shape");
                }
                else
                {
                    return PlugData._indexTipo;
                }
            }
            set { PlugData._indexTipo = value; }
        }

        public static void ZoomToLocation(PointD p1, PointD p2)
        {
            MapWin.View.LockMap();
            MapWin.View.ZoomToMaxExtents();
            MapWinGIS.Extents ex = MapWin.View.Extents;
            ex.SetBounds(p1.X, p1.Y, 0, p2.X, p2.Y, 0);
            MapWin.View.Extents = ex;
            MapWin.View.UnlockMap();
        }

        public static void ZoomToPoint(PointD p)
        {
            double dx, dy;
            MapWin.View.LockMap();
            MapWin.View.ZoomToMaxExtents();
            MapWinGIS.Extents ex = MapWin.View.Extents;
            dx = ex.xMax - ex.xMin;
            dx *= MapWin.View.ExtentPad;
            dy = ex.yMax - ex.yMin;
            dy *= MapWin.View.ExtentPad;
            //ex.SetBounds(p.X - (dx / 2), p.Y - (dy / 2), 0, p.X + (dx / 2), p.Y + (dy / 2), 0);
            ex.SetBounds(p.X - 200, p.Y - 200, 0, p.X + 200, p.Y + 200, 0);

            MapWin.View.Extents = ex;
            MapWin.View.UnlockMap();
        }

        public static void ZoomToPointPaint(PointD p, int radio)
        {
            MapWin.View.LockMap();
            MapWin.View.ZoomToMaxExtents();
            MapWinGIS.Extents ex = MapWin.View.Extents;
            ex.SetBounds(p.X - radio, p.Y - radio, 0, p.X + radio, p.Y + radio, 0);
            MapWin.View.Extents = ex;
            MapWin.View.Draw.ClearDrawing(DrDireccion.Value);
            DrDireccion = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
            MapWin.View.Draw.DrawCircle(p.X, p.Y, 10, System.Drawing.Color.Red, true);
            MapWin.View.UnlockMap();
        }

        public static void SelectCalle(PointD p1, PointD p2, string nombre, string tipo)
        {
            if (LMapa == null)
                return;
            MapWinGIS.Extents ex = new MapWinGIS.Extents();
            object x = new object();
            ex.SetBounds(p1.X, p1.Y, 0, p2.X, p2.Y, 0);
            ((MapWinGIS.Shapefile)LMapa.GetObject()).SelectShapes(ex, 0, MapWinGIS.SelectMode.INTERSECTION, ref x);
            int[] shapes = x as int[];
            //limpiar calle anterior
            if (CalleSeleccionada!=null)
            {
                foreach (int shape in CalleSeleccionada)
                {
                    LMapa.Shapes[shape].Color = LMapa.Color;
                }
            } 
            List<int> l = new List<int>();
            foreach (int shape in shapes)
            {
                if (((MapWinGIS.Shapefile)LMapa.GetObject()).get_CellValue(IndexNombre, shape).ToString() == nombre && ((MapWinGIS.Shapefile)LMapa.GetObject()).get_CellValue(IndexTipo, shape).ToString() == tipo)
                {
                    l.Add(shape);
                    LMapa.Shapes[shape].Color = System.Drawing.Color.Red;
                }
            }
            CalleSeleccionada = l.Count == 0 ? null : l.ToArray();
        }

        //private static void Serializar(PointD punto)
        //{
        //    FileStream f = new FileStream(Ruta + @"\ubicacion.txt", FileMode.Create);
        //    BinaryFormatter b = new BinaryFormatter();
        //    b.Serialize(f, punto);
        //    f.Close();
        //}

        public static void ZoomToPointsPaint(PointD[] points, string[] labels)
        {
            if (points.Length==1)
            {
                ZoomToPoint(points[0]);
                MapWin.View.Draw.ClearDrawing(DrCarros.Value);
                DrCarros = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
                LMapa.ClearLabels();
                // pintar punto
                MapWin.View.Draw.DrawCircle(points[0].X, points[0].Y, 10, System.Drawing.Color.Red, true);
                LMapa.AddLabel(labels[0], Color.Black, points[0].X, points[0].Y-10, MapWinGIS.tkHJustification.hjCenter);

            }
            else
            {
                double minx = double.MaxValue;
                double maxx = double.MinValue;
                double miny = double.MaxValue;
                double maxy = double.MinValue;

                MapWin.View.Draw.ClearDrawing(DrCarros.Value);
                LMapa.ClearLabels();
                DrCarros = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);

                for (int i = 0; i < points.Length; i++)
                {
                    // calcular extent seleccionando los 4 puntos límite
                    PointD p=points[i];
                    if (p.X<minx)
                    {
                        minx = p.X;
                    }
                    if (p.X>maxx)
                    {
                        maxx = p.X;
                    }
                    if (p.Y<miny)
                    {
                        miny = p.Y;
                    }
                    if (p.Y>maxy)
                    {
                        maxy = p.Y;
                    }

                    // pintar punto
                    MapWin.View.Draw.DrawCircle(p.X, p.Y, 10, System.Drawing.Color.Red, true);
                    LMapa.AddLabel(labels[i], Color.Black, p.X, p.Y-10, MapWinGIS.tkHJustification.hjCenter);

                }
                // establecer extent
                MapWinGIS.Extents ex = MapWin.View.Extents;
                ex.SetBounds(minx - 100, miny - 100, 0, maxx + 100, maxy + 100, 0);
                MapWin.View.Extents = ex;
            }
        }
    }
}
