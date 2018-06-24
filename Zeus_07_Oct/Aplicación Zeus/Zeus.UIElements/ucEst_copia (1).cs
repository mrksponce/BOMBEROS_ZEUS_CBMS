using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;
using Zeus.UIElements;
using Zeus.Interfaces;
using System.Collections;

namespace Zeus.UIElements
{
    public partial class ucEst : UserControl
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
            z_estado_carros ec = new z_estado_carros();
            z_conductores conductor = new z_conductores();
            z_carros carro = new z_carros();
            carro = carro.getObjectz_carros(NombreCarro);
            ec = ec.getObjectz_estado_carros(carro.estado);
            Image img = carro.getImagenByNombre(NombreCarro);
            pictureBox1.Image = img;
            conductor = conductor.getObjectz_conductores(carro.id_carro);
            txtOtro.Enabled = false;

            if (carro.estado == 1)
            {
                rbEnServicio.Checked = true;
                gbAsignarCarros.Visible = true;
            }

            if (carro.estado == 3)
            {
                lblDescEstado.Text = "Sin Conductor";
                rbSinConductor.Checked = true;
            }
            else
            {
                lblDescEstado.Text = ec.descripcion + ": " + carro.motivo_fuera_servicio;
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

            txtObservacion.Text = carro.Observacion2;
            lblIngresoOperadora.Text = carro.OpObservacion2;
            LlenarEnServicio();
        }



        private void LlenarEnServicio()
        {
            z_carros carro = new z_carros();
            carro = carro.getObjectz_carros(NombreCarro);
            DataSet ds = new z_conductores().Getz_conductoresCarro(carro.id_carro);
            
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
                    style.ForeColor =  Color.Green;
                }
                else
                { 
                    style.ForeColor =  Color.Goldenrod;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (rbfsElectrico.Checked)
            {
                z_carros carro = new z_carros();
                carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                Carro.FueraServicio(carro.id_carro, rbfsElectrico.Text);
                //Estado = 2;
                BitacoraGestion.NuevoEvento(1, 1,
                                            "Carro: " + Text + " Fuera de Servicio (" + "Eléctrico" +
                                            ")");
                lblDescEstado.Text = rbfsElectrico.Text;
            }

            if (rbfsMecanico.Checked)
            {
                z_carros carro = new z_carros();
                carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                Carro.FueraServicio(carro.id_carro, rbfsMecanico.Text);
                //Estado = 2;
                BitacoraGestion.NuevoEvento(1, 1,
                                            "Carro: " + Text + " Fuera de Servicio (" + "Mecánico" +
                                            ")");
                lblDescEstado.Text = rbfsMecanico.Text;
            }

            if (rbfsOtro.Checked)
            {
                z_carros carro = new z_carros();
                carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                Carro.FueraServicio(carro.id_carro, txtOtro.Text);
                //Estado = 2;
                BitacoraGestion.NuevoEvento(1, 1,
                                            "Carro: " + Text + " Fuera de Servicio (" + txtOtro.Text +
                                            ")");
                lblDescEstado.Text = "Fuera de Servicio: " + txtOtro.Text;
            }

            if (rbSinConductor.Checked)
            {
                z_carros carro = new z_carros();
                carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);

                Carro.SinConductor(carro.id_carro);
                //Carro.FueraServicio(carro.id_carro, "Sin Conductor.");
                BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, DatosLogin.LoginUsuario,
                                            "Carro: " + carro.nombre + " Sin coductor");

                //MessageBox.Show("Sin conductor asignado" + RecursosEstaticos.NombreCarro, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        z_carros carro = new z_carros();
                        carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
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
            }

            MessageBox.Show("Carro "+RecursosEstaticos.NombreCarro+" " + lblDescEstado.Text + " asignado correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gvDisponible_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor = gvDisponible.CurrentRow.Cells[1].Value.ToString();
            Color color = new Color();

            if (valor != "0")
            {
                // poner en servicio
                z_conductores conductor = new z_conductores();
                int id_conductor = Convert.ToInt32(gvDisponible.CurrentRow.Cells[1].Value.ToString());
                z_carros carro = new z_carros();
                carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                var carros = new List<int> { carro.id_carro };

                if (carro.estado == 1 && carro.id_conductor != 0)
                {
                    // Fuera de Servicio con este Conductor
                    Conductor.FueraServicio(carro.id_conductor, carros);
                }

                Conductor.PuestaEnServicio(id_conductor, carros, null);

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

                MessageBox.Show("Conductor " + row["nombre_voluntario"].ToString() + " asignado al carro " + RecursosEstaticos.NombreCarro, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Preguntar antes de liberar
            if (
                MessageBox.Show(
                    "'Liberar Carro' debe ser utilizado sólo como medida de emergencia, ¿Está seguro que desea liberar este carro?",
                    "Liberar Carro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    z_carros carro = new z_carros();
                    carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            z_carros carro = new z_carros();
            carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);

                    Carro.SinConductor(carro.id_carro);
                    BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, DatosLogin.LoginUsuario,
                                                "Carro: " + carro.nombre + " Sin coductor");

                    MessageBox.Show("Sin conductor asignado" + RecursosEstaticos.NombreCarro, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            //string strPublicar = "3 " + label1.Text.ToString();

            // #Publicar en Twitter#
            // #Alinne1712#
                System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                proceso.StartInfo.FileName = @"C:\comander\app_twitter\App_Twitter_Mod.exe";
                proceso.StartInfo.Arguments = "3" + " " + label1.Text.ToString(); ;
                proceso.Start();

                MessageBox.Show("Se ha publicado en Twitter:   0-8 " + label1.Text.ToString() + "              ", "Sistema ZEUS");
        }

        private void btn_09_Click(object sender, EventArgs e)
        {

            //string strPublicar = "4 " + label1.Text.ToString();
            
            // #Publicar en Twitter#
            // #Alinne1712#
                System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                proceso.StartInfo.FileName = @"C:\comander\app_twitter\App_Twitter_Mod.exe";
                proceso.StartInfo.Arguments = "4" + " " + label1.Text.ToString();
                proceso.Start();

                MessageBox.Show("Se ha publicado en Twitter:   0-9 " + label1.Text.ToString() + "              ", "Sistema ZEUS");
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {

            // #Publicar en Twitter#
            // #Alinne1712#
            System.Diagnostics.Process proceso = new System.Diagnostics.Process();
            proceso.StartInfo.FileName = @"C:\comander\app_twitter\App_Twitter_Mod.exe";
            proceso.StartInfo.Arguments = "5" + " " + "GEObit";
            proceso.Start();

            MessageBox.Show("Se ha publicado en Twitter el Reporte del Estado del Mat. Mayor", "Sistema ZEUS");


            // ### Limpiar la Cache
            System.Diagnostics.Process LimpCache = new System.Diagnostics.Process();
            LimpCache.StartInfo.FileName = @"C:\Windows\System32\ipconfig.exe";
            LimpCache.StartInfo.Arguments = "/flushdns";
            LimpCache.Start();
        }
    }
}
