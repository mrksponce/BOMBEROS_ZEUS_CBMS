using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;


namespace Zeus.Util
{
    public class JsonBitacora
    {
        public string expediente { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string clave { get; set; }
        public int carro { get; set; }
        public string hora_clave { get; set; }
        public string conductor { get; set; }
        public string a_cargo { get; set; }
        public int tripulan { get; set; }
    }
}

