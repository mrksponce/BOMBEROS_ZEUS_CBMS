using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using Zeus.Data;


namespace Zeus.Util
{
    public static class JsonUpdateNombreCarroClave
    {
        //################################################
        //###   JSON Actualiza Nombre Carro de Apoyo   ###
        //################################################
        public static void ApoloUpdateNombreCarroApoyo(int idcarro, string NombreCarro)
        {
            //# Objeto Carro
            var ccarros = new z_carros();
            
            JsonUpdateNombreCarro UpCarro = new JsonUpdateNombreCarro();
            UpCarro.id = idcarro;
            UpCarro.nombre = NombreCarro.Replace("Ñ", "N");

            string jsonBit = JsonConvert.SerializeObject(UpCarro);
            string jsonBit_2 = jsonBit.Replace("\"", "%");
            string jsonBit_3 = jsonBit_2.Replace(" ", "?");

            if (ccarros.GetParametroPrioridad(6).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\update_nombre_carro.py";
                proceso2.StartInfo.Arguments = jsonBit_3;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }

            //### Escribir JSON Salidas
            string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonUpdateNombreCarro_" + NombreCarro + "_" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
            StreamWriter sw = new StreamWriter(fic);
            sw.WriteLine("JSON Actualiza Nombre de Carro de Apoyo");
            sw.WriteLine("");
            sw.WriteLine(jsonBit_3);
            sw.Close();
        }

    }
}



