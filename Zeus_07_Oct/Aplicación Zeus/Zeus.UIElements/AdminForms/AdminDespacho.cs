using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminDespacho : AdminBase
    {
        private bool CarroSelectionChanged;
        private List<clistItems> horario_inhabil;
        private DataSet tc;

        public AdminDespacho()
        {
            InitializeComponent();
        }

        private void AdminDespacho_Load(object sender, EventArgs e)
        {
            try
            {
                horario_inhabil = new List<clistItems>();
                DataSet ds = new z_bloque_horario().Getz_bloque_horario();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    horario_inhabil.Add(new clistItems((int) dr["id_bloque_horario"], false));
                    listBloques.Items.Add((string) dr["descripcion"] + " (" +
                                          ((DateTime) dr["hora_inicio"]).ToString("T") + " - " +
                                          ((DateTime) dr["hora_termino"]).ToString("T") + ")");
                }

                // tipos de carro
                tc = new z_tipo_carro().Getz_tipo_carro();
                int i = 0;
                foreach (DataRow dr in tc.Tables[0].Rows)
                {
                    var l = new Label {AutoSize = true, Text = ((string) dr["tipo_carro_letra"])};
                    var t = new TextBox {Size = new Size(29, 21), Name = ((string) dr["columna_despacho"])};
                    dbInhabil.Controls.Add(l, i, 0);
                    dbInhabil.Controls.Add(t, i, 1);
                    i++;
                }
                foreach (DataRow dr in tc.Tables[0].Rows)
                {
                    var l = new Label {AutoSize = true, Text = ((string) dr["tipo_carro_letra"])};
                    var t = new TextBox {Size = new Size(29, 21), Name = ((string) dr["columna_despacho"])};
                    dbHabil.Controls.Add(l, i, 0);
                    dbHabil.Controls.Add(t, i, 1);
                    i++;
                }

                // datos
                comboClaves.DisplayMember = "desc";
                comboClaves.ValueMember = "codigo_llamado";
                comboClaves.DataSource = new z_llamados().Getz_llamados_principal().Tables[0];

                comboArea.DisplayMember = "id_area";
                comboArea.ValueMember = "id_area";
                comboArea.DataSource = new k_areas().Getk_areas().Tables[0];

                listCarro.DisplayMember = "nombre";
                listCarro.ValueMember = "id_carro";
                listCarro.DataSource = new z_carros().Getz_carros().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void comboClaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboClaves.SelectedIndex != -1)
            {
                try
                {
                    listActuales.DisplayMember = "desc";
                    listActuales.ValueMember = "codigo_llamado";
                    Source =
                        new z_llamados().Getz_llamados_clave(
                            (string) ((DataRowView) comboClaves.SelectedItem).Row["clave"]).Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
            else
            {
                listActuales.DataSource = null;
            }
        }

        protected override void Mostrar(int id)
        {
            if (comboArea.SelectedValue == null || listActuales.SelectedValue == null)
            {
                return;
            }

            try
            {
                DataSet dh = new z_despacho_habil().Getz_despacho_habil((int) comboArea.SelectedValue,
                                                                        (int) listActuales.SelectedValue);
                if (dh.Tables[0].Rows.Count == 0)
                {
                    groupdh.Enabled = false;
                    groupdi.Enabled = false;
                    return;
                }
                groupdh.Enabled = true;
                foreach (DataRow dr in tc.Tables[0].Rows)
                {
                    Control c = dbHabil.Controls[(string) dr["columna_despacho"]];
                    c.Text = dh.Tables[0].Rows[0][c.Name].ToString();
                }

                // 2-6
                check2_6.Checked = (bool) dh.Tables[0].Rows[0]["dos_6"];
                listCarro.SelectedItems.Clear();
                if ((bool) dh.Tables[0].Rows[0]["dos_6"])
                {
                    DataSet ds = new z_dos_6().GetDos6Despacho((int) dh.Tables[0].Rows[0]["id_despacho"]);
                    // marcar carros 2-6... 100% ineficiente
                    for (int i = 0; i < listCarro.Items.Count; i++)
                    {
                        var id_carro = (int) ((DataRowView) listCarro.Items[i])["id_carro"];
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if ((int) dr["id_carro"] == id_carro)
                            {
                                listCarro.SetSelected(i, true);
                            }
                        }
                    }
                    CarroSelectionChanged = false;
                }

                // inhabil
                checkInhabil.Checked = (bool) dh.Tables[0].Rows[0]["inhabil"];
                // limpiar marcas
                for (int i = 0; i < listBloques.Items.Count; i++)
                {
                    listBloques.SetItemChecked(i, false);
                }
                if ((bool) dh.Tables[0].Rows[0]["inhabil"])
                {
                    foreach (string s in ((string) dh.Tables[0].Rows[0]["bloques"]).Split(','))
                    {
                        string s1 = s;
                        int index =
                            horario_inhabil.FindIndex(i => (i.index == int.Parse(s1)));
                        listBloques.SetItemChecked(index, true);
                    }

                    // cargar inhabil
                    DataSet di =
                        new z_despacho_inhabil().Getz_despacho_inhabil((int) dh.Tables[0].Rows[0]["id_despacho"]);
                    foreach (DataRow dr in tc.Tables[0].Rows)
                    {
                        Control c = dbInhabil.Controls[(string) dr["columna_despacho"]];
                        c.Text = di.Tables[0].Rows[0][c.Name].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void check2_6_CheckedChanged(object sender, EventArgs e)
        {
            listCarro.Enabled = check2_6.Checked;
        }

        private void checkInhabil_CheckedChanged(object sender, EventArgs e)
        {
            listBloques.Enabled = groupdi.Enabled = checkInhabil.Checked;
        }

        private void comboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboArea.SelectedIndex != -1)
            {
                Mostrar(0);
            }
        }

        private void listBloques_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            horario_inhabil[e.Index].check = e.CurrentValue != CheckState.Checked;
        }

        protected override bool Validar()
        {
            // texts
            string msg = "La siguiente información falta o tiene formato incorrecto:\n";
            bool ok = true;
            int d;

            foreach (Control c in groupdh.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text == "" || !int.TryParse(c.Text, out d))
                    {
                        msg += "* Carros despacho hábil\n";
                        ok = false;
                        break;
                    }
                }
            }

            if (checkInhabil.Checked)
            {
                // bloques
                bool ch = false;
                for (int i = 0; i < listBloques.Items.Count; i++)
                {
                    if (listBloques.GetItemChecked(i))
                    {
                        ch = true;
                        break;
                    }
                }
                if (!ch)
                {
                    msg += "* No se ha seleccionado bloques inhábiles\n";
                    ok = false;
                }

                foreach (Control c in groupdi.Controls)
                {
                    if (c is TextBox)
                    {
                        if (c.Text == "" || !int.TryParse(c.Text, out d))
                        {
                            msg += "* Carros despacho inhábil\n";
                            ok = false;
                            break;
                        }
                    }
                }
            }


            if (!ok)
            {
                MessageBox.Show(msg, "Error en validación");
            }
            return ok;
        }

        protected override void Actualizar()
        {
            try
            {
                DataRow dh =
                    new z_despacho_habil().Getz_despacho_habil((int) comboArea.SelectedValue,
                                                               (int) listActuales.SelectedValue).Tables[0].Rows[0];
                var columnas = new List<KeyValuePair<string, string>>();
                // carros
                foreach (Control c in dbHabil.Controls)
                {
                    if (c is TextBox)
                    {
                        columnas.Add(new KeyValuePair<string, string>(c.Name, c.Text));
                    }
                }

                // 2-6
                //dh.dos_6 = check2_6.Checked;
                columnas.Add(new KeyValuePair<string, string>("dos_6", check2_6.Checked.ToString()));
                if (check2_6.Checked)
                {
                    if (CarroSelectionChanged)
                    {
                        // borrar anteriores
                        var dos6 = new z_dos_6();
                        dos6.DeleteDos6Despacho((int) dh["id_despacho"]);

                        // agregar nuevos
                        foreach (object obj in listCarro.SelectedItems)
                        {
                            var d6 = new z_dos_6
                                         {
                                             id_despacho = ((int) dh["id_despacho"]),
                                             id_carro = ((int) ((DataRowView) obj)["id_carro"])
                                         };
                            d6.addz_dos_6(d6);
                        }
                    }
                }

                // inhabil
                //dh.inhabil = checkInhabil.Checked;
                columnas.Add(new KeyValuePair<string, string>("inhabil", checkInhabil.Checked.ToString()));
                if (checkInhabil.Checked)
                {
                    // bloques
                    string bloques = "";
                    for (int i = 0; i < horario_inhabil.Count; i++)
                    {
                        if (horario_inhabil[i].check)
                        {
                            bloques += "," + horario_inhabil[i].index;
                        }
                    }
                    //dh.bloques = bloques.Trim(',');
                    columnas.Add(new KeyValuePair<string, string>("bloques", "'" + bloques.Trim(',') + "'"));

                    // carros
                    DataRow di = null;
                    DataSet dsi = new z_despacho_inhabil().Getz_despacho_inhabil((int) dh["id_despacho"]);
                    if (dsi.Tables[0].Rows.Count != 0)
                    {
                        di = dsi.Tables[0].Rows[0];
                    }
                    var columnas_inhabil = new List<KeyValuePair<string, string>>();
                    foreach (Control c in dbInhabil.Controls)
                    {
                        if (c is TextBox)
                        {
                            columnas_inhabil.Add(new KeyValuePair<string, string>(c.Name, c.Text));
                        }
                    }

                    if (di == null)
                    {
                        // nuevo
                        columnas_inhabil.Add(new KeyValuePair<string, string>("codigo_llamado",
                                                                              dh["codigo_llamado"].ToString()));
                        columnas_inhabil.Add(new KeyValuePair<string, string>("id_area", dh["id_area"].ToString()));
                        columnas_inhabil.Add(new KeyValuePair<string, string>("id_despacho",
                                                                              dh["id_despacho"].ToString()));
                        new z_despacho_inhabil().addz_despacho_inhabil(columnas_inhabil);
                    }
                    else
                    {
                        new z_despacho_inhabil().modifyz_despacho_inhabil((int) dh["id_despacho"], columnas_inhabil);
                    }
                }

                new z_despacho_habil().modifyz_despacho_habil((int) dh["id_despacho"], columnas);
                BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval, "Modificación Tablas Despacho");

                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void listCarro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarroSelectionChanged = true;
        }

        #region Nested type: clistItems

        private class clistItems
        {
            public readonly int index;
            public bool check;

            public clistItems(int x, bool y)
            {
                index = x;
                check = y;
            }
        }

        #endregion
    }
}