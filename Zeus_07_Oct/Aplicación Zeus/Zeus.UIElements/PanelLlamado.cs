using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;
using System.Collections;



namespace Zeus.UIElements
{
    public partial class PanelLlamado : BaseControl
    {
        private int id_area;
        private int id_expediente;
        private int id_expediente_asignado;
        string fecha_registro;
        string[] arreglo_1;
        string[] arreglo_2;
        string hora_decimal;
        int bloque_hora = 0;

        public PanelLlamado()
        {
            InitializeComponent();
        }

        public void MostrarInfo(int idExpediente)
        {
            id_expediente = idExpediente;
            var exp = new e_expedientes();
            try
            {
                exp = exp.getObjecte_expedientes(idExpediente);
                // expediente
                id_area = exp.id_area;
                informacionExpediente1.Expediente = exp;
                RecursosEstaticos.IdExpediente = exp.id_expediente;

                // oficial a cargo
                if (exp.id_voluntario != 0)
                {
                    z_cargos cargo = new z_cargos().getObjectz_cargos(exp.id_voluntario);
                    var vol = new z_voluntarios();
                    vol = vol.getObjectz_voluntarios(exp.id_voluntario);
                    btnACargo.Text = cargo.id_voluntario != 0 ? cargo.llamado_oficial.ToString() : vol.num_llamado.ToString();
                }
                else
                {
                    btnACargo.Text = "Ninguno";
                }

                // frecuencia
                e_frecuencias freq = new e_frecuencias().getObjecte_frecuencias(exp.id_frecuencia);
                btnFrecuencia.Text = freq.frecuencia;
                btnFrecuencia.BackColor = Color.FromArgb(freq.color);

                if (id_expediente_asignado == idExpediente)
                {
                    btnDespachar.Blink = true;
                    id_expediente_asignado = 0;
                }
                else
                {
                    btnDespachar.Blink = false;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        public void OnAsignacionHandler(DataEventArgs e)
        {
            id_expediente_asignado = e.Id;
        }

        private void btnDespachar_Click(object sender, EventArgs e)
        {
            DatosLogin.InvokeTwitter = "FT1";
            Cursor.Current = Cursors.WaitCursor;
            var exp = new e_expedientes();
            var llam = new z_llamados();
            string sindesp = "";

            try
            {
                exp = exp.getObjecte_expedientes(id_expediente);
                llam = llam.getObjectz_llamados(exp.codigo_principal);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }

            bloque_hora = recIDHORA();

            string NuevoBloque = Convert.ToString(bloque_hora);


            // ################################
            // ### Coordenadas para Twitter ###
            // ################################
            string strTw_X = (Math.Truncate(exp.puntoX)).ToString();
            string strTw_Y = (Math.Truncate(exp.puntoY)).ToString();
            string strLatLong = exp.Utm_2_LatLong(strTw_X, strTw_Y);
            string strURL = "https://maps.google.cl/maps?q=";
            string strZOOM = "&t=m&z=17";
            string strPlano = strURL + strLatLong + strZOOM;

            // ### Agregar en el expediente el link del Plano
            exp.AgregarPlanoTwitter(id_expediente, strPlano);

            // ### Agregar en el expediente las coordenadas Lat Long
            exp.AgregarLatLongWeb(id_expediente, strLatLong);



            if (exp.id_area != 0)
            {
                // verificar si es despacho normal o despacho de incendio 
                List<int> id_carros = Despacho.ranking(id_expediente, id_area, bloque_hora);
                //List<int> id_carros = Despacho.Despachar(id_expediente, id_area);


                //##################################
                //### Módulo Agregar B en 10-3-1 ###
                //##################################
                var DxD = new DespachoPorDistancia();
                int IdMM = DxD.LlamadoEnRadioDeCia(id_expediente);
                if (IdMM > 0)
                {
                    //### Despachar Carro si esta Disponible
                    int intCarro26 = DespachoPorDistancia.DespachoPorDosSeis(IdMM);
                    if (intCarro26 > 0)
                    {
                        id_carros.Add(intCarro26);
                    }
                }



                // ### Si no hay carros, no se muestra la ventana de preparar despacho.
                // ### Esto ocurre porque para la intersección ingresada, Commander no 
                // ### entrego un Ranking valido (todos los carros tienen Ranking = 1).
                if (id_carros.Count > 0)
                {
                    var cd = new ConfirmarDespacho
                    {
                        IdCarros = id_carros,
                        IdExpediente = id_expediente,
                        IdArea = id_area
                    };
                    cd.lblSinDesp.Text += "\n" + sindesp;


                    // ****** 

                    // ******************

                    cd.ShowDialog();
                    btnDespachar.Blink = false;
                    ZeusWin.Actualizar();                
                }

            }
            else
            {
                var id_carros = new List<int>();
                var cd = new CarroDisponible { IdCarros = id_carros };
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    Despacho.ConfirmarDespacho(id_carros, id_expediente);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        public ArrayList Un_Carro_X_Clave_All(int id_grupo, int bloque, int id_expediente)
        {
            Cursor.Current = Cursors.WaitCursor;
            var exp = new e_expedientes();
            var llam = new z_llamados();
            int id_carro_tip = 0;
            string sindesp = "";
            ArrayList list_carros_alist = new ArrayList();

            try
            {
                exp = exp.getObjecte_expedientes(id_expediente);
                llam = llam.getObjectz_llamados(exp.codigo_principal);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }

            if (exp.id_area != 0)
            {
                // Obtener el ID de Carro Según Grupo Solicitado 
                list_carros_alist = Despacho.Ranking_x_Claves_All(exp.id_expediente, id_grupo.ToString(), bloque);
                // List<int> id_carros = llam.incendio ? Despacho.DespacharBatallon(id_expediente, id_area, llam.codigo_llamado - 50, out sindesp) : Despacho.Despachar(id_expediente, id_area);



                /*
                var cd = new ConfirmarDespacho
                {
                    IdCarros = id_carros,
                    IdExpediente = id_expediente,
                    IdArea = id_area
                };
                cd.lblSinDesp.Text += "\n" + sindesp;

                // ****** 

                // ******************

                cd.ShowDialog();
                btnDespachar.Blink = false;
                ZeusWin.Actualizar();

            }
            else
            {
                var id_carros = new List<int>();
                var cd = new CarroDisponible { IdCarros = id_carros };
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    Despacho.ConfirmarDespacho(id_carros, id_expediente);
                }
            }
            Cursor.Current = Cursors.Default;
            */

            }
            return list_carros_alist;

        }


        public int Un_Carro_X_Clave(int id_grupo, int bloque, int id_expediente)
        {
            Cursor.Current = Cursors.WaitCursor;
            var exp = new e_expedientes();
            var llam = new z_llamados();
            int id_carro_tip = 0;
            string sindesp = "";

            try
            {
                exp = exp.getObjecte_expedientes(id_expediente);
                llam = llam.getObjectz_llamados(exp.codigo_principal);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }

            if (exp.id_area != 0)
            {
                // Obtener el ID de Carro Según Grupo Solicitado 
                id_carro_tip = Despacho.Ranking_x_Claves(exp.id_expediente, id_grupo.ToString(), bloque);
                // List<int> id_carros = llam.incendio ? Despacho.DespacharBatallon(id_expediente, id_area, llam.codigo_llamado - 50, out sindesp) : Despacho.Despachar(id_expediente, id_area);



                /*
                var cd = new ConfirmarDespacho
                {
                    IdCarros = id_carros,
                    IdExpediente = id_expediente,
                    IdArea = id_area
                };
                cd.lblSinDesp.Text += "\n" + sindesp;

                // ****** 

                // ******************

                cd.ShowDialog();
                btnDespachar.Blink = false;
                ZeusWin.Actualizar();

            }
            else
            {
                var id_carros = new List<int>();
                var cd = new CarroDisponible { IdCarros = id_carros };
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    Despacho.ConfirmarDespacho(id_carros, id_expediente);
                }
            }
            Cursor.Current = Cursors.Default;
            */

            }
            return id_carro_tip;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Desea cerrar este expediente?", "Confirmar Cierre", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                // liberar empresas
                var rec = new e_recursos_empresas();
                e_expedientes expediente = new e_expedientes();
                expediente.limpiarTablaZcarrosLlamado(id_expediente);
                rec.freee_recursos_empresas(id_expediente);

                // liberar carros
                var carros = new e_carros_usados();
                DataSet ds = carros.Gete_carros_exp(id_expediente);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    carros.freee_carros_usados((int) dr["id_carro"]);
                    Carro.Liberar((int) dr["id_carro"]);
                    BitacoraLlamado.NuevoEvento(id_expediente, (int) dr["id_carro"],
                                                BitacoraLlamado.Carro, "6-10");
                }
                // cerrar
                var exp = new e_expedientes();
                exp = exp.getObjecte_expedientes(id_expediente);
                exp.activo = false;
                exp.Update(exp);
                BitacoraLlamado.NuevoEvento(id_expediente, 0, BitacoraLlamado.Llamado,
                                            "Cierre de Expediente");
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btn62_Click(object sender, EventArgs e)
        {
            var cd = new ConfirmarDespacho
                         {
                             IdCarros = new List<int>(),
                             IdExpediente = id_expediente,
                             IdArea = id_area,
                             Agregando = true
                         };
            cd.ShowDialog();
            ZeusWin.Actualizar();
        }

        private void btn1Bat_Click(object sender, EventArgs e)
        {
            try
            {

                btn1FRM btn1frm = new btn1FRM();
                btn1frm.IdArea = id_area;
                btn1frm.IdExpediente = id_expediente;
                if (MessageBox.Show(
"La Alarma se activó de manera accidental ?", "Confirmar Alarma de Incendio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    if (btn1frm.ShowDialog() == DialogResult.OK)
                    {

                    }
                }

                /*string sindesp;
                List<int> id_carros = Despacho.DespacharBatallon(id_expediente, id_area, 1, out sindesp);
                var cd = new ConfirmarDespacho
                             {
                                 IdCarros = id_carros,
                                 IdExpediente = id_expediente,
                                 IdArea = id_area
                             };
                cd.lblSinDesp.Text += "\n" + sindesp;
                cd.Batallon = 1;
                cd.ShowDialog();*/
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btn2Bat_Click(object sender, EventArgs e)
        {
            try
            {
                string sindesp;
                List<int> id_carros = Despacho.DespacharBatallon(id_expediente, id_area, 2, out sindesp);
                var cd = new ConfirmarDespacho
                             {
                                 IdCarros = id_carros,
                                 IdExpediente = id_expediente,
                                 IdArea = id_area
                             };
                cd.lblSinDesp.Text += "\n" + sindesp;
                cd.Batallon = 2;
                cd.ShowDialog();

                // verificar cubrir cuarteles
                if (cd.DialogResult == DialogResult.OK)
                {
                    
#if !CBQN
                    int compania;
                    z_carros carro = Despacho.BuscarCubrirCuartel(id_area, out compania);
                    if (carro.id_carro != 0)
                    {
                        // confirmar
                        if (MessageBox.Show("El carro " + carro.nombre + " puede cubrir cuartel.\n¿Desea activar Cubrir Cuartel?", "Cubrir Cuarteles", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // cubrir cuartel
                            Carro.CubrirCuartel(carro, compania);
                            BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval, "0-11: Carro " + carro.nombre + " cubre cuartel " + compania + " compañía");
                        }
                    }
#endif
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btn3Bat_Click(object sender, EventArgs e)
        {
            try
            {
                string sindesp;
                List<int> id_carros = Despacho.DespacharBatallon(id_expediente, id_area, 3, out sindesp);
                var cd = new ConfirmarDespacho
                             {
                                 IdCarros = id_carros,
                                 IdExpediente = id_expediente,
                                 IdArea = id_area
                             };
                cd.lblSinDesp.Text += "\n" + sindesp;
                cd.Batallon = 3;
                cd.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btn4Bat_Click(object sender, EventArgs e)
        {
            try
            {
                string sindesp;
                List<int> id_carros = Despacho.DespacharBatallon(id_expediente, id_area, 4, out sindesp);
                var cd = new ConfirmarDespacho
                             {
                                 IdCarros = id_carros,
                                 IdExpediente = id_expediente,
                                 IdArea = id_area
                             };
                cd.lblSinDesp.Text += "\n" + sindesp;
                cd.Batallon = 4;
                cd.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnFrecuencia_Click(object sender, EventArgs e)
        {
            var f = new Frecuencia();
            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    e_expedientes exp = new e_expedientes().getObjecte_expedientes(id_expediente);
                    e_frecuencias freq = new e_frecuencias().getObjecte_frecuencias(f.Id_frecuencia);
                    btnFrecuencia.Text = freq.frecuencia;
                    btnFrecuencia.BackColor = Color.FromArgb(freq.color);
                    exp.id_frecuencia = f.Id_frecuencia;
                    exp.Update(exp);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btn67_Click(object sender, EventArgs e)
        {
            try
            {
                e_expedientes exp = new e_expedientes().getObjecte_expedientes(id_expediente);
                exp.sit_controlada = true;
                exp.Update(exp);
                ZeusWin.Actualizar();
                MessageBox.Show("Incendio finalizado a las " + DateTime.Now.ToShortTimeString() + " horas",
                                "Mensaje de Zeus");
                BitacoraLlamado.NuevoEvento(id_expediente, 0, BitacoraLlamado.Carro,
                                            "Finalización de Incendio");
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btn5bat_Click(object sender, EventArgs e)
        {
            btn5FRM btnfrm5 = new btn5FRM();
            btnfrm5.IdExpediente = id_expediente;
            btnfrm5.IdArea = id_area;
            if (MessageBox.Show(
"La Alarma se activó de manera accidental ?", "Confirmar Alarma de Incendio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                if (btnfrm5.ShowDialog() == DialogResult.OK)
                {

                }
            }

            /*List<int> carros = Despacho.DespacharTodo();
            var cd = new ConfirmarDespacho {IdArea = id_area, IdExpediente = id_expediente, IdCarros = carros, AlarmaGeneral = true};
            cd.ShowDialog();*/
        }

        private void btn71_Click(object sender, EventArgs e)
        {
            var inf = new Info71 {Id_expediente = id_expediente};
            inf.ShowDialog();
        }

        private void btnExterno_Click(object sender, EventArgs e)
        {
            IPlugin agenda = ZeusWin.GetPluginActivo("Agenda Geográfica");
            if (agenda != null)
            {
                agenda.GetButton().PerformClick();
            }
            else
            {
                MessageBox.Show("El módulo GeoAgenda no está activado.", "Mensaje de ZEUS");
            }
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            IPlugin depto = ZeusWin.GetPluginActivo("Solicitud de Inspectores y Ayudantes Generales");
            if (depto != null)
            {
                depto.GetButton().PerformClick();
            }
            else
            {
                MessageBox.Show("El módulo AgendaDepartamentos no está activado.", "Mensaje de ZEUS");
            }
        }

        private void btnACargo_Click(object sender, EventArgs e)
        {
            var oc = new OficialCargo {IdExpediente = id_expediente};
            if (oc.ShowDialog() == DialogResult.OK)
            {
                btnACargo.Text = oc.NumLlamado.ToString();
            }
        }

        private void btnOtros_Click(object sender, EventArgs e)
        {
            var oe = new OtrosEventos {ZeusWin = ZeusWin};
            oe.ShowDialog();
        }

/*
        private void btnClave_Click(object sender, EventArgs e)
        {
            var c = new Claves();
            e_expedientes exp = new e_expedientes().getObjecte_expedientes(id_expediente);
            c.codigo_principal = exp.codigo_principal;
            c.codigo_llamado = exp.codigo_llamado;
            if (c.ShowDialog() == DialogResult.OK)
            {
                exp.codigo_llamado = c.codigo_llamado;
                exp.codigo_principal = c.codigo_principal;
                exp.Update(exp);
            }
        }
*/

        private void PanelLlamado_Load(object sender, EventArgs e)
        {
            try
            {
                informacionExpediente1.ComunasDataSource = new k_comuna().Getk_comuna().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }

            // establecer elementos para CBQN
#if CBQN
            btn3Bat.Dispose();
            btn4Bat.Dispose();
            btn5bat.Dispose();
            tableLayoutPanel5.RowCount = 5;
            btn1Bat.Text = "Inc. Estructural";   //"Incendio"
            btn2Bat.Text = "Inc. Forestal";  //"Alarma General"
            // boton 2 es alarma ahora, transferir handler
            btn2Bat.Click -= btn2Bat_Click;
            btn2Bat.Click += btn5bat_Click;
#endif
        }

        private int recIDHORA()
        {
            int bloque = 0;
            
            //### Validar Día Feriado
            e_expedientes expB = new e_expedientes(); 
            if (expB.EsFeriado() == true)
            {
                bloque = 1;
            }
            else
            {
                try
                {

                    int id = 0;
                    e_expedientes exp = new e_expedientes(0, "", "", 0.0, "", "", false, 0.0, DateTime.Now, DateTime.Now, "", "", "", "", "", "", "", 0, 0, 0, false, 0, 0, "", "");
                    fecha_registro = informacionExpediente1.Controls["textFechaHoraAlarma"].Text;
                    arreglo_1 = fecha_registro.Split(' ');
                    arreglo_2 = arreglo_1[1].Split(':');
                    hora_decimal = arreglo_2[0].ToString() + "." + arreglo_2[1].ToString() + arreglo_2[2].ToString();
                    bloque = exp.recuperarIDHoraDLL(hora_decimal);

                }
                catch (Exception exe)
                {

                }

                //catch (Exception myErr)
                //{
                //    throw (new Exception(myErr.ToString() + reqSQL));
                //}
            }
            return bloque;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAf.Checked)
            {
                btn2Bat.Visible = true;
                chkAf.Checked = true;
            }
            else
            {
                btn2Bat.Visible = false;
                chkAf.Checked = false;
            }
        }
    }
}