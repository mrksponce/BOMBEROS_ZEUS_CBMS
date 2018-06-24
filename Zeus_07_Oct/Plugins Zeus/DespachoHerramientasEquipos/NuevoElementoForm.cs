using System;
using System.Windows.Forms;

namespace DespachoHerramientasEquipos
{
    public partial class NuevoElementoForm : Form
    {
        public NuevoElementoForm()
        {
            InitializeComponent();
        }

        public string Elemento
        {
            get { return textNombre.Text; }
            set { textNombre.Text = value; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}