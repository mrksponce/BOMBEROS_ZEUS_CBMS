using System;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
            // datos actuales
            textIP.Text = DatosSGC.Host;
            textREDTIC.Text = DatosSGC.RedTicURL;
        }

        public bool Validar()
        {
            if (textIP.Text == "")
            {
                MessageBox.Show("IP de servidor no válida.", "Faltan parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (textREDTIC.Text == "")
            {
                MessageBox.Show("URL de servidor REDTIC no válida.", "Faltan parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                DatosSGC.Host = textIP.Text;
                DatosSGC.RedTicURL = textREDTIC.Text;
                MessageBox.Show("Debe reiniciar la aplicación para que los cambios tengan efecto.", "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}