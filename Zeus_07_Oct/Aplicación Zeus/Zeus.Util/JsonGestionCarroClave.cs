using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace Zeus.Util
{
    public class JsonGestionCarroClave
    {
        //protected z_carros carro;
        private e_carros_usados carroUsado;
        private e_expedientes exp = new e_expedientes();

        public int IdExpediente { get; set; }

        /// <summary>
        /// Inicializa una instancia cargando el carro pasado
        /// </summary>
        /// <param name="id_carro"></param>
        //public JsonGestionCarroClave(int id_carro)
        //{
        //    carroUsado = new e_carros_usados().getObjecte_carros_usados(id_carro);
        //}

        public JsonGestionCarroClave()
        {
        }

        //# Objeto Carro
        z_carros ccarros = new z_carros();

        //public e_carros_usados CarroUsado
        //{
        //    get { return carroUsado; }
        //}



        //#########################
        //###   JSON Gestión Carro   ###
        //#########################
        public void ApoloHoraGestionCarro(int IdExp, int IdCarro, int intOp, int intIdGestion)
        {
            //# Objeto Expediente
            exp = exp.getObjecte_expedientes(IdExp);
            string[] GetFechaHora = exp.fecha.ToString().Split(' ');
            string[] GetHoraActual = System.DateTime.Now.ToString().Split(' ');

            JsonGstionCarro gestion = new JsonGstionCarro();
            switch (IdExp)
            {
                case -1:
                    gestion.acto = "6-13";
                    break;
                case -2:
                    gestion.acto = "6-14";
                    break;
                case -3:
                    gestion.acto = "6-15";
                    break;
                default:
                    break;
            }
            gestion.fecha = GetHoraActual[0].ToString();
            gestion.hora = GetHoraActual[1].ToString();
            gestion.carro = IdCarro;
            gestion.operadora = intOp;
            gestion.idgestion = intIdGestion;

            string jsonBit = JsonConvert.SerializeObject(gestion);
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
            string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonGestionCarro.txt";
            StreamWriter sw = new StreamWriter(fic);
            sw.WriteLine("JSON Bitacora ZEUS");
            sw.WriteLine("");
            sw.WriteLine(jsonBit_3);
            sw.Close();
            
        }
    }
}



