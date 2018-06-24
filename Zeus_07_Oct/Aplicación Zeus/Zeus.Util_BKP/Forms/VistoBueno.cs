using System;
using System.Windows.Forms;

namespace Zeus.Util.Forms
{
    public partial class VistoBueno : Form
    {
        public VistoBueno()
        {
            InitializeComponent();
        }

        public int IdExpediente { get; set; }

        public string Mensaje { get; set; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textOficial.Text != "")
            {
                BitacoraLlamado.NuevoEvento(IdExpediente, BitacoraLlamado.Llamado,
                                            "Asignación de carros autorizado por: " + textOficial.Text);
            }
            else
            {
                MessageBox.Show("Debe ingresar el nombre del oficial.");
            }
        }

        private void VistoBueno_Load(object sender, EventArgs e)
        {
            label1.Text = Mensaje;
        }
    }
}