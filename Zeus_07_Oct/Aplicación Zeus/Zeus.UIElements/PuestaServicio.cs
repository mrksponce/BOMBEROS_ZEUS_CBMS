using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class PuestaServicio : Form
    {
        private bool _clic;
        private List<int> carros;
        private List<int> carrosAct;
        private List<int> carrosCheck;
        private List<int> carrosUncheck;
        private DataSet ds;
        private List<object> nombres;

        public PuestaServicio()
        {
            InitializeComponent();
            carros = new List<int>();
            carrosCheck = new List<int>();
            carrosUncheck = new List<int>();
        }

        public IZeusWin IZeusWin { get; set; }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            datePuestaServicio.Enabled = radioProgramar.Checked;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var cond = new z_conductores();
                cond = cond.getObjectz_conductores(textNombres.Text);
                switch (cond.id_tipo_conductor)
                {
                    case 1:
                        z_cuarteleros cuart = new z_cuarteleros().getObjectz_cuarteleros(cond.id_cuart_vol);
                        textNombres.Text = cuart.apellidos + " " + cuart.nombres;
                        listNombres.SelectedItem = cuart.apellidos + " " + cuart.nombres;
                        break;
                    case 2:
                        z_voluntarios vol = new z_voluntarios().getObjectz_voluntarios(cond.id_cuart_vol);
                        textNombres.Text = vol.apellidos + " " + vol.nombres;
                        listNombres.SelectedItem = vol.apellidos + " " + vol.nombres;
                        break;
                    default:
                        break;
                }
            }
        }

        private void listNombres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNombres.SelectedIndex != -1)
            {
                _clic = true;
                textNombres.Text = ((KeyValuePair<string, int>) listNombres.SelectedItem).Key;
                if (!checkTemporal.Checked)
                {
                    FillCarros(((KeyValuePair<string, int>) listNombres.SelectedItem).Value);
                }
                else
                {
                    FillCarros();
                }
            }
        }

        private void textNombres_TextChanged(object sender, EventArgs e)
        {
            if (!_clic)
            {
                var o = new ListBox.ObjectCollection(listNombres);
                foreach (KeyValuePair<string, int> k in nombres)
                {
                    if (k.Key.ToUpper().Contains(textNombres.Text.ToUpper()))
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

        private void FillConductores(int compania)
        {
            var cond = new z_conductores();
            ds = cond.GetListz_conductores(compania);
            nombres = new List<object>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var p = new KeyValuePair<string, int>((string) dr["nombre_completo"],
                                                                            (int) dr["id_conductor"]);
                nombres.Add(p);
            }
            listNombres.Items.Clear();
            listNombres.Items.AddRange(nombres.ToArray());
        }

        private void FillVoluntarios()
        {
            DataSet set = new z_voluntarios().Getz_voluntarios();
            nombres = new List<object>();
            foreach (DataRow dr in set.Tables[0].Rows)
            {
                var p =
                    new KeyValuePair<string, int>((string) dr["apellidos"] + " " + dr["nombres"],
                                                  (int) dr["id_voluntario"]);
                nombres.Add(p);
            }
            listNombres.Items.Clear();
            listNombres.Items.AddRange(nombres.ToArray());
        }

        private void FillCarros()
        {
            listCarros.Items.Clear();
            carros = new List<int>();
            carrosCheck = new List<int>();
            carrosUncheck = new List<int>();
            carrosAct = new List<int>();
            var carro = new z_carros();
            DataSet set = carro.Getz_carros();
            foreach (DataRow dr in set.Tables[0].Rows)
            {
                carros.Add((int) dr["id_carro"]);
                listCarros.Items.Add(dr["nombre"]);
            }
        }

        private void FillCarros(int id_conductor)
        {
            listCarros.Items.Clear();
            var cond = new z_conductores();
            cond = cond.getObjectz_conductores(id_conductor);

            // lista de carros a integer
            carros = new List<int>();
            carrosCheck = new List<int>();
            carrosUncheck = new List<int>();
            carrosAct = new List<int>();
            if (cond.id_carros != "")
            {
                foreach (string s in cond.id_carros.Split(','))
                {
                    carros.Add(int.Parse(s));
                }
            }

            // agregar
            foreach (int i in carros)
            {
                var carro = new z_carros();
                carro = carro.getObjectz_carros(i);

                // no listar carros en acto, ni carros no existentes
                if (carro.id_carro != 0 && (carro.estado != 4 && carro.estado != 5))
                {
                    if (carro.id_conductor == id_conductor)
                    {
                        listCarros.Items.Add(carro.nombre, true);
                        carrosAct.Add(carro.id_carro);
                    }
                    else
                    {
                        listCarros.Items.Add(carro.nombre);
                    }
                }
            }
        }

        private void PuestaServicio_Load(object sender, EventArgs e)
        {
            datePuestaServicio.Value = DateTime.Now;
            datePuestaServicio.Value.AddSeconds(-datePuestaServicio.Value.Second);
            listNombres.DisplayMember = "Key";
            listNombres.ValueMember = "Value";

            comboCompania.DisplayMember = "id_compania";
            comboCompania.ValueMember = "id_compania";
            comboCompania.DataSource = new z_companias().Getz_companias().Tables[0];
            //FillConductores();
        }

        private void listCarros_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                // eliminar
                if (carrosAct.Contains(carros[e.Index]))
                {
                    carrosUncheck.Add(carros[e.Index]);
                }
                if (carrosCheck.Contains(carros[e.Index]))
                {
                    carrosCheck.Remove(carros[e.Index]);
                }
            }
            else
            {
                // agregar
                if (!carrosAct.Contains(carros[e.Index]))
                {
                    carrosCheck.Add(carros[e.Index]);
                }
                if (carrosUncheck.Contains(carros[e.Index]))
                {
                    carrosUncheck.Remove(carros[e.Index]);
                }
            }
        }

        private void checkTemporal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTemporal.Checked)
            {
                // establecer temporal
                textAutoriza.Enabled = true;
                label1.Enabled = true;
                // combo con voluntarios
                FillVoluntarios();
                FillCarros();
                textNombres.Text = "";
            }
            else
            {
                textAutoriza.Enabled = false;
                label1.Enabled = false;
                textNombres.Text = "";
                listCarros.Items.Clear();

                // volver
                FillConductores((int) comboCompania.SelectedValue);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // verificar
            bool ok = true;
            string msg = "Han ocurrido los siguientes errores:\n";
            if (listNombres.SelectedIndex == -1)
            {
                msg += "* No ha seleccionado conductor.\n";
                ok = false;
            }
            if (carrosCheck.Count == 0 && carrosUncheck.Count == 0)
            {
                msg += "* No ha seleccionado carros.\n";
                ok = false;
            }
            if (checkTemporal.Checked && textAutoriza.Text == "")
            {
                msg += "* No ha ingresado oficial que autoriza.\n";
                ok = false;
            }
            if (!ok)
            {
                MessageBox.Show(msg, "Faltan datos");
                return;
            }
            //MessageBox.Show("En desarrollo");
            //return;

            // obtener id de conductor desde temporal o el correspondiente
            int id_conductor = checkTemporal.Checked ? Conductor.CrearConductorTemporal(((KeyValuePair<string, int>) listNombres.SelectedItem).Value,
                                                                                        carrosCheck) : new z_conductores().getObjectz_conductores(
                                                                                                           ((KeyValuePair<string, int>) listNombres.SelectedItem).Value).id_conductor;
            // poner en servicio o agregar a la tabla de puesta en serv
            if (radioProgramar.Checked)
            {
                // programar
                var ps = new z_puesta_servicio
                             {
                                 fecha_hora = datePuestaServicio.Value,
                                 id_conductor = id_conductor,
                                 id_operadora = IZeusWin.IdOperadora
                             };
                foreach (int i in carrosCheck)
                {
                    ps.id_carros_ps += "," + i;
                }
                ps.id_carros_ps = ps.id_carros_ps.Trim(',');

                foreach (int i in carrosUncheck)
                {
                    ps.id_carros_fs += "," + i;
                }
                ps.id_carros_fs = ps.id_carros_fs.Trim(',');
                ps.addz_puesta_servicio(ps);
                // temporal??
                string auth = "";
                if (checkTemporal.Checked)
                {
                    auth = ", Autorizado por: " + textAutoriza.Text;
                }
                if (ps.id_carros_ps != "")
                {
                    BitacoraGestion.NuevoEvento(IZeusWin.IdOperadora, IZeusWin.IdAval,
                                                string.Format(
                                                    "Puesta en servicio programada. Fecha: {0}, Conductor: {1}, Carros: {2}" +
                                                    auth, ps.fecha_hora,
                                                    new z_conductores().getObjectz_conductores(id_conductor).
                                                        codigo_conductor, ps.id_carros_ps));
                }
                if (ps.id_carros_fs != "")
                {
                    BitacoraGestion.NuevoEvento(IZeusWin.IdOperadora, IZeusWin.IdAval,
                                                string.Format(
                                                    "Fuera de servicio programado. Fecha: {0}, Conductor: {1}, Carros: {2}",
                                                    ps.fecha_hora,
                                                    new z_conductores().getObjectz_conductores(id_conductor).
                                                        codigo_conductor, ps.id_carros_fs));
                }
            }
            else
            {
                // poner en servicio
                Conductor.PuestaEnServicio(id_conductor, carrosCheck, textAutoriza.Text);
                Conductor.FueraServicio(id_conductor, carrosUncheck);
            }


            // todo: bitacora
            MessageBox.Show("Se ha realizado la operación exitosamente");
        }

        private void comboCompania_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCompania.SelectedIndex != -1)
            {
                FillConductores((int) comboCompania.SelectedValue);
            }
        }
    }
}