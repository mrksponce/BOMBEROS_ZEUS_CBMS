using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminOficiales : AdminBase
    {
        private bool _clic;
        private DataSet ds;
        private List<object> nombres = new List<object>();

        public AdminOficiales()
        {
            InitializeComponent();
        }

        private void AdminOficiales_Load(object sender, EventArgs e)
        {
            try
            {
                // agregar cargos oficiales
                DataSet c_oficiales = new z_oficiales().Getz_oficialesVisibles();
                comboCargos.DisplayMember = "tipo";
                comboCargos.ValueMember = "id_oficial";
                comboCargos.DataSource = c_oficiales.Tables[0];

                listNombres.DisplayMember = "Key";
                listNombres.ValueMember = "Value";

                var vol = new z_voluntarios();
                ds = vol.Getz_voluntarios();
                nombres = new List<object>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var p =
                        new KeyValuePair<string, int>((string)dr["apellidos"] + " " + dr["nombres"],
                                                      (int)dr["id_voluntario"]);
                    nombres.Add(p);
                }
                listNombres.Items.Clear();
                listNombres.Items.AddRange(nombres.ToArray());

                listActuales.DisplayMember = "nombre_completo";
                listActuales.ValueMember = "id_cargo";
                Source = new z_cargos().Getz_cargosLista().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void listVoluntarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNombres.SelectedIndex != -1)
            {
                _clic = true;
                textVoluntarios.Text = ((KeyValuePair<string, int>)listNombres.SelectedItem).Key;
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

        protected override void Mostrar(int id)
        {
            try
            {
                z_cargos cargo = new z_cargos().getObjectz_cargos(id);

                //textVoluntarios.Text = vol.apellidos + " " + vol.nombres;
                object i =
                    nombres.Find(
                        o => (((KeyValuePair<string, int>)o).Value == cargo.id_voluntario));
                listNombres.SelectedItem = i;

                //textGrado.Text = cargo.grado.ToString();
                comboCargos.SelectedValue = cargo.id_oficial;
                textLlamado.Text = cargo.llamado_oficial.ToString();
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Limpiar()
        {
            textVoluntarios.Text = "";
            textVoluntarios_TextChanged(null, null);
            textLlamado.Text = "";
            //textGrado.Text = "";
            //listNombres.SelectedIndex = -1;
        }

        protected override void Insertar()
        {
            try
            {
                var cargo = new z_cargos
                {
                    id_voluntario = ((KeyValuePair<string, int>)listNombres.SelectedItem).Value,
                    llamado_oficial = int.Parse(textLlamado.Text),
                    id_oficial = (int)comboCargos.SelectedValue,
                    //int.Parse(textGrado.Text)
                    activo = true
                };

                var oldCargo =
                    new z_cargos().getObjectz_cargos_llam(cargo.llamado_oficial);
                if (oldCargo.id_voluntario != 0)
                {
                    cargo.id_cargo = oldCargo.id_cargo;
                    cargo.orden_antiguedad = oldCargo.orden_antiguedad;
                    cargo.cargo_antiguedad = oldCargo.cargo_antiguedad;
                    oldCargo.modifyz_cargos(cargo);
                }
                else
                {
                    cargo.addz_cargos(cargo);
                }

                Source = cargo.Getz_cargosLista().Tables[0];
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                z_cargos cargo = new z_cargos().getObjectz_cargos((int)listActuales.SelectedValue);
                cargo.id_voluntario = ((KeyValuePair<string, int>)listNombres.SelectedItem).Value;
                cargo.llamado_oficial = int.Parse(textLlamado.Text);
                cargo.id_oficial = (int)comboCargos.SelectedValue;//int.Parse(textGrado.Text)
                cargo.modifyz_cargos(cargo);
                Source = cargo.Getz_cargosLista().Tables[0];
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Eliminar()
        {
            try
            {
                z_cargos cargo = new z_cargos().getObjectz_cargos((int)listActuales.SelectedValue);
                cargo.deletez_cargos(cargo.id_cargo);
                Source = cargo.Getz_cargosLista().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override bool Validar()
        {
            string msg = "La siguiente información falta o tiene formato incorrecto:\n";
            bool ok = true;
            int x;

            if (listNombres.SelectedIndex == -1)
            {
                msg += "* Debe seleccionar un nombre" + "\n";
                ok = false;
            }

            //if (textGrado.Text == "" || !int.TryParse(textGrado.Text, out x))
            //{
            //    msg += "* Grado" + "\n";
            //    ok = false;
            //}
            if (textLlamado.Text == "" || !int.TryParse(textLlamado.Text, out x))
            {
                msg += "* Número de Llamado" + "\n";
                ok = false;
            }

            if (!ok)
            {
                MessageBox.Show(msg, "Error en validación");
            }
            return ok;
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            new AdminOficialesOrden().ShowDialog();
        }
    }
}