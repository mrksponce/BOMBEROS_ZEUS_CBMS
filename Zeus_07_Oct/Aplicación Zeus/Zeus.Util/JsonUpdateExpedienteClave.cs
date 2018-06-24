using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using Zeus.Data;

namespace Zeus.Util
{
    public static class JsonUpdateExpedienteClave
    {
        //public JsonUpdateExpedienteClave()
        //{
        //}
        
        //#################################
        //###   JSON Compañia a Cargo   ###
        //#################################
        public static void ApoloUpdateExpediente(string IdExp, string stCampo, string stValor)
        {
            //# Objeto Carro
            var ccarros = new z_carros();
            
            JsonUpdateExpediente UpExp = new JsonUpdateExpediente();
            UpExp.expediente = IdExp;
            UpExp.campo = stCampo;
            UpExp.valor = stValor.Replace("Ñ", "N");

            string jsonBit = JsonConvert.SerializeObject(UpExp);
            string jsonBit_2 = jsonBit.Replace("\"", "%");
            string jsonBit_3 = jsonBit_2.Replace(" ", "?");

            if (ccarros.GetParametroPrioridad(6).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\UpdateExpediente.py";
                proceso2.StartInfo.Arguments = jsonBit_3;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }

            //### Escribir JSON Salidas
            string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonUpdateExpediente.txt";
            StreamWriter sw = new StreamWriter(fic);
            sw.WriteLine("JSON Compania a Cargo ZEUS");
            sw.WriteLine("");
            sw.WriteLine(jsonBit_3);
            sw.Close();
        }
    }
}




