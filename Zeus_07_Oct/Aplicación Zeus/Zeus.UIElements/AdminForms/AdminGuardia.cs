using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminGuardia : AdminBase
    {
        public AdminGuardia()
        {
            InitializeComponent();
        }

        private void AdminGuardia_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new z_guardia().Getz_guardia();
                listActuales.DisplayMember = "tipo_oficial";
                listActuales.ValueMember = "id_guardia";
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
                z_guardia guardia = new z_guardia().getObjectz_guardia(id);
                textTipoOficial.Text = guardia.tipo_oficial;
                textOficial.Text = guardia.oficial;
                textResponsabilidades.Text = guardia.responsabilidades;
                checkMostrar.Checked = guardia.mostrar;
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
            if (textTipoOficial.Text == "")
            {
                msg += "* Tipo Oficial";
                ok = false;
            }

            if (textOficial.Text == "")
            {
                msg += "* Oficial";
                ok = false;
            }

            if (textResponsabilidades.Text == "")
            {
                msg += "* Responsabilidades";
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
                var guardia = new z_guardia
                                  {
                                      tipo_oficial = textTipoOficial.Text,
                                      oficial = textOficial.Text,
                                      responsabilidades = textResponsabilidades.Text,
                                      mostrar = checkMostrar.Checked
                                  };
                guardia.addz_guardia(guardia);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Source = guardia.Getz_guardia().Tables[0];
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
                z_guardia guardia = new z_guardia().getObjectz_guardia((int) listActuales.SelectedValue);
                guardia.tipo_oficial = textTipoOficial.Text;
                guardia.oficial = textOficial.Text;
                guardia.responsabilidades = textResponsabilidades.Text;
                guardia.mostrar = checkMostrar.Checked;
                guardia.modifyz_guardia(guardia);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Source = guardia.Getz_guardia().Tables[0];
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
                new z_guardia().deletez_guardia((int) listActuales.SelectedValue);
            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
        }

        protected override void Limpiar()
        {
            textTipoOficial.Text = "";
            textOficial.Text = "";
            textResponsabilidades.Text = "";
            checkMostrar.Checked = false;
        }
    }
}