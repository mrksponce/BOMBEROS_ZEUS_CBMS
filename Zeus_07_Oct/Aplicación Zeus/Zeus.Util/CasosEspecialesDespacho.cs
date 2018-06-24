using System.Collections.Generic;
using System.Data;
using Zeus.Data;

namespace Zeus.Util
{
    internal class CasosEspecialesDespacho
    {
        public static void Ejecutar(e_expedientes expediente, List<int> carros)
        {
#if CBMS
            CBMS_CasoEspecialAgregarBX(expediente, carros);
            CBMS_CasoEspecialBXporB(expediente, carros);
            CBMS_CasoEspecialAgregarUT(expediente, carros);
#endif
        }

        /// <summary>
        /// Se debe despachar el B y BX de la misma compañía cuando se cumple lo siguiente:
        /// 1. El 10-0 se registra en sector que corresponde a alguna de las compañías que cuentan con ambos carros.
        /// 2. Se encuentran ambos carros en servicio con distinto conductor.
        /// 3. Si la compañía cuenta con ambos carros, pero al momento del despacho está en servicio sólo el ‘B’, no 
        /// se despacha una segunda prioridad de BX, sino que la segunda prioridad de carro ‘B’ que corresponda al 
        /// área del llamado.
        ///
        /// NOTA: Este caso es aplicable para todos los despachos cuya pauta determina que deben ser despachados 2 o 
        /// más carros de tipo ‘B’.
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="id_carros"></param>
        private static void CBMS_CasoEspecialAgregarBX(e_expedientes exp, ICollection<int> id_carros)
        {
            z_llamados llam = new z_llamados().getObjectz_llamados_id(exp.codigo_principal);
            // verificar 10-0
            if (llam.clave == "10-0")
            {
                // verificar 2 B despachados
                int cant_b = 0;
                DataTable tipo_carro = new z_tipo_carro().Getz_tipo_carro().Tables[0];
                DataTable carros = new z_carros().Getz_carros().Tables[0];
                var tipo_b = (int) (tipo_carro.Select("tipo_carro_letra='B'")[0]["id_tipo_carro"]);
                var columna_b = (string) (tipo_carro.Select("tipo_carro_letra='B'")[0]["columna_despacho"]);
                var tipo_bx = (int) (tipo_carro.Select("tipo_carro_letra='BX'")[0]["id_tipo_carro"]);
                var carros_b = new List<int>();

                foreach (int id in id_carros)
                {
                    DataRow dr = carros.Select("id_carro=" + id)[0];
                    if ((int) dr["id_tipo_carro"] == tipo_b)
                    {
                        cant_b++;
                        carros_b.Add(id);
                    }
                }

                if (cant_b >= 2)
                {
                    // obtener primera prioridad B (hecho arriba)
                    DataSet prioridad = new z_prioridad().Getz_prioridad(exp.id_area);
                    // si primer carro == primera prioridad, verificar bx
                    var prim_prioridad = (int) prioridad.Tables[0].Rows[0][columna_b];
                    if ((int) carros.Select("id_carro=" + carros_b[0])[0]["id_compania"] == prim_prioridad)
                    {
                        DataRow[] dr =
                            carros.Select("id_compania = " + prim_prioridad + " and id_tipo_carro=" + tipo_bx +
                                          " and estado=1");
                        // si dr!= null, liberar último B solicitado y agregar bx al despacho
                        if (dr.Length != 0)
                        {
                            // liberar último carro B
                            //Carro.Liberar(carros_b[carros_b.Count-1]);
                            //id_carros.Remove(carros_b[carros_b.Count - 1]);

                            // despachar BX
                            var bx = (int) dr[0]["id_carro"];
                            id_carros.Add(bx);
                            //Carro.MarcarDespachado(bx);
                            z_carros c = new z_carros().getObjectz_carros(bx);
                            Carro.Despachar(c);
                            //Conductor.FueraServicio(c.id_conductor, c.id_carro);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Igual al caso especial Agregar BX, pero para los UT
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="id_carros"></param>
        private static void CBMS_CasoEspecialAgregarUT(e_expedientes exp, ICollection<int> id_carros)
        {
            z_llamados llam = new z_llamados().getObjectz_llamados_id(exp.codigo_principal);
            // verificar 10-0
            if (llam.clave == "10-0")
            {
                // verificar 2 B despachados
                int cant_b = 0;
                DataTable tipo_carro = new z_tipo_carro().Getz_tipo_carro().Tables[0];
                DataTable carros = new z_carros().Getz_carros().Tables[0];
                var tipo_b = (int)(tipo_carro.Select("tipo_carro_letra='B'")[0]["id_tipo_carro"]);
                var columna_b = (string)(tipo_carro.Select("tipo_carro_letra='B'")[0]["columna_despacho"]);
                var tipo_ut = (int)(tipo_carro.Select("tipo_carro_letra='UT'")[0]["id_tipo_carro"]);
                var carros_b = new List<int>();

                foreach (int id in id_carros)
                {
                    DataRow dr = carros.Select("id_carro=" + id)[0];
                    if ((int)dr["id_tipo_carro"] == tipo_b)
                    {
                        cant_b++;
                        carros_b.Add(id);
                    }
                }

                if (cant_b >= 2)
                {
                    // obtener primera prioridad B (hecho arriba)
                    DataSet prioridad = new z_prioridad().Getz_prioridad(exp.id_area);
                    // si primer carro == primera prioridad, verificar bx
                    var prim_prioridad = (int)prioridad.Tables[0].Rows[0][columna_b];
                    if ((int)carros.Select("id_carro=" + carros_b[0])[0]["id_compania"] == prim_prioridad)
                    {
                        DataRow[] dr =
                            carros.Select("id_compania = " + prim_prioridad + " and id_tipo_carro=" + tipo_ut +
                                          " and estado=1");
                        // si dr!= null, liberar último B solicitado y agregar ut al despacho
                        if (dr.Length != 0)
                        {
                            // liberar último carro B
                            //Carro.Liberar(carros_b[carros_b.Count-1]);
                            //id_carros.Remove(carros_b[carros_b.Count - 1]);

                            // despachar BX
                            var ut = (int)dr[0]["id_carro"];
                            id_carros.Add(ut);
                            //Carro.MarcarDespachado(ut);
                            z_carros c = new z_carros().getObjectz_carros(ut);
                            //Conductor.FueraServicio(c.id_conductor, c.id_carro);
                            Carro.Despachar(c);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Si ocurre un llamado 10-2, 10-8 o 10-9 en alguna de las áreas correspondiente a compañías que cuentan con ‘B’ y ‘BX’, 
        /// debe ser despachado el ‘BX’ en lugar del ‘B’ que indica la pauta. Si al momento del despacho de alguna de estas claves 
        /// (10-2, 10-8 o 10-9), el ‘BX’ se encuentra fuera de servicio, debe ser despachado el ‘B’ de la misma compañía en caso que 
        /// se encuentre disponible o el ‘B’ de la compañía que corresponda según la prioridad.
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="id_carros"></param>
        private static void CBMS_CasoEspecialBXporB(e_expedientes exp, ICollection<int> id_carros)
        {
            // verificar llamado 10-2, 10-8 o 10-9
            DataTable llamados = new z_llamados().Getz_llamados().Tables[0];
            DataRow[] res =
                llamados.Select("codigo_llamado=" + exp.codigo_principal +
                                " and (clave='10-2' or clave='10-8' or clave='10-9')");
            if (res.Length != 0)
            {
                // verificar que no haya BX
                //bool salio_bx = false;
                int compania = exp.id_area/100;
                bool compania_tiene_bx = false;
                //bool bx_en_llamado_es_de_compañia = false;
                //int id_bx = 0;
                z_carros bx = null;
                DataTable tipo_carro = new z_tipo_carro().Getz_tipo_carro().Tables[0];
                DataTable carros = new z_carros().Getz_carros().Tables[0];
                int tipo_b = (int) (tipo_carro.Select("tipo_carro_letra='B'")[0]["id_tipo_carro"]);
                int tipo_bx = (int) (tipo_carro.Select("tipo_carro_letra='BX'")[0]["id_tipo_carro"]);

                // salio un bx?
                foreach (int id in id_carros)
                {
                    DataRow dr = carros.Select("id_carro=" + id)[0];
                    if ((int) dr["id_tipo_carro"] == tipo_bx)
                    {
                        //salio_bx = true;
                        //id_bx = id;
                        bx = new z_carros().getObjectz_carros(id);
                        break;
                    }
                }

                // compañia tiene bx?
                foreach (DataRow dr in carros.Select("id_tipo_carro=" + tipo_bx))
                {
                    if ((int) dr["id_compania"] == compania)
                    {
                        compania_tiene_bx = true;
                        break;
                    }
                }
                // si salio el bx que no era, o no salio bx, (liberar bx y) asignar B segun prioridad
                if ((bx!=null && bx.id_compania!=compania && compania_tiene_bx) || bx==null && compania_tiene_bx)
                {
                    // liberar BX si habia
                    if (bx!=null)
                    {
                        Carro.Liberar(bx.id_carro);
                        id_carros.Remove(bx.id_carro);
                    }
                    // obtener carro B
                    z_carros carro_b = Despacho.ObtenerCarro(tipo_b, exp.id_area);
                    if (carro_b.id_carro != 0)
                    {
                        Carro.Despachar(carro_b);
                        //Conductor.FueraServicio(carro_b.id_conductor, carro_b.id_carro);
                        id_carros.Add(carro_b.id_carro);
                    }
                }
            }
        }
    }
}