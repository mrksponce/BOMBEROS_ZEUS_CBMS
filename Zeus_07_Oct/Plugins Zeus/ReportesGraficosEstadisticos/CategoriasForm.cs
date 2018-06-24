using System;
using System.Windows.Forms;

namespace ReportesGraficosEstadisticos
{
    public partial class CategoriasForm : Form
    {
        public CategoriasForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textResultado.Text == "")
            {
                MessageBox.Show("Debe ingresar un valor", "Mensaje de Zeus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}