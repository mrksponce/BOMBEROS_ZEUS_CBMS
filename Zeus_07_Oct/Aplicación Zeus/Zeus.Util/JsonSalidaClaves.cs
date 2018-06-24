using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using Zeus.Data;

namespace Zeus.Util
{
    public class JsonSalidaClaves
    {
        //protected z_carros carro;
        private e_carros_usados carroUsado;
        private e_expedientes exp = new e_expedientes();

        public int IdExpediente { get; set; }

        /// <summary>
        /// Inicializa una instancia cargando el carro pasado
        /// </summary>
        /// <param name="id_carro"></param>
        public JsonSalidaClaves(int id_carro)
        {
            carroUsado = new e_carros_usados().getObjecte_carros_usados(id_carro);
        }

        public e_carros_usados CarroUsado
        {
            get { return carroUsado; }
        }



        //#########################
        //###   JSON Salidas   ###
        //#########################
        public void ApoloHoraCarro(int idgestion,string ClaveCarro, int iDcarro, string nomVoluntario, int CantTripulan, int IdExp)
        {
            //# Objeto Expediente
            exp = exp.getObjecte_expedientes(IdExp);
            string[] GetFechaHora = exp.fecha.ToString().Split(' ');
            string[] GetHoraActual = System.DateTime.Now.ToString().Split(' ');
            
            //# Objeto Carro
            var ccarros = new z_carros();
            ccarros = ccarros.getObjectz_carros(iDcarro);
            string strNomConductor = new z_conductores().Getz_NombreConductor(ccarros.id_conductor).ToString().Replace("Ñ", "N");
            string strCarro = ccarros.nombre.Replace("Ñ", "N");

            //# Carro en Llamado
            //var cen = new CarroEnLlamado(iDcarro);
            //string aCargoVol = cen.id

            JsonSalida salida = new JsonSalida();
            salida.idgestion = idgestion;
            switch (IdExp)
            {
                case -1:
                    salida.acto = "6-13";
                    break;
                case -2:
                    salida.acto = "6-14";
                    break;
                case -3:
                    salida.acto = "6-15";
                    break;
                default:
                    break;
            }
            salida.fecha = GetHoraActual[0].ToString();
            salida.hora = GetHoraActual[1].ToString();
            salida.clave = ClaveCarro;
            salida.carro = iDcarro;
            salida.conductor = strNomConductor;
            salida.a_cargo = nomVoluntario.Replace("Ñ", "N");
            salida.tripulan = CantTripulan;

            string jsonBit = JsonConvert.SerializeObject(salida);
            string jsonBit_2 = jsonBit.Replace("\"", "%");
            string jsonBit_3 = jsonBit_2.Replace(" ", "?");

            if (ccarros.GetParametroPrioridad(6).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\salidas.py";
                proceso2.StartInfo.Arguments = jsonBit_3;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }


            //### Escribir JSON Salidas
            string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonSalidas.txt";
            StreamWriter sw = new StreamWriter(fic);
            sw.WriteLine("JSON Bitacora ZEUS");
            sw.WriteLine("");
            sw.WriteLine(jsonBit_3);
            sw.Close();

        }

    }
}
