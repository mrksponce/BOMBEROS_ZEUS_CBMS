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
    public partial class FrmConsultaRecados : Form
    {
        private string IDRegistro { get; set; }
        private z_operadoras operadora = new z_operadoras();
        public FrmConsultaRecados(string idRecado)
        {
            InitializeComponent();
            IDRegistro = idRecado;
        }

        private void FrmConsultaRecados_Load(object sender, EventArgs e)
        {
            GenerarDatos();
            ConsultarRegistro(Convert.ToInt32(IDRegistro));
        }

        private void GenerarDatos()
        {
            txtOperadora.Text = DatosLogin.LoginUsuario.ToString();
            txtTurno.Text = DatosLogin.LoginUsuario.ToString();
        }

        private void ConsultarRegistro(int idRecado)
        {
            try
            {
                m_recados recados = new m_recados();
                string[] op = null;
                foreach (DataRow r in recados.GetRecadosProID(idRecado).Tables[0].Rows)
                {
                    txtTitulo.Text = r["titulo"].ToString();
                    txtInformacion.Text = r["detalle_recado"].ToString();
                    CargarComboEstado(r["estado"].ToString());

                    if (rbRecado.Text == r["tipo"].ToString())
                    {
                        rbRecado.Checked = true;
                    }

                    if (rbNovedad.Text == r["tipo"].ToString())
                    {
                        rbNovedad.Checked = true;
                    }

                    if (rbPendiente.Text == r["tipo"].ToString())
                    {
                        rbPendiente.Checked = true;
                    }
                    op = r["operadoras"].ToString().Split(',');
                }
                int i = 0;
                int indice = 0;
                bool flag = true;
                //clOperadoras.DataSource = operadora.Getz_operadorasLista2().Tables[0];
                //clOperadoras.ValueMember = "id_operadora";
                //clOperadoras.DisplayMember = "nombre_completo";

                for (int a = 0; a < operadora.Getz_operadorasLista2().Tables[0].Rows.Count; a++)
                {
                    string lbl = "OP " + a;
                    foreach (string opp in op)
                    {
                        if (lbl == opp)
                        {
                            clOperadoras.Items.Add(lbl, true);
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        clOperadoras.Items.Add(lbl, false);
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception exe)
            { 
            
            }
        }

        private void CargarComboEstado(string estado)
        {
            cbEstado.Items.Clear();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Vigente", "Vigente");
            dic.Add("Cerrado", "Cerrado");

            cbEstado.Text = estado;
            cbEstado.DataSource = new BindingSource(dic, null);
            cbEstado.DisplayMember = "Value";
            cbEstado.ValueMember = "Key";
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
            if (recados.ActualizarRecado(Convert.ToInt32(IDRegistro)) == 1)
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
