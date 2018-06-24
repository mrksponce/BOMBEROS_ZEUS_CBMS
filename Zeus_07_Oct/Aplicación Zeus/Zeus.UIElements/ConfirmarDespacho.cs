using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;
using System.Drawing;
using System.Collections;
using System.Linq;
using Newtonsoft.Json;
using System.IO;



namespace Zeus.UIElements
{
    public partial class ConfirmarDespacho : Form
    {
        private bool confirmado;
        private z_carros carros = new z_carros();
        private e_expedientes exp = new e_expedientes();
        private Twitter twitt = new Twitter();

        public ConfirmarDespacho()
        {
            InitializeComponent();
        }

        public List<int> IdCarros { get; set; }
        public int IdExpediente { get; set; }
        public int IdArea { get; set; }
        public int Batallon { get; set; }
        public bool Agregando { get; set; }
        public bool AlarmaGeneral { get; set; }

        private void btnDespachar_Click(object sender, EventArgs e)
        {
            //### Confirmar si hay Carros para Despachar
            if (IdCarros.Count > 0)
            {
                z_carros carros = new z_carros();
                exp = exp.getObjecte_expedientes(IdExpediente);

                DatosLogin.LogPrimerDespacho = false;

                //### Sólo Si es el Primer Despacho, Actualiza la Hora del Expediente.
                if (exp.material_despachado == "")
                {
                    exp.ActualizarFechaExpediente(IdExpediente);
                    DatosLogin.LogPrimerDespacho = true;
                }

                //### Asigna el Estado NOTEMPORAL a los Carros que se Despacharán.
                for (int a = 0; a < IdCarros.Count; a++)
                {
                    carros.actualizarZcarrosLlamadoEspecifico(IdCarros[a], IdExpediente);
                }


                if (confirmado)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                try
                {
                    if (AlarmaGeneral)
                    {
                        Despacho.ConfirmarDespacho(IdCarros, IdExpediente, true);
                    }
                    else
                    {
                        if (Batallon != 0)
                        {
                            Despacho.ConfirmarDespacho(IdCarros, IdExpediente, Batallon);
                        }
                        else
                        {
                            Despacho.ConfirmarDespacho(IdCarros, IdExpediente);
                        }
                    }
                    confirmado = true;
                    btnDespachar.Text = "Cerrar";
                    btnAgregar.Enabled = false;
                    btnCancelar.Enabled = false;

                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }

                //### Asigna la Hora de 6-0 a los Carros Despachados
                for (int i = 0; i < IdCarros.Count; i++)
                {
                    BitacoraLlamado.NuevoEvento(exp.id_expediente, IdCarros[i],
                                                        BitacoraLlamado.Carro,
                                                        "6-0");
                }


                string StIdCarro = "";
                string StIdConductor = "";
            
                string CDString = "";
                string CDStringFinal = "";
                for (int x = 0; x < IdCarros.Count; x++)
                {
                    CDString += carros.ObtenerNombreCarro(IdCarros[x]) + ",";

                    carros = carros.getObjectz_carros(IdCarros[x]);
                    StIdCarro += carros.id_carro + ",";
                    StIdConductor += carros.id_conductor + ",";

                }
                CDString += "#";
                CDStringFinal = CDString.Replace(",#", "");

                StIdCarro += "#";
                StIdCarro = StIdCarro.Replace(",#", "");
                StIdConductor += "#";
                StIdConductor = StIdConductor.Replace(",#", "");





                int TipoTw = 2; //### Para Despachos debe ser Valor 2


                //############################################################
                //### Insertar Servicio por Carro Despachado JSON MULTIPLE ###
                //############################################################
                //                 public z_servicio(int id_carro, DateTime fecha, int estado, int id_conductor, string motivo_fuera_servicio)
                //z_servicio servicio = new z_servicio(99, System.DateTime.Now, 4, 99, "Despacho de carros: Se genera el despacho de los carros " + CDStringFinal + "");
                //servicio.Insert(servicio);
                //string strIdCarros, string strIdConductores, string strCarros
            
                //### Insert Multiple en Z_SERVICIOS
                z_servicio servicio = new z_servicio();
                servicio.InsertMultiple(StIdCarro, StIdConductor, CDString);

                //### JSON Multiple en servicio
                if (carros.GetParametroPrioridad(6) == "TRUE")
                {
                    JsonServicioClaves jsc = new JsonServicioClaves();
                    jsc.JsonServicioHoraMultipleJSON(StIdCarro, 4, StIdConductor, "En Acto", "Azul", false);

                    //### Actualiz Todos los Carros   :)
                    jsc.JsonServicioHoraMultipleJSON_TodosLosCarros();
                }




                //###########################
                //### Publicar en Twitter ###
                //###########################
                if (carros.GetParametroPrioridad(1) == "TRUE")
                {
                    if (CDStringFinal != "#")
                    {
                        System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                        proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                        proceso.StartInfo.Arguments = TipoTw.ToString() + " " + IdExpediente.ToString() + " " + DatosLogin.InvokeTwitter.ToString() + " " + CDStringFinal;
                        proceso.StartInfo.CreateNoWindow = true;
                        proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        proceso.Start();
                    }
                }







                //#################
                //### App VIPER ###
                //#################
                var llam = new z_llamados();
                llam = llam.getObjectz_llamados(exp.codigo_llamado);


                //############################
                //### Producción CBMS ########
                //############################
                //# ID Usuario
                string text3 = "\"uEpZYQpJz2;"; //"\"6jD2ex00SN;";
                //# Password
                text3 += "M29vzK1BEg;"; //"a057ldMhGm;";



                //# Expediente
                text3 += exp.id_expediente.ToString() + ";";
                //# Fecha
                text3 += exp.fecha.ToString() + ";";

                ////# Clave con 0-4 para 10-12
                //if (llam.clave.ToString() == "10-12")
                //{
                //    text3 += llam.clave.ToString() + " A " + exp.cero4_10_12.ToString() + ";";
                //}
                //else
                //{
                    text3 += llam.clave.ToString() + ";";
                //}

                //# Calle
                text3 += exp.seis2.ToString() + ";";
                //# Esquina
                text3 += exp.cero5.ToString() + ";";
                //# Carros    
                text3 += CDStringFinal + ";";
                //# ID Area
                text3 += exp.id_area.ToString() + ";";
                //# Comuna
                text3 += exp.comuna.ToString() + ";";
                //# O-4
                text3 += exp.OrigenAlamarma.ToString() + ";";
                //# Latitud
                string[] array = exp.e_lat_long.ToString().Split(',');
                text3 += array[0].ToString() + ";";
                //# Longitud
                text3 += array[1].ToString() + ";";
                //# Incendio
                if (DatosLogin.InvokeTwitter == "FT1")
                {
                    text3 += "";
                }

                //if (DatosLogin.InvokeTwitter == "FT2")
                //{
                //    int intPrincipal = Convert.ToInt32(exp.codigo_principal.ToString());
                //    if (intPrincipal > 49)
                //    {
                //        text3 += "SALE A INCENDIO ";
                //    }
                //    else
                //    {
                //        text3 += "SALE";
                //    }
                //}

                ////### Incendios Estructural
                //if (DatosLogin.InvokeTwitter == "FT3")
                //{
                //    text3 += "INCENDIO";
                //}

                //if (DatosLogin.InvokeTwitter == "FT4")
                //{
                //    text3 += "2da ALARMA DE INCENDIO";
                //}

                //if (DatosLogin.InvokeTwitter == "FT5")
                //{
                //    text3 += "3ra ALARMA DE INCENDIO";
                //}

                //if (DatosLogin.InvokeTwitter == "FT6")
                //{
                //    text3 += "4ta ALARMA DE INCENDIO";
                //}

                //if (DatosLogin.InvokeTwitter == "FT7")
                //{
                //    text3 += "5ta ALARMA DE INCENDIO";
                //}

                //if (DatosLogin.InvokeTwitter == "FT8")
                //{
                //    text3 += "6ta ALARMA DE INCENDIO";
                //}

                //if (DatosLogin.InvokeTwitter == "FT9")
                //{
                //    text3 += "7ma ALARMA DE INCENDIO";
                //}

                ////### Incendios Forestal
                //if (DatosLogin.InvokeTwitter == "FT3F")
                //{
                //    text3 += "INCENDIO FORESTAL";
                //}

                //if (DatosLogin.InvokeTwitter == "FT4F")
                //{
                //    text3 += "2da ALARMA FORESTAL";
                //}

                //if (DatosLogin.InvokeTwitter == "FT5F")
                //{
                //    text3 += "3ra ALARMA FORESTAL";
                //}

                //if (DatosLogin.InvokeTwitter == "FT6F")
                //{
                //    text3 += "4ta ALARMA FORESTAL";
                //}

                //if (DatosLogin.InvokeTwitter == "FT7F")
                //{
                //    text3 += "5ta ALARMA FORESTAL";
                //}

                //if (DatosLogin.InvokeTwitter == "FT8F")
                //{
                //    text3 += "6ta ALARMA FORESTAL";
                //}

                //if (DatosLogin.InvokeTwitter == "FT9F")
                //{
                //    text3 += "7ma ALARMA FORESTAL";
                //}



                if (DatosLogin.InvokeTwitter == "FT2")
                {
                    int intPrincipal = Convert.ToInt32(exp.codigo_principal.ToString());
                    if (intPrincipal > 49)
                    {
                        text3 += "SALE A BATALLON DE INCENDIO ";
                    }
                    else
                    {
                        text3 += "SALE";
                    }
                }

                //### Incendios Estructural
                if (DatosLogin.InvokeTwitter == "FT3")
                {
                    text3 += "1er BATALLON DE INCENDIO ";
                }

                if (DatosLogin.InvokeTwitter == "FT4")
                {
                    text3 += "2do BATALLON DE INCENDIO ";
                }

                if (DatosLogin.InvokeTwitter == "FT5")
                {
                    text3 += "3er BATALLON DE INCENDIO ";
                }

                if (DatosLogin.InvokeTwitter == "FT6")
                {
                    text3 += "4to BATALLON DE INCENDIO ";
                }

                if (DatosLogin.InvokeTwitter == "FT7")
                {
                    text3 += "5to BATALLON DE INCENDIO ";
                }

                if (DatosLogin.InvokeTwitter == "FT8")
                {
                    text3 += "6to BATALLON DE INCENDIO ";
                }

                if (DatosLogin.InvokeTwitter == "FT9")
                {
                    text3 += "7mo BATALLON DE INCENDIO ";
                }

                //### Incendios Forestal
                if (DatosLogin.InvokeTwitter == "FT3F")
                {
                    text3 += "INCENDIO FORESTAL";
                }

                if (DatosLogin.InvokeTwitter == "FT4F")
                {
                    text3 += "2da ALARMA FORESTAL";
                }

                if (DatosLogin.InvokeTwitter == "FT5F")
                {
                    text3 += "3ra ALARMA FORESTAL";
                }

                if (DatosLogin.InvokeTwitter == "FT6F")
                {
                    text3 += "4ta ALARMA FORESTAL";
                }

                if (DatosLogin.InvokeTwitter == "FT7F")
                {
                    text3 += "5ta ALARMA FORESTAL";
                }

                if (DatosLogin.InvokeTwitter == "FT8F")
                {
                    text3 += "6ta ALARMA FORESTAL";
                }

                if (DatosLogin.InvokeTwitter == "FT9F")
                {
                    text3 += "7ma ALARMA FORESTAL";
                }





                //# Terminar Argumento
                text3 += "\"";


                //### Chequear si esta habilitado VIPER
                if (carros.GetParametroPrioridad(2) == "TRUE")
                {
                    System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                    proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Viper\viper - Acceso directo";
                    proceso2.StartInfo.Arguments = text3;
                    proceso2.StartInfo.CreateNoWindow = true;
                    proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    proceso2.Start();

                 }








                //###########################
                //###   JSON Emergencia   ###
                //###########################
                //var llam = new z_llamados();
                //llam = llam.getObjectz_llamados(exp.codigo_llamado);
                string sector_r = exp.comuna.ToString().Replace("/", "-");
                string[] array2 = exp.e_lat_long.ToString().Split(',');
                //string CarrosSlach = CDStringFinal.Replace(",", "/");   //### NOMBRES de Carros
                string CarrosSlach = StIdCarro.Replace(",", "/");         //### ID de Carros

                string[] GetFechaHora = exp.fecha.ToString().Split(' ');

                JsonEmergencia emergencia = new JsonEmergencia();
                emergencia.expediente = exp.id_expediente.ToString();
                emergencia.correlativo = exp.correlativo.ToString();
                emergencia.fecha = GetFechaHora[0].ToString();
                emergencia.hora = GetFechaHora[1].ToString();
            
                emergencia.id_acto = exp.codigo_principal.ToString();
                emergencia.id_llamado = llam.codigo_llamado.ToString();
                emergencia.calle = exp.seis2.ToString().Replace("Ñ", "N");
                emergencia.casa = exp.casa.ToString();
                emergencia.block = exp.block.ToString();
                emergencia.piso = exp.Piso.ToString();
                emergencia.villa = exp.comuna.ToString().Replace("Ñ", "N");
                emergencia.area = exp.id_area.ToString();
                emergencia.comuna = exp.comuna_real.ToString().Replace("Ñ", "N");
                emergencia.esquina = exp.cero5.ToString();
                emergencia.carros = CarrosSlach.Replace("Ñ", "N");
                emergencia.casa = exp.casa.ToString();
                emergencia.esquina = exp.cero5.ToString().Replace("Ñ", "N");
                emergencia.quien_llama = exp.quien_llama.ToString().Replace("Ñ", "N");
                emergencia.telefono = exp.telefono.ToString();
                emergencia.estado = exp.activo.ToString();
                emergencia.operadora = DatosLogin.NomUsuario.ToString().Replace("Ñ", "N");
                emergencia.latitud = array2[0].ToString();
                emergencia.longitud = array2[1].ToString();
                //# Tono de Llamado
                string strTono = "";
                if (Batallon != 0)
                {
                    strTono = "1"; 
                    emergencia.acto = "BATALLON DE INCENDIO";
                }
                else
                {
                    strTono = new e_expedientes().Get_Id_Tono(exp.codigo_principal.ToString());
                    emergencia.acto = llam.clave.ToString();
                }
                emergencia.tono = strTono;

                //### Incluir Notificación ZEUS Alerta
                if (carros.GetParametroPrioridad(8).Equals("TRUE"))
                {
                    emergencia.mobile = true;
                }
                else
                {
                    emergencia.mobile = false;
                }

                string json = JsonConvert.SerializeObject(emergencia);
                string json_2 = json.Replace("\"", "%");
                string json_3 = json_2.Replace(" ", "?");

                if (carros.GetParametroPrioridad(6).Equals("TRUE"))
                {
                    System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                    proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Apolo\emergencias.py";
                    proceso2.StartInfo.Arguments = json_3.ToString();
                    proceso2.StartInfo.CreateNoWindow = true;
                    proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    proceso2.Start();
                    //MessageBox.Show(json_3, "Json ZEUS            :)");
                }

                //### Escribir JSON MultiPuestaServicio
                string fic = @"C:\ZEUS_CBMS\ZTablasApolo\JsonExpediente_" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
                StreamWriter sw = new StreamWriter(fic);
                sw.WriteLine("JSON Despacho ZEUS");
                sw.WriteLine("");
                sw.WriteLine(json_3);
                sw.Close();


            
                //######################## OJO
                //### Tonos Selectivos ### Agregar esta linea "using System.Linq;"
                //######################## para Distinct()
                string strParametros = "";
                if (Batallon > 0)
                {
                    //# Tono de Incendio
                    strParametros = "100,90,50";
                }
                else
                {
                    //# Tonos Selectivos
                    int[] IdCias = new int[IdCarros.Count];
                    for (int x = 0; x < IdCarros.Count; x++)
                    {
                        carros = carros.getObjectz_carros(IdCarros[x]);
                        IdCias[x] = carros.id_compania;
                    }
                    //# Ordenar y Eliminar Compañias Repetidas            
                    Array.Sort(IdCias);
                    //if (IdCias.Length > 1)
                    //{
                    //    IEnumerable<int> IdCiasUnico = IdCias.Distinct();
                    //}
                    //else
                    //{
                    //    IEnumerable<int> IdCiasUnico = IdCias;
                    //}


                    List<int> IdCiasUnico = new List<int>();
                    foreach (int i in IdCias)
                    {
                        if (!IdCiasUnico.Contains(i))
                        {
                            IdCiasUnico.Add(i);
                        }
                    }

                    //# Agrupa Tipo de Llamado
                    int ClavPrincipal = exp.codigo_principal; 
                    int TonoDelLlamado = 0;
                    if (EsLlamadoComandancia(ClavPrincipal))
                    {
                        TonoDelLlamado = 70;
                    }
                        if (EsRescate(ClavPrincipal))
                    {
                        TonoDelLlamado = 60;
                    }
                    if (EsOtrosServicios(ClavPrincipal))
                    {
                        TonoDelLlamado = 80;
                    }

                    //# Crear el String de Parámetro
                    foreach (int c in IdCiasUnico)
                    {
                        strParametros += c.ToString() + ","; 
                    }

                    strParametros = "99," + strParametros + TonoDelLlamado;
                } //Fin If

                //MessageBox.Show("ParamSelectivo:  " + strParametros, "Tonos ZEUS");
                //### Activar Tonos
                if (carros.GetParametroPrioridad(3).Equals("TRUE"))
                {
                    System.Diagnostics.Process proceso2 = new System.Diagnostics.Process();
                    proceso2.StartInfo.FileName = @"C:\ZEUS_CBMS\Tonos\TonosDesdeZeus.exe";
                    proceso2.StartInfo.Arguments = strParametros;
                    proceso2.StartInfo.CreateNoWindow = true;
                    proceso2.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    proceso2.Start();
                }

            } //# Fin IF Si hay Carros
            else
            {
                MessageBox.Show("No hay Carros Seleccionados para ser Despachados", "ZEUS");
            } //# Fin IF Si hay Carros
        }


