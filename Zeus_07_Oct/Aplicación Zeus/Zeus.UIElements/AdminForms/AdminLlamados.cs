using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminLlamados : AdminBase
    {
        public AdminLlamados()
        {
            InitializeComponent();
        }

        private void AdminLlamados_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DataSource = new z_llamados().Getz_llamados_principal().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                try
                {
                    listActuales.DisplayMember = "desc";
                    listActuales.ValueMember = "id_llamado";
                    Source = new z_llamados().Getz_llamados_clave((string)comboBox1.SelectedValue).Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
            else
            {
                Source = null;
            }
        }

        protected override void Mostrar(int id)
        {
            try
            {
                z_llamados llam = new z_llamados().getObjectz_llamados_id(id);
                textCodigo.Text = llam.codigo_llamado.ToString();
                textClave.Text = llam.clave;
                textDescripcion.Text = llam.descripcion;
                numericMaxB.Value = llam.max_b;
                checkIncendio.Checked = llam.incendio;
                checkRestr.Checked = llam.rest_incendio;
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Limpiar()
        {
            textClave.Text = "";
            textCodigo.Text = "";
            textDescripcion.Text = "";
            comboBox1.SelectedIndex = -1;
            checkIncendio.Checked = false;
            checkRestr.Checked = false;
            numericMaxB.Value = 0;
        }

        protected override bool Validar()
        {
            string msg = "La siguiente información falta o tiene formato incorrecto:\n";
            bool ok = true;
            int d;
            if (textClave.Text == "")
            {
                msg += "* Clave";
                ok = false;
            }
            if (textCodigo.Text == "" || !int.TryParse(textCodigo.Text, out d))
            {
                msg += "* Código";
                ok = false;
            }
            if (textDescripcion.Text == "")
            {
                msg += "* Descripción";
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
                var llam = new z_llamados
                               {
                                   clave = textClave.Text,
                                   codigo_llamado = int.Parse(textCodigo.Text),
                                   descripcion = textDescripcion.Text,
                                   incendio = checkIncendio.Checked,
                                   rest_incendio = checkRestr.Checked,
                                   max_b = ((int)numericMaxB.Value)
                               };
                llam.addz_llamados(llam);
                comboBox1.DataSource = new z_llamados().Getz_llamados_principal().Tables[0];
                BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval, "Inserción Tabla Llamados");

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
                z_llamados llam = new z_llamados().getObjectz_llamados_id((int)listActuales.SelectedValue);
                llam.clave = textClave.Text;
                llam.codigo_llamado = int.Parse(textCodigo.Text);
                llam.descripcion = textDescripcion.Text;
                llam.incendio = checkIncendio.Checked;
                llam.rest_incendio = checkRestr.Checked;
                llam.max_b = (int)numericMaxB.Value;
                llam.modifyz_llamados(llam);
                comboBox1.DataSource = new z_llamados().Getz_llamados_principal().Tables[0];
                BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval, "Modificación Tabla Llamados");
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
                new z_llamados().deletez_llamados((int)listActuales.SelectedValue);
                comboBox1.DataSource = new z_llamados().Getz_llamados_principal().Tables[0];
                BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval, "Elminiación Tabla Llamados");
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!enNuevo)
            {
                comboBox1.Enabled = false;
            }
            base.btnNuevo_Click(sender, e);
            if (!enNuevo)
            {
                comboBox1.Enabled = true;
                try
                {
                    comboBox1.DataSource = new z_llamados().Getz_llamados_principal().Tables[0];
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        protected override void btnActualizar_Click(object sender, EventArgs e)
        {
            if (enNuevo)
            {
                comboBox1.Enabled = true;
            }
            base.btnActualizar_Click(sender, e);
        }
    }
}