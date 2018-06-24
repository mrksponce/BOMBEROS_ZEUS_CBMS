using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;

namespace Carros
{
    public partial class CarroAlternativo : Form
    {
        public CarroAlternativo()
        {
            InitializeComponent();
            //listBox3.DisplayMember = "Key";
        }

        private void CarroAlternativo_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.carro_alternativo_32.GetHicon());
            var carros = new z_carros();
            DataSet ds1 = carros.Getz_carrosNoDisponibles();
            DataSet ds2 = carros.Getz_carrosDisponibles();
            listBox1.DataSource = ds1.Tables[0];
            listBox2.DataSource = ds2.Tables[0];
            Alternativos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un carro", "Carro no Seleccionado", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            var carro = new z_carros();
            carro = carro.getObjectz_carros((int) listBox1.SelectedValue);

            if (listBox2.SelectedIndex != -1)
            {
                if (carro.CheckAlternativo((int) listBox2.SelectedValue))
                {
                    if (carro.id_carro != (int) listBox2.SelectedValue)
                    {
                        carro.id_tipo_alternativo = (int) listBox2.SelectedValue;
                        carro.modifyz_carros(carro);
                    }
                    else
                    {
                        MessageBox.Show(
                            "No puede asignar el mismo carro como alternativo. Seleccione otro carro alternativo.",
                            "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El carro elegido ya está asignado. Seleccione otro carro alternativo.",
                                    "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de carro alternativo", "Error de Selección",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Alternativos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Alternativos()
        {
            var carro = new z_carros();
            DataSet ds = carro.Getz_carros();
            listView1.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((int) dr["id_tipo_alternativo"] != 0)
                {
                    ////listBox3.Items.Add(new KeyValuePair<string,int>((string)dr["nombre"] + " -> " + ds.Tables[0].Select("id_carro=" + dr["id_tipo_alternativo"])[0]["nombre"],(int)dr["id_carro"]));
                    var li = new ListViewItem((string) dr["nombre"]);
                    li.SubItems.Add((string) ds.Tables[0].Select("id_carro=" + dr["id_tipo_alternativo"])[0]["nombre"]);
                    li.Tag = (int) dr["id_carro"];
                    listView1.Items.Add(li);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                // eliminar
                var carro = new z_carros();
                carro = carro.getObjectz_carros((int) listView1.SelectedItems[0].Tag);
                carro.id_tipo_alternativo = 0;
                carro.modifyz_carros(carro);
                Alternativos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una asociación para eliminar", "Error de Selección",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}