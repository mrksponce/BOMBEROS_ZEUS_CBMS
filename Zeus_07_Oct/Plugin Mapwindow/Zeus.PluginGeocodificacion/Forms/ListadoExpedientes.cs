using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class ListadoExpedientes : Form
    {
        public ListadoExpedientes()
        {
            InitializeComponent();
             Datos = new PostgresDataAccess.DataAccess();
        }

        private void ListadoExpedientes_Load(object sender, EventArgs e)
        {
            DataTable dt = Datos.ObtenerExpedientesActivos();
            dgExpedientes.DataSource = dt;
        }

        private void dgExpedientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgExpedientes.Columns[e.ColumnIndex] == bEditar)
            {
                //editar
                PostgresDataAccess.Expediente exp = Datos.ObtenerExpediente((int)dgExpedientes["id_expediente", e.RowIndex].Value);
                Expediente Editar = new Expediente(exp);
                if (Editar.ShowDialog() == DialogResult.OK)
                    ListadoExpedientes_Load(this, new EventArgs());
            }
            if (dgExpedientes.Columns[e.ColumnIndex] == bEliminar)
            {
                // eliminar
                if (MessageBox.Show(this, "¿Desea realmente borrar este expediente?", "Borrar Expediente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Datos.EliminarExpediente((int)dgExpedientes["id_expediente", e.RowIndex].Value) == true)
                        dgExpedientes.Rows.RemoveAt(e.RowIndex);
                    else
                        MessageBox.Show("No se puede eliminar el expediente. Compruebe que\nno hayan recursos asignados a este expediente y reitere la operación", "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private PostgresDataAccess.DataAccess Datos;

        private void btnMapa_Click(object sender, EventArgs e)
        {
            if (dgExpedientes.SelectedRows.Count!=0)
            {
                PointD p = new PointD((double)(dgExpedientes["puntoX", dgExpedientes.SelectedRows[0].Index].Value), (double)(dgExpedientes["puntoY", dgExpedientes.SelectedRows[0].Index].Value));
                PlugData.ZoomToPoint(p);
                // dibujar
                if (PlugData.DrDireccion.HasValue)
                    PlugData.MapWin.View.Draw.ClearDrawing(PlugData.DrDireccion.Value);
                PlugData.DrDireccion = PlugData.MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
                PlugData.MapWin.View.Draw.DrawCircle(p.X, p.Y, 10, Color.Red, true);

            }
            else
            {
                MessageBox.Show("Seleccione un expediente", "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}