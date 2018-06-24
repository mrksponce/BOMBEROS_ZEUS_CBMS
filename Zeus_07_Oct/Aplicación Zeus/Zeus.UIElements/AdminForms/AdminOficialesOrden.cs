using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminOficialesOrden : Form
    {
        public AdminOficialesOrden()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        reorderListBox1.DisplayMember = "nombre_completo";
                        reorderListBox1.ValueMember = "id_cargo";
                        reorderListBox1.DataSource = new z_cargos().Getz_cargosGrado(1).Tables[0];
                        break;
                    case 1:
                        reorderListBox1.DisplayMember = "nombre_completo";
                        reorderListBox1.ValueMember = "id_cargo";
                        reorderListBox1.DataSource = new z_cargos().Getz_cargosGrado(40).Tables[0];
                        break;
                    case 2:
                        reorderListBox1.DisplayMember = "nombre_completo";
                        reorderListBox1.ValueMember = "id_cargo";
                        reorderListBox1.DataSource = new z_cargos().Getz_cargosGrado(100).Tables[0];
                        break;
                    case 3:
                        reorderListBox1.DisplayMember = "nombre_completo";
                        reorderListBox1.ValueMember = "id_cargo";
                        reorderListBox1.DataSource = new z_cargos().Getz_cargosGrado(200).Tables[0];
                        break;
                    case 4:
                        reorderListBox1.DisplayMember = "nombre_completo";
                        reorderListBox1.ValueMember = "id_cargo";
                        reorderListBox1.DataSource = new z_cargos().Getz_cargosGrado(300).Tables[0];
                        break;
                    default:
                        reorderListBox1.DataSource = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int[] items = reorderListBox1.Items;
                var c = new z_cargos();

                for (int i = 0; i < items.Length; i++)
                {
                    c = c.getObjectz_cargos(items[i]);
                    c.orden_antiguedad = i + 1;
                    c.modifyz_cargos(c);
                }
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void AdminOficialesOrden_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }
    }
}