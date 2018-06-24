using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Zeus.Data;
using System;

namespace Zeus.PluginGeocodificacion
{
    public class Direccion
    {
        private string _calle1, _calle2, _comuna, _geoz;

        private int _altura;

        public int Altura
        {
            get { return _altura; }
            set { _altura = value; }
        }

        public string Geoz
        {
            get { return _geoz; }
            set { _geoz = value; }
        }

        public string Comuna
        {
            get { return _comuna; }
            set { _comuna = value; }
        }

        public string Calle2
        {
            get { return _calle2; }
            set { _calle2 = value; }
        }

        public string Calle1
        {
            get { return _calle1; }
            set { _calle1 = value; }
        }
        private PointD? _ubicacion;

        public PointD? Ubicacion
        {
            get { return _ubicacion; }
            set 
            { 
                _ubicacion = value;
                //if (_ubicacion.HasValue)
                //{
                //    Serializar(new PointD(this._ubicacion.Value.X, this._ubicacion.Value.Y));
                //}
                //else
                //{
                //    Serializar(new PointD(this._ubicacion.Value.X, this._ubicacion.Value.Y));
                //}
            }
        }

        private void Serializar(PointD punto)
        {
            //FileStream f = new FileStream(PlugData.Ruta + @"\ubicacion.txt", FileMode.Create);
            FileStream f = File.Create(Path.Combine(Path.GetTempPath(), "ubicacion.txt"));
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, punto);
            f.Close();
        }
    }
}
