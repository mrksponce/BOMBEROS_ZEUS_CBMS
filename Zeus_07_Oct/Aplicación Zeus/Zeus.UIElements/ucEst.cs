using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;
using Zeus.UIElements;
using System.Collections;


namespace Zeus.UIElements
{
    //public partial class ucEst : UserControl
    public partial class ucEst : BaseControl
    {
        public string NombreCarro { get; set; }
        public int IdCarro { get; set; }

        public ucEst()
        {
            InitializeComponent();
        }

        //private void ucEst_Load(object sender, EventArgs e)
        //{
        //    z_estado_carros ec = new z_estado_carros();
        //    z_conductores conductor = new z_conductores();
        //    z_carros carro = new z_carros();
        //    carro = carro.getObjectz_carros(NombreCarro);
        //    ec = ec.getObjectz_estado_carros(carro.estado);
        //    Image img = carro.getImagenByNombre(NombreCarro);
        //    pictureBox1.Image = img;
        //    conductor = conductor.getObjectz_conductores(carro.id_carro);
        //    txtOtro.Enabled = false;

        //    if (carro.estado == 1)
        //    {
        //        rbEnServicio.Checked = true;
        //        gbAsignarCarros.Visible = true;
        //    }

        //    if (carro.estado == 3)
        //    {
        //        lblDescEstado.Text = "Sin Conductor";
        //        rbSinConductor.Checked = true;
        //    }
        //    else
        //    {
        //        lblDescEstado.Text = ec.descripcion + ": " + carro.motivo_fuera_servicio;
        //    }

        //    if (carro.estado == 2 && carro.motivo_fuera_servicio.Contains("Eléctrico"))
        //    {
        //        rbfsElectrico.Checked = true;
        //    }
        //    else if (carro.estado == 2 && carro.motivo_fuera_servicio.Contains("Mecánico"))
        //    {
        //        rbfsMecanico.Checked = true;
        //    }
        //    else if (carro.estado == 2 && (!carro.motivo_fuera_servicio.Contains("Mecánico") || !carro.motivo_fuera_servicio.Contains("Eléctrico")))
        //    {
        //        rbfsOtro.Checked = true;
        //        txtOtro.Enabled = true;
        //        txtOtro.Text = carro.motivo_fuera_servicio;
        //    }

        //    lblDesConductor.Text = carro.id_conductor.ToString();
            
        //    if (conductor.GetNombreConductor(carro.id_conductor).Tables[0].Rows.Count == 0)
        //    {
        //        lblDesConductor.Text = "";
        //    }
        //    else
        //    {
        //        DataRow row = conductor.GetNombreConductor(carro.id_conductor).Tables[0].Rows[0];
        //        lblDesConductor.Text = row["nombre_voluntario"].ToString();
        //    }
            
        //    txtObservacion.Text = carro.Observacion2;
        //    lblIngresoOperadora.Text = carro.OpObservacion2;
        //    LlenarEnServicio();
        //}

        private void ucEst_Load(object sender, EventArgs e)
        {
            LlenarControles();
        }


