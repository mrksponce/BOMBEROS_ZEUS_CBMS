using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace AgendaDepartamentos
{
    public partial class AgendaDepartamentosAdminForm : Form
    {
        public AgendaDepartamentosAdminForm()
        {
            InitializeComponent();
        }

        private void btnNuevoDepto_Click(object sender, EventArgs e)
        {
            if (textNombreDepto.Text != "")
            {
                try
                {
                    var depto = new d_departamento {nombre = textNombreDepto.Text};
                    depto.Insert(depto);
                    listDeptos.DataSource = depto.Getd_departamento().Tables[0];
                    MessageBox.Show("Operación completada exitosamente", "Mensaje de Zeus", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar el nombre del nuevo departamento.", "Faltan datos", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void AgendaDepartamentosAdminForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.agenda_inspectores_32.GetHicon());
            // llenar deptos
            listDeptos.DisplayMember = "nombre";
            listDeptos.ValueMember = "id_departamento";
            try
            {
                listDeptos.DataSource = new d_departamento().Getd_departamento().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnActualizarDepto_Click(object sender, EventArgs e)
        {
            if (listDeptos.SelectedItem != null && textNombreDepto.Text != "")
            {
                try
                {
                    d_departamento depto = new d_departamento().getObjectd_departamento((int) listDeptos.SelectedValue);
                    depto.nombre = textNombreDepto.Text;
                    depto.Update(depto);
                    listDeptos.DataSource = depto.Getd_departamento().Tables[0];
                    MessageBox.Show("Operación completada exitosamente.", "Mensaje de Zeus", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un departamento e ingresar el nuevo nombre.", "Faltan datos",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDepto_Click(object sender, EventArgs e)
        {
            if (listDeptos.SelectedItem != null)
            {
                if (
                    MessageBox.Show("¿Seguro que desea eliminar este departamento?", "Confirmar eliminación",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var depto = new d_departamento();
                        depto.Delete((int) listDeptos.SelectedValue);
                        listDeptos.DataSource = depto.Getd_departamento().Tables[0];
                        MessageBox.Show("Operación completada exitosamente.", "Mensaje de Zeus", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un departamento primero.", "Error al eliminar", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevoDetalle_Click(object sender, EventArgs e)
        {
            if (ValidarDetalle())
            {
                if (listDeptos.SelectedItem != null)
                {
                    var det = new d_departamento_detalle
                                  {
                                      nombre = textNombreDet.Text,
                                      id_departamento = ((int) listDeptos.SelectedValue),
                                      cargo = textCargo.Text,
                                      codigo = textCodigo.Text,
                                      fono_fijo = textFonoFijo.Text,
                                      fono_movil = textFonoMovil.Text
                                  };
                    try
                    {
                        det.Insert(det);
                        MessageBox.Show("Operación completada exitosamente.", "Mensaje de Zeus", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        listDetalle.DataSource = det.Getd_departamento_detalle((int) listDeptos.SelectedValue).Tables[0];
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un departamento.", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void btnActualizarDetalle_Click(object sender, EventArgs e)
        {
            if (ValidarDetalle())
            {
                if (listDetalle.SelectedItem != null)
                {
                    d_departamento_detalle det =
                        new d_departamento_detalle().getObjectd_departamento_detalle((int) listDetalle.SelectedValue);
                    det.nombre = textNombreDet.Text;
                    det.cargo = textCargo.Text;
                    det.codigo = textCodigo.Text;
                    det.fono_fijo = textFonoFijo.Text;
                    det.fono_movil = textFonoMovil.Text;
                    try
                    {
                        det.Update(det);
                        MessageBox.Show("Operación completada exitosamente.", "Mensaje de Zeus", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        listDetalle.DataSource = det.Getd_departamento_detalle((int) listDeptos.SelectedValue).Tables[0];
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (listDetalle.SelectedItem != null)
            {
                if (
                    MessageBox.Show("¿Seguro que desea eliminar este item?", "Confirmar eliminación",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var det = new d_departamento_detalle();
                        det.Delete((int) listDetalle.SelectedValue);
                        listDetalle.DataSource = listDeptos.SelectedItem != null ? det.Getd_departamento_detalle((int) listDeptos.SelectedValue).Tables[0] : null;
                        MessageBox.Show("Operación completada exitosamente.", "Mensaje de Zeus", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un item primero.", "Error al eliminar", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private bool ValidarDetalle()
        {
            string msg = "Los siguientes datos faltan o son incorrectos:\n";
            bool ok = true;
            if (textNombreDet.Text == "")
            {
                msg += "* Nombre\n";
                ok = false;
            }
            if (textCargo.Text == "")
            {
                msg += "* Cargo\n";
                ok = false;
            }
            if (textCodigo.Text == "")
            {
                msg += "* Código\n";
                ok = false;
            }
            if (textFonoFijo.Text == "")
            {
                msg += "* Fono Fijo\n";
                ok = false;
            }
            if (textFonoMovil.Text == "")
            {
                msg += "* Fono Móvil\n";
                ok = false;
            }

            if (!ok)
            {
                MessageBox.Show(msg, "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }

        private void listDeptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDeptos.SelectedItem != null)
            {
                textNombreDepto.Text = (string) ((DataRowView) listDeptos.SelectedItem)["nombre"];
                listDetalle.DisplayMember = "nombre";
                listDetalle.DataSource =
                    new d_departamento_detalle().Getd_departamento_detalle((int) listDeptos.SelectedValue).Tables[0];
            }
            else
            {
                listDetalle.DataSource = null;
            }
        }

        private void listDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDetalle.SelectedItem != null)
            {
                textNombreDet.Text = (string) ((DataRowView) listDetalle.SelectedItem)["nombre"];
                textCodigo.Text = (string) ((DataRowView) listDetalle.SelectedItem)["codigo"];
                textCargo.Text = (string) ((DataRowView) listDetalle.SelectedItem)["cargo"];
                textFonoFijo.Text = (string) ((DataRowView) listDetalle.SelectedItem)["fono_fijo"];
                textFonoMovil.Text = (string) ((DataRowView) listDetalle.SelectedItem)["fono_movil"];
            }
        }

        private void listDetalle_DataSourceChanged(object sender, EventArgs e)
        {
            textNombreDet.Text = "";
            textCodigo.Text = "";
            textCargo.Text = "";
            textFonoFijo.Text = "";
            textFonoMovil.Text = "";
        }

        private void listDeptos_DataSourceChanged(object sender, EventArgs e)
        {
            textNombreDepto.Text = "";
        }
    }
}