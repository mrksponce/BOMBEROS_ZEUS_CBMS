using System;
using System.Drawing;
using System.Windows.Forms;

namespace HazMat
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
            // datos actuales
            textFile.Text = HazMatSettings.Default.Ejecutable;
            textVersion.Text = HazMatSettings.Default.Version;
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
                MessageBox.Show("Falta la versión del archivo.", "Faltan parámetros", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                HazMatSettings.Default.Ejecutable = textFile.Text;
                HazMatSettings.Default.Version = textVersion.Text;
                HazMatSettings.Default.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textFile.Text = openFileDialog1.FileName;
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.ergo_32.GetHicon());
        }
    }
}