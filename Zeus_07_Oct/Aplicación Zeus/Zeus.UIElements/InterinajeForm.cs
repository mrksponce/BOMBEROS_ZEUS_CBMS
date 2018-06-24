using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class InterinajeForm : Form
    {
        private List<Interinaje.Interino> Interinos = new List<Interinaje.Interino>();

        public InterinajeForm()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int d;
            if (int.TryParse(textNum.Text, out d))
            {
                // buscar
                var cargo = new z_cargos();
                DataRow[] dr = cargo.Getz_cargos().Tables[0].Select("llamado_oficial=" + d);
                if (dr.GetLength(0) == 0)
                {
                    listInt.Items.Clear();
                    Interinos.Clear();
                    textNombre.Text = "";
                    comboInter.DataSource = null;
                    comboInter.Enabled = false;
                    return;
                }
                cargo = cargo.getObjectz_cargos((int) dr[0]["id_cargo"]);
                if (cargo.id_voluntario != 0)
                {
                    // mostrar nombre
                    z_voluntarios vol = new z_voluntarios().getObjectz_voluntarios(cargo.id_voluntario);
                    textNombre.Text = vol.apellidos + " " + vol.nombres;
                    //obtener y mostrar interinos
                    Interinos = Interinaje.ObtenerInterinaje(cargo);
                    listInt.Items.Clear();
                    foreach (Interinaje.Interino i in Interinos)
                    {
                        cargo = cargo.getObjectz_cargos(i.Reemplazo);
                        vol = vol.getObjectz_voluntarios(cargo.id_voluntario);
                        var item = new ListViewItem(vol.apellidos + " " + vol.nombres);
                        cargo = cargo.getObjectz_cargos(i.Oficial);
                        vol = vol.getObjectz_voluntarios(cargo.id_voluntario);
                        item.SubItems.Add(vol.apellidos + " " + vol.nombres);
                        listInt.Items.Add(item);
                    }

                    // combo
                    comboInter.DataSource = vol.Getz_voluntarios(-Interinos[Interinos.Count - 1].Reemplazo).Tables[0];
                    comboInter.Enabled = true;
                }
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // validar
            if (Interinos.Count == 0)
            {
                MessageBox.Show("Debe ingresar un oficial válido.");
                return;
            }
            if (comboInter.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un voluntario para Teniente Tercero");
                return;
            }
            Interinaje.ConfirmarInterinaje(Interinos, dateDesde.Value, dateHasta.Value);
            MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void Interinaje_Load(object sender, EventArgs e)
        {
            comboInter.DisplayMember = "nombre_completo";
            comboInter.ValueMember = "id_voluntario";
        }

        private void comboInter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboInter.SelectedValue != null)
            {
                Interinos[Interinos.Count - 1] = new Interinaje.Interino(Interinos[Interinos.Count - 1].Oficial,
                                                                         (int) comboInter.SelectedValue);
                listInt.Items[listInt.Items.Count - 1].SubItems[0].Text =
                    (string) ((DataRowView) comboInter.SelectedItem).Row["nombre_completo"];
            }
        }
    }
}