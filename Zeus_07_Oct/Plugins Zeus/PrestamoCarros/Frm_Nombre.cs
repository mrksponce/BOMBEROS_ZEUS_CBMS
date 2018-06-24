using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestamoCarros
{
    public partial class Frm_Nombre : Form
    {
        public Frm_Nombre()
        {
            InitializeComponent();
        }

        public string Retorno { get; set; }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Retorno = tbx_nombre.Text.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
