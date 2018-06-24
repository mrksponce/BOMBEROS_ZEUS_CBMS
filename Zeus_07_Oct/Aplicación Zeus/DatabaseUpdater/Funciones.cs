using System;
using System.Data;
using Zeus.Data;
using Zeus.Util;

namespace DatabaseUpdater
{
    class Funciones
    {
        public static void VerificarServicio()
        {
            //todo: try-catch!
            DataSet ds = new z_puesta_servicio().Getz_puesta_servicio();
            string es = "", fs = "";
            //Console.WriteLine(DateTime.Now.ToString() + " regs:" + ds.Tables[0].Rows.Count);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                z_conductores cond = new z_conductores().getObjectz_conductores((int)dr["id_conductor"]);
                if ((DateTime)dr["fecha_hora"] <= DateTime.Now)
                {

                    if ((string)dr["id_carros_ps"] != "")
                    {
                        // poner en servicio
                        foreach (string s in ((string)dr["id_carros_ps"]).Split(','))
                        {
                            z_carros carro = Carro.EnServicioConductor(int.Parse(s), cond.id_conductor);
                            //    new z_carros().getObjectz_carros(int.Parse(s));
                            //carro.id_conductor = cond.id_conductor;
                            //carro.estado = 1;
                            //carro.modifyz_carros(carro);
                            Conductor.FueraServicio(carro.id_conductor, carro.id_carro);
                            es += "," + carro.nombre;
                        }

                        BitacoraGestion.NuevoEvento((int)dr["id_operadora"], dr.IsNull("id_aval") ? 0 : (int)dr["id_aval"], string.Format("Puesta en servicio de carros. Fecha: {0}, Conductor: {1}, Carros: {2}", ((DateTime)dr["fecha_hora"]).ToString(), cond.codigo_conductor, es.Trim(',')));
                    }

                   
                    if ((string)dr["id_carros_fs"] != "")
                    {
                        // fuera servicio

                        foreach (string s in ((string)dr["id_carros_fs"]).Split(','))
                        {
                            z_carros carro = Carro.SinConductor(int.Parse(s));
                            //    new z_carros().getObjectz_carros(int.Parse(s));
                            //carro.estado = 3;
                            //carro.id_conductor = 0;
                            ////LiberarConductor((int)dr["id_conductor"]);
                            //carro.modifyz_carros(carro);
                            fs += "," + carro.nombre;
                        }
                        BitacoraGestion.NuevoEvento((int)dr["id_operadora"], dr.IsNull("id_aval") ? 0 : (int)dr["id_aval"], string.Format("Fuera de servicio de carros. Fecha: {0}, Conductor: {1}, Carros: {2}", ((DateTime)dr["fecha_hora"]).ToString(), cond.codigo_conductor, fs.Trim(',')));
                    }

                    // mensaje
                    //MessageBox.Show(string.Format("Fecha: {0}, Conductor: {1}\nEn servicio: {2}\nFuera de servicio: {3}", ((DateTime)dr["fecha_hora"]).ToString(), cond.codigo_conductor, es.Trim(','), fs.Trim(',')));
                    new z_puesta_servicio().deletez_puesta_servicio((int)dr["id_puesta_servicio"]);
                    // verificar temporal
                    if (cond.temporal)
                    {
                        Conductor.VerificarTemporal(cond);
                    }
                }


            }

        }
        public static void VerificarInterinaje()
        {

        }
    }
}
