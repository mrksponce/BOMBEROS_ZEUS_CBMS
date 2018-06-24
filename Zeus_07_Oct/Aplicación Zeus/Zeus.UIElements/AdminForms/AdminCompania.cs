using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminCompania : AdminBase
    {
        public AdminCompania()
        {
            InitializeComponent();
        }


        private void AdminCompania_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new z_companias().Getz_companias();
                listActuales.DisplayMember = "id_compania";
                listActuales.ValueMember = "id_compania";
                Source = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Mostrar(int id)
        {
            z_companias comp = new z_companias().getObjectz_companias(id);
            textNumero.Text = comp.id_compania.ToString();
            textEmail.Text = comp.email;
        }

        protected override bool Validar()
        {
            string msg = "La siguiente información falta o tiene formato incorrecto:\n";
            bool ok = true;
            int d;
            if (textNumero.Text == "" || !int.TryParse(textNumero.Text, out d))
            {
                msg += "* Número";
                ok = false;
            }

            if (textEmail.Text == "")
            {
                msg += "* E-mail";
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
                var comp = new z_companias {id_compania = int.Parse(textNumero.Text), email = textEmail.Text};
                comp.addz_companias(comp);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Source = comp.Getz_companias().Tables[0];
            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
        }

        protected override void Actualizar()
        {
            try
            {
                z_companias comp = new z_companias().getObjectz_companias((int) listActuales.SelectedValue);
                comp.id_compania = int.Parse(textNumero.Text);
                comp.email = textEmail.Text;
                comp.modifyz_companias(comp);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Source = comp.Getz_companias().Tables[0];
            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
        }

        protected override void Eliminar()
        {
            try
            {
                new z_companias().deletez_companias((int) listActuales.SelectedValue);
            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
        }

        protected override void Limpiar()
        {
            textEmail.Text = "";
            textNumero.Text = "";
        }
    }
}