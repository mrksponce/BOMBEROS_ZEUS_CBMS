using System;
using Zeus.Data;

namespace Zeus.Util
{
    public static class BitacoraGestion
    {
        public static void NuevoEvento(int id_operadora, int id_aval, string evento)
        {
            var bg = new bitacora_gestion
                         {
                             id_operadora1 = id_operadora,
                             id_operadora2 = id_aval,
                             evento = evento,
                             fecha = DateTime.Now
                         };
            try
            {
                bg.Insert(bg, true);
            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
        }

        public static void NuevoEvento(int id_operadora, int id_aval, string evento, DateTime fecha)
        {
            var bg = new bitacora_gestion
                         {
                             id_operadora1 = id_operadora,
                             id_operadora2 = id_aval,
                             evento = evento,
                             fecha = fecha
                         };
            try
            {
                bg.Insert(bg, false);
            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
        }
    }
}