        //### Llenar Controles
        public void LlenarControles()
        {
            z_estado_carros ec = new z_estado_carros();
            z_conductores conductor = new z_conductores();

            z_carros carro = new z_carros();

            //if (carro.GetParametroPrioridad(1) == "TRUE")
            //{
            //    checkBox1.Checked = true;
            //}
            //else
            //{
            //    checkBox1.Checked = false;
            //}

            //if (carro.GetParametroPrioridad(2) == "TRUE")
            //{
            //    checkBox2.Checked = true;
            //}
            //else
            //{
            //    checkBox2.Checked = false;
            //}

            carro = carro.getObjectz_carros(NombreCarro);
            ec = ec.getObjectz_estado_carros(carro.estado);
            
            //#f  Comentar estas Lineas y Agregar los IF
            //Image img = carro.getImagenByNombre(NombreCarro);
            //pictureBox1.Image = img;
            if (System.IO.File.Exists(carro.urlimagen))
            {
                pictureBox1.ImageLocation = carro.urlimagen == string.Empty ? @"C:\ZEUS\Resources\Carros\comodin.jpg" : carro.urlimagen;
            }
            else
            {
                pictureBox1.ImageLocation = @"C:\ZEUS\Resources\Carros\comodin.jpg";
            }
            
            conductor = conductor.getObjectz_conductores(carro.id_carro);
            txtOtro.Enabled = false;

            if (carro.estado == 1)
            {
                rbEnServicio.Checked = true;
                gbAsignarCarros.Visible = true;
            }

            if (carro.estado == 3)
            {
                //lblDescEstado.Text = "Sin Conductor";
                lblDescEstado.Text = "";
                rbSinConductor.Checked = true;
            }
            else
            {
                //lblDescEstado.Text = ec.descripcion + ": " + carro.motivo_fuera_servicio;
                lblDescEstado.Text = ec.descripcion;
            }

            if (carro.estado == 2 && carro.motivo_fuera_servicio.Contains("Eléctrico"))
            {
                rbfsElectrico.Checked = true;
            }
            else if (carro.estado == 2 && carro.motivo_fuera_servicio.Contains("Mecánico"))
            {
                rbfsMecanico.Checked = true;
            }
            else if (carro.estado == 2 && (!carro.motivo_fuera_servicio.Contains("Mecánico") || !carro.motivo_fuera_servicio.Contains("Eléctrico")))
            {
                rbfsOtro.Checked = true;
                txtOtro.Enabled = true;
                txtOtro.Text = carro.motivo_fuera_servicio;
            }


            //### Obtiene Tipo y Nombre de Conductor
            DataSet ds = new z_conductores().Getz_conductoresCarro(carro.id_carro);
            int id_tipo_coductor = 0;
            foreach (DataRow row2 in ds.Tables[0].Rows)
            {
                if ((int)row2["id_conductor"] == carro.id_conductor)
                {
                    id_tipo_coductor = (int)row2["id_tipo_conductor"];
                    break;
                }
            }
            lblDesConductor.Text = carro.id_conductor.ToString();
            if (conductor.GetNombreConductor(carro.id_conductor, id_tipo_coductor).Tables[0].Rows.Count == 0)
            {
                lblDesConductor.Text = "";
            }
            else
            {
                DataRow row = conductor.GetNombreConductor(carro.id_conductor, id_tipo_coductor).Tables[0].Rows[0];
                lblDesConductor.Text = row["nombre_voluntario"].ToString();
            }

            //### Muestra la Observación del Carro
            txtObservacion.Text = carro.Observacion2;
            //lblIngresoOperadora.Text = carro.OpObservacion2;
            
            //### Agregar Conductores Autorizados
            LlenarEnServicio();
        }

        //### Crea Lista de Conductores Autorizados
        private void LlenarEnServicio()
        {
            z_carros carro = new z_carros();
            carro = carro.getObjectz_carros(NombreCarro);
            DataSet ds = new z_conductores().Getz_conductoresCarro(carro.id_carro);

            gvDisponible.Rows.Clear();

            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                if ((bool)dr["disponible"] == false)
                {
                    gvDisponible.Rows.Add(dr["nombre_completo"].ToString(), "0");
                }
                else
                {
                    gvDisponible.Rows.Add(dr["nombre_completo"].ToString(), dr["id_conductor"].ToString());
                }


                if ((int)dr["id_tipo_conductor"] == 1)
                {
                    style.ForeColor = Color.Green;
                }
                else
                {
                    style.ForeColor = Color.Goldenrod;
                }

                // no disponible
                if ((bool)dr["disponible"] == false)
                {
                    gvDisponible.Rows[i].ReadOnly = true;
                    style.ForeColor = Color.Gray;
                    gvDisponible.Rows[i].DefaultCellStyle = style;
                    i++;
                }
                else
                {
                    gvDisponible.Rows[i].DefaultCellStyle = style;
                    i++;
                }
            }
        }

        private void lblDescEstado_Click(object sender, EventArgs e)
        {

        }


