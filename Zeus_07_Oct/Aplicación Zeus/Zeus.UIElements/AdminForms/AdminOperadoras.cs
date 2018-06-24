using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminOperadoras : AdminBase
    {
        public AdminOperadoras()
        {
            InitializeComponent();
        }

        private void AdminOperadoras_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new z_operadoras().Getz_operadorasLista();
                listActuales.DisplayMember = "nombre_completo";
                listActuales.ValueMember = "id_operadora";
                Source = ds.Tables[0];
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
                z_operadoras op = new z_operadoras().getObjectz_operadoras(id);
                textRut.Text = op.rut;
                textFechaNac.Text = op.fecha_nacimiento.ToShortDateString();
                textApellidos.Text = op.apellidos;
                textNombres.Text = op.nombres;
                textDireccion.Text = op.direccion;
                textComuna.Text = op.comuna;

                textFono.Text = op.telefono;
                textMovil.Text = op.celular;
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
            textDireccion.Text = "";
            textComuna.Text = "";

            textFono.Text = "";
            textMovil.Text = "";
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
            if (textDireccion.Text == "")
            {
                msg += "* Dirección" + "\n";
                ok = false;
            }
            if (textComuna.Text == "")
            {
                msg += "* Comuna" + "\n";
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
                var op = new z_operadoras
                             {
                                 rut = textRut.Text,
                                 fecha_nacimiento = DateTime.Parse(textFechaNac.Text),
                                 apellidos = textApellidos.Text,
                                 nombres = textNombres.Text,
                                 direccion = textDireccion.Text,
                                 comuna = textComuna.Text,
                                 telefono = textFono.Text,
                                 celular = textMovil.Text
                             };

                op.addz_operadoras(op);
                Source = op.Getz_operadorasLista().Tables[0];
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
                z_operadoras op = new z_operadoras().getObjectz_operadoras((int) listActuales.SelectedValue);
                op.rut = textRut.Text;
                op.fecha_nacimiento = DateTime.Parse(textFechaNac.Text);
                op.apellidos = textApellidos.Text;
                op.nombres = textNombres.Text;
                op.direccion = textDireccion.Text;
                op.comuna = textComuna.Text;

                op.telefono = textFono.Text;
                op.celular = textMovil.Text;

                op.modifyz_operadoras(op);
                Source = op.Getz_operadorasLista().Tables[0];
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
                var op = new z_operadoras();
                op.deletez_operadoras((int) listActuales.SelectedValue);
                Source = op.Getz_operadorasLista().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }
    }
}