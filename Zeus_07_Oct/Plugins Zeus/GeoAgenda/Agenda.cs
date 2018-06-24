using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace GeoAgenda
{
    public partial class Agenda : Form
    {
        private DataSet Categorias;
        private DataSet Empresas;
        private DataSet Expedientes;
        private IZeusWin zeusWin;

        public Agenda()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        private void FillCombos()
        {
            var cat = new a_agenda_cat();
            Categorias = cat.Geta_agenda_cat();
            var det = new a_agenda_detalle();
            Empresas = det.Geta_agenda_detalle();

            listClaves.Items.Clear();
            listClaves.DisplayMember = "nombre";
            listClaves.ValueMember = "id_cat";
            listClaves.DataSource = Categorias.Tables[0];
        }

        private void listApoyos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listClaves.SelectedIndex != -1)
            {
                // llenar subcat.
                listEmpresas.DataSource = null;
                listSubcat.DisplayMember = "nombre";
                listSubcat.ValueMember = "id_subcat";

                var sub = new a_agenda_subcat();
                listSubcat.DataSource = sub.Geta_agenda_subcat((int) listClaves.SelectedValue).Tables[0];
            }
        }

        private void listSubcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSubcat.SelectedIndex != -1)
            {
                var det = new a_agenda_detalle();
                Empresas = det.Geta_agenda_detalle((int) listSubcat.SelectedValue);
                listEmpresas.DisplayMember = "nombre";
                listEmpresas.ValueMember = "id_empresa";
                listEmpresas.DataSource = Empresas.Tables[0];
                // si hay georef, mostrar entrada adecuada
                DataRow cat = Categorias.Tables[0].Select("id_cat=" + listClaves.SelectedValue)[0];
                if (comboExpedientes.SelectedIndex != -1 && (bool) cat["ref_espacial"])
                {
                    DataRow dr = Expedientes.Tables[0].Select("id_expediente=" + comboExpedientes.SelectedValue)[0];
                    var p = new PointD((double) dr["puntoX"], (double) dr["puntoY"]);
                    listEmpresas.SelectedValue = det.GetEmpresa(p, (string) cat["tabla"]);
                }
            }
        }

        private void listEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listEmpresas.SelectedIndex != -1)
            {
                // info
                textInformacion.Text = (string) ((DataRowView) listEmpresas.SelectedItem).Row["nombre"] +
                                       Environment.NewLine +
                                       (string) ((DataRowView) listEmpresas.SelectedItem).Row["telefono"];
                if (comboExpedientes.SelectedIndex != -1)
                {
                    // solicitado o en lugar
                    e_recursos_empresas re =
                        new e_recursos_empresas().getObjecte_recursos_empresas((int) comboExpedientes.SelectedValue,
                                                                               (int) listEmpresas.SelectedValue);
                    //bool? estado = Datos.ObtenerEmpresaSolicitado(lempresas[listEmpresas.SelectedIndex].Id_empresa, exps[comboExpedientes.SelectedIndex].Id_expediente);
                    btnSolicita.Image = null;
                    btnLugar2.Image = null;
                    btnSolicita.Enabled = true;
                    btnLugar2.Enabled = true;
                    if (re.id_expediente == 0)
                        return;
                    switch (re.estado)
                    {
                        case true: //"SE SOLICITA":
                            btnSolicita.Image = Resources.success.ToBitmap();
                            btnSolicita.Enabled = false;
                            break;
                        case false: //"EN LUGAR":
                            btnLugar2.Image = Resources.success.ToBitmap();
                            btnLugar2.Enabled = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    btnSolicita.Image = null;
                    btnSolicita.Enabled = true;
                    btnLugar2.Image = null;
                    btnLugar2.Enabled = true;
                }
            }
        }

        private void btnSolicita_Click(object sender, EventArgs e)
        {
            if (comboExpedientes.SelectedIndex != -1 && listEmpresas.SelectedIndex != -1)
            {
                try
                {
                    e_recursos_empresas re =
                        new e_recursos_empresas().getObjecte_recursos_empresas((int) comboExpedientes.SelectedValue,
                                                                               (int) listEmpresas.SelectedValue);
                    re.estado = true;
                    if (re.id_expediente == 0)
                    {
                        re.id_expediente = (int) comboExpedientes.SelectedValue;
                        re.id_empresa = (int) listEmpresas.SelectedValue;
                        re.Insert(re);
                    }
                    else
                    {
                        re.Update(re);
                    }
                    a_agenda_detalle det = new a_agenda_detalle().getObjecta_agenda_detalle(re.id_empresa);
                    BitacoraLlamado.NuevoEvento((int) comboExpedientes.SelectedValue, "apoyo",
                                                "Se Solicita: " + det.nombre);
                    FillSolicitado();

                    ((Button) sender).Image = Resources.success.ToBitmap();
                    ((Button) sender).Enabled = false;
                    if (btnLugar.Enabled != true)
                    {
                        btnLugar.Image = null;
                        btnLugar.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    Log.Write(ex);
                    MessageBox.Show("No se pudo completar la operación debido a un error de Base de Datos.",
                                    "Mensaje de Zeus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un expediente y una empresa primero.", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnLugar_Click(object sender, EventArgs e)
        {
            if (listSolicitado.SelectedItems.Count != 0)
            {
                try
                {
                    e_recursos_empresas ere =
                        new e_recursos_empresas().getObjecte_recursos_empresas((int) listSolicitado.SelectedItems[0].Tag);
                    ere.estado = false;
                    ere.Update(ere);
                    a_agenda_detalle det = new a_agenda_detalle().getObjecta_agenda_detalle(ere.id_empresa);
                    BitacoraLlamado.NuevoEvento((int) comboExpedientes.SelectedValue, "apoyo",
                                                "En el Lugar: " + det.nombre);

                    FillSolicitado();
                }
                catch
                {
                    MessageBox.Show("No se pudo completar la operación debido a un error de Base de Datos.",
                                    "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un apoyo primero.", "Mensaje de ZEUS", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void comboExpedientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLugar.Image = null;
            btnLugar.Enabled = true;
            btnSolicita.Image = null;
            btnSolicita.Enabled = true;
            listClaves.SelectedIndex = -1;

            // apoyo solicitado
            if (comboExpedientes.SelectedValue != null)
            {
                FillSolicitado();
            }
        }

        private void FillSolicitado()
        {
            var ere = new e_recursos_empresas();
            DataSet ds = ere.Gete_recursos_empresas_expediente((int) comboExpedientes.SelectedValue);
            listSolicitado.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var li = new ListViewItem {Tag = dr["id_empresa"], Text = ((string) dr["nombre"])};
                li.SubItems.Add((bool) dr["estado"] ? "Solicitado" : "En el Lugar");
                listSolicitado.Items.Add(li);
            }
        }

/*
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            new GeoAdmin().ShowDialog();
        }
*/

        private void Agenda_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.Agenda.GetHicon());

            var exp = new e_expedientes();
            Expedientes = exp.Gete_expedientes();
            comboExpedientes.DisplayMember = "clave_dir";
            comboExpedientes.ValueMember = "id_expediente";
            comboExpedientes.DataSource = Expedientes.Tables[0];
            comboExpedientes.SelectedValue = zeusWin.IdExpediente;
            FillCombos();
        }

        private void btnLugar2_Click(object sender, EventArgs e)
        {
            if (comboExpedientes.SelectedIndex != -1 && listEmpresas.SelectedIndex != -1)
            {
                try
                {
                    e_recursos_empresas re =
                        new e_recursos_empresas().getObjecte_recursos_empresas((int) comboExpedientes.SelectedValue,
                                                                               (int) listEmpresas.SelectedValue);
                    re.estado = false;
                    if (re.id_expediente == 0)
                    {
                        re.id_expediente = (int) comboExpedientes.SelectedValue;
                        re.id_empresa = (int) listEmpresas.SelectedValue;
                        re.Insert(re);
                    }
                    else
                    {
                        re.Update(re);
                    }
                    ((Button) sender).Image = Resources.success.ToBitmap();
                    ((Button) sender).Enabled = false;
                    if (btnSolicita.Enabled != true)
                    {
                        btnSolicita.Image = null;
                        btnSolicita.Enabled = true;
                    }
                    FillSolicitado();
                }
                catch (Exception ex)
                {
                    Log.Write(ex);
                    MessageBox.Show("No se pudo completar la operación debido a un error de Base de Datos.",
                                    "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un expediente y una empresa primero.", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (listSolicitado.SelectedItems.Count != 0)
            {
                if (
                    MessageBox.Show("¿Seguro desea deshacer esta solicitud?", "Confirme", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        e_recursos_empresas ere =
                            new e_recursos_empresas().getObjecte_recursos_empresas(
                                (int) listSolicitado.SelectedItems[0].Tag);
                        ere.Delete(ere.id_empresa);
                        a_agenda_detalle det = new a_agenda_detalle().getObjecta_agenda_detalle(ere.id_empresa);
                        BitacoraLlamado.NuevoEvento((int) comboExpedientes.SelectedValue, "apoyo",
                                                    "Eliminación de Solicitud: " + det.nombre);

                        FillSolicitado();
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo completar la operación debido a un error de Base de Datos.",
                                        "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un apoyo primero.", "Mensaje de ZEUS", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }
    }
}