using System;
using System.Windows.Forms;
using Zeus.Data;

namespace Zeus.Util
{
    public static class BitacoraLlamado
    {
        public static readonly string Carro = "carro";
        public static readonly string Despacho = "despacho";
        public static readonly string Incendio = "incendio";
        public static readonly string Llamado = "llamado";
        public static int IdOperadora { get; set; }

        public static void NuevoEvento(int id_operadora, int id_expediente, int id_carro, string tipo, string evento, DateTime date)
        {
            var bl = new bitacora_llamados
                         {
                             id_operadora = id_operadora,
                             id_expediente = id_expediente,
                             id_carro = id_carro,
                             evento = evento,
                             fecha = date,
                             tipo = tipo
                         };
            try
            {
                bl.Insert(bl, false);
            }
            catch (Exception e)
            {
                Log.Write(e);
                MessageBox.Show("No se pudo completar la operación debido a un error de Base de Datos.",
                                "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        public static void NuevoEvento(int id_expediente, string tipo, string evento)
        {
            NuevoEvento(IdOperadora, id_expediente, 0, tipo, evento, DateTime.Now);
        }


        public static void NuevoEvento(int id_expediente, string tipo, string evento, DateTime date)
        {
            NuevoEvento(IdOperadora, id_expediente, 0, tipo, evento, date);
        }

        public static void NuevoEvento(int id_expediente, int id_carro, string tipo, string evento)
        {
            NuevoEvento(IdOperadora, id_expediente, id_carro, tipo, evento, DateTime.Now);
        }
    }
}