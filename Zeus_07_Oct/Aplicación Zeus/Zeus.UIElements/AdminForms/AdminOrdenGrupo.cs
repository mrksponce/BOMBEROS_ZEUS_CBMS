using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminOrdenGrupo : AdminBase
    {
        public AdminOrdenGrupo()
        {
            InitializeComponent();
        }

        private void AdminPrioridad_Load(object sender, EventArgs e)
        {
            try
            {
                // controles!
                var l = new List<ReorderListBox>();
                    // poner de a 6 controles por linea

                    var r = new ReorderListBox
                    {
                        Text = "Grupos de despacho",
                        DisplayMember = "tipo_nom",
                        ValueMember = "tipo_carro",
                        Size = new Size(200, 532)
                    };
                    l.Add(r);
                
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.SuspendLayout();

                for (int i = 0; i < l.Count; i++)
                {
                    tableLayoutPanel1.Controls.Add(l[i], i % 6, i / 6);
                }
                tableLayoutPanel1.ResumeLayout();

                // datos!
                listActuales.DisplayMember = "clave";
                listActuales.ValueMember = "codigo_llamado";
                Source = new k_areas().Getz_llamados().Tables[0];
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
                DataSet ds = new z_prioridad().Getx_orden_tipo(id);
                    foreach (Control rl in tableLayoutPanel1.Controls)
                    {
                        var l = rl as ReorderListBox;
                        if (l != null)
                        {
                            // agregar columnas y valores
                            l.DataSource = ds.Tables[0];
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}