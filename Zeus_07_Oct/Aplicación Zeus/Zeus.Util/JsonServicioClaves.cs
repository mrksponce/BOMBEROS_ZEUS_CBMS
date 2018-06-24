using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using System;
using Zeus.Util;
using Zeus.Interfaces;


namespace Zeus.Util
{
    public class JsonServicioClaves
    {
        //protected z_carros carro;
        private e_carros_usados carroUsado;
        private e_expedientes exp = new e_expedientes();

        public int IdExpediente { get; set; }

        /// <summary>
        /// Inicializa una instancia cargando el carro pasado
        /// </summary>
        /// <param name="id_carro"></param>
        public JsonServicioClaves(int id_carro)
        {
            carroUsado = new e_carros_usados().getObjecte_carros_usados(id_carro);
        }

        public JsonServicioClaves()
        {

        }

        public e_carros_usados CarroUsado
        {
            get { return carroUsado; }
        }



        //#####################################
        //###   JSON Servicio Clave SIMPLE  ###
        //#####################################
        public void JsonServicioHora(int IdCarro, int IdEstado, string strConductor, string strMotivo, string strColor, Boolean booManual)
        {
            string[] GetHoraActual = System.DateTime.Now.ToString().Split(' ');
            
            //# Objeto Carro
            var ccarros = new z_carros();
            ccarros = ccarros.getObjectz_carros(IdCarro);
            string strCarro = ccarros.nombre;

            JsonServicio servicios = new JsonServicio();
            servicios.fecha = GetHoraActual[0].ToString();
            servicios.hora = GetHoraActual[1].ToString();
            servicios.carro = IdCarro;
            servicios.estado = IdEstado;
            servicios.conductor = strConductor.Replace("Ñ", "N");
            servicios.motivo = strMotivo.Replace("Ñ", "N");
            servicios.color = strColor;
            servicios.manual = booManual;

            string jsonBit = JsonConvert.SerializeObject(servicios);
            string jsonBit_2 = jsonBit.Replace("\"", "%");
            string jsonBit_3 = jsonBit_2.Replace(" ", "?");

            if (ccarros.GetParametroPrioridad(6).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\servicios.py";
                proceso2.StartInfo.Arguments = jsonBit_3;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }


            //### Escribir JSON MultiPuestaServicio
            string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonPuestaServicio.txt";
            StreamWriter sw = new StreamWriter(fic);
            sw.WriteLine("JSON Bitacora ZEUS");
            sw.WriteLine("");
            sw.WriteLine(jsonBit_3);
            sw.Close();


        }


        //########################################
        //###   JSON Servicio Clave MULTIPLE   ###
        //########################################
        public void JsonServicioHoraMultipleJSON(string strIdCarros, int IdEstado, string strIdConductores, string strMotivo, string strColor, Boolean booManual)
        {
            string[] ArIdCarro = strIdCarros.ToString().Split(',');
            string[] ArIdConductor = strIdConductores.ToString().Split(',');
            //string[] ArNomCarro = strCarros.ToString().Split(',');
            string[] MultiInsert = new string[ArIdCarro.Length];
            string[] GetHoraActual = System.DateTime.Now.ToString().Split(' ');

            //# Crear CadaObjeto JSON
            JsonServicio servicios = new JsonServicio();
            string strVector = "";
            string strVectorJSON = "";
            for (int x = 0; x < ArIdCarro.Length; x++)
            {
                servicios.fecha = GetHoraActual[0].ToString();
                servicios.hora = GetHoraActual[1].ToString();
                servicios.carro = Convert.ToInt32(ArIdCarro[x].ToString());
                servicios.estado = IdEstado;
                //### Nombre de Conductor
                string strNomConductor = new z_conductores().Getz_NombreConductor(Convert.ToInt32(ArIdConductor[x].ToString()));
                servicios.conductor = strNomConductor.Replace("Ñ", "N");
                servicios.motivo = strMotivo.Replace("Ñ", "N");
                servicios.color = strColor;
                servicios.manual = booManual;

                string jsonBit = JsonConvert.SerializeObject(servicios);
                strVector += jsonBit + ",";

                //# Agregar en Bitacora de Gestión
                BitacoraGestion.NuevoEvento(BitacoraLlamado.IdOperadora, 0, "Carro: " + servicios.carro.ToString() + "   Estado: " + servicios.estado.ToString() + "   Conductor: " + servicios.conductor.ToString());
            }
            strVector += "#";
            strVectorJSON = strVector.Replace(",#", "");
            string strVectorJSON_2 = strVectorJSON.Replace("\"", "%");
            string strVectorJSON_3 = strVectorJSON_2.Replace(" ", "?");

            z_carros ccarros = new z_carros();
            if (ccarros.GetParametroPrioridad(6).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\servicios.py";
                proceso2.StartInfo.Arguments = strVectorJSON_3;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }

            //### Escribir JSON MultiPuestaServicio
            string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonMultiPuestaServicio.txt";
            StreamWriter sw = new StreamWriter(fic);
            sw.WriteLine("JSON Bitacora ZEUS");
            sw.WriteLine("");
            sw.WriteLine(strVectorJSON_3);
            sw.Close();

        }




