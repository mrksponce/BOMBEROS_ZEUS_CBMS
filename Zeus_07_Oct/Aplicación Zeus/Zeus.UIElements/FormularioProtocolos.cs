using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zeus.Data;

namespace Zeus.UIElements
{
    public partial class FormularioProtocolos : Form
    {
        public FormularioProtocolos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Protocolo protocolo = new Protocolo();
            if (checkBox1.Checked)
            {
                if (protocolo.Update(comboBox1.SelectedValue.ToString(), richTextBox1.Text, "ACTIVO") == 1)
                {
                    MessageBox.Show("Protocolo Actualizado correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (protocolo.Update(comboBox1.SelectedValue.ToString(), richTextBox1.Text, "NOACTIVO") == 1)
                {
                    MessageBox.Show("Protocolo Actualizado correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormularioProtocolos_Load(object sender, EventArgs e)
        {
            try
            {
                ObtenerProtocolos();
            }
            catch (Exception exe)
            { 
            
            }
        }

        protected void ObtenerProtocolosPorTipo()
        {
            Protocolo protocolo = new Protocolo();
            foreach (DataRow row in protocolo.GetProtocoloPorTipo(comboBox1.SelectedValue.ToString()).Tables[0].Rows)
            {
                if (row["activo"].ToString() == "ACTIVO")
                {
                    checkBox1.Text = "Check protocolo para" + row["tipo"].ToString();
                    checkBox1.Checked = true;
                    richTextBox1.Text = row["descripcion"].ToString();
                }
                else if (row["activo"].ToString() == "NOACTIVO")
                {
                    checkBox1.Text = "Check protocolo para" + row["tipo"].ToString();
                    checkBox1.Checked = false;
                    richTextBox1.Text = row["descripcion"].ToString();
                }
            }
        }

        protected void ObtenerProtocolos()
        {
            Protocolo protocolo = new Protocolo();
            comboBox1.DisplayMember = "tipo";
            comboBox1.ValueMember = "tipo";
            comboBox1.DataSource = protocolo.GetProtocolos().Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerProtocolosPorTipo();
        }
    }
}
