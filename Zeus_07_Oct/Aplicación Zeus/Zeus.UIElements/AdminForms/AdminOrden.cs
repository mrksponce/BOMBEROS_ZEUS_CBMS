using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminOrden : AdminBase
    {
        public AdminOrden()
        {
            InitializeComponent();
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
                var orden = new z_orden();
                reorderListBox1.DisplayMember = "tipo_carro_letra";
                reorderListBox1.ValueMember = "id_orden";
                reorderListBox1.DataSource = orden.Getz_orden_tipo((int) listActuales.SelectedValue).Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void AdminOrden_Load(object sender, EventArgs e)
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

        protected override void Actualizar()
        {
            try
            {
                int[] items = reorderListBox1.Items;
                var o = new z_orden();

                for (int i = 0; i < items.Length; i++)
                {
                    o = o.getObjectz_orden(items[i]);
                    o.orden_numero = i + 1;
                    o.modifyz_orden(o);
                }
                BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval,
                                            "Modificación Tabla Orden de Solicitud de Carros");

                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }
    }
}