        //### Es Llamado de Comandancia
        public static bool EsLlamadoComandancia(int IfLlCom)
        {
            return IfLlCom == 1 || IfLlCom == 2 || IfLlCom == 3 || IfLlCom == 6 || IfLlCom == 7 || IfLlCom == 8 || IfLlCom == 13 || IfLlCom == 11 || IfLlCom == 12 || IfLlCom == 14 || IfLlCom == 15 || IfLlCom == 16 || IfLlCom == 17;
        }

        //### Es Rescate
        public static bool EsRescate(int IfRec)
        {
            return IfRec == 4 || IfRec == 5;
        }

        //### Es Otros Servicios
        public static bool EsOtrosServicios(int IfOtrSer)
        {
            return IfOtrSer == 9 || IfOtrSer == 10;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Se debe hacer una limpieza de los carros al momento de cerrar la ventana, cosa de que cuando se habra n veses, estos siempre se inserten o se borren
            // esto evita que el tema de la resta falle siempre, al momento de confirmar el despacho los registros no pueden ser borrados.

            for (int i = 0; i < IdCarros.Count; i++)
            {
                carros.eliminarZcarrosLlamadoEspecifico(IdCarros[i], IdExpediente);
            }

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ConfirmarDespacho_Load(object sender, EventArgs e)
        {
            try
            {
                var exp = new e_expedientes();
                exp = exp.getObjecte_expedientes(IdExpediente);

                z_carros carro = new z_carros();



                // cargar datos

                var llam = new z_llamados();
                llam = llam.getObjectz_llamados(exp.codigo_llamado);
                // formatear texto
                lblClave.Text = "";
                // batallon?
                if (Batallon != 0)
                {
                    switch (Batallon)
                    {
                        case 1:
#if CBMS
                            lblClave.Text = "Sale Primer Batallón de Incendio.\n";
#elif CBQN
                            lblClave.Text = "Sale Incendio.\n";
#endif
                            break;
                        case 2:
#if CBMS
                            lblClave.Text = "Sale Segundo Batallón de Incendio.\n";
#elif CBQN
                            lblClave.Text = "Sale Alarma General.\n";
#endif
                            break;
                        case 3:
                            lblClave.Text = "Sale Tercer Batallón de Incendio.\n";
                            break;
                        case 4:
                            lblClave.Text = "Sale Cuarto Batallón de Incendio.\n";
                            break;
                    }
                }
                if (AlarmaGeneral)
                {
#if CBMS
                    // TODO: poner texto para alarma
#elif CBQN
                    lblClave.Text = "Sale Alarma General.\n";
#endif
                }
                if (Agregando)
                {

                    tableLayoutPanel1.SetRow(lblArea, 4);
                    tableLayoutPanel1.SetRow(lbl05, 3);
                    tableLayoutPanel1.SetRow(lblClave, 2);
                    tableLayoutPanel1.SetRow(tableCarros, 1);
                    tableLayoutPanel1.SetRow(lblExtra, 0);
                    lblExtra.Text = "Sale:";
                    lblClave.Text = "A: ";
                }

                lblClave.Text += llam.clave; // +" " + llam.descripcion;
                lbl05.Text = ToLower(exp.seis2 + " Y " + exp.cero5);

                //### Motrar Sector del Despacho
                string StrSector = exp.comuna;
                string AsTitleCase = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(StrSector.ToLower());

                lblArea.Text = "Área de Referencia " + exp.id_area + "\n\n" + AsTitleCase;
                MostrarCarros(exp.codigo_principal);

#if CBMS
                // consola
                axShockwaveFlash1.LoadMovie(0, Application.StartupPath + "\\Consola\\Consola.swf");
#elif CBQN
                int width = axShockwaveFlash1.Width;
                axShockwaveFlash1.Dispose();
                Width -= width;
#endif
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private static string ToLower(string s)
        {
            // la primera mayuscula y el resto minusculas
            string[] str = s.Split(' ');
            string ret = "";
            foreach (string st in str)
            {
                string temp;
                ret += " ";
                if (st.Length == 1)
                {
                    temp = st.ToLower();
                }
                else
                {
                    temp = st.Substring(0, 1).ToUpper() + st.Substring(1).ToLower();
                }
                ret += temp;
            }
            return ret.Trim();
        }

        private void MostrarCarros(int codigo_principal)
        {
            //-*- Asigna el ID de carro Cascada para pintar Amarillo.
            string val = "";

            //-*- Asigna el ID de Bomba que Alimenta Mecanica para pintar Rojo.
            string val2 = "";

            e_expedientes exp = new e_expedientes();
            exp = exp.getObjecte_expedientes(RecursosEstaticos.IdExpediente);

            ArrayList arrGrupoCarros = new ArrayList();
            arrGrupoCarros = StaticClass.ArrGrupoCarros;

            //-*- Para Ordenar los Carros
            List<z_carros>[] lista = OrdenarCarros();

            // HACK: 10-3 y 10-4 muestran R al inicio
            if ((codigo_principal == 5 || codigo_principal == 4) && Batallon == 0)
            {
                // insertar R al principio
                List<z_carros> l = lista[6];
                for (int i = 6; i > 0; i--)
                {
                    lista[i] = lista[i - 1];
                }
                lista[0] = l;
            }

            //-*- Pinta Color Amarillo Carros Con Cascada
            // 12 => H como Cascada
            // 20 => RH1 como Cascada
            // 21 => BX como Cascada
            // 22 => B como Cascada

            //### Pintar última Bomba si hay Mecánica
            string UltimaB = "";
            var GruposList = new List<string>();
            for (int x = 0; x < arrGrupoCarros.Count; x++)
            {
                string[] GrSplit = arrGrupoCarros[x].ToString().Split('/');
                GruposList.Add(GrSplit[1].ToString());
            }

            for (int a = 0; a < arrGrupoCarros.Count; a++)
            {
                string[] aaa = arrGrupoCarros[a].ToString().Split('/');
                if (aaa[1].ToString() == "224" || aaa[1].ToString() == "117" || aaa[1].ToString() == "119")
                {
                    val = aaa[0];
                }

                //# Si el despacho tiene Mecánica, queda guardado el ID de la Última Bomba
                if (GruposList.Contains("3") && aaa[1].ToString() == "1")
                {
                    UltimaB = aaa[0].ToString().ToString();
                }
            }

            // mostrar
            tableCarros.Controls.Clear();
            int contador = 1;
            for (int i = 0; i < lista.Length; i++)
            {
                if (vEstatica.Variable == 3)
                {
                    if (contador == 1)
                    {
                        var fl_despachados = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Fill };
                        fl_despachados.Controls.Add(new Label() { Text = exp.material_despachado, AutoSize = true, Dock = DockStyle.Fill });
                        tableCarros.Controls.Add(fl_despachados);
                        contador = 0;
                    }
                    vEstatica.Variable = 1;
                }

                //# Pintar Carros con Distinto Color
                Boolean SinColor = true;
                if (lista[i] != null)
                {
                    var fl = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Fill };
                    foreach (z_carros c in lista[i])
                    {
                        //# Pinta Cascada
                        if (c.id_carro.ToString() == val)
                        {
                            var cb = new CheckBox
                            {
                                Text = c.nombre,
                                AutoSize = true,
                                Appearance = Appearance.Button,
                                Tag = c.id_carro,
                                Checked = true,
                                BackColor = Color.Yellow
                            };
                            cb.CheckedChanged += cb_CheckedChanged;
                            fl.Controls.Add(cb);
                            SinColor = false;
                        }

                        //# Pintar Última Bomba
                        if (UltimaB == c.id_carro.ToString())
                        {
                            var cb = new CheckBox
                            {
                                Text = c.nombre,
                                AutoSize = true,
                                Appearance = Appearance.Button,
                                Tag = c.id_carro,
                                Checked = true,
                                BackColor = Color.Red
                            };
                            cb.CheckedChanged += cb_CheckedChanged;
                            fl.Controls.Add(cb);
                            SinColor = false;
                        }

                        //# Si No se Debe Pintar el Carro
                        if (SinColor)
                        {
                            var cb = new CheckBox
                            {
                                Text = c.nombre,
                                AutoSize = true,
                                Appearance = Appearance.Button,
                                Tag = c.id_carro,
                                Checked = true
                            };
                            cb.CheckedChanged += cb_CheckedChanged;
                            fl.Controls.Add(cb);
                        }
                        SinColor = true;

                    }
                    tableCarros.Controls.Add(fl);
                }
            }
            StaticClass.ArrGrupoCarros = new ArrayList();
        }

        private List<z_carros>[] OrdenarCarros()
        {
            int largo = new z_tipo_carro().getCantidad();
            var lista = new List<z_carros>[largo];
            var carro = new z_carros();

            // clasificar por tipo
            foreach (int i in IdCarros)
            {
                carro = carro.getObjectz_carros(i);
                int resto = carro.id_tipo_carro - 1;
                if (lista[resto] == null)
                {
                    lista[resto] = new List<z_carros>();
                }
                lista[resto].Add(carro);
            }

            // dejar el primero al frente, ordenar el resto por compañia ( *Deshabilitado )
            foreach (List<z_carros> l in lista)
            {
                if (l != null)
                {
                    //l.Sort(1, l.Count - 1, new z_carroComparer());
                }
            }

            return lista;
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            if (c != null)
            {
                int index = (c.Parent).Controls.GetChildIndex(c);

                if (c.Checked)
                {
                    // agregar el carro
                    IdCarros[index] = (int)c.Tag;
                }
                else
                {
                    // eliminar el carro
                    // MRKSPONCE: ELIMINAR CARROS DE LA LISTA.
                    Carro.Liberar((int)c.Tag);
                    z_carros carrosDelete = new z_carros();
                    carrosDelete.eliminarZcarrosLlamadoEspecifico((int)c.Tag, IdExpediente);
                    IdCarros.Remove((int)c.Tag);
                    (c.Parent).Controls.Remove((Control)sender);
                    ((Control)sender).Dispose();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var sc = new SolicitudCarros { Id_area = IdArea, IdCarros = IdCarros, Id_expediente = IdExpediente };
            sc.ShowDialog();
            MostrarCarros(0);
        }

        private void ConfirmarDespacho_FormClosed(object sender, FormClosedEventArgs e)
        {
            axShockwaveFlash1.Dispose();
            if (!confirmado)
            {
                //### Cancelar Despacho N°1
                Despacho.CancelarDespacho(IdCarros);
            }
        }

        private void ConfirmarDespacho_Shown(object sender, EventArgs e)
        {
            // agregando
            if (Agregando)
            {
                btnAgregar_Click(btnAgregar, new EventArgs());
            }
        }

        private void tableLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Height = tableLayoutPanel1.Height + 25;
            if (tableLayoutPanel1.Height > Height - 150)
            {
                Height = tableLayoutPanel1.Height + 160;
            }
            lblSinDesp.Top = groupBox1.Bottom + 10;
        }

        #region Nested type: z_carroComparer

        private class z_carroComparer : IComparer<z_carros>
        {
            #region IComparer<z_carros> Members

            public int Compare(z_carros x, z_carros y)
            {
                return x.id_compania.CompareTo(y.id_compania);
            }

            #endregion
        }

        #endregion


    }
}