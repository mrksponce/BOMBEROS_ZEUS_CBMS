using System;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;

namespace GeoAgenda
{
    public partial class GeoAdmin : Form
    {
        public GeoAdmin()
        {
            InitializeComponent();
        }

        private void GeoAdmin_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.Agenda.GetHicon());

            FillCombos();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            switch (((Button) sender).Name)
            {
                case "btnNueva1":
                    var AS = new AgendaSolicitud();
                    if (AS.ShowDialog() == DialogResult.OK)
                        MessageBox.Show("Datos ingresados correctamente", "GEO Agenda", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    FillCombos();
                    break;
                case "btnNueva2":
                    if (listClavesAd.SelectedIndex != -1)
                    {
                        var AC = new AgendaCategoria {Id_cat = ((int) listClavesAd.SelectedValue)};
                        if (AC.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Datos ingresados correctamente", "GEO Agenda", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            FillCombos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una clave de servicio.", "Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    break;
                case "btnNueva3":
                    if (listSubcatAd.SelectedIndex != -1)
                    {
                        // ventana
                        var AE = new AgendaEmpresa {Id_subcat = ((int) listSubcatAd.SelectedValue)};
                        if (AE.ShowDialog() == DialogResult.OK)
                            FillCombos();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una subcategoría.", "Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            switch (((Button) sender).Name)
            {
                case "btnModif1":
                    if (listClavesAd.SelectedIndex != -1)
                    {
                        var AS = new AgendaSolicitud {Editar = true, Id_cat = ((int) listClavesAd.SelectedValue)};
                        if (AS.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Datos ingresados correctamente", "GEO Agenda", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            FillCombos();
                        }
                    }
                    break;
                case "btnModif2":
                    if (listSubcatAd.SelectedIndex != -1)
                    {
                        var AC = new AgendaCategoria
                                     {
                                         Id_cat = ((int) listClavesAd.SelectedValue),
                                         Id_subcat = ((int) listSubcatAd.SelectedValue),
                                         Editar = true
                                     };
                        if (AC.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Datos ingresados correctamente", "GEO Agenda", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            FillCombos();
                        }
                    }
                    break;
                case "btnModif3":
                    if (listEmpresasAd.SelectedIndex != -1)
                    {
                        var AE = new AgendaEmpresa
                                     {
                                         Id_empresa = ((int) listEmpresasAd.SelectedValue),
                                         Id_subcat = ((int) listSubcatAd.SelectedValue),
                                         Editar = true
                                     };
                        if (AE.ShowDialog() == DialogResult.OK)
                            FillCombos();
                    }
                    break;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            switch (((Button) sender).Name)
            {
                case "btnEliminar1":
                    if (listClavesAd.SelectedIndex != -1)
                    {
                        if (
                            MessageBox.Show(this, "¿Desea realmente eliminar este registro?", "Eliminar",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            new a_agenda_cat().Delete((int) listClavesAd.SelectedValue);
                            FillCombos();
                        }
                    }
                    break;
                case "btnEliminar2":
                    if (listSubcatAd.SelectedIndex != -1)
                    {
                        if (
                            MessageBox.Show(this, "¿Desea realmente eliminar este registro?", "Eliminar",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            new a_agenda_subcat().Delete((int) listSubcatAd.SelectedValue);
                            FillCombos();
                        }
                    }
                    break;
                case "btnEliminar3":
                    if (listEmpresasAd.SelectedIndex != -1)
                    {
                        if (
                            MessageBox.Show(this, "¿Desea realmente eliminar este registro?", "Eliminar",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            new a_agenda_detalle().Delete((int) listEmpresasAd.SelectedValue);
                            FillCombos();
                        }
                    }
                    break;
            }
        }

        private void FillCombos()
        {
            listClavesAd.DisplayMember = "nombre";
            listClavesAd.ValueMember = "id_cat";
            listClavesAd.DataSource = new a_agenda_cat().Geta_agenda_cat().Tables[0];
        }

        private void listClavesAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listClavesAd.SelectedValue != null)
            {
                listEmpresasAd.DataSource = null;
                listSubcatAd.DisplayMember = "nombre";
                listSubcatAd.ValueMember = "id_subcat";

                var sub = new a_agenda_subcat();
                listSubcatAd.DataSource = sub.Geta_agenda_subcat((int) listClavesAd.SelectedValue).Tables[0];
            }
        }

        private void listSubcatAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSubcatAd.SelectedValue != null)
            {
                var det = new a_agenda_detalle();
                listEmpresasAd.DisplayMember = "nombre";
                listEmpresasAd.ValueMember = "id_empresa";
                listEmpresasAd.DataSource = det.Geta_agenda_detalle((int) listSubcatAd.SelectedValue).Tables[0];
            }
        }
    }
}