        //### Agregar una Observación de Carro
        private void button1_Click(object sender, EventArgs e)
        {
            z_carros carro = new z_carros();
            carro = carro.getObjectz_carros(NombreCarro);
            carro.ActualizarObservacionesCarros(txtObservacion.Text, DatosLogin.LoginUsuario.ToString(), carro.id_carro);
            lblIngresoOperadora.Text = DatosLogin.LoginUsuario.ToString();
            MessageBox.Show("Observación ingresada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rbfsOtro_CheckedChanged(object sender, EventArgs e)
        {
            txtOtro.Enabled = true;
        }

        private void rbfsElectrico_CheckedChanged(object sender, EventArgs e)
        {
            txtOtro.Enabled = false;
        }

        private void rbfsMecanico_CheckedChanged(object sender, EventArgs e)
        {
            txtOtro.Enabled = false;
        }


        //### 0-8
        private void button2_Click(object sender, EventArgs e)
        {
            //### JSON SERVICIO 2 = 0-8
            z_carros carro = new z_carros();
            carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
            JsonServicioClaves jsc = new JsonServicioClaves(carro.id_carro);
            

            //### Fuera de Servicio Electrico
            if (rbfsElectrico.Checked)
            {
                //### Hacer Click al 0-8
                btn_08.PerformClick();
                
                //z_carros carro = new z_carros();
                //carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                Carro.FueraServicio(carro.id_carro, rbfsElectrico.Text);
                //Estado = 2;
                BitacoraGestion.NuevoEvento(1, 1,
                                            "Carro: " + Text + " Fuera de Servicio (" + "Eléctrico" +
                                            ")");

                z_servicio servicio1 = new z_servicio(carro.id_carro, System.DateTime.Now, 2, carro.id_conductor, "Gestión M.M.: Carro " + RecursosEstaticos.NombreCarro + " fuera de servicio -> Eléctrico");
                servicio1.Insert(servicio1);

                lblDescEstado.Text = rbfsElectrico.Text;


                //### JSON SERVICIO 2 = 0-8
                if (carro.GetParametroPrioridad(6) == "TRUE")
                {
                    jsc.JsonServicioHora(carro.id_carro, 2, "", "0-8", "Rojo", true);
                }
            }


            //### Fuera de Servicio Mecánico
            if (rbfsMecanico.Checked)
            {
                //### Hacer Click al 0-8
                btn_08.PerformClick();

                //z_carros carro = new z_carros();
                //carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                Carro.FueraServicio(carro.id_carro, rbfsMecanico.Text);
                //Estado = 2;
                BitacoraGestion.NuevoEvento(1, 1,
                                            "Carro: " + Text + " Fuera de Servicio (" + "Mecánico" +
                                            ")");

                z_servicio servicio1 = new z_servicio(carro.id_carro, System.DateTime.Now, 2, carro.id_conductor, "Gestión M.M.: Carro " + RecursosEstaticos.NombreCarro + " fuera de servicio -> Mecánico");
                servicio1.Insert(servicio1);

                lblDescEstado.Text = rbfsMecanico.Text;

                //### JSON SERVICIO 2 =0-8
                if (carro.GetParametroPrioridad(6) == "TRUE")
                {
                    jsc.JsonServicioHora(carro.id_carro, 2, "", "0-8", "Rojo", true);
                }
            }


            //### Fuera de Servicio
            if (rbfsOtro.Checked)
            {
                //### Hacer Click al 0-8
                btn_08.PerformClick();

                //z_carros carro = new z_carros();
                //carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                Carro.FueraServicio(carro.id_carro, txtOtro.Text);
                //Estado = 2;
                BitacoraGestion.NuevoEvento(1, 1,
                                            "Carro: " + Text + " Fuera de Servicio (" + txtOtro.Text +
                                            ")");

                z_servicio servicio1 = new z_servicio(carro.id_carro, System.DateTime.Now, 2, carro.id_conductor, "Gestión M.M.: Carro " + RecursosEstaticos.NombreCarro + " fuera de servicio -> "+txtOtro.Text+"");
                servicio1.Insert(servicio1);

                lblDescEstado.Text = "Fuera de Servicio: " + txtOtro.Text;

                //### JSON SERVICIO 2 =0-8
                if (carro.GetParametroPrioridad(6) == "TRUE")
                {
                    jsc.JsonServicioHora(carro.id_carro, 2, "", "0-8", "Rojo", true);
                }
            }

            //### Fuera de Servicio SIN CONDUCTOR
            if (rbSinConductor.Checked)
            {
                //### Hacer Click al 0-8
                btn_08.PerformClick();

                //z_carros carro = new z_carros();
                //carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);

                Carro.SinConductor(carro.id_carro);
                //Carro.FueraServicio(carro.id_carro, "Sin Conductor.");
                BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, DatosLogin.LoginUsuario,
                                            "Carro: " + carro.nombre + " Sin coductor");

                z_servicio servicio1 = new z_servicio(carro.id_carro, System.DateTime.Now, 3, carro.id_conductor, "Gestión M.M.: Carro " + RecursosEstaticos.NombreCarro + " sin conductor");
                servicio1.Insert(servicio1);

                //MessageBox.Show("Sin conductor asignado" + RecursosEstaticos.NombreCarro, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //### JSON SERVICIO 2 =0-8
                if (carro.GetParametroPrioridad(6) == "TRUE")
                {
                    jsc.JsonServicioHora(carro.id_carro, 2, "", "0-8", "Amarillo", true);
                }
            }

            if (rbLiberarCarro.Checked)
            {
                // Preguntar antes de liberar
                if (
                    MessageBox.Show(
                        "'Liberar Carro' debe ser utilizado sólo como medida de emergencia, ¿Está seguro que desea liberar este carro?",
                        "Liberar Carro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {
                        //z_carros carro = new z_carros();
                        //carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                        // liberar carro
                        Carro.Liberar(carro.id_carro);
                        var cu = new e_carros_usados();
                        cu = cu.getObjecte_carros_usados(carro.id_carro);
                        cu.freee_carros_usados(cu.id_carro);

                        z_servicio servicio1 = new z_servicio(carro.id_carro, System.DateTime.Now, 1, carro.id_conductor, "Gestión M.M.: Carro " + RecursosEstaticos.NombreCarro + " liberado");
                        servicio1.Insert(servicio1);
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }

                lblEstadoCarro.Text = "En servicio";
            }

            MessageBox.Show("Carro "+RecursosEstaticos.NombreCarro+" " + lblDescEstado.Text + " asignado correctamente", "ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //private void gvDisponible_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string valor = gvDisponible.CurrentRow.Cells[1].Value.ToString();
        //    if (valor != "0")
        //    {
        //        // poner en servicio
        //        z_conductores conductor = new z_conductores();
        //        int id_conductor = Convert.ToInt32(gvDisponible.CurrentRow.Cells[1].Value.ToString());
        //        z_carros carro = new z_carros();
        //        carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
        //        var carros = new List<int> { carro.id_carro };

        //        if (carro.estado == 1 && carro.id_conductor != 0)
        //        {
        //            // fuera de servicio con cond. actual
        //            Conductor.FueraServicio(carro.id_conductor, carros);
        //        }

        //        Conductor.PuestaEnServicio(id_conductor, carros, null);

        //        DataRow row = conductor.GetNombreConductor(id_conductor).Tables[0].Rows[0];
        //        lblDesConductor.Text = row["nombre_voluntario"].ToString();
        //        lblDescEstado.Text = "En servicio";

        //        MessageBox.Show("Conductor " + row["nombre_voluntario"].ToString() + " asignado al carro " + RecursosEstaticos.NombreCarro, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}


        //### 0-9
        private void gvDisponible_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //### JSON SERVICIO 1 = 0-9
            z_carros carro = new z_carros();
            carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
            JsonServicioClaves jsc = new JsonServicioClaves(carro.id_carro);
            
            string valor = gvDisponible.CurrentRow.Cells[1].Value.ToString();
            Color color = new Color();

            if (valor != "0")
            {
                // poner en servicio
                z_conductores conductor = new z_conductores();
                int id_conductor = Convert.ToInt32(gvDisponible.CurrentRow.Cells[1].Value.ToString());
                //z_carros carro = new z_carros();
                //carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                var carros = new List<int> { carro.id_carro };

                if (carro.estado == 1 && carro.id_conductor != 0)
                {
                    DataSet ds1 = new z_conductores().Getz_conductoresCarro(carro.id_carro);
                    int id_tipo_coductor1 = 0;
                    foreach (DataRow row2 in ds1.Tables[0].Rows)
                    {
                        //if ((int)row2["id_conductor"] == carro.id_conductor)
                        if ((int)row2["id_conductor"] == id_conductor)
                        {
                            id_tipo_coductor1 = (int)row2["id_tipo_conductor"];
                            break;
                        }
                    }

                    z_servicio servicio1 = new z_servicio(carro.id_carro, System.DateTime.Now, 1, carro.id_conductor, "Gestión M.M.: Asignación de conductor para el carro "+RecursosEstaticos.NombreCarro+"");
                    servicio1.Insert(servicio1);

                    //### JSON SERVICIO 1 = 0-9
                    if (carro.GetParametroPrioridad(6) == "TRUE")
                    {
                        //jsc.JsonServicioHora(carro.id_carro, 1, "Juan Perez", "0-9", "Verde");
                    }
                    
                    // Fuera de Servicio con este Conductor
                    Conductor.FueraServicio(carro.id_conductor, carros);

                }

                Conductor.PuestaEnServicio(id_conductor, carros, null);


                //### JSON SERVICIO 1 = 0-9
                if (carro.GetParametroPrioridad(6) == "TRUE")
                {
                    //### Nombre de Conductor
                    string strNomConductor = new z_conductores().Getz_NombreConductor(id_conductor);
                    jsc.JsonServicioHora(carro.id_carro, 1, strNomConductor, "0-9", "Verde", true);
                }


                DataSet ds = new z_conductores().Getz_conductoresCarro(carro.id_carro);
                int id_tipo_coductor = 0;
                foreach (DataRow row2 in ds.Tables[0].Rows)
                {
                    //if ((int)row2["id_conductor"] == carro.id_conductor)
                    if ((int)row2["id_conductor"] == id_conductor)
                    {
                        id_tipo_coductor = (int)row2["id_tipo_conductor"];
                        break;
                    }
                }

                DataRow row = conductor.GetNombreConductor(id_conductor, id_tipo_coductor).Tables[0].Rows[0];
                lblDesConductor.Text = row["nombre_voluntario"].ToString();
                lblDescEstado.Text = "En servicio";

                z_servicio servicio2 = new z_servicio(carro.id_carro, System.DateTime.Now, 1, carro.id_conductor, "Gestión M.M.: Conductor queda en servicio para el carro " + carro.nombre + "");
                servicio2.Insert(servicio2);

                MessageBox.Show("Conductor " + row["nombre_voluntario"].ToString() + " asignado al carro " + RecursosEstaticos.NombreCarro, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //### Hacer Click al 0-9
                btn_09.PerformClick();

            }
        }


        //### Liberar Carro
        private void button3_Click(object sender, EventArgs e)
        {

            //### JSON SERVICIO 1 = 0-9
            z_carros carro = new z_carros();
            carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
            JsonServicioClaves jsc = new JsonServicioClaves(carro.id_carro);
            
            // Preguntar antes de liberar
            if (
                MessageBox.Show(
                    "'Liberar Carro' debe ser utilizado sólo como medida de emergencia, ¿Está seguro que desea liberar este carro?",
                    "Liberar Carro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    //z_carros carro = new z_carros();
                    //carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                    // liberar carro
                    Carro.Liberar(carro.id_carro);
                    var cu = new e_carros_usados();
                    cu = cu.getObjecte_carros_usados(carro.id_carro);
                    cu.freee_carros_usados(cu.id_carro);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }

            lblEstadoCarro.Text = "En servicio";
            
            //### JSON SERVICIO 1 = 0-9
            if (carro.GetParametroPrioridad(6) == "TRUE")
            {
                //### Nombre de Conductor
                string strNomConductor = new z_conductores().Getz_NombreConductor(carro.id_conductor);
                jsc.JsonServicioHora(carro.id_carro, 1, strNomConductor, "0-9", "Verde", false);
            }
        }

        //### Sin Conductor
        private void button4_Click(object sender, EventArgs e)
        {
            //### JSON SERVICIO 1 = 0-9
            z_carros carro = new z_carros();
            carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
            JsonServicioClaves jsc = new JsonServicioClaves(carro.id_carro);

                    Carro.SinConductor(carro.id_carro);
                    BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, DatosLogin.LoginUsuario,
                                                "Carro: " + carro.nombre + " Sin coductor");

                    MessageBox.Show("Sin conductor asignado" + RecursosEstaticos.NombreCarro, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //### JSON SERVICIO 2 = 0-8
                    if (carro.GetParametroPrioridad(6) == "TRUE")
                    {
                        jsc.JsonServicioHora(carro.id_carro, 8, "", "0-8", "Amarillo", true);
                    }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbEnServicio_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEnServicio.Checked)
            {
                gbAsignarCarros.Visible = true;
            }
            else
            {
                gbAsignarCarros.Visible = false;
            }
        }

        private void btn_08_Click(object sender, EventArgs e)
        {
            z_conductores conductor = new z_conductores();
            z_carros carros = new z_carros();
            if (carros.GetParametroPrioridad(1) == "TRUE")
            {
                carros = carros.getObjectz_carros(label1.Text.ToString());
                conductor = conductor.getObjectz_conductores(carros.id_conductor);
                string strConductor = conductor.codigo_conductor;

                // #Publicar en Twitter#
                // #Alinne1712#
                System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                proceso.StartInfo.Arguments = "3" + " " + label1.Text.ToString() + " " + "[" + strConductor + " " + DatosLogin.NomUsuario.ToString() + "]";
                proceso.StartInfo.CreateNoWindow = true;
                proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso.Start();

                MessageBox.Show("Se ha publicado en Twitter:   0-8 " + label1.Text.ToString() + "              ", "Sistema ZEUS");
            }
        }

        private void btn_09_Click(object sender, EventArgs e)
        {
            z_conductores conductor = new z_conductores();
            z_carros carros = new z_carros();

            if (carros.GetParametroPrioridad(1) == "TRUE")
            {
                carros = carros.getObjectz_carros(label1.Text.ToString());
                conductor = conductor.getObjectz_conductores(carros.id_conductor);
                string strConductor = conductor.codigo_conductor;

                // #Publicar en Twitter#
                // #Alinne1712#
                System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                proceso.StartInfo.Arguments = "4" + " " + label1.Text.ToString() + " " + "[" + strConductor + " " + DatosLogin.NomUsuario.ToString() + "]";
                proceso.StartInfo.CreateNoWindow = true;
                proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso.Start();
              
                MessageBox.Show("Se ha publicado en Twitter:   0-9 " + label1.Text.ToString() + "              " , "Sistema ZEUS");

            }
        }


        private void btn_Reporte_Click(object sender, EventArgs e)
        {

            z_carros carros = new z_carros();
            if (carros.GetParametroPrioridad(1) == "TRUE")
            {
                // #Publicar en Twitter#
                // #Alinne1712#
                System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                proceso.StartInfo.Arguments = "5" + " " + "GEObit";
                proceso.StartInfo.CreateNoWindow = true;
                proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proceso.Start();

                MessageBox.Show("Se ha publicado en Twitter el Boletín Informativo del Material Mayor", "Sistema ZEUS");

                // ### Limpiar la Cache
                System.Diagnostics.Process LimpCache = new System.Diagnostics.Process();
                LimpCache.StartInfo.FileName = @"C:\Windows\System32\ipconfig.exe";
                LimpCache.StartInfo.Arguments = "/flushdns";
                LimpCache.Start();
            }
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
             z_carros carros = new z_carros();
             if (carros.GetParametroPrioridad(1) == "TRUE")
             {
                 System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                 proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                 proceso.StartInfo.Arguments = "1" + " " + txtww.Text + " ";
                 proceso.StartInfo.CreateNoWindow = true;
                 proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 proceso.Start();

                 MessageBox.Show("Twitter publicado de forma exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
        }
    }
}
