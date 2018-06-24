using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class AdministrarExpediente : Form
    {
        private int idOperadora;

        public AdministrarExpediente()
        {
            InitializeComponent();
        }

        public int IdOperadora
        {
            get { return idOperadora; }
            set { idOperadora = value; }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (dataExpedientes.SelectedRows.Count != 0)
            {
                try
                {
                    // reabrir expediente, y reasignar a operadora que lo abre
                    e_expedientes exp =
                        new e_expedientes().getObjecte_expedientes(
                            (int) dataExpedientes.SelectedRows[0].Cells["id_expediente"].Value);
                    exp.activo = true;
                    exp.id_operadora = idOperadora;
                    exp.Update(exp);

                    DataSet ds = exp.Gete_expedientes_cerrados(dateDesde.Value, dateHasta.Value);
                    dataExpedientes.DataSource = ds.Tables[0];

                    MessageBox.Show("Operación realizada correctamente.", "Mensaje de ZEUS");
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un expediente.", "Mensaje de ZEUS");
            }
        }

        private void ReabrirExpediente_Load(object sender, EventArgs e)
        {
            dateDesde.Value = DateTime.Now.AddDays(-1);
            dateHasta.Value = DateTime.Now;
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                DataSet ds = new e_expedientes().Gete_expedientes_cerrados(dateDesde.Value, dateHasta.Value.AddDays(1));
                dataExpedientes.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataExpedientes.SelectedRows.Count != 0)
            {
                var ed = new EditarExpediente();
                ed.IdExpediente = (int) dataExpedientes.SelectedRows[0].Cells["id_expediente"].Value;
                ed.ShowDialog();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un expediente.", "Mensaje de ZEUS");
            }
        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Desea eliminar este expediente?", "Eliminar Expediente", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    new e_expedientes().Delete((int) dataExpedientes.SelectedRows[0].Cells["id_expediente"].Value);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
                CargarDatos();
            }
        }
    }
}