using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Zeus.Data;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class Agenda : Form
    {
        public Agenda()
        {
            InitializeComponent();
            Regex r=new Regex(@"(\(.*\)|Exp)");
            Datos = new PostgresDataAccess.DataAccess();

            // llenar combobox
            List<PostgresDataAccess.Expediente> l = new List<PostgresDataAccess.Expediente>();
            DataTable dt = Datos.ObtenerExpedientesActivos();
            foreach (DataRow dr in dt.Rows)
            {
                PostgresDataAccess.Expediente exp = new PostgresDataAccess.Expediente();
                exp.Id_expediente = (int)dr["id_expediente"];
                exp.Seis2 = (string)dr["seis2"];
                exp.Cero5 = (string)dr["cero5"];
                exp.Ubicacion = new PointD((double)dr["puntoX"], (double)dr["puntoY"]);
                comboExpedientes.Items.Add(Datos.ObtenerClaveLlamado((int)dr["codigo_llamado"]) + " >> " + exp.Seis2+" / "+exp.Cero5);
                l.Add(exp);
            }

            exps = l.ToArray();

            FillCombos();

        }

        private void FillCombos()
        {
            claves = Datos.ObtenerClaves(null);
            listClavesAd.Items.Clear();
            listClaves.Items.Clear();
            foreach (PostgresDataAccess.Clave clave in claves)
            {
                listClavesAd.Items.Add(clave.Nombre);
                listClaves.Items.Add(clave.Nombre);
            }
            listSubcat.Items.Clear();
            listEmpresas.Items.Clear();
            listSubcatAd.Items.Clear();
            listEmpresasAd.Items.Clear();
        }
        private PostgresDataAccess.DataAccess Datos;
        private PostgresDataAccess.Expediente[] exps;
        //private PostgresDataAccess.Clave[] claves;

        private void btnNueva_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "btnNueva1":
                    AgendaSolicitud AS = new AgendaSolicitud();
                    if (AS.ShowDialog() == DialogResult.OK)
                        MessageBox.Show("Datos ingresados correctamente", "GEO Agenda");
                    FillCombos();
                    break;
                case "btnNueva2":
                    if (listClavesAd.SelectedIndex != -1)
                    {
                        AgendaCategoria AC = new AgendaCategoria(claves[listClavesAd.SelectedIndex].Id_cat);
                        if (AC.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Datos ingresados correctamente", "GEO Agenda");
                            FillCombos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una clave de servicio.", "Error");
                    }
                    break;
                case "btnNueva3":
                    if (listSubcatAd.SelectedIndex != -1)
                    {
                        // ventana
                        AgendaEmpresa AE = new AgendaEmpresa(subcats[listSubcatAd.SelectedIndex].Key);
                        if (AE.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Datos ingresados correctamente", "GEO Agenda");
                            FillCombos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una subcategoría.", "Error");
                    }
                    break;
                default:
                    break;
            }
        }

        //private void IniciarAdmin()
        //{
        //    // llenar combobox
        //    claves = Datos.ObtenerClaves(null);
        //    comboClaves.Items.Clear();
        //    foreach (PostgresDataAccess.Clave c in claves)
        //    {
        //        comboClaves.Items.Add(c.Nombre);
        //    }

            
        //}

        private PostgresDataAccess.Clave[] claves;
        private PostgresDataAccess.Empresa[] empresas, lempresas;
        private KeyValuePair<int, string>[] subcats, lsubcats;

        private void comboClaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listClavesAd.SelectedIndex != -1)
            {
                subcats = Datos.ObtenerSubCats(claves[listClavesAd.SelectedIndex].Id_cat);
                listSubcatAd.Items.Clear();
                listEmpresasAd.Items.Clear();
                foreach (KeyValuePair<int, string> k in subcats)
                {
                    listSubcatAd.Items.Add(k.Value);
                }
            }
        }

        private void comboSubcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSubcatAd.SelectedIndex != -1)
            {
                empresas = Datos.ObtenerEmpresas(subcats[listSubcatAd.SelectedIndex].Key);
                listEmpresasAd.Items.Clear();
                foreach (PostgresDataAccess.Empresa em in empresas)
                {
                    listEmpresasAd.Items.Add(em.Nombre);
                }
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "btnModif1":
                    if (listClavesAd.SelectedIndex!=-1)
                    {
                        AgendaSolicitud AS = new AgendaSolicitud(claves[listClavesAd.SelectedIndex].Id_cat);
                        if (AS.ShowDialog() == DialogResult.OK)
                            FillCombos();
                        
                    } break;
                case "btnModif2":
                    if (listSubcatAd.SelectedIndex!=-1)
                    {
                        AgendaCategoria AC = new AgendaCategoria(subcats[listSubcatAd.SelectedIndex].Key, true);
                        if (AC.ShowDialog() == DialogResult.OK)
                            FillCombos();

                    } break;
                case "btnModif3":
                    if (listEmpresasAd.SelectedIndex!=-1)
                    {
                        AgendaEmpresa AE = new AgendaEmpresa(empresas[listEmpresasAd.SelectedIndex].Id_empresa, true);
                        if (AE.ShowDialog() == DialogResult.OK)
                            FillCombos();

                    } break;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "btnEliminar1":
                    if (listClavesAd.SelectedIndex != -1)
                    {
                        if (MessageBox.Show(this, "¿Desea realmente eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Datos.EliminarClave(claves[listClavesAd.SelectedIndex].Id_cat);
                            FillCombos();
                        }

                    } break;
                case "btnEliminar2":
                    if (listSubcatAd.SelectedIndex != -1)
                    {
                        if (MessageBox.Show(this, "¿Desea realmente eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Datos.EliminarSubCat(subcats[listSubcatAd.SelectedIndex].Key);
                            FillCombos();
                        }

                    } break;
                case "btnEliminar3":
                    if (listEmpresasAd.SelectedIndex != -1)
                    {
                        if (MessageBox.Show(this, "¿Desea realmente eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Datos.EliminarEmpresa(empresas[listEmpresasAd.SelectedIndex].Id_empresa);
                            FillCombos();
                        }

                    } break;
            }
        }

        private void listApoyos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listClaves.SelectedIndex!=-1)
            {
                // llenar subcat.
                listSubcat.Items.Clear();
                listEmpresas.Items.Clear();
                listEmpresas.SelectedIndex = -1;
                lsubcats = Datos.ObtenerSubCats(claves[listClaves.SelectedIndex].Id_cat);
                foreach (KeyValuePair<int, string> k in lsubcats)
                {
                    listSubcat.Items.Add(k.Value);
                }
                if (listSubcat.Items.Count == 1)
                {
                    listSubcat.SelectedIndex = 0;
                    //listSubcat_SelectedIndexChanged(this, new EventArgs());
                }
                
            }
        }

        private void listSubcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            listEmpresas.Items.Clear();
            listEmpresas.SelectedIndex = -1;
            lempresas = Datos.ObtenerEmpresas(lsubcats[listSubcat.SelectedIndex].Key);
            foreach (PostgresDataAccess.Empresa em in lempresas)
            {
                listEmpresas.Items.Add(em.Nombre);
            }
            // si hay georef, mostrar entrada adecuada
            if (comboExpedientes.SelectedIndex != -1 && claves[listClaves.SelectedIndex].Ref_espacial==true)
            {
                listEmpresas.SelectedItem = Datos.ObtenerNombreEmpresa(exps[comboExpedientes.SelectedIndex].Ubicacion, claves[listClaves.SelectedIndex].Tabla);
            }
        }

        private void listEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // info
            textInformacion.Text = lempresas[listEmpresas.SelectedIndex].Nombre + Environment.NewLine+ lempresas[listEmpresas.SelectedIndex].Telefono;
            if (comboExpedientes.SelectedIndex!=-1)
            {
                // solicitado o en lugar
                bool? estado = Datos.ObtenerEmpresaSolicitado(lempresas[listEmpresas.SelectedIndex].Id_empresa, exps[comboExpedientes.SelectedIndex].Id_expediente);
                btnSolicita.Image = null;
                btnLugar.Image = null;
                btnSolicita.Enabled = true;
                btnLugar.Enabled = true;
                switch (estado)
                {
                    case true://"SE SOLICITA":
                        btnSolicita.Image = Iconos.success.ToBitmap();
                        btnSolicita.Enabled = false;
                        break;
                    case false://"EN LUGAR":
                        btnLugar.Image = Iconos.success.ToBitmap();
                        btnLugar.Enabled = false;
                        break;
                    default:
                        break;
                } 
            }
            else
            {
                btnSolicita.Image = null;
                btnSolicita.Enabled = true;
                btnLugar.Image = null;
                btnLugar.Enabled = true;
            }
        }

        private void btnSolicita_Click(object sender, EventArgs e)
        {
            if (comboExpedientes.SelectedIndex != -1)
            {
                bool res = Datos.MarcarEmpresa(lempresas[listEmpresas.SelectedIndex].Id_empresa, exps[comboExpedientes.SelectedIndex].Id_expediente, true);
                if (!res)
                    MessageBox.Show("Ha fallado la operación", "Error");
                else
                {
                    ((Button)sender).Image = Iconos.success.ToBitmap();
                    ((Button)sender).Enabled = false;
                    if (btnLugar.Enabled != true)
                    {
                        btnLugar.Image = null;
                        btnLugar.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un expediente primero.", "Error");
            }
        }

        private void btnLugar_Click(object sender, EventArgs e)
        {
            if (comboExpedientes.SelectedIndex != -1)
            {
                bool res = Datos.MarcarEmpresa(lempresas[listEmpresas.SelectedIndex].Id_empresa, exps[comboExpedientes.SelectedIndex].Id_expediente, false);
                if (!res)
                    MessageBox.Show("Ha fallado la operación", "Error");
                else
                {
                    ((Button)sender).Image = Iconos.success.ToBitmap();
                    ((Button)sender).Enabled = false;
                    if (btnSolicita.Enabled != true)
                    {
                        btnSolicita.Image = null;
                        btnSolicita.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un expediente primero.", "Error");
            }
        }

        private void comboExpedientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listEmpresas.Items.Clear();
            listSubcat.Items.Clear();
            btnLugar.Image = null;
            btnLugar.Enabled = true;
            btnSolicita.Image = null;
            btnSolicita.Enabled = true;
            listClaves.SelectedIndex = -1;
        }
    }
}