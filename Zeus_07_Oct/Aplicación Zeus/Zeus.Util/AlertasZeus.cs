using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeus.Util
{
    public class AlertasZeus
    {
        public static event EventHandler<DespachoEventDiezTres> OnAlertas;
        
        public static int AsignaExpediente(int intIdExp)
        {
            OnAlertas(null, new DespachoEventDiezTres(intIdExp));
            return 1;
        }

    }
}
