using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminCuarteleros : AdminBase
    {
        public AdminCuarteleros()
        {
            InitializeComponent();
        }

        private void AdminCuarteleros_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new z_cuarteleros().Getz_cuartelerosLista();
                listActuales.DisplayMember = "nombre_completo";
                listActuales.ValueMember = "id_cuartelero";
                Source = ds.Tables[0];
                comboCompania.DisplayMember = "id_compania";
                comboCompania.ValueMember = "id_compania";
                comboCompania.DataSource = new z_companias().Getz_companias().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Mostrar(int id)
        {
            try
            {
                z_cuarteleros cuart = new z_cuarteleros().getObjectz_cuarteleros(id);
                textRut.Text = cuart.rut;
                textFechaNac.Text = cuart.fecha_nacimiento.ToShortDateString();
                textApellidos.Text = cuart.apellidos;
                textNombres.Text = cuart.nombres;
                textAlergia.Text = cuart.alergia;
                textPadece.Text = cuart.padece;
                textSangre.Text = cuart.tipo_sangre;

                textFono.Text = cuart.telefono;
                textMovil.Text = cuart.celular;
                comboCompania.SelectedValue = cuart.id_compania;
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Limpiar()
        {
            textRut.Text = "";
            textFechaNac.Text = "";
            textApellidos.Text = "";
            textNombres.Text = "";
            textAlergia.Text = "";
            textPadece.Text = "";
            textSangre.Text = "";

            textFono.Text = "";
            textMovil.Text = "";
            comboCompania.SelectedIndex = -1;
        }

        protected override bool Validar()
        {
            string msg = "La siguiente información falta o tiene formato incorrecto:\n";
            bool ok = true;
            DateTime d;

            if (textRut.Text == "")
            {
                msg += "* Rut" + "\n";
                ok = false;
            }
            if (textFechaNac.Text == "" || !DateTime.TryParse(textFechaNac.Text, out d))
            {
                msg += "* Fecha Nacimiento" + "\n";
                ok = false;
            }
            if (textApellidos.Text == "")
            {
                msg += "* Apellidos" + "\n";
                ok = false;
            }
            if (textNombres.Text == "")
            {
                msg += "* Nombres" + "\n";
                ok = false;
            }
            if (textSangre.Text == "")
            {
                msg += "* Tipo de sangre" + "\n";
                ok = false;
            }
            if (textAlergia.Text == "")
            {
                msg += "* Alergia" + "\n";
                ok = false;
            }
            if (textPadece.Text == "")
            {
                msg += "* Voluntario Padece" + "\n";
                ok = false;
            }

            if (textFono.Text == "")
            {
                msg += "* Teléfono fijo" + "\n";
                ok = false;
            }
            if (textMovil.Text == "")
            {
                msg += "* Teléfono móvil" + "\n";
                ok = false;
            }

            if (comboCompania.SelectedIndex == -1)
            {
                msg += "* Compañía" + "\n";
                ok = false;
            }

            if (!ok)
            {
                MessageBox.Show(msg, "Error en validación");
            }
            return ok;
        }

        protected override void Insertar()
        {
            try
            {
                var cuart = new z_cuarteleros
                                {
                                    rut = textRut.Text,
                                    fecha_nacimiento = DateTime.Parse(textFechaNac.Text),
                                    apellidos = textApellidos.Text,
                                    nombres = textNombres.Text,
                                    alergia = textAlergia.Text,
                                    padece = textPadece.Text,
                                    tipo_sangre = textSangre.Text,
                                    telefono = textFono.Text,
                                    celular = textMovil.Text,
                                    id_compania = ((int) ((DataRowView) comboCompania.SelectedItem).Row["id_compania"])
                                };

                cuart.addz_cuarteleros(cuart);
                Source = cuart.Getz_cuartelerosLista().Tables[0];
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
                var cuart = new z_cuarteleros().getObjectz_cuarteleros((int)listActuales.SelectedValue);
                cuart.rut = textRut.Text;
                cuart.fecha_nacimiento = DateTime.Parse(textFechaNac.Text);
                cuart.apellidos = textApellidos.Text;
                cuart.nombres = textNombres.Text;
                cuart.alergia = textAlergia.Text;
                cuart.padece = textPadece.Text;
                cuart.tipo_sangre = textSangre.Text;

                cuart.telefono = textFono.Text;
                cuart.celular = textMovil.Text;
                cuart.id_compania = (int)((DataRowView)comboCompania.SelectedItem).Row["id_compania"];

                cuart.modifyz_cuarteleros(cuart);
                Source = cuart.Getz_cuartelerosLista().Tables[0];
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
                var cuart = new z_cuarteleros();
                cuart.deletez_cuarteleros((int)listActuales.SelectedValue);
                Source = cuart.Getz_cuartelerosLista().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }
    }
}