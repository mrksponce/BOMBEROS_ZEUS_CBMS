using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util.Forms;
using System.Collections;
//using Tamir.SharpSsh;
using System.IO;


namespace Zeus.Util
{
    public static class Despacho
    {
        public static event EventHandler<DespachoEventArgs> OnDespacho;
        public static int id_carro_puntero = 0;
        public static string[] carros_compuesto = null;
        public static ArrayList companias_a_despachar = new ArrayList();
        public static System.Timers.Timer tiempo = new System.Timers.Timer();
        public static bool estadoDemonio = true;
        public static bool estadoTiempoTranscurrido = false;
        
        
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
                string aa = "asdfasdf";
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
                    // Crear el Objeto Carro Según su ID
                    carro = carro.getObjectz_carros((int)Row["id_carro"]);

                    // verificar cubrir cuarteles   PARAMETRO BOOLEANO DE LA FUNCION
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



        public static List<int> ranking(int id_expediente, int id_area, int bloque)
        {
            e_expedientes expediente = new e_expedientes();
            z_carros zcarros = new z_carros();
            z_orden zorden = new z_orden();
            ArrayList puntero_final = new ArrayList();
            ArrayList lista_carros = new ArrayList();
            ArrayList list_ranking = new ArrayList();
            ArrayList array_final = new ArrayList();
            ArrayList CiasDespachadas = new ArrayList();
            ArrayList funcion_u_chile = new ArrayList();
            ArrayList CoordenadasDeGrupos = new ArrayList();
            ArrayList n_carros_x_grupo = new ArrayList();
            ArrayList Rkg = new ArrayList();
            string[] carros_in = null;
            x_grupo_alias xgrupoalias = new x_grupo_alias();

            List<int> envioFinalCarros = new List<int>();

            //int cant_carros = 0;
            int j = 0;
            int p = 0;
            try
            {
                // Inicializa el Objeto Expediente
                expediente = expediente.getObjecte_expedientes(id_expediente);

                // Asigna código distinto a la Pauta, si el llamado es en un Área específica
                // -Condidera RH16 y RH19 para 10-3 y 10-4 en Áreas Periféricas. 
                int CodigoLlamadoFinal = expediente.CambioCodigoLlamadoExpediente(expediente.codigo_llamado, id_area);

                // Obtiene el Grupo de Área Periferica, Si no es periferica, corresponde valor 1;
                int grupo_area = zcarros.obtenerCodigoArea(expediente.id_area);

                // Obtiene el valor booleano "comp_ga_tipo" de x_despacho_habil;
                bool EvGpAr = zcarros.EvaluaGrupoArea(CodigoLlamadoFinal);

                // Asigna los valores X e Y del Objeto Expediente.
                string punto_x = expediente.puntoX.ToString();
                string punto_y = expediente.puntoY.ToString();

                //* carros_in es el arreglo que contiene los Grupos a Despachar.
                //* carros_in Contiene el complemento si ya se ha despachado otra Clave
                //* Contar Carros Despachados en este Expediente.

                if (zcarros.existenciaZcarrosParaEsteExpediente(id_expediente) == 0)
                {
                    carros_in = expediente.recuperarDespachoHabil(CodigoLlamadoFinal);
                }
                else
                {
                    string[] GruposEnNuevaClave = expediente.recuperarDespachoHabil(CodigoLlamadoFinal);
                    carros_in = generarCarrosIncencio(GruposEnNuevaClave, id_expediente);
                }

                
                //### Establecer si sedebe aplicar un Orden_Grupo_Distinto
                int IdDistinto = zorden.xOrdenGrupoDistinto(CodigoLlamadoFinal, expediente.id_area);


                //* alist_orden_grupo: Listado del orden en que se deben despachar los grupos según codigo_llamado.
                ArrayList alist_orden_grupo = zorden.xOrdenGrupo(CodigoLlamadoFinal, IdDistinto);
                //* Grupos a Despachar
                ArrayList alist_GrupoDespacho = zorden.xGruposDespachoHabil(CodigoLlamadoFinal);
                //* Lista de Listas: Id_Carros, coordenada_x, coordenada_y, Id_Compañia, Ranking 
                ArrayList[] array_lista_carros = new ArrayList[5];
                int[] posicion = new int[carros_in.Length];

                //* Ordena los grupos según el orden correspondiente
                for (int a = 0; a < carros_in.Length; a++)
                {
                    string strG = alist_orden_grupo[a].ToString();
                    for (int i = 0; i < carros_in.Length; i++)
                    {
                        if (strG == alist_GrupoDespacho[i].ToString())
                        {
                            posicion[p] = j;
                            p++;
                        }
                        j++;
                    }
                    j = 0;
                }
                //Array.Sort(posicion);
                int[] orden_final = new int[posicion.Length];

                for (int c = 0; c < posicion.Length; c++)
                {
                    int valor_posicion_array = Convert.ToInt32(posicion[c].ToString());
                    orden_final[c] = Convert.ToInt32(alist_orden_grupo[valor_posicion_array].ToString());
                }

          


                //# Diccionario de Despacho Por Pauta
                object[] objDiccionario = zcarros.GenerarDiccionario(CodigoLlamadoFinal);
                Dictionary<int, int> DicGrupReem = new Dictionary<int, int>();
                Dictionary<int, string> DicGrupo = new Dictionary<int, string>();
                Dictionary<int, string> DicRecurso = new Dictionary<int, string>();
                Dictionary<int, bool> DicPauta = new Dictionary<int, bool>();
                Dictionary<int, bool> DicReemplazo = new Dictionary<int, bool>();
                Dictionary<int, string> DicGrupoReemplazo = new Dictionary<int, string>();

                DicGrupo = (Dictionary<int, string>)objDiccionario[0];
                DicRecurso = (Dictionary<int, string>)objDiccionario[1];
                DicPauta = (Dictionary<int, bool>)objDiccionario[2];
                DicReemplazo = (Dictionary<int, bool>)objDiccionario[3];
                DicGrupoReemplazo = (Dictionary<int, string>)objDiccionario[4];


                // ######################
                // ### For de Proceso ###
                // ######################
                int grupoOriginal = 0;
                for (int f = 0; f < orden_final.Length; f++)
                {
                    //posicion
                    int int_ordenfinal = posicion[f];
                    string[] group = carros_in[int_ordenfinal].Split('/');
                    int int_r = Convert.ToInt32(group[2].ToString());

                    // Selecciona los carros del Grupo N utilizando Alias de Grupo
                    // Para cada Carro Virtual, recupera: Id_Carro, Coordenadas, Compañía y Ranking

                    int intAlias = xgrupoalias.GetAliasGrupo(group[1]);

                    array_lista_carros = zcarros.obtenerCarrosVirtual(group[1], id_area, intAlias);

                    //cant_carros = lista_carros.Count;
                    ArrayList list_id_carros = new ArrayList();
                    ArrayList list_carro_x = new ArrayList();
                    ArrayList list_carro_y = new ArrayList();
                    ArrayList list_compania = new ArrayList();
                    ArrayList list_rkn = new ArrayList();
                    ArrayList list_carros_despacho = new ArrayList();

                    list_id_carros = array_lista_carros[0];
                    list_carro_x = array_lista_carros[1];
                    list_carro_y = array_lista_carros[2];
                    list_compania = array_lista_carros[3];
                    list_rkn = array_lista_carros[4];

                    // -*- Buscar Reemplazo
                    //# Si, el Grupo esta en la Pauta y Tiene Reemplazo
                    if (DicPauta[Convert.ToInt32(group[1].ToString())])
                    {
                        if (DicPauta[Convert.ToInt32(group[1].ToString())] && DicReemplazo[Convert.ToInt32(group[1].ToString())])
                        {
                            // Crear Log.txt
                            //int intValor3 = EscribeLog(id_expediente.ToString(), group[1].ToString(), list_ranking, list_id_carros, list_compania);

                            // Selecciona Carros del Grupo N
                            puntero_final = despacharGrupo(list_rkn);

                            string ret_final = ordenArreglo(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_rkn, group[0], group[1], group[2], CodigoLlamadoFinal, list_compania, grupo_area, EvGpAr, false, id_expediente, grupoOriginal);
                            //array_final.Add(ret_final);
                            if (ret_final == "#")
                            {
                                string Gp_Reem = DicGrupoReemplazo[Convert.ToInt32(group[1].ToString())];
                                DicPauta[Convert.ToInt32(Gp_Reem)] = true;
                                if (grupoOriginal == 0)
                                {
                                    grupoOriginal = Convert.ToInt32(group[1].ToString());
                                }
                                //MessageBox.Show("No hay carros de este grupo", "GEObit ...");
                            }
                            else
                            {
                                array_final.Add(ret_final);
                            }
                        }
                        else
                        {
                            //# El Grupo esta en la Pauta y No Tiene Reemplazo
                            // Crear Log.txt
                            //int intValor3 = EscribeLog(id_expediente.ToString(), group[1].ToString(), list_ranking, list_id_carros, list_compania);

                            // Selecciona Carros del Grupo N
                            puntero_final = despacharGrupo(list_rkn);
                            string ret_final = ordenArreglo(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_rkn, group[0], group[1], group[2], CodigoLlamadoFinal, list_compania, grupo_area, EvGpAr, false, id_expediente, grupoOriginal);
                            array_final.Add(ret_final);
                        }
                    }
                }
                int count = array_final.Count;
                ArrayList aa_empty = new ArrayList();
                companias_a_despachar = aa_empty;


                for (int w = 0; w < array_final.Count; w++)
                {
                    string val1 = array_final[w].ToString().Replace(",#", "");
                    if (val1 != "#")
                    {
                        string[] val2 = val1.Split(',');
                        for (int m = 0; m < val2.Length; m++)
                        {
                            envioFinalCarros.Add(Convert.ToInt32(val2[m].ToString()));
                        }
                    }
                }
            }
            catch (Exception exe)
            {

            }

            return envioFinalCarros;
        }



        static void tiempo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            estadoTiempoTranscurrido = true;
            tiempo.Enabled = false;
        }




