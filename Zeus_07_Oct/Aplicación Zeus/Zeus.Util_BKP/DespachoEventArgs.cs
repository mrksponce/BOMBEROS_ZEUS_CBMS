using System;
using System.Collections.Generic;

namespace Zeus.Util
{
    public class DespachoEventArgs : EventArgs
    {
        public DespachoEventArgs(int id_expediente, List<int> id_carros)
        {
            IdCarros = id_carros;
            IdExpediente = id_expediente;
        }

        public int IdExpediente { get; set; }

        public List<int> IdCarros { get; set; }
    }
}