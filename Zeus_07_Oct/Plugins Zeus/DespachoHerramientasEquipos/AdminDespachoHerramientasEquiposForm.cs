using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace DespachoHerramientasEquipos
{
    public partial class AdminDespachoHerramientasEquiposForm : Form
    {
        public AdminDespachoHerramientasEquiposForm()
        {
            InitializeComponent();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            var nef = new NuevoElementoForm {Text = "Nueva Categoría"};
            if (nef.ShowDialog() == DialogResult.OK)
            {
                // agregar
                var cat = new dh_categorias {categoria = nef.Elemento};
                cat.Insert(cat);

                DataSet ds = new dh_categorias().GetDataSet();
                listCategorias.DisplayMember = "categoria";
                listCategorias.ValueMember = "id_categoria";
                listCategorias.DataSource = ds.Tables[0];
            }
        }

        private void btnAgregarSubcategoria_Click(object sender, EventArgs e)
        {
            var nef = new NuevoElementoForm {Text = "Nueva Subcategoría"};
            if (nef.ShowDialog() == DialogResult.OK)
            {
                // agregar
                var subcat = new dh_subcategorias
                                 {
                                     subcategoria = nef.Elemento,
                                     id_categoria = ((int) listCategorias.SelectedValue)
                                 };
                subcat.Insert(subcat);

                DataSet ds = new dh_subcategorias().GetDataSet((int) listCategorias.SelectedValue);
                listSubcategorias.DisplayMember = "subcategoria";
                listSubcategorias.ValueMember = "id_subcategoria";
                listSubcategorias.DataSource = ds.Tables[0];
            }
        }

        private void btnAgregarHerramienta_Click(object sender, EventArgs e)
        {
            var nef = new NuevoElementoForm {Text = "Nueva Herramienta"};
            if (nef.ShowDialog() == DialogResult.OK)
            {
                // agregar
                var herr = new dh_herramientas
                               {
                                   herramienta = nef.Elemento,
                                   id_subcategoria = ((int) listSubcategorias.SelectedValue)
                               };
                herr.Insert(herr);

                DataSet ds = new dh_herramientas().GetDataSet((int) listSubcategorias.SelectedValue);
                listHerramientas.DisplayMember = "herramienta";
                listHerramientas.ValueMember = "id_herramienta";
                listHerramientas.DataSource = ds.Tables[0];
            }
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "Si elimina esta categoría, se eliminarán todos los elementos que contiene, ¿está seguro?",
                    "Eliminar Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // eliminar
                try
                {
                    new dh_categorias().Delete((int) listCategorias.SelectedValue);

                    DataSet ds = new dh_categorias().GetDataSet();
                    listCategorias.DisplayMember = "categoria";
                    listCategorias.ValueMember = "id_categoria";
                    listCategorias.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnEliminarSubcategoria_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "Si elimina esta subcategoría, se eliminarán todos los elementos que contiene, ¿está seguro?",
                    "Eliminar Subcategoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // eliminar
                try
                {
                    new dh_subcategorias().Delete((int) listSubcategorias.SelectedValue);

                    DataSet ds = new dh_subcategorias().GetDataSet((int) listCategorias.SelectedValue);
                    listSubcategorias.DisplayMember = "subcategoria";
                    listSubcategorias.ValueMember = "id_subcategoria";
                    listSubcategorias.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnEliminarHerramienta_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "Si elimina esta herramienta, se eliminarán todas las asociaciones a carros, ¿está seguro?",
                    "Eliminar Herramienta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // eliminar
                try
                {
                    new dh_herramientas().Delete((int) listHerramientas.SelectedValue);

                    DataSet ds = new dh_herramientas().GetDataSet((int) listSubcategorias.SelectedValue);
                    listHerramientas.DisplayMember = "herramienta";
                    listHerramientas.ValueMember = "id_herramienta";
                    listHerramientas.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void listCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listCategorias.SelectedIndices.Count != 0)
                {
                    // cargar subs
                    DataSet ds = new dh_subcategorias().GetDataSet((int) listCategorias.SelectedValue);
                    listSubcategorias.DisplayMember = "subcategoria";
                    listSubcategorias.ValueMember = "id_subcategoria";
                    listSubcategorias.DataSource = ds.Tables[0];

                    btnModificarCategoria.Enabled = true;
                    btnEliminarCategoria.Enabled = true;
                    btnAgregarSubcategoria.Enabled = true;
                }
                else
                {
                    listSubcategorias.Items.Clear();
                    btnModificarCategoria.Enabled = false;
                    btnEliminarCategoria.Enabled = false;
                    btnAgregarSubcategoria.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void AdminDespachoHerramientasEquiposForm_Load(object sender, EventArgs e)
        {
            //icono
            Icon = Icon.FromHandle(Resources.icon.GetHicon());

            try
            {
                // cargar elementos
                DataSet ds = new dh_categorias().GetDataSet();
                listCategorias.DisplayMember = "categoria";
                listCategorias.ValueMember = "id_categoria";
                listCategorias.DataSource = ds.Tables[0];

                // carros
                DataSet ds2 = new z_carros().Getz_carros();
                colCarros.DisplayMember = "nombre";
                colCarros.ValueMember = "id_carro";
                colCarros.DataSource = ds2.Tables[0];

                // area
                DataSet ds3 = new k_areas().Getk_areas();
                comboArea.DisplayMember = "id_area";
                comboArea.ValueMember = "id_area";
                comboArea.DataSource = ds3.Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void listHerramientas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listHerramientas.SelectedIndices.Count != 0)
                {
                    // cargar carros
                    btnAgregarCantidad.Enabled = true;
                    btnModificarHerramienta.Enabled = true;
                    btnEliminarHerramienta.Enabled = true;

                    FillCarros((int) listHerramientas.SelectedValue);
                }
                else
                {
                    btnAgregarCantidad.Enabled = false;
                    btnModificarHerramienta.Enabled = false;
                    btnEliminarHerramienta.Enabled = false;
                    dgCantidad.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void listSubcategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listSubcategorias.SelectedIndices.Count != 0)
                {
                    // cargar herramientas
                    DataSet ds = new dh_herramientas().GetDataSet((int) listSubcategorias.SelectedValue);
                    listHerramientas.DisplayMember = "herramienta";
                    listHerramientas.ValueMember = "id_herramienta";
                    listHerramientas.DataSource = ds.Tables[0];

                    btnAgregarHerramienta.Enabled = true;
                    btnModificarSubcategoria.Enabled = true;
                    btnEliminarSubcategoria.Enabled = true;
                }
                else
                {
                    listHerramientas.Items.Clear();
                    btnAgregarHerramienta.Enabled = false;
                    btnModificarSubcategoria.Enabled = false;
                    btnEliminarSubcategoria.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            var nef = new NuevoElementoForm
                          {
                              Text = "Modificar Categoría",
                              Elemento = listCategorias.SelectedItems[0].Text
                          };
            if (nef.ShowDialog() == DialogResult.OK)
            {
                // modificar
                try
                {
                    dh_categorias cat = new dh_categorias().getObject((int) listCategorias.SelectedValue);
                    cat.categoria = nef.Elemento;
                    cat.Update(cat);

                    DataSet ds = new dh_categorias().GetDataSet();
                    listCategorias.DisplayMember = "categoria";
                    listCategorias.ValueMember = "id_categoria";
                    listCategorias.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnModificarSubcategoria_Click(object sender, EventArgs e)
        {
            var nef = new NuevoElementoForm
                          {
                              Text = "Modificar Subcategoría",
                              Elemento = listSubcategorias.SelectedItems[0].Text
                          };
            if (nef.ShowDialog() == DialogResult.OK)
            {
                // modificar
                try
                {
                    dh_subcategorias subcat = new dh_subcategorias().getObject((int) listSubcategorias.SelectedValue);
                    subcat.subcategoria = nef.Elemento;
                    subcat.id_categoria = (int) listCategorias.SelectedValue;
                    subcat.Update(subcat);

                    DataSet ds = new dh_subcategorias().GetDataSet((int) listCategorias.SelectedValue);
                    listSubcategorias.DisplayMember = "subcategoria";
                    listSubcategorias.ValueMember = "id_subcategoria";
                    listSubcategorias.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnModificarHerramienta_Click(object sender, EventArgs e)
        {
            var nef = new NuevoElementoForm
                          {
                              Text = "Modificar Herramienta",
                              Elemento = listHerramientas.SelectedItems[0].Text
                          };
            if (nef.ShowDialog() == DialogResult.OK)
            {
                // agregar
                try
                {
                    dh_herramientas herr = new dh_herramientas().getObject((int) listHerramientas.SelectedValue);
                    herr.herramienta = nef.Elemento;
                    herr.id_subcategoria = (int) listSubcategorias.SelectedValue;
                    herr.Update(herr);

                    DataSet ds = new dh_herramientas().GetDataSet((int) listSubcategorias.SelectedValue);
                    listHerramientas.DisplayMember = "herramienta";
                    listHerramientas.ValueMember = "id_herramienta";
                    listHerramientas.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnAgregarCantidad_Click(object sender, EventArgs e)
        {
            // agregar elemento
            try
            {
                var dhc = new dh_herramientas_carros((int) listHerramientas.SelectedValue,
                                                                        (int)
                                                                        ((DataRowView) colCarros.Items[0])["id_carro"],
                                                                        0);
                dhc.Insert(dhc);
                FillCarros((int) listHerramientas.SelectedValue);
                dgCantidad.Rows[dgCantidad.Rows.Count - 1].Selected = true;
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void FillCarros(int id_herramienta)
        {
            dgCantidad.Rows.Clear();
            DataSet ds = new dh_herramientas_carros().GetDataSet(id_herramienta);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int row = dgCantidad.Rows.Add();
                dgCantidad.Rows[row].Cells[colCarros.Name].Value = dr["id_carro"];
                dgCantidad.Rows[row].Cells[colCantidad.Name].Value = (int) dr["cantidad"];
                dgCantidad.Rows[row].Cells[colId.Name].Value = (int) dr["id_herramienta_carro"];
            }

            if (dgCantidad.Rows.Count != 0)
            {
                dgCantidad.Rows[0].Selected = true;
                btnEliminarCantidad.Enabled = true;
            }
            else
            {
                btnEliminarCantidad.Enabled = false;
            }
        }

        private void dgCantidad_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == colCantidad.Index)
            {
                // validar numero
                int d;
                if (!int.TryParse(e.FormattedValue.ToString(), out d))
                {
                    MessageBox.Show("El valor ingresado es inválido, debe ingresar un valor numérico.", "Valor inválido",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void dgCantidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colActualizar.Index)
            {
                // cargar y actualizar
                try
                {
                    dh_herramientas_carros dhc =
                        new dh_herramientas_carros().getObject((int) dgCantidad.Rows[e.RowIndex].Cells[colId.Name].Value);
                    dhc.id_carro = (int) dgCantidad.Rows[e.RowIndex].Cells[colCarros.Name].Value;
                    dhc.cantidad = int.Parse(dgCantidad.Rows[e.RowIndex].Cells[colCantidad.Name].Value.ToString());

                    // verificar que sea el unico carro para esta herramienta
                    DataSet ds = new dh_herramientas_carros().GetDataSet((int) listHerramientas.SelectedValue);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if ((int) dr["id_carro"] == dhc.id_carro &&
                            (int) dr["id_herramienta_carro"] != dhc.id_herramienta_carro)
                        {
                            MessageBox.Show(
                                "El carro seleccionado ya tiene un valor asignado. Cambie dicho valor en vez de agregar uno nuevo.",
                                "Carro ya asignado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    dhc.Update(dhc);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnEliminarCantidad_Click(object sender, EventArgs e)
        {
            try
            {
                new dh_herramientas_carros().Delete((int) dgCantidad.SelectedRows[0].Cells[colId.Name].Value);
                FillCarros((int) listHerramientas.SelectedValue);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void comboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboArea.SelectedIndex != -1)
            {
                // cargar reorder
                try
                {
                    DataSet ds = new dh_prioridad().GetDataSet((int) comboArea.SelectedValue);
                    reorderPrioridad.DisplayMember = "despacho_herramienta";
                    reorderPrioridad.ValueMember = "despacho_herramienta";
                    reorderPrioridad.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (reorderPrioridad.Items.Length != 0 && comboArea.SelectedValue != null)
            {
                // actualizar tabla de prioridades
                try
                {
                    new dh_prioridad().Update((int) comboArea.SelectedValue, reorderPrioridad.Items);
                    MessageBox.Show("Operación realizada correctamente.", "Mensaje de Zeus", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }
    }
}