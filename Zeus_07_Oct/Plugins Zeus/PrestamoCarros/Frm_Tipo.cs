using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zeus.Data;

namespace PrestamoCarros
{
    public partial class Frm_Tipo : Form
    {
        public Frm_Tipo()
        {
            InitializeComponent();
        }

        public int RetornoInt { get; set; }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            RetornoInt = (int)cbx_tipo_carro.SelectedValue; ;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Frm_Tipo_Load(object sender, EventArgs e)
        {
            cbx_tipo_carro.DisplayMember = "tipo_carro_letra";
            cbx_tipo_carro.ValueMember = "id_tipo_carro";
            cbx_tipo_carro.DataSource = new z_tipo_carro().Getz_tipo_carro().Tables[0];
        }
    }
}
