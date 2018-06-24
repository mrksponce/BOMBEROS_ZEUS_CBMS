using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;

namespace Recados
{
    public partial class FrmIngresarRecado : Form
    {
        public FrmIngresarRecado()
        {
            InitializeComponent();
        }

        private void FrmIngresarRecado_Load(object sender, EventArgs e)
        {
            GenerarDatos();
        }

        private void GenerarDatos()
        {
            z_operadoras operadora = new z_operadoras();
            txtOperadora.Text = DatosLogin.LoginUsuario.ToString();
            txtTurno.Text = DatosLogin.LoginUsuario.ToString();
            clOperadoras.DataSource = operadora.Getz_operadorasLista2().Tables[0];
            clOperadoras.ValueMember = "id_operadora";
            clOperadoras.DisplayMember = "nombre_completo";
        }

        private void rbNovedad_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbRecado_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbPendiente_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rbVigente_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbCerrar_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_recados recados = new m_recados();
            string operadores = "";
            string tipoRecado = "";
            foreach (object item in clOperadoras.CheckedItems)
            {
                operadores += clOperadoras.GetItemText(item).ToString() + ",";
            }

            if (rbRecado.Checked)
            {
                tipoRecado = "Recado";
            }

            if (rbPendiente.Checked)
            {
                tipoRecado = "Pendiente";
            }

            if (rbNovedad.Checked)
            {
                tipoRecado = "Novedad";
            }

            recados.Operadoras = operadores;
            recados.OperadoraCreador = txtOperadora.Text;
            recados.DetalleRecado = txtInformacion.Text;
            recados.Estado = cbEstado.Text;
            recados.Tipo = tipoRecado;
            recados.Titulo = txtTitulo.Text;
            if (recados.IngresarRecado() == 1)
            {
                MessageBox.Show("Recado ingresado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se pudo ingresar el recado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
