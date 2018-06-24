using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class Reff : Form
    {
        PostgresDataAccess.DataAccess access = new PostgresDataAccess.DataAccess();
        public Reff(string coordenada)
        {
            InitializeComponent();
            llenar(coordenada);

            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        public string Retorno { get; set; }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Retorno = listBox1.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
        }

        private void llenar(string coordenada)
        {
            foreach (string row in access.ObtenerCallesExp2(coordenada))
            {
                listBox1.Items.Add(row);
            }
        }
    }
}
