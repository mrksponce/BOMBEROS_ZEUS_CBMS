using System;
using System.Collections.Generic;

namespace Zeus.Util
{
    public class DespachoEventDiezTres : EventArgs
    {
        public DespachoEventDiezTres(int id_expediente)
        {
            IdExpediente = id_expediente;
        }

        public int IdExpediente { get; set; }

    }
}
