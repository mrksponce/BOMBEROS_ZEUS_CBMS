using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.UIElements;
using Zeus.Util;
using Zeus.Data;
using System.Data;

namespace Zeus.UIElements
{
    public partial class _011_CubrirCuartel : Form
    {
        z_carros carros = new z_carros();


        // GetCarros();
        public _011_CubrirCuartel()
        {
            InitializeComponent();
            GetCompaniaOrigen();
            GetCompania();
            GetCarros011();
        }

        protected void GetCarros011()
        {
            dataGridView1.Rows.Clear();
            foreach(DataRow row in carros.ObtenerCarros011().Tables[0].Rows)
            {
                dataGridView1.Rows.Add(row["nombre"].ToString());
            }
        }

        protected void GetCompaniaOrigen()
        {
            ddlOrigen.DisplayMember = "nombre_compania";
            ddlOrigen.ValueMember = "id_compania";
            ddlOrigen.DataSource = carros.GetCompaniasId().Tables[0];
        }

        protected void GetCarros()
        {
            ddlCarros.DisplayMember = "nombre";
            ddlCarros.ValueMember = "id_carro";
            ddlCarros.DataSource = carros.GetCarros().Tables[0];
        }

        protected void GetCompania()
        {
            ddlCompanias.DisplayMember = "nombre_compania";
            ddlCompanias.ValueMember = "Coordenadas";
            ddlCompanias.DataSource = carros.GetCompanias().Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] spli_coordenadas = ddlCompanias.SelectedValue.ToString().Split('-');
            if (carros.ActualizarCoordenadasCubrirCuartel(Convert.ToInt32(ddlCarros.SelectedValue.ToString()), Convert.ToInt32(spli_coordenadas[0]), Convert.ToInt32(spli_coordenadas[1])) > 0)
            {
                MessageBox.Show("Despacho 0-11 asignado al carro "+ddlCarros.Text+"", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, 1, "Carro: "+ddlCarros.Text+" 0-11 Despacho "+ddlCompanias.Text+"");
                GetCarros011();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se pudo realizar la operación, por favor intentelo nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] spli_coordenadas = ddlCompanias.SelectedValue.ToString().Split('-');
            if (carros.Actualizar011_Retornar(Convert.ToInt32(ddlCarros.SelectedValue.ToString()), Convert.ToInt32(spli_coordenadas[0]), Convert.ToInt32(spli_coordenadas[1])) > 0)
            {
                MessageBox.Show("Retorno 0-11 asignado al carro "+ddlCarros.Text+"", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, 1, "Carro: " + ddlCarros.Text + " 0-11 Retorno " + ddlCompanias.Text + "");
                GetCarros011();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se pudo realizar la operación, por favor intentelo nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (carros.Actualizar011_Campo(dataGridView1.CurrentRow.Cells[0].Value.ToString()) > 0)
                {
                    MessageBox.Show("6-20 Asignado al carro " + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, 1, "Carro: " + ddlCarros.Text + " 0-11 6-20");
                    GetCarros011();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la operación, por favor intentelo nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un carro de la lista 0-11 para asignar 6-20", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (carros.Actualizar011_seisdies(dataGridView1.CurrentRow.Cells[0].Value.ToString()) > 0)
                {
                    MessageBox.Show("6-10 Asignado al carro " + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, 1, "Carro: " + ddlCarros.Text + " 0-11 6-10");
                    GetCarros011();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la operación, por favor intentelo nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un carro de la lista 0-11 para asignar 6-20", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void ddlOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Set Cia", "GEObit");
            
            if (ddlOrigen.SelectedIndex != -1)
            {
                DataSet ds = carros.Get_Compania_Seleccionada((int)ddlOrigen.SelectedValue);
                ddlCarros.DisplayMember = "nombre";
                ddlCarros.ValueMember = "id_carro";
                ddlCarros.DataSource = ds.Tables[0];
            }
        }
    }
}
