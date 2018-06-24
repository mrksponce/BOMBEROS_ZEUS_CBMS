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
    public partial class Frm_Compania : Form
    {
        public Frm_Compania()
        {
            InitializeComponent();
        }

        public int RetornoInt { get; set; }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            RetornoInt = (int)cmb_compania.SelectedValue; ;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Frm_Compania_Load(object sender, EventArgs e)
        {
            cmb_compania.DisplayMember = "id_compania";
            cmb_compania.ValueMember = "id_compania";
            cmb_compania.DataSource = new z_companias().Getz_companias().Tables[0];
        }
    }
}
