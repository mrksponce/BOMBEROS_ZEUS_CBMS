using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class ContinuarExpediente : Form
    {
        private IZeusWin zeusWin;

        public ContinuarExpediente()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        private void ContinuarExpediente_Load(object sender, EventArgs e)
        {
            dataGridExpedientes.DataSource = new e_expedientes().Gete_expedientes_tomados().Tables[0];
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dataGridExpedientes.SelectedRows.Count != 0)
            {
                // cambiar expediente de "mano"
                try
                {
                    z_locutores loc =
                        new z_locutores().Login((string) dataGridExpedientes.SelectedRows[0].Cells["login"].Value,
                                                textContraseña.Text);
                    if (loc == null)
                    {
                        MessageBox.Show("La contraseña ingresada no es correcta.", "Mensaje de ZEUS");
                        return;
                    }
                    e_expedientes exp =
                        new e_expedientes().getObjecte_expedientes(
                            (int) dataGridExpedientes.SelectedRows[0].Cells["id_expediente"].Value);
                    exp.id_operadora = zeusWin.IdOperadora;
                    exp.Update(exp);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }
    }
}