        //###############################################################
        //###      JSON Servicio Clave MULTIPLE TODOS LOS CARROS      ###
        //###############################################################
        // public void JsonServicioHoraMultipleJSON_TodosLosCarros(string strIdCarros, int IdEstado, string strIdConductores, string strMotivo, string strColor)
        public void JsonServicioHoraMultipleJSON_TodosLosCarros()
        {
            //string[] ArIdCarro = strIdCarros.ToString().Split(',');
            //string[] ArIdConductor = strIdConductores.ToString().Split(',');
            //string[] ArNomCarro = strCarros.ToString().Split(',');
            //string[] MultiInsert = new string[ArIdCarro.Length];
            string[] GetHoraActual = System.DateTime.Now.ToString().Split(' ');

            //### Obtiene Registro con Estado de Todos los Carros
            //### Crear CadaObjeto JSON
            z_carros carros = new z_carros();
            JsonServicio servicios = new JsonServicio();
            string strVector = "";
            string strVectorJSON = "";
            foreach (DataRow row_est in carros.Estado_Carro_Web().Tables[0].Rows)
            {
                servicios.fecha = GetHoraActual[0].ToString();
                servicios.hora = GetHoraActual[1].ToString();
                servicios.carro = Convert.ToInt32(row_est["id_carro"].ToString());
                servicios.estado = Convert.ToInt32(row_est["estado"].ToString());
                if (Convert.ToInt32(row_est["estado"].ToString()) == 2 | Convert.ToInt32(row_est["estado"].ToString()) == 3)
                {
                    servicios.conductor = "";
                }
                else
                {
                    servicios.conductor = row_est["conductor"].ToString().Replace("Ñ", "N");
                }
                servicios.motivo = row_est["motivo"].ToString().Replace("Ñ", "N");
                servicios.color = row_est["color"].ToString();
                servicios.manual = false;
                string jsonBit = JsonConvert.SerializeObject(servicios);
                strVector += jsonBit + ",";
            }
            strVector += "#";
            strVectorJSON = strVector.Replace(",#", "");
            string strVectorJSON_2 = strVectorJSON.Replace("\"", "%");
            string strVectorJSON_3 = strVectorJSON_2.Replace(" ", "?");

            z_carros ccarros = new z_carros();
            if (ccarros.GetParametroPrioridad(6).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\servicios.py";
                proceso2.StartInfo.Arguments = strVectorJSON_3;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }

            //### Escribir JSON MultiPuestaServicio
            string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonMultiPuestaServicioTodos.txt";
            StreamWriter sw = new StreamWriter(fic);
            sw.WriteLine("JSON Bitacora ZEUS");
            sw.WriteLine("");
            sw.WriteLine(strVectorJSON_3);
            sw.Close();
        }



    }
}


