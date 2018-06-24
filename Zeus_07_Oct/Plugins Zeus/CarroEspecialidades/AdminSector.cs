using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace CarroEspecialidades
{
    public partial class AdminSector : Form
    {
        public AdminSector()
        {
            InitializeComponent();
        }

        private void AdminSector_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.asignacion_carro_especialidad_32.GetHicon());

            CargarSectores();
        }

        private void CargarSectores()
        {
            try
            {
                DataSet ds = new s_sector().Gets_sector();
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var es = new EditSector
                                 {
                                     IdSector = ((int) dr["id_sector"]),
                                     Descripcion = ((string) dr["descripcion"]),
                                     Areas = ((string) dr["id_areas"])
                                 };
                    flowLayoutPanel1.Controls.Add(es);
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var es = new EditSector {IdSector = 0};
            flowLayoutPanel1.Controls.Add(es);
            flowLayoutPanel1.ScrollControlIntoView(es);
            es.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                // guardar cambios!
                try
                {
                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        var es = c as EditSector;
                        if (es != null)
                        {
                            var sect = new s_sector
                                           {
                                               id_sector = es.IdSector,
                                               id_areas = es.Areas.Replace(" ", "").Trim(','),
                                               descripcion = es.Descripcion
                                           };
                            if (sect.id_sector != 0)
                            {
                                sect.modifys_sector(sect);
                            }
                            else
                            {
                                sect.adds_sector(sect);
                            }
                        }
                    }
                    CargarSectores();
                    MessageBox.Show("Operación Realizada Exitosamente.", "Mensaje de Zeus", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private bool Validar()
        {
            try
            {
                // generar lista para verificar areas
                DataSet ds = new k_areas().Getk_areas();
                var areas = new Dictionary<int, int>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    areas.Add((int) dr["id_area"], 0);
                }

                // verificar por cada control la presencia del area (y que sea una vez)
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    var es = c as EditSector;
                    if (es != null)
                    {
                        if (es.Descripcion == "" || es.Areas == "")
                        {
                            MessageBox.Show("Los campos Descripción y Áreas no pueden estar vacíos.",
                                            "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        // areas
                        foreach (string s in es.Areas.Replace(" ", "").Split(','))
                        {
                            int i = int.Parse(s);
                            areas[i] = areas[i] + 1;
                        }
                    }
                }

                // ver si faltan/se repiten
                string areafallada = "";
                bool ret = true;
                foreach (int i in areas.Keys)
                {
                    if (areas[i] != 1)
                    {
                        areafallada += "," + i;
                        ret = false;
                    }
                }
                if (!ret)
                {
                    MessageBox.Show(
                        "Las siguiente áreas no se han incluido o se han incluído más de una vez.\n" +
                        areafallada.Trim(','), "Error en áreas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return ret;
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
                return false;
            }
        }
    }
}