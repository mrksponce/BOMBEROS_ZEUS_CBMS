using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlertaFerias
{
    public partial class ConfigFerias : Form
    {
        public ConfigFerias()
        {
            InitializeComponent();
        }

        private void checkHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHabilitar.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
            }
        }

        private void ConfigFerias_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.ferias_32_1.GetHicon());
            // cargar
            checkHabilitar.Checked = AlertaSettings.Default.Habilitado;
            textRadio.Text = AlertaSettings.Default.Radio.ToString();
            textTiempo.Text = AlertaSettings.Default.Tiempo.ToString();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            // validar
            if (Validar())
            {
                AlertaSettings.Default.Habilitado = checkHabilitar.Checked;
                if (checkHabilitar.Checked)
                {
                    AlertaSettings.Default.Radio = int.Parse(textRadio.Text);
                    AlertaSettings.Default.Tiempo = int.Parse(textTiempo.Text);
                }
                AlertaSettings.Default.Save();
                Close();
            }
        }

        private bool Validar()
        {
            int d;
            if (checkHabilitar.Checked && int.TryParse(textRadio.Text, out d) != true)
            {
                MessageBox.Show("Radio no válido.", "Faltan parámetros", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }
            if (checkHabilitar.Checked && int.TryParse(textTiempo.Text, out d) != true)
            {
                MessageBox.Show("Tiempo no válido.", "Faltan parámetros", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
    }
}