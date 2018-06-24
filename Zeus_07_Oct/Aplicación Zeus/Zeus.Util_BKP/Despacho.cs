using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util.Forms;
using System.Collections.Generic;
using System.Collections;

namespace Zeus.Util
{
    public static class Despacho
    {
        public static event EventHandler<DespachoEventArgs> OnDespacho;
        public static int id_carro_puntero = 0;
        public static string[] carros_compuesto = null;
        public static ArrayList companias_a_despachar = new ArrayList();
        private static CantidadCarros ObtenerCantidadCarros(int id_area, int codigo_llamado, out List<int> dos_6)
        {
            var dos6 = new List<int>();
            // 4
            var cantidad = new CantidadCarros();
            // obtener cantidad de carros necesaria
            DataTable di = null;
            DataTable dh = new z_despacho_habil().Getz_despacho_habil(id_area, codigo_llamado).Tables[0];
            DataTable tipo_carro = new z_tipo_carro().Getz_tipo_carro_despacho().Tables[0];
            // 4.a
            if ((bool)dh.Rows[0]["inhabil"])
            {
                if (EnBloqueHorario((string)dh.Rows[0]["bloques"]))
                {
                    di = new z_despacho_inhabil().Getz_despacho_inhabil(id_area, codigo_llamado).Tables[0];
                }
            }

            if (di == null)
            {
                for (int i = 0; i < tipo_carro.Rows.Count; i++)
                {
                    var columna = (string)tipo_carro.Rows[i]["columna_despacho"];
                    cantidad.Cantidad[i] = (int)dh.Rows[0][columna];
                }

                //dos6?
                if ((bool)dh.Rows[0]["dos_6"])
                {
                    var dos = new z_dos_6();
                    DataSet ds = dos.GetDos6Despacho((int)dh.Rows[0]["id_despacho"]);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var carro = new z_carros();
                        carro = carro.getObjectz_carros((int)dr["id_carro"]);
                        if (Carro.EstaDisponible(carro))
                        {
                            Carro.Despachar(carro);
                            //Conductor.FueraServicio(carro.id_conductor, carro.id_carro);
                            dos6.Add(carro.id_carro);
                        }
                    }
                }
            }
            else
            {
                // despacho inhábil
                for (int i = 0; i < tipo_carro.Rows.Count; i++)
                {
                    string columna = (string)tipo_carro.Rows[i]["columna_despacho"];
                    cantidad.Cantidad[i] = (int)di.Rows[0][columna];
                }

                //dos6?
                if ((bool)di.Rows[0]["dos_6"])
                {
                    var dos = new z_dos_6();
                    DataSet ds = dos.GetDos6Despacho((int)di.Rows[0]["id_despacho"]);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var carro = new z_carros();
                        carro = carro.getObjectz_carros((int)dr["id_carro"]);
                        if (Carro.EstaDisponible(carro))
                        {
                            Carro.Despachar(carro);
                            //Conductor.FueraServicio(carro.id_conductor, carro.id_carro);
                            dos6.Add(carro.id_carro);
                        }
                    }
                }
            }
            dos_6 = dos6;
            return cantidad;
        }

        private static void OrdenarCarros(CantidadCarros cantidad, int codigo_llamado)
        {
            // 5
            var orden = new z_orden();
            DataSet ds = orden.Getz_orden(codigo_llamado);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cantidad.Orden[i] = (int)ds.Tables[0].Rows[i]["orden_numero"];
            }
            cantidad.Ordenar();
        }

        public static z_carros ObtenerCarro(int id_tipo_carro, int id_area)
        {
            return ObtenerCarro(id_tipo_carro, id_area, false);
        }

        public static z_carros ObtenerCarro(int id_tipo_carro, int id_area, bool verificar_cubriendo)
        {
            return ObtenerCarro(id_tipo_carro, id_area, verificar_cubriendo, null);
        }

        public static z_carros ObtenerCarro(int id_tipo_carro, int id_area, bool verificar_cubriendo,
                                            List<int> compañias_usadas)
        {
            DataTable tipo_carros = new z_tipo_carro().Getz_tipo_carro().Tables[0];

            // Obtener compañía que debe despachar el tipo de carro especificado 
            // (desde z_prioridad, parámetros: tipo_carro, cantidad)
            var prioridad = new z_prioridad();
            DataSet ds = prioridad.Getz_prioridad(id_area);
            // Verificar, desde tabla z_carros, si la compañía seleccionada tiene el tipo de carro requerido, 
            // y que su estado sea=1 (en servicio)
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                var carro = new z_carros();
                string columna =
                    (string)(tipo_carros.Select("id_tipo_carro=" + id_tipo_carro)[0]["columna_despacho"]);
                int compañia = (int)dr[columna];

                //// CBQN: sólo un carro por compañía
                if (compañias_usadas != null && compañias_usadas.Contains(compañia))
                {
                    continue;
                }
                DataSet carros = carro.GetCarrosCompania(id_tipo_carro, compañia);
                foreach (DataRow Row in carros.Tables[0].Rows)
                {
                    carro = carro.getObjectz_carros((int)Row["id_carro"]);

                    // verificar cubrir cuarteles
                    if (verificar_cubriendo && carro.id_carro != 0)
                    {
                        // carro cubre área si 1) id_compania!=id_compania_orig y 2) id_compania_cubre==1° prioridad área
                        int primera_prioridad = (int)ds.Tables[0].Rows[0][columna];
                        if (carro.id_compania_orig != carro.id_compania && carro.id_compania == primera_prioridad)
                        {
                            // carro cubre área, ignorar
                            carro.id_carro = 0;
                        }
                    }

                    // seleccionar carro
                    if (carro.id_carro != 0)
                    {
                        if (Carro.EstaDisponible(carro))
                        {
                            Carro.Despachar(carro);
                            //Conductor.FueraServicio(carro.id_conductor, carro.id_carro);
                            return carro;
                        }
                        // carro alternativo???
                        if (carro.id_tipo_alternativo != 0)
                        {
                            carro = carro.getObjectz_carros(carro.id_tipo_alternativo);
                            if (carro.id_carro != 0 && Carro.EstaDisponible(carro))
                            {
                                Carro.Despachar(carro);
                                //Conductor.FueraServicio(carro.id_conductor, carro.id_carro);
                                return carro;
                            }
                        }
                    }
                }
            }
            return new z_carros();
        }


        private static bool EnBloqueHorario(string bloques)
        {
            string[] Bloques = bloques.Split(',');
            var bh = new z_bloque_horario();
            int bloque = bh.GetBloqueActual();
            bool enbloque = false;
            foreach (string s in Bloques)
            {
                if (s == bloque.ToString())
                {
                    enbloque = true;
                }
            }
            return enbloque;
        }

        //private static Dictionary<int, string> tipo_carros;

        public static int ranking(int id_expediente, int id_area, int bloque)
        {
            e_expedientes expediente = new e_expedientes();
            z_carros zcarros = new z_carros();
            z_orden zorden = new z_orden();
            ArrayList puntero_final = new ArrayList();
            ArrayList lista_carros = new ArrayList();
            ArrayList list_ranking = new ArrayList();
            ArrayList array_final = new ArrayList();
            int cant_carros = 0;
            int j = 0;
            int p = 0;
            try
            {
                expediente = expediente.getObjecte_expedientes(id_expediente);
                string punto_x = expediente.puntoX.ToString();
                string punto_y = expediente.puntoY.ToString();
                string[] carros_in = expediente.recuperarDespachoHabil(expediente.codigo_llamado);
                ArrayList alist_orden_grupo = zorden.xOrdenGrupo(expediente.codigo_llamado);
                ArrayList[] array_lista_carros = new ArrayList[5];
                int[] posicion = new int[carros_in.Length];
                for (int a = 0; a < carros_in.Length; a++)
                {
                    string[] operacion_grupos = carros_in[a].Split('/');
                    for (int i = 0; i < alist_orden_grupo.Count; i++ )
                    {
                        if (operacion_grupos[1].ToString() == alist_orden_grupo[i].ToString())
                        {
                            posicion[p] = j;
                            p++;
                            j++;
                        }
                    }
                }
                Array.Sort(posicion);
                int[] orden_final = new int[posicion.Length];
                for (int c = 0; c < posicion.Length; c++)
                {
                    int valor_posicion_array = Convert.ToInt32(posicion[c].ToString());
                    orden_final[c] = Convert.ToInt32(alist_orden_grupo[valor_posicion_array].ToString());
                }
                for (int f = 0; f < orden_final.Length; f++)
                {
                    string[] group = carros_in[f].Split('/');
                    for (int l = 0; l < carros_in.Length; l++)
                    {
                        if (group[1].ToString() == orden_final[f].ToString())
                        {
                            int int_r = Convert.ToInt32(group[2].ToString());
                            // Crear arraylist por cada campos.
                            array_lista_carros = zcarros.obtenerCarrosIN(group[0]);
                            //cant_carros = lista_carros.Count;
                            ArrayList list_id_carros = new ArrayList();
                            ArrayList list_carro_x = new ArrayList();
                            ArrayList list_carro_y = new ArrayList();
                            ArrayList list_compania = new ArrayList();
                            //ArrayList list_ranking = new ArrayList();
                            // arreglo nuevo que creamos **************************
                            ArrayList list_carros_despacho = new ArrayList();
                            // ****************************************************

                            list_id_carros = array_lista_carros[0];
                            list_carro_x = array_lista_carros[1];
                            list_carro_y = array_lista_carros[2];
                            list_compania = array_lista_carros[3];
                            list_ranking = array_lista_carros[4];

                            string[] ccarro = new string[list_id_carros.Count];
                            string[] px = new string[list_carro_x.Count];
                            string[] py = new string[list_carro_y.Count];
                            string[] comp = new string[list_compania.Count];
                            string[] ranking = new string[list_ranking.Count];

                            for (int b = 0; b < list_id_carros.Count; b++)
                            {
                                ccarro[b] = list_id_carros[b].ToString();
                            }

                            for (int c = 0; c < list_carro_x.Count; c++)
                            {
                                px[c] = list_carro_x[c].ToString();
                            }

                            for (int d = 0; d < list_carro_y.Count; d++)
                            {
                                py[d] = list_carro_y[d].ToString();
                            }

                            for (int e = 0; e < list_compania.Count; e++)
                            {
                                comp[e] = list_compania[e].ToString();
                            }

                            for (int h = 0; h < list_ranking.Count; h++)
                            {
                                ranking[h] = list_ranking[h].ToString();
                            }

                            puntero_final = despacharGrupo(group[0], group[1], group[2], list_ranking);
                            string ret_final = ordenArreglo(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_ranking, group[0], group[1], group[2], expediente.codigo_llamado, list_compania);
                            array_final.Add(ret_final);
                            ArrayList aa_empty = new ArrayList();
                            companias_a_despachar = aa_empty;
                            l = l + 1;
                        }
                    }
                }
            }
            catch (Exception exe)
            { 
                
            }

            return 1;
        }

        public static string ordenArreglo(ArrayList puntero_final, ArrayList list_id_carros, ArrayList list_carro_x, ArrayList list_carro_y, ArrayList list_compania, ArrayList list_ranking, string idcarros, string idgrupos, string recu, int cod_llamado, ArrayList list_comp)
        {
                
                List<int> despGrupo = new List<int>();
                var ccarros = new z_carros();
                var cczorden = new z_orden();
                string[] arr = new string[puntero_final.Count];
                string[] arr_split = new string[puntero_final.Count];
                string[] arr_uso = new string[puntero_final.Count];
                int r = Convert.ToInt32(recu);
                string valores_finales_retorno = "";
                for (int a = 0; a < puntero_final.Count; a++)
                {
                    arr[a] = puntero_final[a].ToString(); 
                }
                while(r != 0)
                {
                    for (int b = 0; b < arr.Length; b++)
                    {
                        string valor_envio = arr[b].ToString();
                        if (carrosPorRanking(valor_envio, list_id_carros) == 1)
                        {
                            ccarros = ccarros.getObjectz_carros(id_carro_puntero);
                            if (Carro.EstaDisponible(ccarros) && r != 0)
                            {
                                //despGrupo.Add(ccarros.id_carro);
                                if (companias_a_despachar.Count != 0)
                                {
                                    if (verificarCandidatosDespacho(ccarros.id_compania, companias_a_despachar))
                                    {
                                        companias_a_despachar.Add(ccarros.id_compania);
                                        valores_finales_retorno += ccarros.id_carro + ",";
                                        r--;
                                    }
                                }
                                else
                                {
                                    companias_a_despachar.Add(ccarros.id_compania);
                                    valores_finales_retorno += ccarros.id_carro + ",";
                                    r--;
                                }
                            }
                        }
                        else
                        {
                            int[] t_carro = new int[carros_compuesto.Length];
                            string tc_string = "";
                            string tc_string_2 = "";
                            string tc_usar = "";
                            string tc_usar_2 = "";
                            for (int c = 0; c < carros_compuesto.Length; c++)
                            {
                                tc_string_2 += carros_compuesto[c].ToString() + ",";
                                tc_string += ccarros.recuperarValorTipoCarro(Convert.ToInt32(carros_compuesto[c])) + ",";
                            }
                            tc_string += "#";
                            tc_string_2 += "#";

                            tc_usar = tc_string.Replace(",#", "");
                            tc_usar_2 = tc_string_2.Replace(",#", "");

                            int[] tc_recuperado = cczorden.recuperarTipoCarroOrdenTipo(cod_llamado, tc_usar);
                            for (int d = 0; d < tc_recuperado.Length; d++)
                            {
                                int id_carro_final = cczorden.despachoPorTipo(Convert.ToInt32(tc_recuperado[d].ToString()), tc_usar_2);
                                ccarros = ccarros.getObjectz_carros(id_carro_final);
                                if (Carro.EstaDisponible(ccarros) && r != 0)
                                {
                                    //despGrupo.Add(ccarros.id_carro);
                                    if (companias_a_despachar.Count != 0)
                                    {
                                        if (verificarCandidatosDespacho(ccarros.id_compania, companias_a_despachar))
                                        {
                                            companias_a_despachar.Add(ccarros.id_compania);
                                            valores_finales_retorno += ccarros.id_carro + ",";
                                            r--;
                                        }
                                    }
                                    else
                                    {
                                        companias_a_despachar.Add(ccarros.id_compania);
                                        valores_finales_retorno += ccarros.id_carro + ",";
                                        r--;
                                    }
                                }
                            }
                        }
                    }
                    r = 0;
                }
                valores_finales_retorno += "#";
                return valores_finales_retorno;
        }

        public static bool verificarCandidatosDespacho(int compania_id, ArrayList aid_companias)
        {
            bool estado = true;
            for (int i = 0; i < aid_companias.Count; i++)
            {
                if (Convert.ToInt32(aid_companias[i].ToString()) == compania_id)
                {
                    estado = false;
                }
            }
            return estado;
        }

        public static int carrosPorRanking(string arr, ArrayList list_id_carros)
        {
            string valor_split = arr.Replace(",#", "");
            string[] arr_interno_split = valor_split.Split(',');
            int count = arr_interno_split.Length;
            carros_compuesto = new string[arr_interno_split.Length];
            if (count == 1)
            {
                id_carro_puntero = Convert.ToInt32(list_id_carros[Convert.ToInt32(arr_interno_split[0].ToString())].ToString());
            }
            else
            {
                for (int i = 0; i < arr_interno_split.Length; i++)
                {
                    carros_compuesto[i] = list_id_carros[Convert.ToInt32(arr_interno_split[i].ToString())].ToString();
                }
            }
            return count;
        }

        public static ArrayList despacharGrupo(string carros, string grupo, string recurso, ArrayList list_ranking)
        {
            ArrayList puntero = new ArrayList();
            ArrayList copia = new ArrayList();
            copia = list_ranking;
            int count = list_ranking.Count;
            int[] list_rk_int = new int[count];
            for (int g = 0; g < count; g++)
            {
                list_rk_int[g] = Convert.ToInt32(list_ranking[g].ToString());
            }
            Array.Sort(list_rk_int);
            int bb = count - 1;
            int mayor = list_rk_int[bb];
            int rk = 1;
            string str_i = "";
                while (rk != mayor + 1)
                {
                    for (int i = 0; i <= count - 1; i++)
                    {
                        if (Convert.ToInt32(copia[i].ToString()) == rk)
                        {
                            str_i += i + ",";
                        }
                    }
                    str_i += "#";
                    puntero.Add(str_i);
                    str_i = "";
                    rk++;
                }
            return puntero;
        }

        public static List<int> Despachar(int id_expediente, int id_area)
        {
            // 6
            var sinDespacho = new List<int>();
            var idDespacho = new List<int>();
            var compañias_usadas = new List<int>();
            // tipos de carro
            try
            {
                var exp = new e_expedientes();
                exp = exp.getObjecte_expedientes(id_expediente);
                int codigo_llamado = exp.codigo_llamado;
                // id area

                CantidadCarros cantidad = ObtenerCantidadCarros(id_area, codigo_llamado, out idDespacho);

                OrdenarCarros(cantidad, codigo_llamado);
                for (int i = 0; i < cantidad.Cantidad.GetLength(0); i++)
                {
                    while (cantidad.Cantidad[i] > 0)
                    {
                        // obtener carro
#if CBMS
                        z_carros carro = ObtenerCarro(cantidad.Id_tipo[i], id_area);
#elif CBQN
                        z_carros carro = ObtenerCarro(cantidad.Id_tipo[i], id_area, false, compañias_usadas);
#endif
                        if (carro.id_carro != 0)
                        {
                            idDespacho.Add(carro.id_carro);
                            cantidad.Cantidad[i]--;
                            compañias_usadas.Add(carro.id_compania);
                        }
                        else
                        {
                            sinDespacho.Add(cantidad.Id_tipo[i]);
                            break;
                        }
                    }
                }
                // Ejecutar casos especiales de despacho
                CasosEspecialesDespacho.Ejecutar(exp, idDespacho);
            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
            return idDespacho;
        }



        public static bool ConfirmarDespacho(List<int> id_carro, int id_expediente, int batallon)
        {
            // cambiar clave!
            // obtener codigo llamado batallon
            var llam = new z_llamados();
            DataSet db = llam.Getz_llamados_incendio();
            int codigo_llamado = (int)db.Tables[0].Rows[batallon - 1]["codigo_llamado"];

            var exp = new e_expedientes();
            exp = exp.getObjecte_expedientes(id_expediente);
            // actualizar expediente
            exp.codigo_principal = codigo_llamado;
            exp.batallon = batallon;
            // correlativo
            if (exp.correlativo_iioo == 0)
            {
                exp.correlativo_iioo = exp.GetNextCorrelativoIIOO();
            }
            exp.Update(exp);

            var retValue = ConfirmarDespacho(id_carro, id_expediente, batallon, false);

            return retValue;
        }

        public static bool ConfirmarDespacho(List<int> id_carro, int id_expediente)
        {
            return ConfirmarDespacho(id_carro, id_expediente, 0, false);
        }

        public static bool ConfirmarDespacho(List<int> id_carro, int id_expediente, bool despachandoTodo)
        {
            return ConfirmarDespacho(id_carro, id_expediente, 0, despachandoTodo);
        }

        private static bool ConfirmarDespacho(List<int> id_carro, int id_expediente, int batallon, bool despachandoTodo)
        {
            // verificar restricciones
            if (!CheckRestriccionIncendio(id_expediente) || !CheckRestriccionB(id_expediente, id_carro))
            {
                return false;
            }


            e_expedientes exp = new e_expedientes().getObjecte_expedientes(id_expediente);
            var c = new z_carros();
            var carros = new e_carros_usados();
            string material = "";
            foreach (int id in id_carro)
            {
                if (id == 0)
                    continue;
                // marcar carro!
                carros = carros.getObjecte_carros_usados(id);
                if (carros.id_carro == 0)
                {
                    carros.id_carro = id;
                    carros.id_expediente = id_expediente;
                    carros.seis = "6-0R";
                    carros.Insert(carros);
                }
                else
                {
                    carros.id_expediente = id_expediente;
                    carros.seis = "6-0R";
                    carros.Update(carros);
                }

                // agregar a lista!
                c = c.getObjectz_carros(id);
                material += "," + c.nombre;
            }
            exp.material_despachado = (exp.material_despachado + material).Trim(',');
            material = material.Trim(',');
            exp.Update(exp);

            // agregar información a bitácora
            // verificar si es primer despacho para agregar información de despacho
            if (carros.getCantidad(exp.id_expediente) == 0)
            {
                var llam = new z_llamados();
                llam = llam.getObjectz_llamados(exp.codigo_principal);
                BitacoraLlamado.NuevoEvento(exp.id_expediente, 0, BitacoraLlamado.Llamado,
                                            "LLAMADO: " + llam.clave + " " + llam.descripcion);
                llam = llam.getObjectz_llamados(exp.codigo_llamado);
                BitacoraLlamado.NuevoEvento(exp.id_expediente, 0, BitacoraLlamado.Llamado,
                                            "SUBCLASIFICACION: " + llam.clave + " " + llam.descripcion);
                BitacoraLlamado.NuevoEvento(exp.id_expediente, 0, BitacoraLlamado.Llamado,
                                            "0-5: " + exp.cero5);
            }
            if (batallon >= 1 && batallon <= 4)
            {
#if CBMS
                BitacoraLlamado.NuevoEvento(exp.id_expediente, 0, BitacoraLlamado.Incendio, "Despacho " + batallon + " Batallón Incendio");
#elif CBQN
                BitacoraLlamado.NuevoEvento(exp.id_expediente, 0, BitacoraLlamado.Incendio,
                                            "Despacho Incendio");
#endif
            }
            if (despachandoTodo)
            {
#if CBMS
                BitacoraLlamado.NuevoEvento(exp.id_expediente, 0, BitacoraLlamado.Incendio,
                                            "Despacho 5° Batallón de Incendio");
#elif CBQN
                BitacoraLlamado.NuevoEvento(exp.id_expediente, 0, BitacoraLlamado.Incendio,
                                            "Despacho Alarma General");
#endif
            }

            BitacoraLlamado.NuevoEvento(exp.id_expediente, 0, BitacoraLlamado.Despacho,
                        "CARROS: " + material);

#if CBQN
            // dar 6-0 inmediatamente
            if ((batallon >= 1 && batallon <= 4)||despachandoTodo)
            {

                // registrar 6-0 inmediatamente, sin of. a cargo ni num de vols
                foreach (int i in id_carro)
                {
                    var cen = new CarroEnLlamado(i);
                    cen.Clave6_0(0, 0, null);
                }
            }
#endif

            // avisar
            if (OnDespacho != null)
            {
                OnDespacho(null, new DespachoEventArgs(id_expediente, id_carro));
            }
            return true;
        }

        public static void CancelarDespacho(List<int> id_carro)
        {
            foreach (int id in id_carro)
            {
                Carro.Liberar(id);
            }
        }

        private static bool CheckRestriccionB(int id_expediente, IEnumerable<int> id_carros)
        {
            // 1: Cantidad de carros b
            var exp = new e_expedientes();
            exp = exp.getObjecte_expedientes(id_expediente);
            var llam = new z_llamados();
            llam = llam.getObjectz_llamados(exp.codigo_principal);
            if (llam.max_b == 0)
            {
                return true;
            }

            var carros = new e_carros_usados();
            int cant = 0;
            DataSet ds = carros.Gete_carros_exp(id_expediente);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var c = new z_carros();
                c = c.getObjectz_carros((int)dr["id_carro"]);
                if (c.id_tipo_carro == 1)
                {
                    cant++;
                }
            }

            // carros actuales
            foreach (int id in id_carros)
            {
                var c = new z_carros();
                c = c.getObjectz_carros(id);
                if (c.id_tipo_carro == 1)
                {
                    cant++;
                }
            }

            if (cant > llam.max_b)
            {
                var vb = new VistoBueno
                             {
                                 IdExpediente = id_expediente,
                                 Mensaje = "La cantidad de carros permitida para esta clave ha sido superada."
                             };

                if (vb.ShowDialog() == DialogResult.OK)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        private static bool CheckRestriccionIncendio(int id_expediente)
        {
            var exp = new e_expedientes();
            exp = exp.getObjecte_expedientes(id_expediente);
            var llam = new z_llamados();
            llam = llam.getObjectz_llamados(exp.codigo_principal);

            if (exp.EnIncendio() && llam.rest_incendio)
            {
                var vb = new VistoBueno
                             {
                                 IdExpediente = id_expediente,
                                 Mensaje = "Este despacho requiere autorización de un oficial.",
                                 Text = "Despacho restringido en Incendio"
                             };

                if (vb.ShowDialog() == DialogResult.OK)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        private static void CheckBatallon(int id_expediente, IEnumerable<int> id_carros)
        {
            var exp = new e_expedientes();
            exp = exp.getObjecte_expedientes(id_expediente);
            List<int> s;
            int id_mayor = 0;
            var cu = new e_carros_usados();
            // no hay batallones para áreas
            if (exp.id_area == 0)
            {
                return;
            }
            // revisar si esta combinación de carros+los actuales superan un batallón

            var llam = new z_llamados();
            DataSet ds = llam.Getz_llamados_incendio();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                // cantidad de carros
                CantidadCarros cc = ObtenerCantidadCarros(exp.id_area, (int)dr["codigo_llamado"], out s);
                var ca = new CantidadCarros();
                // sumar
                DataSet de = cu.Gete_carros_exp(id_expediente);
                foreach (DataRow dw in de.Tables[0].Rows)
                {
                    var carro = new z_carros();
                    carro = carro.getObjectz_carros((int)dw["id_carro"]);
                    ca.Cantidad[carro.id_tipo_carro - 1]++;
                }
                // carros actuales
                foreach (int i in id_carros)
                {
                    var carro = new z_carros();
                    carro = carro.getObjectz_carros(i);
                    ca.Cantidad[carro.id_tipo_carro - 1]++;
                }
                // comparar
                if (ca >= cc)
                {
                    id_mayor = (int)dr["codigo_llamado"];
                }
            }
            if (id_mayor != 0)
            {
                // avisar
                MessageBox.Show("Se han superado los carros para un batallón. Se cambiará la clave.");
                // cambiar clave
                exp.codigo_principal = id_mayor;
                exp.Update(exp);
            }
        }

        public static List<int> DespacharBatallon(int id_expediente, int id_area, int batallon, out string sindesp)
        {
            // 6
            var sinDespacho = new List<int>();
            var idDespacho = new List<int>();
            var companias = new List<int>();
            var R = new List<int>();
            var cu = new e_carros_usados();
            sindesp = "";

            // tipos de carro
            try
            {
                // obtener codigo llamado batallon
                var llam = new z_llamados();
                DataSet db = llam.Getz_llamados_incendio();
                int codigo_llamado = (int)db.Tables[0].Rows[batallon - 1]["codigo_llamado"];

                CantidadCarros cantidad = ObtenerCantidadCarros(id_area, codigo_llamado, out idDespacho);
                // cantidad de carros
                var actual = new CantidadCarros();
                // sumar
                DataSet de = cu.Gete_carros_exp(id_expediente);
                foreach (DataRow dw in de.Tables[0].Rows)
                {
                    var carro = new z_carros();
                    carro = carro.getObjectz_carros((int)dw["id_carro"]);
                    actual.Cantidad[carro.id_tipo_carro - 1]++;
                }
                // restar carros actuales
                cantidad = cantidad - actual;

                OrdenarCarros(cantidad, codigo_llamado);
                for (int i = 0; i < cantidad.Cantidad.GetLength(0); i++)
                {
                    while (cantidad.Cantidad[i] > 0)
                    {
                        // obtener carro verificando 0-11
                        z_carros carro = batallon > 2 ? ObtenerCarro(cantidad.Id_tipo[i], id_area, true) : ObtenerCarro(cantidad.Id_tipo[i], id_area);

                        if (carro.id_carro != 0)
                        {
                            // es r?
                            if (carro.id_tipo_carro == 7)
                            {
                                R.Add(carro.id_carro);
                            }
                            else
                            {
                                if (!companias.Contains(carro.id_compania))
                                {
                                    companias.Add(carro.id_compania);
                                }
                            }
                            idDespacho.Add(carro.id_carro);
                            // disminuir
                            cantidad.Cantidad[i]--;
                        }
                        else
                        {
                            sinDespacho.Add(cantidad.Id_tipo[i]);
                            break;
                        }
                    }
                }

                for (int i = 0; i < cantidad.Id_tipo.Length; i++)
                {
                    if (cantidad.Cantidad[i] != 0)
                    {
                        z_tipo_carro tipo = new z_tipo_carro().getObjectz_tipo_carro(cantidad.Id_tipo[i]);

                        //sindesp += tipo.tipo_carro_letra + ": " + cantidad.Cantidad[i] + "; ";
                        sindesp += cantidad.Cantidad[i] + " " + tipo.tipo_carro_letra + "; ";
                    }
                }
            }
            catch (Exception e)
            {
                Log.Write(e);
                MessageBox.Show("No se pudo completar la operación debido a un error de Base de Datos.",
                                "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // verificar r en compañia
            var c = new z_carros();
            int sinR = 0;
            foreach (int id in R)
            {
                bool encompania = false;
                c = c.getObjectz_carros(id);
                foreach (int comp in companias)
                {
                    if (comp == c.id_compania)
                    {
                        encompania = true;
                    }
                }
                if (!encompania)
                {
                    // liberar carro
                    var l = new List<int> { id };
                    CancelarDespacho(l);
                    idDespacho.Remove(id);
                    sinR++;
                }
            }
            if (sinR != 0)
            {
                sindesp += sinR + " R";
            }
            return idDespacho;
        }

        public static List<int> DespacharTodo()
        {
            var carros = new List<int>();
            DataSet ds = new z_carros().Getz_carrosDisponibles();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                carros.Add((int)dr["id_carro"]);
            }
            return carros;
        }

        public static z_carros BuscarCubrirCuartel(int id_area, out int id_compania)
        {
            var carro = new z_carros();
            DataSet ds = new z_prioridad().Getz_prioridad(id_area);
            // buscar en prioridades 10 y 9
            int primera_prioridad = (int)ds.Tables[0].Rows[0]["despacho_b"];
            for (int i = 9; i > 7; i--)
            {
                // obtener bombas
                DataSet carros = carro.GetCarrosCompania(1, (int)ds.Tables[0].Rows[i]["despacho_b"]);
                foreach (DataRow dr in carros.Tables[0].Rows)
                {
                    carro = carro.getObjectz_carros((int)dr["id_carro"]);
                    if (carro.id_carro != 0 && Carro.EstaDisponible(carro))
                    {
                        id_compania = primera_prioridad;
                        return carro;
                    }
                }
            }
            id_compania = 0;
            return new z_carros();
        }

        public static void DespachoGestion(int id_carro, bool en_servicio, int id_expediente, string clave, string[] coor_carros)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            if (en_servicio)
            {
                Carro.DisponibleEnActo(carro);
            }
            else
            {
                Carro.FueraServicio(carro, clave);
            }

            Conductor.FueraServicio(carro.id_conductor, carro.id_carro);

            e_carros_usados ec = new e_carros_usados().getObjecte_carros_usados(id_carro);
            ec.id_expediente = id_expediente;
            ec.seis = en_servicio ? "0-9" : "0-8";
            if (ec.id_carro != 0)
            {
                ec.Update(ec);
            }
            else
            {
                ec.id_carro = id_carro;
                ec.Insert(ec);
            }

            // ****** CODIGO AGREGADO POR MARCOS PONCE

            // ***************************************
            if (carro.asignarCoordenadasGestionDestino(coor_carros, id_carro) == 0)
            {
                MessageBox.Show("No fue posible asignar las coordenadas de gestion al carro!!","error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //DBNotifyListeners.Notify("despacho");
        }
    }
}
