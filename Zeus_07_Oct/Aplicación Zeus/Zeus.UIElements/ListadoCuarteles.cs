using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeus.UIElements
{
    public partial class ListadoCuarteles : Form
    {
        RadioButton but_defecto_compania = new RadioButton();
        private int id_carro;

        public int Id_carro
        {
            get { return id_carro; }
            set { id_carro = value; }
        }

        private string cuartel_seleccion;

        public string Cuartel_seleccion
        {
            get { return cuartel_seleccion; }
            set { cuartel_seleccion = value; }
        }

        public ListadoCuarteles()
        {
            InitializeComponent();
            
        }

        private void ListadoCuarteles_Load(object sender, EventArgs e)
        {
            Zeus.Data.z_companias comp = new Zeus.Data.z_companias();
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Width = 100;
            tlp.Height = 700;
            string nombre = "";

            nombre = comp.get_CompaniaCarroConsulta(Id_carro);
            but_defecto_compania.Name = "defecto";
            but_defecto_compania.Text = nombre;
            but_defecto_compania.Checked = true;
            but_defecto_compania.BackColor = Color.Red;
            but_defecto_compania.Click += new EventHandler(but_defecto_compania_Click);
            tlp.Controls.Add(but_defecto_compania);

            string[] lista_companias = comp.get_ListaCarrosCompania();
            for (int i = 0; i < lista_companias.Length ; i++)
            {
                if (nombre != lista_companias[i])
                {
                    RadioButton r_button = new RadioButton();
                    r_button.LostFocus += new EventHandler(r_button_LostFocus);
                    r_button.Click += new EventHandler(but_defecto_compania_Click);
                    r_button.Name = "compania_" + lista_companias[i];
                    r_button.Text = lista_companias[i];
                    tlp.Controls.Add(r_button);
                }
            }
            panel1.Controls.Add(tlp);
        }

        void r_button_LostFocus(object sender, EventArgs e)
        {
            RadioButton r_button = (sender) as RadioButton;
            r_button.BackColor = Color.Transparent;
        }

        void but_defecto_compania_Click(object sender, EventArgs e)
        {
            RadioButton radiobutton = (sender) as RadioButton;
            if (radiobutton.Name.ToString() != "defecto")
            {
                radiobutton.BackColor = Color.Yellow;
            }
            Cuartel_seleccion = radiobutton.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zeus.Data.z_carros carros = new Zeus.Data.z_carros();
            if (carros.asignarCoordenadasCarro(Cuartel_seleccion, id_carro) > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
