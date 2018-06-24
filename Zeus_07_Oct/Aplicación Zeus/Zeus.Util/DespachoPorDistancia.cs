using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;
using System.Collections;


namespace Zeus.Util
{
    public class DespachoPorDistancia
    {
        
        //### Agrega un Carropor 2-6 si esta Disponible
        public static int DespachoPorDosSeis(int intIdExp)
        {
            DatosLogin.InvokeTwitter = "FT2";

            int RetornoCarro = 0;
            if (intIdExp > 0)
            {
                var carro = new z_carros();
                carro = carro.getObjectz_carros(intIdExp);
                if (!Carro.EstaDisponible(carro))
                {
                    MessageBox.Show("En Despacho por Distancia, el carro más próximo no esta disponible... ", "Sistema ZEUS");
                }
                else
                {
                    // marcar y asignar
                    //carro.estado = 4;
                    //carro.modifyz_carros(carro);

                    //string strExp = DatosLogin.LoginExp.ToString();
                    //MessageBox.Show("El Expediente..." + strExp, "Mensaje de ZEUS");

                    int id_carro_seleccionado = carro.id_carro;

                    //### Agregar Carro en tabla z_carros_llamado
                    if (carro.existenciaZcarrosLlamado(id_carro_seleccionado, DatosLogin.LoginExp) == 0)
                    {
                        carro.insertZcarrosLlamado(id_carro_seleccionado, DatosLogin.LoginGrp != 0 ? DatosLogin.LoginGrp : Convert.ToInt32(DatosLogin.LoginGrp), DatosLogin.LoginExp);
                        StaticClass.ArrGrupoCarros.Add(id_carro_seleccionado + "/" + DatosLogin.LoginGrp);
                    }


                    //### Asignar el Carro Seleccionado
                    Carro.Despachar(carro);

                    //idCarros.Add(id_carro_seleccionado);
                    RetornoCarro = id_carro_seleccionado;
                }
            }
            return RetornoCarro;
        }

        ////### Obtiene un Id de Carro si es un Id_Llamado en el Radio de una Compañía
        //public static int LlamadoEnRadioDeCia(int IdExpediente)
        //{
        //    var exp = new e_expedientes().getObjecte_expedientes(IdExpediente);
        //    var Desp_x_Dist = new m001_config();
        //    DataSet ds = Desp_x_Dist.GetConfigM001(exp.codigo_llamado);
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        Desp_x_Dist.id_llamado = (int)dr["id_llamado"];
        //        Desp_x_Dist.radio = (int)dr["radio"];
        //        Desp_x_Dist.id_compania = (int)dr["id_compania"];
        //        Desp_x_Dist.id_carro = (int)dr["id_carro"];
        //        return 1;
        //    }
        //    return 0;
        //}


        //### Data Set    Obtiene un Id de Carro si es un Id_Llamado en el Radio de una Compañía
        public int LlamadoEnRadioDeCia(int IdExpediente)
        {
            var exp = new e_expedientes().getObjecte_expedientes(IdExpediente);
            var Desp_x_Dist = new m001_config();
            DataSet ds = Desp_x_Dist.GetConfigM001(exp.codigo_llamado);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (exp.codigo_llamado == (int)dr["id_llamado"])
                {
                    Desp_x_Dist.id_llamado = (int)dr["id_llamado"];
                    Desp_x_Dist.radio = (int)dr["radio"];
                    Desp_x_Dist.id_compania = (int)dr["id_compania"];
                    Desp_x_Dist.id_carro = (int)dr["id_carro"];
                    //Desp_x_Dist.x_cor = Convert.ToInt32(dr["pto_x"].ToString());  //(int)dr["pto_x"]; 
                    //Desp_x_Dist.y_cor = Convert.ToInt32(dr["pto_y"].ToString());  //(int)dr["pto_y"];
                    int x_cia = Convert.ToInt32(dr["pto_x"].ToString());  //(int)dr["pto_x"]; 
                    int y_cia = Convert.ToInt32(dr["pto_y"].ToString());  //(int)dr["pto_y"];

                    var centro = new PointD(x_cia, y_cia);
                    var pto_exp = new PointD(exp.puntoX, exp.puntoY);
                    int IdCarro = Desp_x_Dist.HayExpEnRadio(centro, (int)dr["radio"], pto_exp);
                    if (IdCarro > 0)
                    {
                        return IdCarro;
                    }
                }
            }
            return 0;
        }







    }
}