        public static List<int> rakingParaIncendio(int id_expediente, int id_area, int bloque, int codigoIncencio)
        {
            e_expedientes expediente = new e_expedientes();
            z_carros zcarros = new z_carros();
            z_orden zorden = new z_orden();
            ArrayList puntero_final = new ArrayList();
            ArrayList lista_carros = new ArrayList();
            ArrayList list_ranking = new ArrayList();
            ArrayList array_final = new ArrayList();
            ArrayList CiasDespachadas = new ArrayList();
            ArrayList funcion_u_chile = new ArrayList();
            ArrayList CoordenadasDeGrupos = new ArrayList();
            ArrayList n_carros_x_grupo = new ArrayList();
            ArrayList Rkg = new ArrayList();
            x_grupo_alias xgrupoalias = new x_grupo_alias();

            List<int> envioFinalCarros = new List<int>();

            int j = 0;
            int p = 0;
            try
            {
                // Inicializa el Objeto Expediente
                expediente = expediente.getObjecte_expedientes(id_expediente);

                // Obtiene el Grupo de Área Periferica, Si no es periferica, corresponde valor 1;
                int grupo_area = zcarros.obtenerCodigoArea(expediente.id_area);

                // Obtiene el valor booleano "comp_ga_tipo" de x_despacho_habil;
                bool EvGpAr = zcarros.EvaluaGrupoArea(expediente.codigo_llamado);

                // Asigna los valores X e Y del Objeto Expediente.
                string punto_x = expediente.puntoX.ToString();
                string punto_y = expediente.puntoY.ToString();

                //* carros_in es el arreglo que contiene los Grupos a Despachar.
                //* carros_in Contiene el complemento si ya se ha despachado otra Clave
                //* Contar Carros Despachados en este Expediente.
                string[] carros_incendio = expediente.recuperarDespachoHabil(codigoIncencio);
                string[] carros_in = generarCarrosParaIncendio(carros_incendio, id_expediente, codigoIncencio);
                
                //* alist_orden_grupo: Listado del orden en que se deben despachar los grupos según codigo_llamado.
                ArrayList alist_orden_grupo = zorden.xOrdenGrupo(codigoIncencio, 0);
                
                //* Grupos a Despachar
                ArrayList alist_GrupoDespacho = zorden.xGruposDespachoHabil(codigoIncencio);
                
                //* Lista de Listas: Id_Carros, coordenada_x, coordenada_y, Id_Compañia, Ranking 
                ArrayList[] array_lista_carros = new ArrayList[5];
                int[] posicion = new int[carros_in.Length];

                //* Ordena los grupos según el orden correspondiente
                for (int a = 0; a < carros_in.Length; a++)
                {
                    string strG = alist_orden_grupo[a].ToString();
                    for (int i = 0; i < carros_in.Length; i++)
                    {
                        //if (rec_grupo[1].ToString() == alist_orden_grupo[i].ToString())
                        if (strG == alist_GrupoDespacho[i].ToString())
                        {
                            posicion[p] = j;
                            p++;
                        }
                        j++;
                    }
                    j = 0;
                }
                int[] orden_final = new int[posicion.Length];

                for (int c = 0; c < posicion.Length; c++)
                {
                    int valor_posicion_array = Convert.ToInt32(posicion[c].ToString());
                    orden_final[c] = Convert.ToInt32(alist_orden_grupo[valor_posicion_array].ToString());
                }



                //// ### For Ranking General
                //int UltimoCount = 0;
                //for (int f = 0; f < orden_final.Length; f++)
                //{
                //    //posicion
                //    int int_ordenfinal = posicion[f];
                //    string[] groupS = carros_in[f].Split('/');

                //    // Obtiene Ranking Según el Respectivo Grupo
                //    funcion_u_chile = zcarros.obtenerRankingUchile(groupS[1], CoordenadasDeGrupos);
                //    if (n_carros_x_grupo.Count == 0)
                //    {
                //        n_carros_x_grupo.Add(funcion_u_chile.Count);
                //        UltimoCount = funcion_u_chile.Count;
                //    }
                //    else
                //    {
                //        n_carros_x_grupo.Add(funcion_u_chile.Count - UltimoCount);
                //        UltimoCount = funcion_u_chile.Count;
                //    }
                //}


                //// ### Crear Parametros.txt
                //string strBloque = Convert.ToString(bloque);
                //string n_carros = funcion_u_chile.Count.ToString();
                //int intValor = EscribeParametros(punto_x.Replace(",", "."), punto_y.Replace(",", "."), strBloque, n_carros);
                //int intValor_Log = EscribeParametros_Log(id_expediente.ToString(), punto_x.Replace(",", "."), punto_y.Replace(",", "."), strBloque, n_carros);


                //// ### Crear Carros.txt
                //int intValor2 = EscribeCarros(funcion_u_chile);
                //int intValor2_Log = EscribeCarros_Log(id_expediente.ToString(), funcion_u_chile);
                

                //// ### Ejecutar Aviso.exe
                //System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                //proceso.StartInfo.FileName = @"C:\comander\minPathWin32_zeus01.exe - Acceso directo";
                //proceso.Start();
                //proceso.WaitForExit();
                
                
                // ZONA DE IMPLEMENTACIÓN DEL DEMONIO

                //estadoDemonio = true;
                //estadoTiempoTranscurrido = false;
                //tiempo.Elapsed += new System.Timers.ElapsedEventHandler(tiempo_Elapsed);
                //tiempo.Interval = 10000;
                //tiempo.Enabled = true;

                //while (estadoDemonio)
                //{
                //    if (File.Exists(@"C:\comander\ranking.txt"))
                //    {
                //        estadoDemonio = false;
                //    }

                //    if (estadoTiempoTranscurrido == true)
                //    {
                //        estadoTiempoTranscurrido = false;
                //        estadoTiempoTranscurrido = true;
                //        List<int> listEmptyInt = new List<int>();
                //        return listEmptyInt;
                //    }
                //}

                ////estadoDemonio = true;
                //estadoTiempoTranscurrido = false;
                //tiempo.Enabled = false;

                //// FIN DEL CODIGO DEMONIO VERIFICADOR 

                //// ### Leer Ranking General
                //Rkg = LeeRankingGeneral();


                //// ### Verificar si el resultado corresponde a un Ranking.
                //bool SuspendeDespacho = true;
                //foreach (string r in Rkg)
                //{
                //    if (r != "1")
                //    {
                //        SuspendeDespacho = false;
                //    }
                //}
                //if (SuspendeDespacho && codigoIncencio != 90)
                //{
                //    MessageBox.Show("El Sistema Commander no tiene resultado para esta intersección..", "Atención!!!");
                //    MessageBox.Show("Debe ingresar otra intersección más proxima..", "Atención!!!");
                //    string Alexy = "A24";
                //    Convert.ToInt32(Alexy);
                //}




                // ### Crear Arreglo de Arreglo
                //ArrayList BloquesTem = new ArrayList();   // # ArrayList Temporal
                //BloquesTem = n_carros_x_grupo;

                //int[][] RankingXgrupo = new int[BloquesTem.Count][];
                //int[][] RankingXgrupoSort = new int[BloquesTem.Count][];
                //int[][] RkBlq = new int[BloquesTem.Count][];
                //for (int m = 0; m < BloquesTem.Count; m++)
                //{
                //    int ArLong = Convert.ToInt32(BloquesTem[m]);
                //    RankingXgrupo[m] = new int[ArLong];
                //    RankingXgrupoSort[m] = new int[ArLong];
                //    RkBlq[m] = new int[ArLong];
                //}

                // Agregar Ranking a los arreglos
                //int x = 0;
                //for (int b = 0; b < BloquesTem.Count; b++)
                //{
                //    int Elementos = Convert.ToInt32(BloquesTem[b]);
                //    for (int i = 0; i < Elementos; i++)
                //    {
                //        int rr = Convert.ToInt32(Rkg[x]);
                //        RankingXgrupo[b][i] = rr;
                //        RankingXgrupoSort[b][i] = rr;
                //        x++;
                //    }
                //}


                // Ordenar por Grupos
                //for (int m = 0; m < BloquesTem.Count; m++)
                //{
                //    Array.Sort(RankingXgrupoSort[m]);
                //}


                // Crear Ranking Correlativo por Bloque
                //for (int b = 0; b < BloquesTem.Count; b++)
                //{
                //    // Crea Lista No Correlativa
                //    ArrayList ListRKn = new ArrayList();
                //    ArrayList ListRKnOk = new ArrayList();
                //    for (int s = 0; s < RankingXgrupoSort[b].Length; s++)
                //    {
                //        ListRKn.Add(RankingXgrupoSort[b][s]);
                //    }
                //    // Crear Lista Correlativa
                //    ListRKnOk = zcarros.CorrigeRanking(ListRKn);

                //    // Asigna Ranking de Bloque
                //    for (int k = 0; k < RankingXgrupo[b].Length; k++)
                //    {
                //        int v_RKg = RankingXgrupo[b][k];
                //        for (int w = 0; w < RankingXgrupoSort[b].Length; w++)
                //        {
                //            //int v_RKgSort = RankingXgrupoSort[b][w];
                //            if (v_RKg == RankingXgrupoSort[b][w])
                //            {
                //                RkBlq[b][k] = (int)ListRKnOk[w];
                //            }
                //        }
                //    }
                //}



                //# Diccionario de Despacho Por Pauta
                object[] objDiccionario = zcarros.GenerarDiccionario(codigoIncencio);
                Dictionary<int, int> DicGrupReem = new Dictionary<int, int>();
                Dictionary<int, string> DicGrupo = new Dictionary<int, string>();
                Dictionary<int, string> DicRecurso = new Dictionary<int, string>();
                Dictionary<int, bool> DicPauta = new Dictionary<int, bool>();
                Dictionary<int, bool> DicReemplazo = new Dictionary<int, bool>();
                Dictionary<int, string> DicGrupoReemplazo = new Dictionary<int, string>();

                DicGrupo = (Dictionary<int, string>)objDiccionario[0];
                DicRecurso = (Dictionary<int, string>)objDiccionario[1];
                DicPauta = (Dictionary<int, bool>)objDiccionario[2];
                DicReemplazo = (Dictionary<int, bool>)objDiccionario[3];
                DicGrupoReemplazo = (Dictionary<int, string>)objDiccionario[4];



                // ##################################
                // ### For de Proceso de Incendio ###
                // ##################################                
                int grupoOriginal = 0;
                for (int f = 0; f < orden_final.Length; f++)
                {
                    //posicion
                    int int_ordenfinal = posicion[f];
                    string[] group = carros_in[int_ordenfinal].Split('/');
                    int int_r = Convert.ToInt32(group[2].ToString());

                    // Selecciona los carros del Grupo N utilizando Alias de Grupo
                    // Para cada Carro Virtual, recupera: Id_Carro, Coordenadas, Compañía y Ranking
                    int intAlias = xgrupoalias.GetAliasGrupo(group[1]);
                    array_lista_carros = zcarros.obtenerCarrosVirtual_Incendio(group[1], id_area, intAlias);

                    //// Obtiene Ranking Según el Respectivo Grupo
                    //ArrayList ArrayToList = new ArrayList();
                    //int n_bloque = Convert.ToInt32(group[1].ToString());
                    //for (int rl = 0; rl < RkBlq[int_ordenfinal].Length; rl++)
                    //{
                    //    //ArrayToList.Add(RkBlq[n_bloque][rl]);
                    //    ArrayToList.Add(RkBlq[int_ordenfinal][rl]);
                    //}
                    //funcion_u_chile = ArrayToList;

                    ArrayList list_id_carros = new ArrayList();
                    ArrayList list_carro_x = new ArrayList();
                    ArrayList list_carro_y = new ArrayList();
                    ArrayList list_compania = new ArrayList();
                    ArrayList list_rkn = new ArrayList();
                    ArrayList list_carros_despacho = new ArrayList();

                    list_id_carros = array_lista_carros[0];
                    list_carro_x = array_lista_carros[1];
                    list_carro_y = array_lista_carros[2];
                    list_compania = array_lista_carros[3];
                    list_rkn = array_lista_carros[4];


                    // -*- Buscar Reemplazo
                    //# Si el Grupo esta en la Pauta y Tiene Reemplazo
                    if (DicPauta[Convert.ToInt32(group[1].ToString())])
                    {
                        if (DicPauta[Convert.ToInt32(group[1].ToString())] && DicReemplazo[Convert.ToInt32(group[1].ToString())])
                        {
                            // Crear Log.txt
                            //int intValor3 = EscribeLog(id_expediente.ToString(), group[1].ToString(), list_ranking, list_id_carros, list_compania);
                            
                            //# Selecciona Carros del Grupo N [codigoIncencio = 90 Es Material de Comandancia]
                            if (codigoIncencio == 90)
                            {
                                //# Despacho de Comandancia en Alarma de Incendio
                                puntero_final = despacharGrupo_Comandancia(list_rkn);
                            }
                            else
                            {
                                //# Despacho de Grupo N en Alarma de Incendio
                                puntero_final = despacharGrupo(list_rkn);
                            }
                            string ret_final = ordenArregloIncendio(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_rkn, group[0], group[1], group[2], codigoIncencio, list_compania, grupo_area, EvGpAr, false, expediente.id_expediente);
                            //array_final.Add(ret_final);
                            if (ret_final == "#")
                            {
                                string Gp_Reem = DicGrupoReemplazo[Convert.ToInt32(group[1].ToString())];
                                DicPauta[Convert.ToInt32(Gp_Reem)] = true;
                                if (grupoOriginal == 0)
                                {
                                    grupoOriginal = Convert.ToInt32(group[1].ToString());
                                }
                                //MessageBox.Show("No hay carros de este grupo", "GEObit ...");
                            }
                            else
                            {
                                array_final.Add(ret_final);
                            }
                        }
                        else
                        {
                            //# El Grupo esta en la Pauta y No Tiene Reemplazo
                            // Crear Log.txt
                            //int intValor3 = EscribeLog(id_expediente.ToString(), group[1].ToString(), list_ranking, list_id_carros, list_compania);

                            //# Selecciona Carros del Grupo N [codigoIncencio = 90 Es Material de Comandancia]
                            if (codigoIncencio == 90)
                            {
                                //# Despacho de Comandancia en Alarma de Incendio
                                puntero_final = despacharGrupo_Comandancia(list_rkn);
                            }
                            else
                            {
                                //# Despacho de Grupo N en Alarma de Incendio
                                puntero_final = despacharGrupo(list_rkn);
                            }
                            string ret_final = ordenArregloIncendio(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_rkn, group[0], group[1], group[2], codigoIncencio, list_compania, grupo_area, EvGpAr, false, expediente.id_expediente);
                            array_final.Add(ret_final);
                        }
                    }
                }
                int count = array_final.Count;
                ArrayList aa_empty = new ArrayList();
                companias_a_despachar = aa_empty;

                for (int w = 0; w < array_final.Count; w++)
                {
                    string val1 = array_final[w].ToString().Replace(",#", "");
                    if (val1 != "#")
                    {
                        string[] val2 = val1.Split(',');
                        for (int m = 0; m < val2.Length; m++)
                        {
                            envioFinalCarros.Add(Convert.ToInt32(val2[m].ToString()));
                        }
                    }
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }

            return envioFinalCarros;
        }


        public static bool EsCascada(int IfCascada)
        {
            return IfCascada == 20 || IfCascada == 21 || IfCascada == 22;
        }

        public static bool EsMMX(int IfMMX)
        {
            return IfMMX == 19;
        }

        //# La Alarma De Incendio es >= 3ra. Alarma
        public static bool Desde3raAlarma(int CodAlarma)
        {
            return CodAlarma == 52 || CodAlarma == 53 || CodAlarma == 54 || CodAlarma == 55 || CodAlarma == 56;
        }

        public static string[] generarCarrosIncencio(string[] carros_incendio, int id_expediente)
        {
            string[] final_carrosin = null;
            e_expedientes expediente = new e_expedientes();
            string str_carrosin = "";
            final_carrosin = new string[carros_incendio.Length];
            try
            {
                // Para cada grupo que se debe despachar
                for (int i = 0; i < carros_incendio.Length; i++)
                {
                    string valor_arreglo = carros_incendio[i].ToString();
                    string[] carros_incendio_split = valor_arreglo.Split('/');

                    int IntGp = Convert.ToInt32(carros_incendio_split[1].ToString());
                    int IntGpOriginal = Convert.ToInt32(carros_incendio_split[1].ToString());

                    //Gb Comodin de Cascada
                    if (EsCascada(IntGp) == true)
                    {
                        IntGp = 12;
                    }

                    //Gb Comodin de MMX
                    if (EsMMX(IntGp) == true)
                    {
                        IntGp = 3;
                    }
                    
                    int ccarros_despachados = expediente.countRegistroZcarrosLlamado(id_expediente, IntGp);
                    int residuo = Convert.ToInt32(carros_incendio_split[2].ToString()) - ccarros_despachados;

                    //# Obtener ID de Carro Cascada
                    int IdCascada = 0;
                  
                    if (IntGp == 12)
                    {
                        IdCascada = expediente.IdCarroDespachado(id_expediente, IntGp);
                    }

                    //# Determinar Recurso que falta para la alarma seleccionada
                    if (residuo > 0)
                    {
                        int positivo = Math.Abs(residuo);
                        if (positivo > 0)
                        {
                            final_carrosin[i] = carros_incendio_split[0].ToString() + "/" + carros_incendio_split[1].ToString() + "/" + positivo;
                        }
                    }
                    else
                    {
                        final_carrosin[i] = carros_incendio_split[0].ToString() + "/" + carros_incendio_split[1].ToString() + "/0";
                    }
                }
            }
            catch (Exception exe)
            { 
                
            }
            return final_carrosin;
        }


        //### Obtener Carros_IN Complemento de Incendio
        public static string[] generarCarrosParaIncendio(string[] carros_incendio, int id_expediente, int CodigoDeIncendio)
        {
            string[] final_carrosin = null;
            e_expedientes expediente = new e_expedientes();
            string str_carrosin = "";
            final_carrosin = new string[carros_incendio.Length];
            try
            {
                // Para cada grupo que se debe despachar
                for (int i = 0; i < carros_incendio.Length; i++)
                {
                    string valor_arreglo = carros_incendio[i].ToString();
                    string[] carros_incendio_split = valor_arreglo.Split('/');

                    int IntGp = Convert.ToInt32(carros_incendio_split[1].ToString());
                    int IntGpOriginal = Convert.ToInt32(carros_incendio_split[1].ToString());

                    //Gb Comodin de Cascada
                    if (EsCascada(IntGp) == true)
                    {
                        IntGp = 12;
                    }

                    //Gb Comodin de MMX
                    if (EsMMX(IntGp) == true)
                    {
                        IntGp = 3;
                    }

                    int ccarros_despachados = expediente.countRegistroZcarrosLlamado(id_expediente, IntGp);
                    int residuo = Convert.ToInt32(carros_incendio_split[2].ToString()) - ccarros_despachados;

                    //# Obtener ID de Carro Cascada
                    int IdCascada = 0;
                    if (IntGp == 12)
                    {
                        IdCascada = expediente.IdCarroDespachado(id_expediente, IntGp);
                    }

                    //# Omitir Despacho de Cascada a partir de 3ra Alarma Sí H17 ya se ha despachado
                    if (IntGp == 12 && IdCascada == 36 && Desde3raAlarma(CodigoDeIncendio))
                    {
                        final_carrosin[i] = carros_incendio_split[0].ToString() + "/" + carros_incendio_split[1].ToString() + "/0";
                    }
                    else
                    {
                        //# Determinar Recurso que falta para la alarma seleccionada
                        if (residuo > 0)
                        {
                            int positivo = Math.Abs(residuo);
                            if (positivo > 0)
                            {
                                final_carrosin[i] = carros_incendio_split[0].ToString() + "/" + carros_incendio_split[1].ToString() + "/" + positivo;
                            }
                        }
                        else
                        {
                            final_carrosin[i] = carros_incendio_split[0].ToString() + "/" + carros_incendio_split[1].ToString() + "/0";
                        }
                    }

                }
            }
            catch (Exception exe)
            {

            }
            return final_carrosin;
        }


        public static string[] CompletarDespachoDeOtraClave(string[] carros_incendio, int id_expediente)
        {
            string[] final_carrosin = null;
            e_expedientes expediente = new e_expedientes();
            string str_carrosin = "";
            final_carrosin = new string[carros_incendio.Length];
            try
            {
                for (int i = 0; i < carros_incendio.Length; i++)
                {
                    string valor_arreglo = carros_incendio[i].ToString();
                    string[] carros_incendio_split = valor_arreglo.Split('/');
                    int ccarros_despachados = expediente.countRegistroZcarrosLlamado(id_expediente, Convert.ToInt32(carros_incendio_split[1].ToString()));
                    int residuo = Convert.ToInt32(carros_incendio_split[2].ToString()) - ccarros_despachados;
                    if (residuo > 0)
                    {
                        int positivo = Math.Abs(residuo);
                        if (positivo > 0)
                        {
                            final_carrosin[i] = carros_incendio_split[0].ToString() + "/" + carros_incendio_split[1].ToString() + "/" + positivo;
                        }
                    }
                    else
                    {
                        final_carrosin[i] = carros_incendio_split[0].ToString() + "/" + carros_incendio_split[1].ToString() + "/0";
                    }
                }
            }
            catch (Exception exe)
            {

            }
            return final_carrosin;
        }



        public static string ordenArreglo(ArrayList puntero_final, ArrayList list_id_carros, ArrayList list_carro_x, ArrayList list_carro_y, ArrayList list_compania, ArrayList list_ranking, string idcarros, string idgrupos, string recu, int cod_llamado, ArrayList list_comp, int grupo_area, bool Ev_Gp_Ar, bool Desp_X_Clave, int id_expediente, int grupoOriginal)
        {
            List<int> despGrupo = new List<int>();
            var ccarros = new z_carros();
            var cczorden = new z_orden();
            string[] arr = new string[puntero_final.Count];
            string[] arr_split = new string[puntero_final.Count];
            string[] arr_uso = new string[puntero_final.Count];
            int r = Convert.ToInt32(recu);
            string valores_finales_retorno = "";
            bool uno_x_cia = ccarros.ValidacionUnoPorCompania(cod_llamado, Convert.ToInt32(idgrupos));

            bool esReemplazo = false;
            bool boolDisponible;
            List<int> Arr_ID = new List<int>();

            // Obtiene Cia del Area Periferica, Si no es Periferica el Area la Cia es 0
            int CiaDelAreaPeriferica = 0;   //ObtieneCiaDelAreaPeriferica(id_expediente);
            bool ConsultaCarrosPerifericos = true;
            int DespachoCaso = 0;
            bool HabilitaReemplazo = false;


            //-*- Verificar si el carro No esta Disponible y Tiene Reemplazo Automático
            Arr_ID = ccarros.ID_Reemplazo_Automatico(cod_llamado, Convert.ToInt32(idgrupos), list_id_carros);
            // Id del Carro que hace el reemplazo
            int IdCarro = Arr_ID[0];
            // Id del Carro que tiene reemplazo
            int IdReemplazo = Arr_ID[1];
            // Es 1 si la relación: Id_Llamado y Id_Grupo tiene registros en la tabla X_REEMPLAZO_AUTOMATICO.  
            int IdCarroEnGrupo = Arr_ID[2];
            if (IdCarroEnGrupo == 1)
            {
                // Crear ObjetoCarro con Id del carro que tiene reemplazo.
                ccarros = ccarros.getObjectz_carros(IdReemplazo);
                
                // Habilita el reemplazo sólo si el carro IdReemplazo esta 0-8 (2 o 3).
                if (Carro.EstaDisponible(ccarros) == false)
                //if (Carro.Esta08(ccarros) == true)
                {
                    ccarros.Update_Reemplazo_Automatico(Convert.ToInt32(idgrupos), IdCarro, false);
                    HabilitaReemplazo = true;
                }
            }
 

            //# Inicio de Orden Arreglo
            for (int a = 0; a < puntero_final.Count; a++)
            {
                arr[a] = puntero_final[a].ToString();
            }
            while (r != 0)
            {
                for (int b = 0; b < arr.Length; b++)
                {
                    string valor_envio = arr[b].ToString();
                    
                    
                    // ### Si el Ranking tiene 1 Elemento  
                    if (carrosPorRanking(valor_envio, list_id_carros) == 1)
                    {
                        ccarros = ccarros.getObjectz_carros(id_carro_puntero);
                        esReemplazo = ccarros.ObtenerBooleanReemplazo(Convert.ToInt32(id_carro_puntero), Convert.ToInt32(idgrupos));

                            
                            //-*- Selecciona Carro Si: (1)Esta Disponible, (2)Faltan Recursos y (3)El Reemplazo esta habilitado.
                            if (Carro.EstaDisponible(ccarros) && r != 0 && esReemplazo == false)
                            {
                                // # Despacho por Clave
                                if (Desp_X_Clave)
                                {
                                    valores_finales_retorno += ccarros.id_carro + ",";
                                    if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                    {
                                        ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                        StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                    }
                                    r--;
                                    b = arr.Length;
                                    // Despachar el Carro
                                    Carro.Despachar(ccarros);
                                }
                                
                                // ## Despacho por Pauta
                                else
                                {
                                    // # En este Grupo 1 por Cía
                                    if (uno_x_cia)
                                    {
                                        //Si hay a lo menos 1 Cía Despachada y Compara esta Nueva Cía
                                        if (companias_a_despachar.Count != 0)
                                        {
                                            if (verificarCandidatosDespacho(ccarros.id_compania, companias_a_despachar))
                                            {
                                                
                                                //# Excluir Compañías Vecinas con Especalidad de Rescate
                                                if (ExcluirCompañiaVecina(cod_llamado, Convert.ToInt32(companias_a_despachar[0].ToString()), ccarros.id_compania, ccarros.id_conductor))
                                                {
                                                
                                                    //### Agregar en el OR todos los tipo_carro que reemplazan Bomba
                                                    //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                                    //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 )
                                                    if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                                    {
                                                        companias_a_despachar.Add(ccarros.id_compania);
                                                    }
                                                    //companias_a_despachar.Add(ccarros.id_compania);
                                                
                                                    valores_finales_retorno += ccarros.id_carro + ",";
                                                    if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                                    {
                                                        ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                        StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                                    }
                                                    r--;
                                                    // Despachar el Carro
                                                    Carro.Despachar(ccarros);
                                                }
                                            }
                                        }

                                        // Primera Cía a Despachar se Agrega al ArrayList
                                        else
                                        {
                                            //### Agregar en el OR todos los tipo_carro que reemplazan Bomba
                                            //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                            //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2)
                                            if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                            {
                                                companias_a_despachar.Add(ccarros.id_compania);
                                            }

                                            valores_finales_retorno += ccarros.id_carro + ",";
                                            if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                            {
                                                ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                            }
                                            r--;
                                            // Despachar el Carro
                                            Carro.Despachar(ccarros);
                                        }
                                    }

                                    // # No Valida 1 por Cía
                                    else
                                    {
                                        //### Agregar en el OR todos los tipo_carro que reemplazan Bomba
                                        //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                        //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2)
                                        if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                        {
                                            companias_a_despachar.Add(ccarros.id_compania);
                                        }
                                        
                                        valores_finales_retorno += ccarros.id_carro + ",";
                                        if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                        {
                                            ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                            StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                        }
                                        r--;
                                        // Despachar el Carro
                                        Carro.Despachar(ccarros);
                                    }
                                }
                            } 
                    }

                    
                    // ### Si el Ranking tiene +1 Elemento -> OrdenTipo
                    else
                    {
                        int[] t_carro = new int[carros_compuesto.Length];
                        string tc_string = "";
                        string tc_string_2 = "";
                        string tc_usar = "";
                        string tc_usar_2 = "";
                        for (int c = 0; c < carros_compuesto.Length; c++)
                        {
                            // IDs de Carro
                            tc_string_2 += carros_compuesto[c].ToString() + ",";
                            // Tipos de Carro
                            tc_string += ccarros.recuperarValorTipoCarro(Convert.ToInt32(carros_compuesto[c])) + ",";
                        }
                        tc_string += "#";
                        tc_string_2 += "#";

                        tc_usar = tc_string.Replace(",#", "");
                        tc_usar_2 = tc_string_2.Replace(",#", "");

                        //-*- Obtener Orden de Tipo Carro (id_llamado, id_carros_list)
                        // Si hay un registro en que se cumple id_llamado = n AND id_carro = n, retorna 999
                        // Si no hay un registro en la tabla "x_orden_distinto", el valor retornado es 0
                        int IdGrupoArea = cczorden.ObtieneOrdenTipoDistinto(cod_llamado, tc_usar_2);

                        int[] tc_recuperado;
                        if (IdGrupoArea != 0)
                        {
                            // Obtiene Orden Tipo Distinto, se aplica para BX13 y BX20 e 10-4
                            tc_recuperado = cczorden.recuperarTipoCarroOrdenTipo(cod_llamado, tc_usar, IdGrupoArea, Ev_Gp_Ar);                           
                        }
                        else
                        {
                            // Obtiene Orden Tipo Normal
                            tc_recuperado = cczorden.recuperarTipoCarroOrdenTipo(cod_llamado, tc_usar, grupo_area, Ev_Gp_Ar);
                        }

                        for (int d = 0; d < tc_recuperado.Length; d++)
                        {
                            // Esta debes revisar...?
                            // int id_carro_final = cczorden.despachoPorTipo(Convert.ToInt32(tc_recuperado[d].ToString()), tc_usar_2);

                            // ### Si los 2 carros son del mismo tipo, se debe asignar el que está disponible (Cuando se Cubre Cuartel)
                            //int id_carro_final = 0;
                            //string[] Arr_Id_Carros = tc_usar_2.Split(',');
                            //if (ObtieneTipoCarro(Arr_Id_Carros[0]) == ObtieneTipoCarro(Arr_Id_Carros[1]))
                            //{
                            //    //int IdEstado09;
                            //    if (ObtieneEstadoCarro(Arr_Id_Carros[0]) == 1 || ObtieneEstadoCarro(Arr_Id_Carros[0]) == 5)
                            //    {
                            //        id_carro_final = Convert.ToInt32(Arr_Id_Carros[0]);
                            //    }
                            //    else
                            //    {
                            //        if (ObtieneEstadoCarro(Arr_Id_Carros[1]) == 1 || ObtieneEstadoCarro(Arr_Id_Carros[1]) == 5)
                            //        {
                            //            id_carro_final = Convert.ToInt32(Arr_Id_Carros[1]);

                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    // ### Si los 2 tipo de carros son distintos
                            //    id_carro_final = cczorden.despachoPorTipo(Convert.ToInt32(tc_recuperado[d].ToString()), tc_usar_2);
                            //}

                            int id_carro_final = cczorden.despachoPorTipo(Convert.ToInt32(tc_recuperado[d].ToString()), tc_usar_2);
                            ccarros = ccarros.getObjectz_carros(id_carro_final);

                            esReemplazo = ccarros.ObtenerBooleanReemplazo(Convert.ToInt32(id_carro_final), Convert.ToInt32(idgrupos));

                            if (1 == 1)  // Reemplaza al IF anterior de Despacho de Cias Perifericas
                            {
                                if (Carro.EstaDisponible(ccarros) && r != 0 && esReemplazo == false)
                                {
                                    // ## Despacho por Clave
                                    if (Desp_X_Clave)
                                    {
                                        valores_finales_retorno += ccarros.id_carro + ",";
                                        if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                        {
                                            ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                            StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                        }
                                        r--;
                                        b = arr.Length;
                                        // Despachar el Carro
                                        Carro.Despachar(ccarros);
                                    }
                                    
                                    // ## Despacho por Pauta
                                    else
                                    {
                                        // # En este Grupo 1 por Cía
                                        if(uno_x_cia)
                                        {
                                            // Asignar ID y Compañia
                                            if (companias_a_despachar.Count != 0)
                                            {
                                                // Revisar si la Compañia ya fue despachada
                                                if (verificarCandidatosDespacho(ccarros.id_compania, companias_a_despachar))
                                                {

                                                    //# Excluir Compañías Vecinas con Especalidad de Rescate
                                                    if (ExcluirCompañiaVecina(cod_llamado, Convert.ToInt32(companias_a_despachar[0].ToString()), ccarros.id_compania, ccarros.id_conductor))
                                                    {

                                                        //Si los tipos de Carro Son: B / BX / R / RX
                                                        if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                                        {
                                                            companias_a_despachar.Add(ccarros.id_compania);
                                                        }
                                                        //companias_a_despachar.Add(ccarros.id_compania);

                                                        valores_finales_retorno += ccarros.id_carro + ",";
                                                        if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                                        {
                                                            ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                            StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                                        }
                                                        r--;
                                                        // Despachar el Carro
                                                        Carro.Despachar(ccarros);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                                if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                                {
                                                    companias_a_despachar.Add(ccarros.id_compania);
                                                }
                                                //companias_a_despachar.Add(ccarros.id_compania);
                                                
                                                valores_finales_retorno += ccarros.id_carro + ",";
                                                if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                                {
                                                    ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                    StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                                }
                                                r--;
                                                // Despachar el Carro
                                                Carro.Despachar(ccarros);
                                            }                                            
                                        }
                                        
                                        // # No Valida 1 por Cía
                                        else
                                        {
                                            //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                            if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                            {
                                                companias_a_despachar.Add(ccarros.id_compania);
                                            }
                                            //companias_a_despachar.Add(ccarros.id_compania);

                                            valores_finales_retorno += ccarros.id_carro + ",";
                                            if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                            {
                                                ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                            }
                                            r--;
                                            // Despachar el Carro
                                            Carro.Despachar(ccarros);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
               
                r = 0;
            }

            //-*- Deshabilita Reemplazo si fue Habilitado
            if (HabilitaReemplazo)
            {
                ccarros.Update_Reemplazo_Automatico(Convert.ToInt32(idgrupos), IdCarro, true);
                HabilitaReemplazo = false;
            }

            valores_finales_retorno += "#";
            return valores_finales_retorno;
        }


        public static int ObtieneTipoCarro(string StrIdCarro)
        {
            int IntIdCarro = Convert.ToInt32(StrIdCarro); 
            var ccarros = new z_carros();
            ccarros = ccarros.getObjectz_carros(IntIdCarro);

            return ccarros.id_tipo_carro;
        }

        public static int ObtieneEstadoCarro(string StrIdCarro)
        {
            int IntIdCarro = Convert.ToInt32(StrIdCarro);
            var ccarros = new z_carros();
            ccarros = ccarros.getObjectz_carros(IntIdCarro);

            return ccarros.estado;
        }


        public static string ordenArreglo2(ArrayList puntero_final, ArrayList list_id_carros, ArrayList list_carro_x, ArrayList list_carro_y, ArrayList list_compania, ArrayList list_ranking, string idcarros, string idgrupos, string recu, int cod_llamado, ArrayList list_comp, int grupo_area, bool Ev_Gp_Ar, bool Desp_X_Clave, int id_expediente, int grupoOriginal)
        {
            List<int> despGrupo = new List<int>();
            var ccarros = new z_carros();
            var cczorden = new z_orden();
            string[] arr = new string[puntero_final.Count];
            string[] arr_split = new string[puntero_final.Count];
            string[] arr_uso = new string[puntero_final.Count];
            int r = Convert.ToInt32(recu);
            string valores_finales_retorno = "";
            bool uno_x_cia = ccarros.ValidacionUnoPorCompania(cod_llamado, Convert.ToInt32(idgrupos));

            bool esReemplazo = false;
            bool boolDisponible;
            List<int> Arr_ID = new List<int>();

            // Obtiene Cia del Area Periferica, Si no es Periferica el Area la Cia es 0
            int CiaDelAreaPeriferica = ObtieneCiaDelAreaPeriferica(id_expediente);
            bool ConsultaCarrosPerifericos = true;
            int DespachoCaso = 0;
            bool HabilitaReemplazo = false;


            //-*- Verificar si el carro No esta Disponible y Tiene Reemplazo Automático
            Arr_ID = ccarros.ID_Reemplazo_Automatico(cod_llamado, Convert.ToInt32(idgrupos), list_id_carros);
            // Id del Carro que hace el reemplazo
            int IdCarro = Arr_ID[0];
            // Id del Carro que tiene reemplazo
            int IdReemplazo = Arr_ID[1];
            // Es 1 si la relación: Id_Llamado y Id_Grupo tiene registros en la tabla X_REEMPLAZO_AUTOMATICO.  
            int IdCarroEnGrupo = Arr_ID[2];
            if (IdCarroEnGrupo == 1)
            {
                // Crear ObjetoCarro con Id del carro que tiene reemplazo.
                ccarros = ccarros.getObjectz_carros(IdReemplazo);

                // Habilita el reemplazo sólo si el carro IdReemplazo esta 0-8 (2 o 3).
                if (Carro.EstaDisponible(ccarros) == false)
                //if (Carro.Esta08(ccarros) == true)
                {
                    ccarros.Update_Reemplazo_Automatico(Convert.ToInt32(idgrupos), IdCarro, false);
                    HabilitaReemplazo = true;
                }
            }


            for (int a = 0; a < puntero_final.Count; a++)
            {
                arr[a] = puntero_final[a].ToString();
            }
            while (r != 0)
            {
                for (int b = 0; b < arr.Length; b++)
                {
                    string valor_envio = arr[b].ToString();


                    // ### Si el Ranking tiene 1 Elemento  
                    if (carrosPorRanking(valor_envio, list_id_carros) == 1)
                    {
                        ccarros = ccarros.getObjectz_carros(id_carro_puntero);
                        esReemplazo = ccarros.ObtenerBooleanReemplazo(Convert.ToInt32(id_carro_puntero), Convert.ToInt32(idgrupos));
                        /*
                        // ### Analisis de Despacho en Areas Perifericas ###
                        // *** El Carro Es de una Cía Periferica
                        if (ccarros.periferia)  
                        {
                            // *** El Area es Periferica
                            if (CiaDelAreaPeriferica > 0)
                            {
                                // El Carro es de la misma Cia del Area?
                                if (ccarros.id_compania == CiaDelAreaPeriferica)
                                {
                                    // * Despachar sin validar N de Carros en Servicio
                                    ConsultaCarrosPerifericos = false;
                                }
                                else
                                {
                                    // * Despachar Sólo si hay más de 1 Carro en Servicio
                                    ConsultaCarrosPerifericos = true;
                                }
                            }
                            else
                            {
                                // *** El Area No es Periferica, Despachar Sólo si hay más de 1 Carro en Servicio
                                ConsultaCarrosPerifericos = true;
                            }
                        }
                        else
                        {
                            // *** El Carro No Es de una Cía Periferica
                            ConsultaCarrosPerifericos = false;
                        }

                        
                        // *** Revisar si hay más carros disponible con distinto conductor en Compañía Periferica
                        bool PseudoSinConductor = true;
                        if (ConsultaCarrosPerifericos)
                        {
                            PseudoSinConductor = DisponiblesConDistintoConductor(ccarros.id_compania, 1);
                        }

                        if (PseudoSinConductor)
                        */

                        if (1 == 1)  // Reemplaza al IF anterior de Despacho de Cias Perifericas
                        {

                            //-*- Selecciona Carro Si: (1)Esta Disponible, (2)Faltan Recursos y (3)El Reemplazo esta habilitado.
                            if (Carro.EstaDisponible(ccarros) && r != 0 && esReemplazo == false)
                            {
                                // # Despacho por Clave
                                if (Desp_X_Clave)
                                {
                                    valores_finales_retorno += ccarros.id_carro + ",";
                                    if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                    {
                                        ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                        StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                    }
                                    r--;
                                    b = arr.Length;
                                    // Despachar el Carro
                                    Carro.Despachar(ccarros);
                                }

                                // ## Despacho por Pauta
                                else
                                {
                                    // # En este Grupo 1 por Cía
                                    if (uno_x_cia)
                                    {
                                        //Si hay a lo menos 1 Cía Despachada y Compara esta Nueva Cía
                                        if (companias_a_despachar.Count != 0)
                                        {
                                            if (verificarCandidatosDespacho(ccarros.id_compania, companias_a_despachar))
                                            {
                                                if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                                {
                                                    companias_a_despachar.Add(ccarros.id_compania);
                                                }
                                                //companias_a_despachar.Add(ccarros.id_compania);
                                                
                                                valores_finales_retorno += ccarros.id_carro + ",";
                                                if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                                {
                                                    ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                    StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                                }
                                                r--;
                                                // Despachar el Carro
                                                Carro.Despachar(ccarros);
                                            }
                                        }

                                        // Primera Cía a Despachar se Agrega al ArrayList
                                        else
                                        {
                                            if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                            {
                                                companias_a_despachar.Add(ccarros.id_compania);
                                            }
                                            //companias_a_despachar.Add(ccarros.id_compania);
                                            
                                            valores_finales_retorno += ccarros.id_carro + ",";
                                            if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                            {
                                                ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                            }
                                            r--;
                                            // Despachar el Carro
                                            Carro.Despachar(ccarros);
                                        }
                                    }

                                    // # No Valida 1 por Cía
                                    else
                                    {
                                        if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                        {
                                            companias_a_despachar.Add(ccarros.id_compania);
                                        }
                                        //companias_a_despachar.Add(ccarros.id_compania);
                                        
                                        valores_finales_retorno += ccarros.id_carro + ",";
                                        if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                        {
                                            ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                            StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                        }
                                        r--;
                                        // Despachar el Carro
                                        Carro.Despachar(ccarros);
                                    }
                                }
                            }
                        }
                    }


                    // ### Si el Ranking tiene +1 Elemento -> OrdenTipo
                    else
                    {
                        int[] t_carro = new int[carros_compuesto.Length];
                        string tc_string = "";
                        string tc_string_2 = "";
                        string tc_usar = "";
                        string tc_usar_2 = "";
                        for (int c = 0; c < carros_compuesto.Length; c++)
                        {
                            // IDs de Carro
                            tc_string_2 += carros_compuesto[c].ToString() + ",";
                            // Tipos de Carro
                            tc_string += ccarros.recuperarValorTipoCarro(Convert.ToInt32(carros_compuesto[c])) + ",";
                        }
                        tc_string += "#";
                        tc_string_2 += "#";

                        tc_usar = tc_string.Replace(",#", "");
                        tc_usar_2 = tc_string_2.Replace(",#", "");

                        //-*- Obtener Orden de Tipo Carro (id_llamado, id_carros_list)
                        // Si hay un registro en que se cumple id_llamado = n AND id_carro = n, retorna 999
                        // Si no hay un registro en la tabla "x_orden_distinto", el valor retornado es 0
                        int IdGrupoArea = cczorden.ObtieneOrdenTipoDistinto(cod_llamado, tc_usar_2);

                        int[] tc_recuperado;
                        if (IdGrupoArea != 0)
                        {
                            // Obtiene Orden Tipo Distinto, se aplica para BX13 y BX20 e 10-4
                            tc_recuperado = cczorden.recuperarTipoCarroOrdenTipo(cod_llamado, tc_usar, IdGrupoArea, Ev_Gp_Ar);
                        }
                        else
                        {
                            // Obtiene Orden Tipo Normal
                            tc_recuperado = cczorden.recuperarTipoCarroOrdenTipo(cod_llamado, tc_usar, grupo_area, Ev_Gp_Ar);
                        }

                        for (int d = 0; d < tc_recuperado.Length; d++)
                        {
                            // Esta debes revisar
                            int id_carro_final = cczorden.despachoPorTipo(Convert.ToInt32(tc_recuperado[d].ToString()), tc_usar_2);
                            ccarros = ccarros.getObjectz_carros(id_carro_final);

                            esReemplazo = ccarros.ObtenerBooleanReemplazo(Convert.ToInt32(id_carro_final), Convert.ToInt32(idgrupos));

                            /*
                            // ### Analisis de Despacho en Areas Perifericas ###
                            // *** El Carro Es de una Cía Periferica
                            if (ccarros.periferia)
                            {
                                // *** El Area es Periferica
                                if (CiaDelAreaPeriferica > 0)
                                {
                                    // El Carro es de la misma Cia del Area?
                                    if (ccarros.id_compania == CiaDelAreaPeriferica)
                                    {
                                        // * Despachar sin validar N de Carros en Servicio
                                        ConsultaCarrosPerifericos = false;
                                    }
                                    else
                                    {
                                        // * Despachar Sólo si hay más de 1 Carro en Servicio
                                        ConsultaCarrosPerifericos = true;
                                    }
                                }
                                else
                                {
                                    // *** El Area No es Periferica, Despachar Sólo si hay más de 1 Carro en Servicio
                                    ConsultaCarrosPerifericos = true;
                                }
                            }
                            else
                            {
                                // *** El Carro No Es de una Cía Periferica
                                ConsultaCarrosPerifericos = false;
                            }


                            // *** Revisar si hay más carros disponible con distinto conductor en Compañía Periferica
                            bool PseudoSinConductor = true;
                            if (ConsultaCarrosPerifericos)
                            {
                                PseudoSinConductor = DisponiblesConDistintoConductor(ccarros.id_compania, 1);
                            }

                            if (PseudoSinConductor)
                            */


                            if (1 == 1)  // Reemplaza al IF anterior de Despacho de Cias Perifericas
                            {

                                if (Carro.EstaDisponible(ccarros) && r != 0 && esReemplazo == false)
                                {
                                    // ## Despacho por Clave
                                    if (Desp_X_Clave)
                                    {
                                        valores_finales_retorno += ccarros.id_carro + ",";
                                        if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                        {
                                            ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                            StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                        }
                                        r--;
                                        b = arr.Length;
                                        // Despachar el Carro
                                        Carro.Despachar(ccarros);
                                    }

                                    // ## Despacho por Pauta
                                    else
                                    {
                                        // # En este Grupo 1 por Cía
                                        if (uno_x_cia)
                                        {
                                            // Asignar ID y Compañia
                                            if (companias_a_despachar.Count != 0)
                                            {
                                                // Revisar si la Compañia ya fue despachada
                                                if (verificarCandidatosDespacho(ccarros.id_compania, companias_a_despachar))
                                                {
                                                    if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                                    {
                                                        companias_a_despachar.Add(ccarros.id_compania);
                                                    }
                                                    //companias_a_despachar.Add(ccarros.id_compania);
                                                    
                                                    valores_finales_retorno += ccarros.id_carro + ",";
                                                    if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                                    {
                                                        ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                        StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                                    }
                                                    r--;
                                                    // Despachar el Carro
                                                    Carro.Despachar(ccarros);
                                                }
                                            }
                                            else
                                            {
                                                if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                                {
                                                    companias_a_despachar.Add(ccarros.id_compania);
                                                }
                                                //companias_a_despachar.Add(ccarros.id_compania);
                                                
                                                valores_finales_retorno += ccarros.id_carro + ",";
                                                if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                                {
                                                    ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                    StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                                }
                                                r--;
                                                // Despachar el Carro
                                                Carro.Despachar(ccarros);
                                            }
                                        }

                                        // # No Valida 1 por Cía
                                        else
                                        {
                                            if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                            {
                                                companias_a_despachar.Add(ccarros.id_compania);
                                            }
                                            //companias_a_despachar.Add(ccarros.id_compania);
                                            
                                            valores_finales_retorno += ccarros.id_carro + ",";
                                            if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, id_expediente) == 0)
                                            {
                                                ccarros.insertZcarrosLlamado(ccarros.id_carro, grupoOriginal != 0 ? grupoOriginal : Convert.ToInt32(idgrupos), id_expediente);
                                                StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                            }
                                            r--;
                                            // Despachar el Carro
                                            Carro.Despachar(ccarros);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                r = 0;
            }

            //-*- Deshabilita Reemplazo si fue Habilitado
            if (HabilitaReemplazo)
            {
                ccarros.Update_Reemplazo_Automatico(Convert.ToInt32(idgrupos), IdCarro, true);
                HabilitaReemplazo = false;
            }

            valores_finales_retorno += "#";
            return valores_finales_retorno;
        }



        public static string ordenArregloIncendio(ArrayList puntero_final, ArrayList list_id_carros, ArrayList list_carro_x, ArrayList list_carro_y, ArrayList list_compania, ArrayList list_ranking, string idcarros, string idgrupos, string recu, int cod_llamado, ArrayList list_comp, int grupo_area, bool Ev_Gp_Ar, bool Desp_X_Clave, int idExpediente)
        {
            
            List<int> despGrupo = new List<int>();
            var ccarros = new z_carros();
            var cczorden = new z_orden();
            string[] arr = new string[puntero_final.Count];
            string[] arr_split = new string[puntero_final.Count];
            string[] arr_uso = new string[puntero_final.Count];
            //companias_a_despachar = ccarros.retornarCarrosUsados(idExpediente);
            companias_a_despachar = ccarros.retornarCarrosUsados_Uno_X_Cia(idExpediente);
            bool uno_x_cia = ccarros.ValidacionUnoPorCompania(cod_llamado, Convert.ToInt32(idgrupos));

            bool esReemplazo = false;
            List<int> Arr_ID = new List<int>();
            bool HabilitaReemplazo = false;


            //-*- Verificar si el carro No esta Disponible y Tiene Reemplazo Automático
            Arr_ID = ccarros.ID_Reemplazo_Automatico(cod_llamado, Convert.ToInt32(idgrupos), list_id_carros);
            // Id del Carro que hace el reemplazo
            int IdCarro = Arr_ID[0];
            // Id del Carro que tiene reemplazo
            int IdReemplazo = Arr_ID[1];
            // Es 1 si la relación: Id_Llamado y Id_Grupo tiene registros en la tabla X_REEMPLAZO_AUTOMATICO.  
            int IdCarroEnGrupo = Arr_ID[2];
            if (IdCarroEnGrupo == 1)
            {
                // Crear ObjetoCarro con Id del carro que tiene reemplazo.
                ccarros = ccarros.getObjectz_carros(IdReemplazo);

                // Habilita el reemplazo sólo si el carro IdReemplazo esta 0-8 (2 o 3).
                if (Carro.EstaDisponible(ccarros) == false)
                //if (Carro.Esta08(ccarros) == true)
                {
                    ccarros.Update_Reemplazo_Automatico(Convert.ToInt32(idgrupos), IdCarro, false);
                    HabilitaReemplazo = true;
                }
            }

            //# Inicio de Orden Arreglo para Incendio
            int r = Convert.ToInt32(recu);
            string valores_finales_retorno = "";
            for (int a = 0; a < puntero_final.Count; a++)
            {
                arr[a] = puntero_final[a].ToString();
            }
            while (r != 0)
            {
                for (int b = 0; b < arr.Length; b++)
                {
                    string valor_envio = arr[b].ToString();


                    //### Si el Ranking tiene 1 Elemento  
                    if (carrosPorRanking(valor_envio, list_id_carros) == 1)
                    {
                        ccarros = ccarros.getObjectz_carros(id_carro_puntero);
                        esReemplazo = ccarros.ObtenerBooleanReemplazo(Convert.ToInt32(id_carro_puntero), Convert.ToInt32(idgrupos));

                        //-*- Selecciona Carro Si: (1)Esta Disponible, (2)Faltan Recursos y (3)El Reemplazo esta habilitado.
                        if (Carro.EstaDisponible(ccarros) && r != 0 && esReemplazo == false)
                        {
                            // # Despacho por Clave
                            if (Desp_X_Clave)
                            {
                                if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, idExpediente) == 0)
                                {
                                    ccarros.insertZcarrosLlamado(ccarros.id_carro, Convert.ToInt32(idgrupos), idExpediente);
                                    StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                }
                                valores_finales_retorno += ccarros.id_carro + ",";
                                r--;
                                b = arr.Length;
                                // Despachar el Carro
                                Carro.Despachar(ccarros);
                            }

                            // # Despacho por Pauta
                            else
                            {
                                // # En este Grupo 1 por Cía
                                if (uno_x_cia)
                                {
                                    //- Si hay a lo menos 1 Cía Despachada y Compara esta Nueva Cía
                                    if (companias_a_despachar.Count != 0)
                                    {
                                        if (verificarCandidatosDespacho(ccarros.id_compania, companias_a_despachar))
                                        {
                                            if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, idExpediente) == 0)
                                            {
                                                ccarros.insertZcarrosLlamado(ccarros.id_carro, Convert.ToInt32(idgrupos), idExpediente);
                                                StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                            }

                                            //### Agregar en el OR todos los tipo_carro que reemplazan Bomba
                                            //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                            if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                            {
                                                companias_a_despachar.Add(ccarros.id_compania);
                                            }
                                            //companias_a_despachar.Add(ccarros.id_compania);
                                            
                                            valores_finales_retorno += ccarros.id_carro + ",";
                                            r--;
                                            // Despachar el Carro
                                            Carro.Despachar(ccarros);
                                        }
                                    }

                                    //- Primera Cía a Despachar se Agrega al ArrayList
                                    else
                                    {
                                        if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, idExpediente) == 0)
                                        {
                                            ccarros.insertZcarrosLlamado(ccarros.id_carro, Convert.ToInt32(idgrupos), idExpediente);
                                            StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                        }

                                        //### Agregar en el OR todos los tipo_carro que reemplazan Bomba
                                        //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                        if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                        {
                                            companias_a_despachar.Add(ccarros.id_compania);
                                        }
                                        
                                        valores_finales_retorno += ccarros.id_carro + ",";
                                        r--;
                                        // Despachar el Carro
                                        Carro.Despachar(ccarros);
                                    }
                                }

                                // # No Valida 1 por Cía
                                else
                                {
                                    if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, idExpediente) == 0)
                                    {
                                        ccarros.insertZcarrosLlamado(ccarros.id_carro, Convert.ToInt32(idgrupos), idExpediente);
                                        StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                    }

                                    //### Agregar en el OR todos los tipo_carro que reemplazan Bomba
                                    //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                    if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                    {
                                        companias_a_despachar.Add(ccarros.id_compania);
                                    }
                                    //companias_a_despachar.Add(ccarros.id_compania);
                                    
                                    valores_finales_retorno += ccarros.id_carro + ",";
                                    r--;
                                    // Despachar el Carro
                                    Carro.Despachar(ccarros);
                                }
                            }
                        }
                    }

                    // Si el Ranking tiene +1 Elemento -> OrdenTipo
                    else
                    {
                        int[] t_carro = new int[carros_compuesto.Length];
                        string tc_string = "";
                        string tc_string_2 = "";
                        string tc_usar = "";
                        string tc_usar_2 = "";
                        for (int c = 0; c < carros_compuesto.Length; c++)
                        {
                            // IDs de Carro
                            tc_string_2 += carros_compuesto[c].ToString() + ",";
                            // Tipos de Carro
                            tc_string += ccarros.recuperarValorTipoCarro(Convert.ToInt32(carros_compuesto[c])) + ",";
                        }
                        tc_string += "#";
                        tc_string_2 += "#";

                        tc_usar = tc_string.Replace(",#", "");
                        tc_usar_2 = tc_string_2.Replace(",#", "");

                        // Orden de Tipo Carro
                        int[] tc_recuperado = cczorden.recuperarTipoCarroOrdenTipo(cod_llamado, tc_usar, grupo_area, Ev_Gp_Ar);
                        for (int d = 0; d < tc_recuperado.Length; d++)
                        {
                            // Esta debes revisar
                            int id_carro_final = cczorden.despachoPorTipo(Convert.ToInt32(tc_recuperado[d].ToString()), tc_usar_2);
                            ccarros = ccarros.getObjectz_carros(id_carro_final);

                            esReemplazo = ccarros.ObtenerBooleanReemplazo(Convert.ToInt32(id_carro_final), Convert.ToInt32(idgrupos));

                            if (Carro.EstaDisponible(ccarros) && r != 0 && esReemplazo == false)
                            {
                                if (Desp_X_Clave)
                                {
                                    //if (companias_a_despachar.Count != 0)
                                    //{
                                        // Revisar si la Compañia ya fue despachada
                                        //if (verificarCandidatosDespacho(ccarros.id_compania, companias_a_despachar))
                                        //{
                                    if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, idExpediente) == 0)
                                    {
                                        ccarros.insertZcarrosLlamado(ccarros.id_carro, Convert.ToInt32(idgrupos), idExpediente);
                                        StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                    }
                                            valores_finales_retorno += ccarros.id_carro + ",";
                                            r--;
                                            b = arr.Length;
                                            // Despachar el Carro
                                            Carro.Despachar(ccarros);
                                        //}
                                    //}
                                }

                                // ## Despacho por Pauta
                                else
                                {
                                    // # En este Grupo 1 por Cía
                                    if (uno_x_cia)
                                    {
                                        // Asignar ID y Compañia
                                        if (companias_a_despachar.Count != 0)
                                        {
                                            // Revisar si la Compañia ya fue despachada
                                            if (verificarCandidatosDespacho(ccarros.id_compania, companias_a_despachar))
                                            {
                                                if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, idExpediente) == 0)
                                                {
                                                    ccarros.insertZcarrosLlamado(ccarros.id_carro, Convert.ToInt32(idgrupos), idExpediente);
                                                    StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                                }

                                                //### Agregar en el OR todos los tipo_carro que reemplazan Bomba
                                                //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                                if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                                {
                                                    companias_a_despachar.Add(ccarros.id_compania);
                                                }
                                                //companias_a_despachar.Add(ccarros.id_compania);
                                                
                                                valores_finales_retorno += ccarros.id_carro + ",";
                                                r--;
                                                // Despachar el Carro
                                                Carro.Despachar(ccarros);
                                            }
                                        }
                                        else
                                        {
                                            if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, idExpediente) == 0)
                                            {
                                                ccarros.insertZcarrosLlamado(ccarros.id_carro, Convert.ToInt32(idgrupos), idExpediente);
                                                StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                            }

                                            //### Agregar en el OR todos los tipo_carro que reemplazan Bomba
                                            //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                            if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                            {
                                                companias_a_despachar.Add(ccarros.id_compania);
                                            }
                                            //companias_a_despachar.Add(ccarros.id_compania);
                                            
                                            valores_finales_retorno += ccarros.id_carro + ",";
                                            r--;
                                            // Despachar el Carro
                                            Carro.Despachar(ccarros);
                                        }
                                    }

                                    // # No Valida 1 por Cía
                                    else
                                    {
                                        if (ccarros.existenciaZcarrosLlamado(ccarros.id_carro, idExpediente) == 0)
                                        {
                                            ccarros.insertZcarrosLlamado(ccarros.id_carro, Convert.ToInt32(idgrupos), idExpediente);
                                            StaticClass.ArrGrupoCarros.Add(ccarros.id_carro + "/" + idgrupos);
                                        }

                                        //### Agregar en el OR todos los tipo_carro que reemplazan Bomba
                                        //if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 14 || ccarros.id_tipo_carro == 15)
                                        if (ccarros.id_tipo_carro == 1 || ccarros.id_tipo_carro == 2 || ccarros.id_tipo_carro == 5 || ccarros.id_tipo_carro == 6 || ccarros.id_tipo_carro == 7)
                                        {
                                            companias_a_despachar.Add(ccarros.id_compania);
                                        }
                                        //companias_a_despachar.Add(ccarros.id_compania);
                                        
                                        valores_finales_retorno += ccarros.id_carro + ",";
                                        r--;
                                        // Despachar el Carro
                                        Carro.Despachar(ccarros);
                                    }
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
       


        // *** Verificar si nuevo carro pertenece a una Cía Despachada
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

        //### Asigna Referencia de Ranking
        public static ArrayList despacharGrupo(ArrayList list_ranking)
        {
            
            ArrayList NuevoPuntero = new ArrayList();
            ArrayList puntero = new ArrayList();
            ArrayList copia = new ArrayList();
            //# NuevaLinea
            ArrayList ListaFinal = new ArrayList();
            
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

            //if (count != puntero.Count)
            //{
            //    puntero = CraerNuevoPuntero(puntero);
            //}

            //return puntero;

            //# NuevasLineas
            foreach (string p in puntero)
            {
                if (!(p.ToString() == "#"))
                {
                    ListaFinal.Add(p);
                }
            }
            return ListaFinal;

        }


        //### Asigna Referencia de Ranking MATERIAL DE COMANDANCIA
        public static ArrayList despacharGrupo_Comandancia(ArrayList list_ranking)
        {
            ArrayList NuevoPuntero = new ArrayList();
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

            if (count != puntero.Count)
            {
                puntero = CraerNuevoPuntero(puntero);
            }

            return puntero;
        }


        //### Crae un Arreglo con el Split
        public static ArrayList CraerNuevoPuntero(ArrayList list_puntero)
        {
            ArrayList NuevoPuntero = new ArrayList();
            foreach (string strElemento in list_puntero)
            {
                string[] ArrayElementos = strElemento.Split(',');
                foreach (string s in ArrayElementos)
                {
                    if (s != "#")
                    {
                        NuevoPuntero.Add(s + ",#");
                    }
                }
            }

            return NuevoPuntero;
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
            if ((batallon >= 1 && batallon <= 4) || despachandoTodo)
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

        //### Cancelar el Despacho
        public static void CancelarDespacho(List<int> id_carro)
        {
            foreach (int id in id_carro)
            {
                //### Metodo para Liberar Excepto Gestion de Carro
                Carro.LiberarCancelar(id);
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


        // Gestión CBS
        //public static void DespachoGestion(int id_carro, bool en_servicio, int id_expediente, string clave, string[] coor_carros)
        //{
        //    z_carros carro = new z_carros().getObjectz_carros(id_carro);
        //    if (en_servicio)
        //    {
        //        Carro.DisponibleEnActo(carro);
        //    }
        //    else
        //    {
        //        Carro.FueraServicio(carro, clave);
        //    }

        //    Conductor.FueraServicio(carro.id_conductor, carro.id_carro);

        //    e_carros_usados ec = new e_carros_usados().getObjecte_carros_usados(id_carro);
        //    ec.id_expediente = id_expediente;
        //    ec.seis = en_servicio ? "0-9" : "0-8";
        //    if (ec.id_carro != 0)
        //    {
        //        ec.Update(ec);
        //    }
        //    else
        //    {
        //        ec.id_carro = id_carro;
        //        ec.Insert(ec);
        //    }

        //    // ****** CODIGO AGREGADO POR MARCOS PONCE

        //    // ***************************************
        //    if (carro.asignarCoordenadasGestionDestino(coor_carros, id_carro) == 0)
        //    {
        //        MessageBox.Show("No fue posible asignar las coordenadas de gestion al carro!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    //DBNotifyListeners.Notify("despacho");
        //}


        //### Gestión de Carro OK
        public static void DespachoGestion(int id_carro, bool en_servicio, int id_expediente, string clave)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            if (en_servicio)
            {
                Carro.DisponibleEnActo(carro);
            }
            else
            {
                //Carro.FueraServicio(carro, clave);
                Carro.NoDisponibleEnActo(carro);
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
            //if (carro.asignarCoordenadasGestionDestino(coor_carros, id_carro) == 0)
            //{
            //    MessageBox.Show("No fue posible asignar las coordenadas de gestion al carro!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //DBNotifyListeners.Notify("despacho");
        }




        //public static void DespachoGestion(int id_carro, bool en_servicio, int id_expediente, string clave)
        //{
        //    z_carros carro = new z_carros().getObjectz_carros(id_carro);
        //    if (en_servicio)
        //    {
        //        Carro.DisponibleEnActo(carro);
        //    }
        //    else
        //    {
        //        Carro.FueraServicio(carro, clave);
        //    }

        //    Conductor.FueraServicio(carro.id_conductor, carro.id_carro);

        //    e_carros_usados ec = new e_carros_usados().getObjecte_carros_usados(id_carro);
        //    ec.id_expediente = id_expediente;
        //    ec.seis = en_servicio ? "0-9" : "0-8";
        //    if (ec.id_carro != 0)
        //    {
        //        ec.Update(ec);
        //    }
        //    else
        //    {
        //        ec.id_carro = id_carro;
        //        ec.Insert(ec);
        //    }
        //    //DBNotifyListeners.Notify("despacho");
        //}

        



        public static int Ranking_x_Claves(int id_expediente, string id_grupo, int bloque)
        {
            e_expedientes expediente = new e_expedientes();
            z_carros zcarros = new z_carros();
            z_orden zorden = new z_orden();
            ArrayList puntero_final = new ArrayList();
            ArrayList lista_carros = new ArrayList();
            ArrayList list_ranking = new ArrayList();
            ArrayList array_final = new ArrayList();
            ArrayList CiasDespachadas = new ArrayList();
            ArrayList funcion_u_chile = new ArrayList();
            int id_car = 0;
            List<int> envioFinalCarros = new List<int>();
            ArrayList CoordenadasDeGrupos = new ArrayList();
            ArrayList Rkg = new ArrayList();
            x_grupo_alias xgrupoalias = new x_grupo_alias();

            int cant_carros = 0;
            int j = 0;
            int p = 0;
            try
            {
                //* Inicializa el Objeto Expediente
                expediente = expediente.getObjecte_expedientes(id_expediente);
                
                //* Obtiene el Grupo de Área Periferica, Si no es periferica, corresponde valor 1;
                int grupo_area = zcarros.obtenerCodigoArea(expediente.id_area);

                //* Obtiene el valor booleano "comp_ga_tipo" de x_despacho_habil;
                bool EvGpAr = zcarros.EvaluaGrupoArea(expediente.codigo_llamado);

                //* Asigna los valores X e Y del Objeto Expediente.
                string punto_x = expediente.puntoX.ToString();
                string punto_y = expediente.puntoY.ToString();

                //* Lista de Listas: Id_Carros, coordenada_x, coordenada_y, Id_Compañia, Ranking 
                ArrayList[] array_lista_carros = new ArrayList[5];

                //posicion
                int int_r = 1;                                                          //*  Recurso = 1


                // Selecciona los carros del Grupo N utilizando Alias de Grupo
                // Para cada Carro Virtual, recupera: Id_Carro, Coordenadas, Compañía y Ranking
                int intAlias = xgrupoalias.GetAliasGrupo(id_grupo);
                array_lista_carros = zcarros.obtenerCarrosVirtualPorClave(id_grupo, expediente.id_area, intAlias);


                //cant_carros = lista_carros.Count;
                ArrayList list_id_carros = new ArrayList();
                ArrayList list_carro_x = new ArrayList();
                ArrayList list_carro_y = new ArrayList();
                ArrayList list_compania = new ArrayList();
                ArrayList list_rkn = new ArrayList();
                ArrayList list_carros_despacho = new ArrayList();

                list_id_carros = array_lista_carros[0];
                list_carro_x = array_lista_carros[1];
                list_carro_y = array_lista_carros[2];
                list_compania = array_lista_carros[3];
                list_rkn = array_lista_carros[4];


                string[] ccarro = new string[list_id_carros.Count];
                string[] px = new string[list_carro_x.Count];
                string[] py = new string[list_carro_y.Count];
                string[] comp = new string[list_compania.Count];
                string[] ranking = new string[list_rkn.Count];


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

                for (int h = 0; h < list_rkn.Count; h++)
                {
                    ranking[h] = list_rkn[h].ToString();
                }

                //### Asigna Referencia de Ranking
                puntero_final = despacharGrupo(list_rkn);
                //string ret_final = ordenArreglo(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_ranking, group[0], group[1], group[2], expediente.codigo_llamado, list_compania, grupo_area, EvGpAr);
                string str_tipos = zcarros.recuperarTiposDeCarroDelGrupo(id_grupo);   //"1,5"
                string str_recurso = "1";
                //string ret_final = ordenArreglo2(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_rkn, str_tipos, id_grupo, str_recurso, expediente.codigo_llamado, list_compania, grupo_area, EvGpAr, true, id_expediente, 0);
                string ret_final = ordenArreglo(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_rkn, str_tipos, id_grupo, str_recurso, expediente.codigo_llamado, list_compania, grupo_area, EvGpAr, true, id_expediente, 0);
                string val_ok = ret_final.ToString().Replace(",#", "");
                id_car = Convert.ToInt32(val_ok);

            }
            catch (Exception exe)
            {

            }

            return id_car;
        }

        public static ArrayList Ranking_x_Claves_All(int id_expediente, string id_grupo, int bloque)
        {
            e_expedientes expediente = new e_expedientes();
            z_carros zcarros = new z_carros();
            z_orden zorden = new z_orden();
            ArrayList puntero_final = new ArrayList();
            ArrayList lista_carros = new ArrayList();
            ArrayList list_ranking = new ArrayList();
            ArrayList array_final = new ArrayList();
            ArrayList CiasDespachadas = new ArrayList();
            ArrayList funcion_u_chile = new ArrayList();
            int id_car = 0;
            List<int> envioFinalCarros = new List<int>();
            ArrayList CoordenadasDeGrupos = new ArrayList();
            ArrayList Rkg = new ArrayList();
            ArrayList list_final_carros_all = new ArrayList();
            x_grupo_alias xgrupoalias = new x_grupo_alias();

            int cant_carros = 0;
            int j = 0;
            int p = 0;
            try
            {
                //* Inicializa el Objeto Expediente
                expediente = expediente.getObjecte_expedientes(id_expediente);

                //* Obtiene el Grupo de Área Periferica, Si no es periferica, corresponde valor 1
                int grupo_area = zcarros.obtenerCodigoArea(expediente.id_area);

                //* Obtiene el valor booleano "comp_ga_tipo" de x_despacho_habil;
                bool EvGpAr = zcarros.EvaluaGrupoArea(expediente.codigo_llamado);

                //* Asigna los valores X e Y del Objeto Expediente.
                string punto_x = expediente.puntoX.ToString();
                string punto_y = expediente.puntoY.ToString();

                //* Lista de Listas: Id_Carros, coordenada_x, coordenada_y, Id_Compañia, Ranking 
                ArrayList[] array_lista_carros = new ArrayList[5];

                //posicion
                int int_r = 1;       //* Convert.ToInt32(group[2].ToString());         Recurso = 1

                // Selecciona los carros del Grupo N utilizando Alias de Grupo
                // Para cada Carro Virtual, recupera: Id_Carro, Coordenadas, Compañía y Ranking
                int intAlias = xgrupoalias.GetAliasGrupo(id_grupo);
                array_lista_carros = zcarros.obtenerCarrosVirtualPorClave(id_grupo, expediente.id_area, intAlias);

                //cant_carros = lista_carros.Count;
                ArrayList list_id_carros = new ArrayList();
                ArrayList list_carro_x = new ArrayList();
                ArrayList list_carro_y = new ArrayList();
                ArrayList list_compania = new ArrayList();
                ArrayList list_rkn = new ArrayList();
                ArrayList list_carros_despacho = new ArrayList();

                list_id_carros = array_lista_carros[0];
                list_carro_x = array_lista_carros[1];
                list_carro_y = array_lista_carros[2];
                list_compania = array_lista_carros[3];
                list_rkn = array_lista_carros[4];


                string[] ccarro = new string[list_id_carros.Count];
                string[] px = new string[list_carro_x.Count];
                string[] py = new string[list_carro_y.Count];
                string[] comp = new string[list_compania.Count];
                string[] ranking = new string[list_rkn.Count];


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

                for (int h = 0; h < list_rkn.Count; h++)
                {
                    ranking[h] = list_rkn[h].ToString();
                }

                //### Asigna Referencia de Ranking
                puntero_final = despacharGrupo(list_rkn);
                //string ret_final = ordenArreglo(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_ranking, group[0], group[1], group[2], expediente.codigo_llamado, list_compania, grupo_area, EvGpAr);
                string str_tipos = zcarros.recuperarTiposDeCarroDelGrupo(id_grupo);   //"1,5"
                //string str_recurso = "1";
                //string ret_final = ordenArreglo2(puntero_final, list_id_carros, list_carro_x, list_carro_y, list_compania, list_ranking, str_tipos, id_grupo, str_recurso, expediente.codigo_llamado, list_compania, grupo_area, EvGpAr, true, id_expediente, 0);
                //string val_ok = ret_final.ToString().Replace(",#", "");
                //id_car = Convert.ToInt32(val_ok);


                list_final_carros_all = ordenIdCarrosPorRanking(puntero_final, list_id_carros);

            }
            catch (Exception exe)
            {

            }

            return list_final_carros_all;
        }



        // Crea un ArrayList con Id de Carros Disponibles Ordenados por Ranking
        public static ArrayList ordenIdCarrosPorRanking(ArrayList puntero_final, ArrayList list_id_carros)
        {
            z_carros ccarros = new z_carros();
            // Pasar elementos del ArrayList a un Arreglo
            string[] arr = new string[puntero_final.Count];
            for (int a = 0; a < puntero_final.Count; a++)
            {
                arr[a] = puntero_final[a].ToString();
            }

            ArrayList IdCarroDisponibleRankiado = new ArrayList();

            // Por cada elemento del Arrey PunteroFinal
            for (int b = 0; b < arr.Length; b++)
            {
                string valor_envio = arr[b].ToString();

                // Si el Ranking tiene sólo 1 Elemento  
                if (carrosPorRanking(valor_envio, list_id_carros) == 1)
                {
                    // "id_carro_puntero" Es el ID de Carro Ordenado por Ranking
                    ccarros = ccarros.getObjectz_carros(id_carro_puntero);

                    // Si el carro esta disponible, se agrega al ArrayList Final
                    if (Carro.EstaDisponible(ccarros))
                    {
                        IdCarroDisponibleRankiado.Add(id_carro_puntero);
                    }
                }

                // Si el Ranking tiene Más de 1 Elemento
                else
                {
                    for (int c = 0; c < carros_compuesto.Length; c++)
                    {
                        // "id_carro_puntero" Es el ID de Carro Ordenado por Ranking
                        ccarros = ccarros.getObjectz_carros(Convert.ToInt32(carros_compuesto[c]));

                        // Si el carro esta disponible, se agrega al ArrayList Final
                        if (Carro.EstaDisponible(ccarros))
                        {
                            IdCarroDisponibleRankiado.Add(carros_compuesto[c]);
                        }
                    }
                }
            }
            return IdCarroDisponibleRankiado;
        }

        //public static void ejecutarComandosLinux(string ip, string user, string pass)
        //{
        //    /*
        //     * Para ejecutar este metodo se necesitan los siguientes parametros:
        //     * user: El usuario de conexión a la máquina linux
        //     * pass: La clave asignada al usuario para la conexión a la máquina linux
        //     * ip: La ip de la máquina linux
        //     * 
        //     * Con estos 3 parametros, se puede probar ejecutando este metodo y pasando en la viable comando
        //     * una ruta linux para realizar una prueba, en este ejemplo, en la carpeta tmp creo un directorio llamado mrksponce_funcionando
        //     * este código funciona correctamente. 
        //     */

        //    try
        //    {
        //        SshExec exec = new SshExec("192.168.0.92", "zeus01", "zeus.2012");
        //        exec.Connect();
        //        if (exec.Connected)
        //        {
        //            string comando = "mkdir /tmp/mrks";
        //            exec.RunCommand(comando);
        //            exec.Close();
        //        }
        //    }
        //    catch (Exception exe)
        //    {
        //        MessageBox.Show("Mensaje: " + exe.Message + "", "ERROR!!");
        //    }
        //}

        public static int EscribeParametros(string StrPunto_x, string StrPunto_y, string StrBloque, string StrNcarros)
        {

            //bool chkFer = 
            int Resulta = 0;
            const string fic = @"C:\comander\parametros.txt";

            StreamWriter sw = new StreamWriter(fic);
            //Ok sw.WriteLine("# example parametros.txt the format is" + '\u000A' + "# Latitude of emergency in UTMS format" + '\u000A' + "# Longitude of emergency in UTMS format" + '\u000A' + "# time of the day" + '\u000A' + "# number of vehicles described in carros.txt" + '\u000A' + StrPunto_x + '\u000A' + StrPunto_y + '\u000A' + Bloque24 + '\u000A' + StrNcarros + '\u000A');
            sw.WriteLine("# example parametros.txt the format is" + '\n' + "# Latitude of emergency in UTMS format" + '\n' + "# Longitude of emergency in UTMS format" + '\n' + "# time of the day" + '\n' + "# number of vehicles described in carros.txt" + '\n' + StrPunto_x + '\n' + StrPunto_y + '\n' + StrBloque + '\n' + StrNcarros + '\n');

            
            sw.Close();

            //MessageBox.Show("Archivo Parametros Creado...", "GEObit", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            //Process.Start(@”c:\WINDOWS\NOTEPAD.EXE”);

            //System.Diagnostics.Process proc;
            //proc = System.Diagnostics.Process.Start(@"C:\WINDOWS\NOTEPAD.EXE");
            //proc.Close();

            return Resulta;
        }


        // ### Crea Parametros_Log
        public static int EscribeParametros_Log(string strExpediente, string StrPunto_x, string StrPunto_y, string StrBloque, string StrNcarros)
        {
            int Resulta = 0;
            string fic = @"C:\comander\ZeusLog_Parametros\" + strExpediente + @"_Parametros.txt";
            //const string fic = @"C:\comander\ZeusLog_Parametros\" + strExpediente + @"_Parametros.txt";

            StreamWriter sw = new StreamWriter(fic);
            //Ok sw.WriteLine("# example parametros.txt the format is" + '\u000A' + "# Latitude of emergency in UTMS format" + '\u000A' + "# Longitude of emergency in UTMS format" + '\u000A' + "# time of the day" + '\u000A' + "# number of vehicles described in carros.txt" + '\u000A' + StrPunto_x + '\u000A' + StrPunto_y + '\u000A' + Bloque24 + '\u000A' + StrNcarros + '\u000A');
            sw.WriteLine("# example parametros.txt the format is" + '\n' + "# Latitude of emergency in UTMS format" + '\n' + "# Longitude of emergency in UTMS format" + '\n' + "# time of the day" + '\n' + "# number of vehicles described in carros.txt" + '\n' + StrPunto_x + '\n' + StrPunto_y + '\n' + StrBloque + '\n' + StrNcarros + '\n');
            sw.Close();
            return Resulta;
        }




        public static int EscribeCarros(ArrayList Carros_X_e_Y)
        {
            int Resulta = 0;
            const string fic = @"C:\comander\carros.txt";

            StreamWriter sw = new StreamWriter(fic);
            string strComentario = "# example carros.txt file," + '\u000A' + "# the file has #Ncarros lines,each one with latitude/longitude in UTMS format";
            string strXeY = "";
            //sw.WriteLine(strXeY);
            //sw.WriteLine("# the file has #Ncarros lines,each one with latitude/longitude in UTMS format");

            for (int c = 0; c < Carros_X_e_Y.Count; c++)
            {
                //string strXeY = "\n"+Carros_X_e_Y[c].ToString();
                strXeY += '\u000A' + Carros_X_e_Y[c].ToString();
                
            }
            sw.WriteLine(strComentario + strXeY + '\u000A');
            sw.Close();

            //MessageBox.Show("Archivo Carros Creado...", "GEObit", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            return Resulta;
        }

        // ### Crea Carros_Log
        public static int EscribeCarros_Log(string strExpediente, ArrayList Carros_X_e_Y)
        {
            int Resulta = 0;
            string fic = @"C:\comander\ZeusLog_Parametros\" + strExpediente + @"_Carros.txt";
            //const string fic = @"C:\comander\ZeusLog_Parametros\" + strExpediente + @"_Carros.txt";
            

            StreamWriter sw = new StreamWriter(fic);
            string strComentario = "# example carros.txt file," + '\u000A' + "# the file has #Ncarros lines,each one with latitude/longitude in UTMS format";
            string strXeY = "";
            //sw.WriteLine(strXeY);
            //sw.WriteLine("# the file has #Ncarros lines,each one with latitude/longitude in UTMS format");

            for (int c = 0; c < Carros_X_e_Y.Count; c++)
            {
                //string strXeY = "\n"+Carros_X_e_Y[c].ToString();
                strXeY += '\u000A' + Carros_X_e_Y[c].ToString();

            }
            sw.WriteLine(strComentario + strXeY + '\u000A');
            sw.Close();

            //MessageBox.Show("Archivo Carros Creado...", "GEObit", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            return Resulta;
        }



        public static int EscribeLog(string strNom, string strGrupo, ArrayList RankingList, ArrayList IdCarro, ArrayList IdCia)
        {
            int Resulta = 0;
            string fic = @"C:\comander\ZeusLog_Ranking\" + strNom + @"_" + strGrupo + @".txt";

            StreamWriter sw = new StreamWriter(fic);
            string strComentario = " Ranking # Id_Carro # Id_Compañia";
            string strXeY = "";
            sw.WriteLine(strComentario);

            for (int c = 0; c < RankingList.Count; c++)
            {
                string strRan = RankingList[c].ToString();
                string strIdCar = IdCarro[c].ToString();
                string strIdCia = IdCia[c].ToString();
                sw.WriteLine(strRan + "  #  " + strIdCar + "  #  " + strIdCia);
            }
            sw.Close();
            return Resulta;
        }



        private static ArrayList LeeRankingGeneral()
        {
            //StreamReader objReader = new StreamReader(@"C:\comander\Ranking2.txt");
            StreamReader objReader = new StreamReader(@"C:\comander\ranking.txt");
            
            string sLine = "";
            ArrayList Rkg = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    Rkg.Add(sLine);
            }
            objReader.Close();
            //System.IO.File.Delete(@"C:\comander\ranking.txt");
            //System.IO.File.Delete(@"C:\comander\parametros.txt");
            //System.IO.File.Delete(@"C:\comander\carros.txt");
            return Rkg;
        }

        public static int ObtieneCiaDelAreaPeriferica(int id_exp)
        {
            var exp = new e_expedientes();
            exp = exp.getObjecte_expedientes(id_exp);
            int idArea = exp.id_area;

            int CiaDelArea = 0;
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT cia_periferica FROM k_areas WHERE id_area = " + idArea + "";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_lcu in myResult.Tables[0].Rows)
                {
                    CiaDelArea = Convert.ToInt32(r_lcu["cia_periferica"].ToString());
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return CiaDelArea;
        }

        public static bool DisponiblesConDistintoConductor(int id_compania, int id_grupo)
        {
            bool Considera = false;
            int idCarro;
            int idConductor;
            ArrayList ConductoresList = new ArrayList();
            
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT id_carro, estado, id_conductor FROM z_carros " +
                "WHERE id_carro IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + id_grupo + ") " +
                "AND id_compania = " + id_compania + " AND (estado = 1 OR estado = 5)";

            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_lcu in myResult.Tables[0].Rows)
                {
                    idCarro = Convert.ToInt32(r_lcu["id_carro"].ToString());
                    idConductor = Convert.ToInt32(r_lcu["id_conductor"].ToString());
                    ConductoresList.Add(idConductor);
                }

                if (ConductoresList.Count > 1)
                {
                    if (ConductoresList[0].ToString() != ConductoresList[1].ToString())
                    {
                        Considera = true;
                    }
                    else
                    {
                        Considera = false;
                    }
                }
                else
                {
                    Considera = false;
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return Considera;
        }



        //# Verificar si se deben Excluir compañias vecinas con la especialidad de Rescate
        public static bool ExcluirCompañiaVecina(int idLlamado, int id_cia_1, int id_cia_2, int id_conductor_2)
        {
            bool Considera = false;
            int idCarro;
            int idConductor = 0;
            ArrayList ConductoresList = new ArrayList();

            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT count(id_llamado) FROM x_excluye " +
            "WHERE id_llamado = " + idLlamado + " AND cia_1 = " + id_cia_1 + " AND cia_2 = " + id_cia_2 + "";  

            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_lcu in myResult.Tables[0].Rows)
                {
                    idConductor = Convert.ToInt32(r_lcu[0].ToString());
                    //ConductoresList.Add(idConductor);
                }

                if (idConductor == 0)
                {
                    Considera = true;   //# No hay relación Id_Llamado v/s Compañías  
                }
                else
                {
                    //# Determinar Conductores por Carro
                    if (MismoConductorRoB(id_cia_2, id_conductor_2))
                    {
                        Considera = true;
                    }
                    else
                    {
                        Considera = false;
                    }
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return Considera;
        }

        //# Verifica si un conductor está asignado a más de un Carro
        public static bool MismoConductorRoB(int id_compania, int id_conductor)
        {
            bool Considera = false;
            int idCarro;
            int idConductor = 1;
            ArrayList ConductoresList = new ArrayList();

            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT count(id_carro) FROM z_carros " +
            "WHERE id_conductor = " + id_conductor + " AND id_compania = " + id_compania + " AND (estado = 1 OR estado = 5) " +
            "AND (id_tipo_carro = 1 OR id_tipo_carro = 2 OR id_tipo_carro = 5 OR id_tipo_carro = 6)";

            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_lcu in myResult.Tables[0].Rows)
                {
                    idConductor = Convert.ToInt32(r_lcu[0].ToString());
                    //ConductoresList.Add(idConductor);
                }

                if (idConductor == 1)
                {
                    Considera = true;
                }
                else
                {
                    Considera = false;
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return Considera;
        }


    }
}