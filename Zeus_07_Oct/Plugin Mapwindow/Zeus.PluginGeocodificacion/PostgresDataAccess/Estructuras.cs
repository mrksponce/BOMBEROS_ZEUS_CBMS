using System;
using Zeus.Data;

namespace PostgresDataAccess
{
    

    public class Grifo
    {
        private int _gid;

        public int Gid
        {
            get { return _gid; }
            set { _gid = value; }
        }

        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private double _distancia;

        public double Distancia
        {
            get { return _distancia; }
            set { _distancia = value; }
        }
        private PointD _ubicacion;

        public PointD Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }
        private bool _utilizado;

        public bool Utilizado
        {
            get { return _utilizado; }
            set { _utilizado = value; }
        }

        private string _esquina;

        public string Esquina
        {
            get { return _esquina; }
            set { _esquina = value; }
        }

        public Grifo(int gid, string dir, string esquina, double dist, PointD ubi, bool uti)
        {
            _gid = gid;
            _direccion = dir;
            _esquina = esquina;
            _distancia = dist;
            _ubicacion = ubi;
            _utilizado = uti;
        }
    }

    public class Expediente
    {
        private int _id_expediente, _codigo_llamado, _codigo_principal, _id_area;

        public int Id_area
        {
            get { return _id_area; }
            set { _id_area = value; }
        }

        public int Codigo_principal
        {
            get { return _codigo_principal; }
            set { _codigo_principal = value; }
        }

        public int Codigo_llamado
        {
            get { return _codigo_llamado; }
            set { _codigo_llamado = value; }
        }

        public int Id_expediente
        {
            get { return _id_expediente; }
            set { _id_expediente = value; }
        }
        private string _cero5, _seis2, _comuna, _geoz, 
            _poblacion_villa, _block, _casa, _telefono, _quien_llama, _compania, _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Compania
        {
            get { return _compania; }
            set { _compania = value; }
        }

        public string Quien_llama
        {
            get { return _quien_llama; }
            set { _quien_llama = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Casa
        {
            get { return _casa; }
            set { _casa = value; }
        }

        public string Block
        {
            get { return _block; }
            set { _block = value; }
        }

        public string Poblacion_villa
        {
            get { return _poblacion_villa; }
            set { _poblacion_villa = value; }
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

        public string Seis2
        {
            get { return _seis2; }
            set { _seis2 = value; }
        }

        public string Cero5
        {
            get { return _cero5; }
            set { _cero5 = value; }
        }
        private PointD _ubicacion;

        public PointD Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }
        private DateTime _fecha, _hora;

        public DateTime Hora
        {
            get { return _hora; }
            set { _hora = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private bool _activo;

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
    }

    public class Clave
    {
        int _id_cat;

        public int Id_cat
        {
            get { return _id_cat; }
            set { _id_cat = value; }
        }
        string _nombre, _tabla;

        public string Tabla
        {
            get { return _tabla; }
            set { _tabla = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        bool _ref_espacial;

        public bool Ref_espacial
        {
            get { return _ref_espacial; }
            set { _ref_espacial = value; }
        }
    }

    public class Empresa
    {
        int _id_empresa;

        public int Id_empresa
        {
            get { return _id_empresa; }
            set { _id_empresa = value; }
        }
        string _nombre, _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        
    }
    public class PuntoInteres
    {
        private string _radioText, _label1, _combo1, _label2, _tabla;

        public string Tabla
        {
            get { return _tabla; }
            set { _tabla = value; }
        }

        public string Label2
        {
            get { return _label2; }
            set { _label2 = value; }
        }

        public string Combo1
        {
            get { return _combo1; }
            set { _combo1 = value; }
        }

        public string Label1
        {
            get { return _label1; }
            set { _label1 = value; }
        }

        public string RadioText
        {
            get { return _radioText; }
            set { _radioText = value; }
        }
    }

    public class PInteres
    {
        public PInteres(string nombre, PointD ubicacion)
        {
            _nombre = nombre;
            _ubicacion = ubicacion;
        }
           
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private PointD _ubicacion;

        public PointD Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }
    }
}
