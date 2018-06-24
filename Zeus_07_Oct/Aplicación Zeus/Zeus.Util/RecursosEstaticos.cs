using System;
using System.Collections.Generic;
using System.Text;

namespace Zeus.Util
{
    public static class RecursosEstaticos
    {
        public static string NombreCarro { get; set; }
        public static int IdExpediente { get; set; }
        public static TimeSpan TimeSpan { get; set; }
        public static Dictionary<string, int> dicEstadoCarros { get; set; }
        public static int PrimeraCarga { get; set; }
        public static string Direccion { get; set; }
        public static int Area { get; set; }
        public static string FechaDespacho { get; set; }
        public static int CodigoLlamado { get; set; }
        public static Dictionary<int, string> AlarmasActivas { get; set; }
    }
}
