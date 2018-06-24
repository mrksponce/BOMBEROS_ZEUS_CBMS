using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;



namespace Zeus.Util
{
    public class JsonBitacoraClaves
    {
        //protected z_carros carro;
        private e_carros_usados carroUsado;
        private e_expedientes exp = new e_expedientes();

        public int IdExpediente { get; set; }

        /// <summary>
        /// Inicializa una instancia cargando el carro pasado
        /// </summary>
        /// <param name="id_carro"></param>
        public JsonBitacoraClaves(int id_carro)
        {
            carroUsado = new e_carros_usados().getObjecte_carros_usados(id_carro);
        }

        public e_carros_usados CarroUsado
        {
            get { return carroUsado; }
        }



        //#########################
        //###   JSON Bitacora   ###
        //#########################
        public void ApoloHoraCarro(string ClaveCarro, int iDcarro, string nomVoluntario, int CantTripulan, int IdExp)
        {
            //# Objeto Expediente
            exp = exp.getObjecte_expedientes(IdExp);
            string[] GetFechaHora = exp.fecha.ToString().Split(' ');
            string[] GetHoraActual = System.DateTime.Now.ToString().Split(' ');
            
            //# Objeto Carro
            var ccarros = new z_carros();
            ccarros = ccarros.getObjectz_carros(iDcarro);
            string strCarro = ccarros.nombre;
            string strNomConductor = new z_conductores().Getz_NombreConductor(ccarros.id_conductor).ToString();
            strNomConductor = strNomConductor.Replace("Ñ", "N");

            //# Carro en Llamado
            //var cen = new CarroEnLlamado(iDcarro);
            //string aCargoVol = cen.id

            JsonBitacora bitacora = new JsonBitacora();
            bitacora.expediente = exp.id_expediente.ToString();
            bitacora.fecha = GetFechaHora[0].ToString();
            bitacora.hora = GetFechaHora[1].ToString();
            bitacora.clave = ClaveCarro;
            bitacora.carro = iDcarro;
            if (ClaveCarro == "6-0")
            {
                bitacora.hora_clave = GetFechaHora[1].ToString();
            }
            else
            {
                bitacora.hora_clave = GetHoraActual[1].ToString();
            }
            bitacora.conductor = strNomConductor;
            nomVoluntario = nomVoluntario.Replace("Ñ", "N");
            bitacora.a_cargo = nomVoluntario;
            bitacora.tripulan = CantTripulan;

            string jsonBit = JsonConvert.SerializeObject(bitacora);
            string jsonBit_2 = jsonBit.Replace("\"", "%");
            string jsonBit_3 = jsonBit_2.Replace(" ", "?");

            if (ccarros.GetParametroPrioridad(6).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\bitacoras.py";
                proceso2.StartInfo.Arguments = jsonBit_3;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }



            //### Escribir JSON Bitacora
            string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonBitacora_" + ClaveCarro + "_" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
            StreamWriter sw = new StreamWriter(fic);
            sw.WriteLine(" JSON Bitacora Claves: 6-0, 6-1, 6-3, 6-9 y 6-10   ZEUS");
            sw.WriteLine("");
            sw.WriteLine(jsonBit_3);
            sw.Close();

        }

    }
}
