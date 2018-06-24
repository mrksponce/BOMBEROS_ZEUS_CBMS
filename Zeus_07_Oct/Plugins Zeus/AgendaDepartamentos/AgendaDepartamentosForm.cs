using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;

namespace AgendaDepartamentos
{
    public partial class AgendaDepartamentosForm : Form
    {
        public AgendaDepartamentosForm()
        {
            InitializeComponent();
            comboDepartamento.DisplayMember = "nombre";
            comboDepartamento.ValueMember = "id_departamento";
        }

        public IZeusWin ZeusWin { get; set; }

        private void AgendaDepartamentosForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.agenda_inspectores_32.GetHicon());
            DataSet ds = new d_departamento().Getd_departamento();
            comboDepartamento.DataSource = ds.Tables[0];

            //// expediente seleccionado
            //if (ZeusWin.IdExpediente!=0)
            //{
            //    e_expedientes exp = new e_expedientes().getObjecte_expedientes(zeusWin.IdExpediente);
            //    comboDepartamento.SelectedValue = exp.codigo_principal;
            //    //comboClaves_SelectedIndexChanged(comboClaves, new EventArgs());
            //    comboExpediente.SelectedValue = exp.id_expediente;
            //}
        }

        private void comboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cargar expedientes para dicha clave
            if (comboDepartamento.SelectedIndex != -1)
            {
                DataSet ds =
                    new d_departamento_detalle().Getd_departamento_detalle((int) comboDepartamento.SelectedValue);
                dataOficiales.DataSource = ds.Tables[0];
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataOficiales_SelectionChanged(object sender, EventArgs e)
        {
            if (dataOficiales.SelectedRows.Count != 0)
            {
                lblDetalle.Text = (string) dataOficiales.SelectedRows[0].Cells["nombre"].Value + "\n" +
                                  "Fono Fijo: " + (string) dataOficiales.SelectedRows[0].Cells["fono_fijo"].Value + "\n" +
                                  "Fono Móvil: " + (string) dataOficiales.SelectedRows[0].Cells["fono_movil"].Value;
            }
        }
    }
}