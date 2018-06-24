using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using Zeus.Data;

namespace Zeus.Util
{
    public static class JsonUpdateHoraActoClave
    {
        //#######################################
        //###   JSON Actualiza Hora de Acto   ###
        //#######################################
        public static void ApoloUpdateHoraActo(int idcarro, int idexpediente, string tipoclave, string lahora)
        {
            //# Objeto Carro
            var ccarros = new z_carros();

            JsonUpdateHoraCarro UpHoraActo = new JsonUpdateHoraCarro();
            UpHoraActo.carro_id = idcarro;
            UpHoraActo.expediente_id = idexpediente;
            UpHoraActo.clave = tipoclave;
            UpHoraActo.hora = lahora;

            string jsonBit = JsonConvert.SerializeObject(UpHoraActo);
            string jsonBit_2 = jsonBit.Replace("\"", "%");
            string jsonBit_3 = jsonBit_2.Replace(" ", "?");

            if (ccarros.GetParametroPrioridad(6).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\update_hora_acto.py";
                proceso2.StartInfo.Arguments = jsonBit_3;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }

            //### Escribir JSON Salidas
            string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonHoraActo_" + tipoclave + "_" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
            StreamWriter sw = new StreamWriter(fic);
            sw.WriteLine("JSON Actualiza Horas de Actos");
            sw.WriteLine("");
            sw.WriteLine(jsonBit_3);
            sw.Close();
        }
    }
}


