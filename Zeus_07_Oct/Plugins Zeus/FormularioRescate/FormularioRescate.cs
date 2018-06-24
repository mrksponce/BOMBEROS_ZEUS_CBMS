using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormularioRescate
{
    public partial class FormularioRescate : Form
    {
        public FormularioRescate()
        {
            InitializeComponent();
        }

        private void FormularioRescate_Load(object sender, EventArgs e)
        {

            if (Zeus.Util.RecursosEstaticos.IdExpediente.Equals(0))
            {
                MessageBox.Show("Debe seleccionar un expediente para operar en el módulo.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            ucFormularioRescate ucfr = new ucFormularioRescate();
            panel1.Controls.Add(ucfr);
        }
    }
}
