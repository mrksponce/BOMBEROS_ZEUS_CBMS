using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminConductor : Form
    {
        private readonly List<int> carros;
        private bool _clic;
        private List<int> carrosCheck;
        private z_conductores conductor;
        private DataSet ds;
        private bool enNuevo;
        private List<object> nombres;
        private object source;

        public AdminConductor()
        {
            InitializeComponent();
            carros = new List<int>();
            carrosCheck = new List<int>();
            conductor = new z_conductores();
        }

        private object Source
        {
            set
            {
                source = value;
                listConductores.DataSource = value;
            }
        }

        private void textVoluntarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int d;
                if (int.TryParse(textVoluntarios.Text, out d))
                {
                    // obtener nombre por num radio
                    DataRow[] dr = ds.Tables[0].Select("num_llamado=" + d);
                    if (dr != null && dr.GetLength(0) > 0)
                    {
                        textVoluntarios.Text = dr[0]["apellidos"] + " " + dr[0]["nombres"];
                        listNombres.SelectedItem = textVoluntarios.Text;
                    }
                }
            }
        }

        private void listVoluntarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNombres.SelectedIndex != -1)
            {
                _clic = true;
                textVoluntarios.Text = ((KeyValuePair<string, int>) listNombres.SelectedItem).Key;
            }
        }

        private void textVoluntarios_TextChanged(object sender, EventArgs e)
        {
            if (!_clic)
            {
                var o = new ListBox.ObjectCollection(listNombres);
                foreach (KeyValuePair<string, int> k in nombres)
                {
                    if (k.Key.ToUpper().Contains(textVoluntarios.Text.ToUpper()))
                    {
                        o.Add(k);
                    }
                }
                listNombres.Items.Clear();
                listNombres.Items.AddRange(o);
                listNombres.SelectedIndex = -1;
            }
            _clic = false;
        }

        private void FillCuarteleros()
        {
            var cuart = new z_cuarteleros();
            ds = cuart.Getz_cuarteleros();
            nombres = new List<object>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var p =
                    new KeyValuePair<string, int>((string) dr["apellidos"] + " " + dr["nombres"],
                                                  (int) dr["id_cuartelero"]);
                nombres.Add(p);
            }
            listNombres.Items.Clear();
            listNombres.Items.AddRange(nombres.ToArray());
        }

        private void FillVoluntarios(int compania)
        {
            try
            {
                var vol = new z_voluntarios();
                ds = compania == 0 ? vol.Getz_voluntarios() : vol.Getz_voluntarios(compania);
                nombres = new List<object>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var p =
                        new KeyValuePair<string, int>((string) dr["apellidos"] + " " + dr["nombres"],
                                                      (int) dr["id_voluntario"]);
                    nombres.Add(p);
                }
                listNombres.Items.Clear();
                listNombres.Items.AddRange(nombres.ToArray());
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void FillConductores()
        {
            try
            {
                //listConductores.DataSource = conductor.GetListz_conductores().Tables[0];
                Source = conductor.GetListz_conductores().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void FillCarros()
        {
            try
            {
                listCarros.Items.Clear();
                carrosCheck = new List<int>();
                var carro = new z_carros();
                DataSet set = carro.Getz_carros();
                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    carros.Add((int) dr["id_carro"]);
                    listCarros.Items.Add(dr["nombre"]);
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void FillCarros(string ids)
        {
            try
            {
                listCarros.Items.Clear();
                carrosCheck = new List<int>();
                var carro = new z_carros();
                DataSet set = carro.Getz_carros();

                // lista de carros a integer
                var id_carros = new List<int>();
                if (ids != "")
                {
                    foreach (string s in ids.Split(','))
                    {
                        id_carros.Add(int.Parse(s));
                    }
                }


                // verificar y chequear
                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    carros.Add((int) dr["id_carro"]);
                    if (id_carros.Contains((int) dr["id_carro"]))
                    {
                        listCarros.Items.Add(dr["nombre"], true);
                    }
                    else
                    {
                        listCarros.Items.Add(dr["nombre"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void FillCompanias()
        {
            try
            {
                comboBox1.DisplayMember = comboBox1.ValueMember = "id_compania";
                comboBox1.DataSource = new z_companias().Getz_companias().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void CrearConductor_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                listConductores.DisplayMember = "nombre_completo";
                listConductores.ValueMember = "id_conductor";
                listNombres.DisplayMember = "Key";

                FillCarros();
                FillCuarteleros();
                FillConductores();
                FillCompanias();
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCuartelero.Checked)
            {
                FillCuarteleros();
                checkCompania.Checked = false;
                checkCompania.Enabled = false;
            }
            else
            {
                FillVoluntarios(0);
                checkCompania.Enabled = true;
            }
        }

        private void listConductores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listConductores.SelectedIndex != -1)
            {
                // cargar informacion
                conductor = conductor.getObjectz_conductores((int) listConductores.SelectedValue);
                if (conductor.id_tipo_conductor == 1)
                {
                    radioCuartelero.Checked = true;
                }
                else
                {
                    radioVoluntario.Checked = true;
                }
                // nombre
                if (nombres != null)
                {
                    listNombres.SelectedItem =
                        nombres.Find(
                            o => (((KeyValuePair<string, int>) o).Value == conductor.id_cuart_vol));
                }

                // resto de datos
                textTipo.Text = conductor.tipo_licencia;
                dateLicencia.Value = conductor.licencia_vence;
                textCodigo.Text = conductor.codigo_conductor;

                FillCarros(conductor.id_carros);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Está seguro que desea eliminar este conductor?", "Confirmar Eliminación",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // eliminar
                    var cond = new z_conductores();
                    cond.deletez_conductores((int) listConductores.SelectedValue);
                    FillConductores();
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!enNuevo)
            {
                // preparar nuevo
                listConductores.Enabled = false;
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                radioCuartelero.Checked = true;
                listNombres.SelectedItem = null;
                textVoluntarios.Text = "";

                textCodigo.Text = "";
                textTipo.Text = "";
                dateLicencia.Value = DateTime.Now;

                FillCarros();
                btnNuevo.Text = "Insertar";

                carrosCheck = new List<int>();
                conductor = new z_conductores();

                enNuevo = true;
            }
            else
            {
                if (Validar(false))
                {
                    try
                    {
                        conductor.codigo_conductor = textCodigo.Text;
                        conductor.disponible = true;
                        conductor.id_cuart_vol = ((KeyValuePair<string, int>) listNombres.SelectedItem).Value;
                        conductor.id_tipo_conductor = radioCuartelero.Checked ? 1 : 2;
                        conductor.licencia_vence = dateLicencia.Value;
                        conductor.tipo_licencia = textTipo.Text;
                        // carros
                        foreach (int i in carrosCheck)
                        {
                            conductor.id_carros += "," + i;
                        }
                        conductor.id_carros = conductor.id_carros.Trim(',');
                        conductor.addz_conductores(conductor);

                        listConductores.Enabled = true;
                        btnActualizar.Enabled = true;
                        btnEliminar.Enabled = true;

                        btnNuevo.Text = "Nuevo";
                        FillConductores();
                        enNuevo = false;
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
        }

        private bool Validar(bool actualizar)
        {
            bool ok = true;
            string msg = "Los siguientes datos faltan o son erróneos:\n";

            if (listNombres.SelectedItem == null)
            {
                ok = false;
                msg += "* No ha seleccionado el nombre del conductor.\n";
            }

            if (textTipo.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado el tipo de licencia.\n";
            }

            if (dateLicencia.Value < DateTime.Now)
            {
                ok = false;
                msg += "* La fecha ingresada no es válida.\n";
            }

            if (textCodigo.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado el código del conductor.\n";
            }

            if (carrosCheck.Count == 0)
            {
                ok = false;
                msg += "* No ha seleccionado los carros.\n";
            }
            if (conductor.getObjectz_conductores(textCodigo.Text).id_conductor != 0 && !actualizar)
            {
                ok = false;
                msg += "* El código del conductor ya existe.\n";
            }
            if (!ok)
            {
                MessageBox.Show(msg, "Faltan datos");
            }
            return ok;
        }

        private void listCarros_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                //quitar
                carrosCheck.Remove(carros[e.Index]);
            }
            else
            {
                carrosCheck.Add(carros[e.Index]);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validar(true))
            {
                if (
                    MessageBox.Show("¿Está seguro que desea actualizar este conductor?", "Confirmar Actualización",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        conductor.codigo_conductor = textCodigo.Text;
                        conductor.id_cuart_vol = ((KeyValuePair<string, int>) listNombres.SelectedItem).Value;
                        conductor.id_tipo_conductor = radioCuartelero.Checked ? 1 : 2;
                        conductor.licencia_vence = dateLicencia.Value;
                        conductor.tipo_licencia = textTipo.Text;
                        // carros
                        conductor.id_carros = "";
                        foreach (int i in carrosCheck)
                        {
                            conductor.id_carros += "," + i;
                        }
                        conductor.id_carros = conductor.id_carros.Trim(',');
                        conductor.modifyz_conductores(conductor);
                        FillConductores();
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
        }

        private void checkCompania_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkCompania.Checked)
            {
                FillVoluntarios(0);
            }
            else
            {
                FillVoluntarios((int) comboBox1.SelectedValue);
            }
            comboBox1.Enabled = checkCompania.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Enabled)
            {
                FillVoluntarios((int) comboBox1.SelectedValue);
            }
        }

        private void textBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (source != null)
            {
                // buscar y asignar
                listConductores.DataSource =
                    ArrayToDataTable(
                        ((DataTable) source).Select(listConductores.DisplayMember + " like '%" + textBusqueda.Text +
                                                    "%'"));
            }
        }

        private DataTable ArrayToDataTable(IEnumerable<DataRow> drs)
        {
            DataTable t = ((DataTable) source).Clone();
            foreach (DataRow dr in drs)
            {
                t.ImportRow(dr);
            }
            return t;
        }
    }
}