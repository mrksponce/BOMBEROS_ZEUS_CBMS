using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class EditarExpediente : Form
    {
        private int id_expediente;


        public EditarExpediente()
        {
            InitializeComponent();
        }

        public int IdExpediente
        {
            get { return id_expediente; }
            set { id_expediente = value; }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditarExpediente_Load(object sender, EventArgs e)
        {
            try
            {
                informacionExpediente1.ComunasDataSource = new k_comuna().Getk_comuna().Tables[0];
                e_expedientes exp = new e_expedientes().getObjecte_expedientes(id_expediente);
                informacionExpediente1.Expediente = exp;
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }
    }
}