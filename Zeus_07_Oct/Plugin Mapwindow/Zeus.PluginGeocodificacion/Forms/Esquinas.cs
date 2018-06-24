using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class Esquinas : Form
    {
        public Esquinas(string calle)
        {
            InitializeComponent();
            // cargar esquinas
            calle = Regex.Replace(calle, "^(AVDA )|^(CALLE )|^(PSJE )|^(PTE )", "");
            label1.Text = string.Format(label1.Text, calle);
            Datos = new PostgresDataAccess.DataAccess();
            List<string> esquinas = Datos.ObtenerEsquinas(calle, true, false, null);
            listEsquina.Items.AddRange(esquinas.ToArray());
        }

        private PostgresDataAccess.DataAccess Datos;
        private string _esquina;

        public string Esquina
        {
            get { return _esquina; }
            set { _esquina = value; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (listEsquina.SelectedIndex!=-1)
            {
                Esquina = listEsquina.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una calle antes de proceder.", "Mostrar Esquinas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listEsquina_DoubleClick(object sender, EventArgs e)
        {
            btnAceptar_Click(this, new EventArgs());
        }
    }
}