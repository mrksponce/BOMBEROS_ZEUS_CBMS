using System;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace ReportesGraficosEstadisticos
{
    public partial class BibliotecaConsultasForm : Form
    {
        private string consulta;
        private IZeusWin zeusWin;

        public BibliotecaConsultasForm()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        public string Consulta
        {
            get { return consulta; }
        }

        private void btnNuevaCat_Click(object sender, EventArgs e)
        {
            // crear nueva categoria
            var form = new CategoriasForm { Text = "Nueva Categoría" };
            form.lblInstruccion.Text = "Ingrese nombre de categoría";
            if (form.ShowDialog() == DialogResult.OK)
            {
                // agregar
                var cat = new est_consultas_cat {nombre = form.textResultado.Text};
                try
                {
                    cat.Insert(cat);
                    listCategorias.DataSource = new est_consultas_cat().Getest_consultas_cat().Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnModifCat_Click(object sender, EventArgs e)
        {
            if (listCategorias.SelectedIndex != -1)
            {
                // modificar categoria
                var form = new CategoriasForm { Text = "Nueva Categoría" };
                form.lblInstruccion.Text = "Ingrese nuevo nombre de categoría";
                form.textResultado.Text = listCategorias.Text;
                form.textResultado.SelectAll();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // agregar
                    est_consultas_cat cat =
                        new est_consultas_cat().getObjectest_consultas_cat((int) listCategorias.SelectedValue);
                    cat.nombre = form.textResultado.Text;
                    try
                    {
                        cat.Update(cat);
                        listCategorias.DataSource = new est_consultas_cat().Getest_consultas_cat().Tables[0];
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría para modificar", "Mensaje de Zeus", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnElimCat_Click(object sender, EventArgs e)
        {
            if (listCategorias.SelectedIndex != -1)
            {
                if (
                    MessageBox.Show("¿Seguro que desea eliminar esta categoría?", "Eliminar Categoría",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        new est_consultas_cat().Delete((int) listCategorias.SelectedValue);
                        listCategorias.DataSource = new est_consultas_cat().Getest_consultas_cat().Tables[0];
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría para eliminar", "Mensaje de Zeus", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void BibliotecaConsultasForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.statistics_32x32.GetHicon());

            // verificar accesibilidad
            if (zeusWin.TipoOperadora == TipoOperadora.Operadora)
            {
                // ocultar botones
                btnNuevaCat.Visible = false;
                btnModifCat.Visible = false;
                btnElimCat.Visible = false;
                btnNuevaCons.Visible = false;
                btnActualizarCons.Visible = false;
                btnEliminarCons.Visible = false;

                listCategorias.Height = btnNuevaCat.Bottom - listCategorias.Top;
            }
            // cargar datos
            try
            {
                listCategorias.DataSource = new est_consultas_cat().Getest_consultas_cat().Tables[0];
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

        private void listCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCategorias.SelectedIndex != -1)
            {
                // cargar consultas
                try
                {
                    listConsultas.DataSource =
                        new est_consultas_detalle().Getest_consultas_detalle((int) listCategorias.SelectedValue).Tables[
                            0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void listConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listConsultas.SelectedIndex != -1)
            {
                // mostrar detalle
                est_consultas_detalle det =
                    new est_consultas_detalle().getObjectest_consultas_detalle((int) listConsultas.SelectedValue);
                textTitulo.Text = det.titulo;
                textAutor.Text = det.autor;
                textDescripcion.Text = det.descripcion;
                textConsulta.Text = det.consulta;
            }
            else
            {
                textTitulo.Text = "";
                textAutor.Text = "";
                textDescripcion.Text = "";
                textConsulta.Text = "";
            }
        }

        private void btnNuevaCons_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (listCategorias.SelectedIndex != -1)
                {
                    var det = new est_consultas_detalle((int) listCategorias.SelectedValue,
                                                                          textAutor.Text, textTitulo.Text,
                                                                          textDescripcion.Text, textConsulta.Text);
                    try
                    {
                        det.Insert(det);
                        listConsultas.DataSource =
                            new est_consultas_detalle().Getest_consultas_detalle((int) listCategorias.SelectedValue).
                                Tables[0];
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una categoría para la consulta", "Mensaja de Zeus",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool Validar()
        {
            bool ok = true;
            string msg = "Los siguientes datos faltan o son erróneos:\n";


            if (textTitulo.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado el título de la consulta.\n";
            }


            if (textAutor.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado el autor.\n";
            }

            if (textDescripcion.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado la descripciónr.\n";
            }

            if (textConsulta.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado la consulta.\n";
            }


            if (!ok)
            {
                MessageBox.Show(msg, "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }

        private void btnActualizarCons_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (listConsultas.SelectedIndex != -1)
                {
                    // actualizar
                    var det = new est_consultas_detalle
                                  {
                                      id_consulta = ((int) listConsultas.SelectedValue),
                                      id_categoria = ((int) listCategorias.SelectedValue),
                                      autor = textAutor.Text,
                                      titulo = textTitulo.Text,
                                      descripcion = textDescripcion.Text,
                                      consulta = textConsulta.Text
                                  };
                    try
                    {
                        det.Update(det);
                        MessageBox.Show("Datos ingresados correctamente", "Mensaje de Zeus", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una consulta", "Mensaje de Zeus", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarCons_Click(object sender, EventArgs e)
        {
            if (listConsultas.SelectedIndex != -1)
            {
                if (
                    MessageBox.Show("¿Desea eliminar esta consulta?", "Eliminar Consulta", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var det = new est_consultas_detalle();
                        det.Delete((int) listConsultas.SelectedValue);
                        listConsultas.DataSource =
                            det.Getest_consultas_detalle((int) listCategorias.SelectedValue).Tables[0];
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (listConsultas.SelectedIndex != -1)
            {
                // exportar consulta seleccionada
                consulta = textConsulta.Text;
                Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una consulta para exportar", "Mensaje de Zeus", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}