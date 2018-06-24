using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminCorrelativos : Form
    {
        public AdminCorrelativos()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdminCorrelativos_Load(object sender, EventArgs e)
        {
            // mostrar valores actuales
            try
            {
                var exp = new e_expedientes();

                textCorrelativoExp.Text = exp.GetCorrelativoExp().ToString();
                textCorrelativoIIOO.Text = exp.GetCorrelativoIIOO().ToString();
                textCorrelativoRedTIC.Text = exp.GetCorrelativoRedTIC().ToString();
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnActualizarExp_Click(object sender, EventArgs e)
        {
            int d;
            if (textCorrelativoExp.Text == "" || !int.TryParse(textCorrelativoExp.Text, out d))
            {
                MessageBox.Show("Debe ingresar un valor numérico correcto", "Mensaje de Zeus");
                textCorrelativoExp.Select();
                return;
            }

            try
            {
                new e_expedientes().UpdateCorrelativoExp(d);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnActualizarIIOO_Click(object sender, EventArgs e)
        {
            int d;
            if (textCorrelativoIIOO.Text == "" || !int.TryParse(textCorrelativoIIOO.Text, out d))
            {
                MessageBox.Show("Debe ingresar un valor numérico correcto", "Mensaje de Zeus");
                textCorrelativoIIOO.Select();
                return;
            }

            try
            {
                new e_expedientes().UpdateCorrelativoIIOO(d);
                MessageBox.Show("Operación realizada exitosamente");
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnActualizarRedTIC_Click(object sender, EventArgs e)
        {
            int d;
            if (textCorrelativoRedTIC.Text == "" || !int.TryParse(textCorrelativoRedTIC.Text, out d))
            {
                MessageBox.Show("Debe ingresar un valor numérico correcto", "Mensaje de Zeus");
                textCorrelativoRedTIC.Select();
                return;
            }

            try
            {
                new e_expedientes().UpdateCorrelativoRedTIC(d);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }
    }
}