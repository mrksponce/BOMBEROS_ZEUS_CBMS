using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;


namespace Zeus.Util
{
    public class JsonEmergencia
    {
        public string expediente { get; set; }
        public string correlativo { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string acto { get; set; }
        public string id_acto { get; set; }
        public string id_llamado { get; set; }
        public string calle { get; set; }
        public string casa { get; set; }
        public string block { get; set; }
        public string piso { get; set; }
        public string villa { get; set; }
        public string area { get; set; }
        public string comuna { get; set; }
        public string esquina { get; set; }
        public string carros { get; set; }
        public string quien_llama { get; set; }
        public string telefono { get; set; }
        public string estado { get; set; }
        public string operadora { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string tono { get; set; }
        public bool mobile { get; set; }
    }
  
}



