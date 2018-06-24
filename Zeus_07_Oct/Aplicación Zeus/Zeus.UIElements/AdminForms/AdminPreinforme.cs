using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminPreinforme : AdminBase
    {
        public AdminPreinforme()
        {
            InitializeComponent();
        }

        private void AdminPreinforme_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DisplayMember = "desc";
                comboBox1.ValueMember = "codigo_llamado";
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
                    listActuales.ValueMember = "codigo_llamado";
                    Source =
                        new z_llamados().Getz_llamados_clave(
                            (string) ((DataRowView) comboBox1.SelectedItem).Row["clave"]).Tables[0];
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
                DataSet ds = new z_preinforme().Getz_preinforme((int) listActuales.SelectedValue);
                listPreinformes.DisplayMember = "preinforme";
                listPreinformes.ValueMember = "id_preinforme";
                listPreinformes.DataSource = ds.Tables[0];
                if (id != 0)
                {
                    listActuales.SelectedValue = id;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override bool Validar()
        {
            if (textPreinforme.Text != "")
            {
                return true;
            }
            MessageBox.Show("Debe ingresar descripción de preinforme.");
            return false;
        }

        protected override void Actualizar()
        {
            try
            {
                z_preinforme pre = new z_preinforme().getObjectz_preinforme((int) listPreinformes.SelectedValue);
                pre.preinforme = textPreinforme.Text;
                pre.modifyz_preinforme(pre);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Mostrar(pre.id_preinforme);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Eliminar()
        {
            if (listPreinformes.SelectedIndex != -1)
            {
                try
                {
                    var pre = new z_preinforme();
                    pre.deletez_preinforme((int) listPreinformes.SelectedValue);
                    Mostrar(0);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        protected override void Insertar()
        {
            try
            {
                var pre = new z_preinforme
                              {
                                  codigo_llamado = ((int) listActuales.SelectedValue),
                                  preinforme = textPreinforme.Text
                              };

                pre.addz_preinforme(pre);
                Mostrar(0);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void listPreinformes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPreinformes.SelectedIndex != -1)
            {
                textPreinforme.Text = (string) ((DataRowView) listPreinformes.SelectedItem)["preinforme"];
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            if (enNuevo)
            {
                listPreinformes.Enabled = false;
                textPreinforme.Text = "";
            }
            else
            {
                listPreinformes.Enabled = true;
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (!listPreinformes.Enabled)
            {
                listPreinformes.Enabled = true;
            }
        }
    }
}