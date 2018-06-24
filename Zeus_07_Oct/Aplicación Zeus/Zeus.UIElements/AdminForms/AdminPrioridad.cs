using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminPrioridad : AdminBase
    {
        public AdminPrioridad()
        {
            InitializeComponent();
        }

        private void AdminPrioridad_Load(object sender, EventArgs e)
        {
            try
            {
                // controles!
                DataSet tc = new z_tipo_carro().Getz_tipo_carro();
                var l = new List<ReorderListBox>();
                for (int i = 0; i < tc.Tables[0].Rows.Count; i++)
                {
                    // poner de a 6 controles por linea

                    var r = new ReorderListBox
                                {
                                    Text = ("Prioridad " + (string) tc.Tables[0].Rows[i]["tipo_nom"].ToString()),
                                    Name = ("ID_PRIORIDAD_" + (string) tc.Tables[0].Rows[i]["alias"].ToString()),
                                    DisplayMember = "id_cuartel",
                                    ValueMember = "id_cuartel",
                                    Size = new Size(110, 175)
                                };
                    l.Add(r);
                }
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.SuspendLayout();

                for (int i = 0; i < l.Count; i++)
                {
                    tableLayoutPanel1.Controls.Add(l[i], i%6, i/6);
                }
                tableLayoutPanel1.ResumeLayout();

                // datos!
                listActuales.DisplayMember = "id_area";
                listActuales.ValueMember = "id_area";
                Source = new k_areas().Getk_areas().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override bool Validar()
        {
            return true;
        }

        protected override void Mostrar(int id)
        {
            try
            {
                DataSet tc = new z_tipo_carro().Getz_tipo_carro();
                foreach (DataRow row in tc.Tables[0].Rows)
                {
                    DataSet ds = new z_prioridad().Getz_prioridad(id, Convert.ToInt32(row["alias"].ToString()));
                    foreach (Control rl in tableLayoutPanel1.Controls)
                    {
                        var l = rl as ReorderListBox;
                        if (l != null && l.Name.Contains("ID_PRIORIDAD_" + row["alias"].ToString()))
                        {
                            // agregar columnas y valores
                            l.DataSource = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Actualizar()
        {
            try
            {
                DataSet tc = new z_tipo_carro().Getz_tipo_carro("");
                foreach (DataRow row in tc.Tables[0].Rows)
                {

                    DataSet ds = new z_prioridad().Getz_prioridad((int)listActuales.SelectedValue, Convert.ToInt32(row["alias"].ToString()));
                    var p = new z_prioridad();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var columnas = new List<KeyValuePair<string, int>>();
                        foreach (Control rl in tableLayoutPanel1.Controls)
                        {
                            var l = rl as ReorderListBox;
                            if (l != null && l.Name.Contains("ID_PRIORIDAD_" + row["alias"].ToString()))
                            {
                                // agregar columnas y valores
                                columnas.Add(new KeyValuePair<string, int>(l.DisplayMember, l.Items[i]));
                            }
                        }

                        // actualizar!
                        p.modifyz_prioridad((int)ds.Tables[0].Rows[i]["id_prioridad"], columnas);
                    }   
                }

                BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval,
                                                "Modificación Tabla Prioridad de Despacho");

                MessageBox.Show("Datos ingresados correctamente", "Mensaje de Zeus", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }
    }
}