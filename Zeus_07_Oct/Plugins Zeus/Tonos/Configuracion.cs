using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tonos
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
            // datos actuales
            textFile.Text = TonosSettings.Default.Ejecutable;
            textVersion.Text = TonosSettings.Default.Version;
        }

        public bool Validar()
        {
            if (textFile.Text == "")
            {
                MessageBox.Show("Ruta no válida.", "Faltan parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (textVersion.Text == "")
            {
                MessageBox.Show("Falta la versión del archivo.", "Faltan parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                TonosSettings.Default.Ejecutable = textFile.Text;
                TonosSettings.Default.Version = textVersion.Text;
                TonosSettings.Default.Save();
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textFile.Text = openFileDialog1.FileName;
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.FromHandle(Resources.consola_tonos_32.GetHicon());
        }
    }
}