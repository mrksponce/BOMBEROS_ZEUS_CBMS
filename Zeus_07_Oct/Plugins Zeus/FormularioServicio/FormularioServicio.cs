using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioServicio
{
    public partial class FormularioServicio : Form
    {
        public FormularioServicio()
        {
            InitializeComponent();
        }

        private void FormularioServicio_Load(object sender, EventArgs e)
        {
            if (Zeus.Util.RecursosEstaticos.IdExpediente.Equals(0))
            {
                MessageBox.Show("Debe seleccionar un expediente para operar en el módulo.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            CUFormularioServicio ucfs = new CUFormularioServicio();
            panel1.Controls.Add(ucfs);
        }
    }
}
