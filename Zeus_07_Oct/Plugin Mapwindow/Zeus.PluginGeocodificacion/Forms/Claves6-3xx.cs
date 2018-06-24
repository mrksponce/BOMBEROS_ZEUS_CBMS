using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class Claves6_3xx : Form
    {
        private string calle1;

        public string Calle1
        {
            get { return calle1; }
            set { calle1 = value; }
        }
        private string calle2;

        public string Calle2
        {
            get { return calle2; }
            set { calle2 = value; }
        }

        private int coor1;

        public int Coor1
        {
            get { return coor1; }
            set { coor1 = value; }
        }

        private int coor2;

        public int Coor2
        {
            get { return coor2; }
            set { coor2 = value; }
        }

        public Claves6_3xx()
        {
            InitializeComponent();
        }

        private void Claves6_3xx_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PostgresDataAccess.DataAccess access = new PostgresDataAccess.DataAccess();
            if (access.claveCarro63(comboClave.Text, Coor1, Coor2, Calle1, Calle2) > 0)
            {
                MessageBox.Show("Coordenadas asignadas a " + comboClave.Text);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
