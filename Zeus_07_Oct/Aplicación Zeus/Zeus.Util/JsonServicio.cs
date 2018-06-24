using System;
using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;


namespace Zeus.Util
{
    public class JsonServicio
    {
        public string fecha { get; set; }
        public string hora { get; set; }
        public int carro { get; set; }
        public int estado { get; set; }
        public string conductor { get; set; }
        public string motivo { get; set; }
        public string color { get; set; }
        public Boolean manual { get; set; }
    }
}
