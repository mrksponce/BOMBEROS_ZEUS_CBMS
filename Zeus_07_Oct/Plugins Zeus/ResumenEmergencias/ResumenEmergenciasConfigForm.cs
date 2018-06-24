using System;
using System.Windows.Forms;
using Zeus.Util;

namespace ResumenEmergencias
{
    public partial class ResumenEmergenciasConfigForm : Form
    {
        public ResumenEmergenciasConfigForm()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            bool ok = true;
            int d;
            string msg = "Los siguientes datos faltan o son erróneos:\n";

            if (textHost.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado un Host.\n";
            }

            if (textPuerto.Text == "" || !int.TryParse(textPuerto.Text, out d))
            {
                ok = false;
                msg += "* No ha ingresado un Puerto válido.\n";
            }

            if (textUsuario.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado el nombre de Usuario.\n";
            }

            if (textContraseña.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado una contraseña.\n";
            }

            if (textEnviado.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado una dirección de envío válida.\n";
            }

            if (!ok)
            {
                MessageBox.Show(msg, "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (Settings.Default.SmtpData == null)
                {
                    Settings.Default.SmtpData = new SmtpData();
                }

                // agregar datos
                Settings.Default.SmtpData.Host = textHost.Text;
                Settings.Default.SmtpData.Port = int.Parse(textPuerto.Text);
                Settings.Default.SmtpData.User = textUsuario.Text;
                Settings.Default.SmtpData.Password = textContraseña.Text;
                Settings.Default.SmtpData.FromAddress = textEnviado.Text;

                Settings.Default.Save();

                MessageBox.Show("Datos ingresados correctamente", "Mensaje de Zeus", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResumenEmergenciasConfigForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.SmtpData != null)
            {
                // mostrar datos actuales
                textHost.Text = Settings.Default.SmtpData.Host;
                textPuerto.Text = Settings.Default.SmtpData.Port.ToString();
                textUsuario.Text = Settings.Default.SmtpData.User;
                textContraseña.Text = Settings.Default.SmtpData.Password;
                textEnviado.Text = Settings.Default.SmtpData.FromAddress;
            }
        }
    }
}