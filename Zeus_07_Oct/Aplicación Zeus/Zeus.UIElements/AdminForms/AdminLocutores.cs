using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminLocutores : Form
    {
        private bool _clic;
        private bool cambiaClave;
        private DataSet ds;
        private bool enNuevo;
        private z_locutores locutor;
        private List<object> nombres;
        private object source;

        public AdminLocutores()
        {
            InitializeComponent();
            locutor = new z_locutores();
        }

        private object Source
        {
            set
            {
                source = value;
                listLocutores.DataSource = value;
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

        private void FillOperadoras()
        {
            var op = new z_operadoras();
            ds = op.Getz_operadorasLista();
            nombres = new List<object>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var p = new KeyValuePair<string, int>((string) dr["nombre_completo"],
                                                                            (int) dr["id_operadora"]);
                nombres.Add(p);
            }
            listNombres.Items.Clear();
            listNombres.Items.AddRange(nombres.ToArray());
        }

        private void FillVoluntarios()
        {
            var vol = new z_voluntarios();
            ds = vol.Getz_voluntarios();
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

        private void FillLocutores()
        {
            try
            {
                //listLocutores.DataSource = locutor.Getz_locutoresLista().Tables[0];
                Source = locutor.Getz_locutoresLista().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        private void CrearLocutores_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                listLocutores.DisplayMember = "nombre_completo";
                listLocutores.ValueMember = "id_locutor";
                listNombres.DisplayMember = "Key";

                FillOperadoras();
                FillLocutores();
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCuartelero.Checked)
            {
                FillOperadoras();
            }
            else
            {
                FillVoluntarios();
            }
        }

        private void listLocutores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listLocutores.SelectedIndex != -1)
            {
                // cargar informacion
                locutor = locutor.getObjectz_locutores((int) listLocutores.SelectedValue);
                if (locutor.id_tipo_locutor == 1)
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
                            o => (((KeyValuePair<string, int>) o).Value == locutor.id_op_vol));
                }

                // resto de datos
                textUser.Text = locutor.login;
                checkAdmin.Checked = locutor.admin;
                textPass.Text = textPass2.Text = locutor.password;
                cambiaClave = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Está seguro que desea eliminar este locutor?", "Confirmar Eliminación",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // eliminar
                try
                {
                    var cond = new z_locutores();
                    cond.deletez_locutores((int) listLocutores.SelectedValue);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
                FillLocutores();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!enNuevo)
            {
                // preparar nuevo
                listLocutores.Enabled = false;
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                radioCuartelero.Checked = true;
                listNombres.SelectedItem = null;
                textVoluntarios.Text = "";

                textPass.Text = textPass2.Text = "";
                textUser.Text = "";

                btnNuevo.Text = "Insertar";

                locutor = new z_locutores();

                enNuevo = true;
            }
            else
            {
                if (Validar())
                {
                    try
                    {
                        locutor.login = textUser.Text;
                        locutor.password = locutor.GenerateHash(textPass.Text);
                        locutor.id_op_vol = ((KeyValuePair<string, int>) listNombres.SelectedItem).Value;
                        locutor.id_tipo_locutor = radioCuartelero.Checked ? 1 : 2;
                        locutor.admin = checkAdmin.Checked;

                        locutor.addz_locutores(locutor);

                        listLocutores.Enabled = true;
                        btnActualizar.Enabled = true;
                        btnEliminar.Enabled = true;

                        btnNuevo.Text = "Nuevo";
                        FillLocutores();
                        enNuevo = false;

                        MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
        }

        private bool Validar()
        {
            bool ok = true;
            string msg = "Los siguientes datos faltan o son erróneos:\n";

            if (listNombres.SelectedItem == null)
            {
                ok = false;
                msg += "* No ha seleccionado el nombre del conductor.\n";
            }

            if (textUser.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado el nombre de inicio de sesión.\n";
            }


            if (textPass.Text == "")
            {
                ok = false;
                msg += "* No ha ingresado la contraseña.\n";
            }

            if (textPass.Text != textPass2.Text)
            {
                ok = false;
                msg += "* Las contraseñas no coinciden.\n";
            }

            if (!ok)
            {
                MessageBox.Show(msg, "Faltan datos");
            }
            return ok;
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (
                    MessageBox.Show("¿Está seguro que desea actualizar este locutor?", "Confirmar Actualización",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        locutor.login = textUser.Text;
                        if (cambiaClave)
                        {
                            locutor.password = locutor.GenerateHash(textPass.Text);
                        }
                        locutor.id_op_vol = ((KeyValuePair<string, int>) listNombres.SelectedItem).Value;
                        locutor.id_tipo_locutor = radioCuartelero.Checked ? 1 : 2;
                        locutor.admin = checkAdmin.Checked;

                        locutor.modifyz_locutores(locutor);
                        FillLocutores();
                        MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {
            cambiaClave = true;
        }

        private void textBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (source != null)
            {
                // buscar y asignar
                listLocutores.DataSource =
                    ArrayToDataTable(
                        ((DataTable) source).Select(listLocutores.DisplayMember + " like '%" + textBusqueda.Text + "%'"));
            }
        }

        private DataTable ArrayToDataTable(DataRow[] drs)
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