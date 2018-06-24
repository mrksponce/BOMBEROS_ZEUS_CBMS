using System;
using System.Windows.Forms;
using Zeus.Application.Properties;

namespace Zeus.Application
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }
        
        private bool ValidarTonos()
        {
            int d;
            if (!checkTonos.Checked)
            {
                return true;
            }
            if (int.TryParse(textTiempo.Text, out d))
            {
                return true;
            }
            return false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarTonos())
            {
                Settings.Default.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void checkTonos_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = checkTonos.Checked;
        }
    }
}