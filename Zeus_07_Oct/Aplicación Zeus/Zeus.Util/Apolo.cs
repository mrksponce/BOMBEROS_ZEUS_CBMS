using Zeus.Data;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;


namespace Zeus.Util
{
    public class Apolo
    {
        //protected z_carros carro;
        private e_carros_usados carroUsado;
        private e_expedientes exp = new e_expedientes();

        /// <summary>
        /// Inicializa una instancia cargando el carro pasado
        /// </summary>
        /// <param name="id_carro"></param>
        public Apolo(int id_carro)
        {
            carroUsado = new e_carros_usados().getObjecte_carros_usados(id_carro);
        }

        public e_carros_usados CarroUsado
        {
            get { return carroUsado; }
        }



        //########################################
        //###   JSON APOLO Y PUBLICAR EVENTOS  ###
        //########################################
        public void ApoloHoraCarro(string ClaveCarro, string zUser, string zPw)
        {
            var ccarros = new z_carros();
            ccarros = ccarros.getObjectz_carros(carroUsado.id_carro);
            string strCarro = ccarros.nombre;

            exp = exp.getObjecte_expedientes(carroUsado.id_expediente);
            string[] GetFechaHora = exp.fecha.ToString().Split(' ');

            string obj = "{";
            obj += "'usuario':'" + zUser + "',";
            obj += "'password':'" + zPw + "',";
            obj += "'expediente':'" + carroUsado.id_expediente.ToString() + "',";
            obj += "'fecha':'" + GetFechaHora[0].ToString() + "',";
            obj += "'hora':'" + GetFechaHora[1].ToString() + "',";
            obj += "'carro':'" + strCarro + "',";
            obj += "'clave_hora':'" + ClaveCarro + "',";
            obj += "'hora_evento':'" + System.DateTime.Now.ToString() + "'}";

            string obj_v2 = obj.Replace(" ", "?");

            if (ccarros.GetParametroPrioridad(2).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\emergencias_2.py";
                proceso2.StartInfo.Arguments = obj_v2;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }
        }


        //###############################################
        //###   JSON APOLO Y PUBLICAR MATERIAL MAYOR  ###
        //###############################################

        public void ApoloHoraCarro(string ClaveCarro, int iDcarro, int iDconductor, string zUser, string zPw)
        {
            var ccarros = new z_carros();
            ccarros = ccarros.getObjectz_carros(carroUsado.id_carro);
            string strCarro = ccarros.nombre;

            exp = exp.getObjecte_expedientes(carroUsado.id_expediente);
            string[] GetFechaHora = exp.fecha.ToString().Split(' ');

            string obj = "{";
            obj += "'usuario':'" + zUser + "',";
            obj += "'password':'" + zPw + "',";
            //obj += "'fecha':'" + GetFechaHora[0].ToString() + "',";
            //obj += "'hora':'" + GetFechaHora[1].ToString() + "',";
            obj += "'estado':'" + ClaveCarro + "',";
            obj += "'carro':" + iDcarro + ",";
            obj += "'conductor':" + iDconductor + ",";
            obj += "'hora_estado':'" + System.DateTime.Now.ToString() + "'}";

            string obj_v2 = obj.Replace(" ", "?");

            if (ccarros.GetParametroPrioridad(6).Equals("TRUE"))
            {
                System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\bitacoras.py";
                proceso2.StartInfo.Arguments = obj_v2;
                proceso2.StartInfo.CreateNoWindow = true;
                proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso2.Start();
            }
        }





    }
}
