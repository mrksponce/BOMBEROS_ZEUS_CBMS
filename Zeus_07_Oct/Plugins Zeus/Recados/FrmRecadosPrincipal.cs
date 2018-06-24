using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;

namespace Recados
{
    public partial class FrmRecadosPrincipal : Form
    {
        public FrmRecadosPrincipal()
        {
            InitializeComponent();
            AlinearFormulario();
        }

        private void AlinearFormulario()
        {
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            FrmIngresarRecado irecado = new FrmIngresarRecado();
            if (irecado.ShowDialog() == DialogResult.OK)
            {
                GrillaDatos();
            }
        }

        private void FrmRecadosPrincipal_Load(object sender, EventArgs e)
        {
            GrillaDatos();
        }

        private void GrillaDatos()
        {
            gvRecados.Rows.Clear();
            gvRecados.DataSource = null;
            m_recados recados = new m_recados();
            foreach (DataRow r in recados.GetRecados().Tables[0].Rows)
            {
                gvRecados.Rows.Add(r["id_recado_cab"].ToString(), r["fecha"].ToString(), r["tipo"].ToString(), r["titulo"].ToString(), r["estado"].ToString(), r["operadora_creador"].ToString());
            }
        }

        private void gvRecados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmConsultaRecados crecados = new FrmConsultaRecados(gvRecados.CurrentRow.Cells[0].Value.ToString());
            if (crecados.ShowDialog() == DialogResult.OK)
            {
                GrillaDatos();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gvRecados.DataSource = null;
            gvRecados.Rows.Clear();
            m_recados recados = new m_recados();
            string[] desde = dtpDesde.Value.ToString().Split(' ');
            string[] hasta = dtpHasta.Value.ToString().Split(' ');
            foreach (DataRow r in recados.GetResuladoFiltro(desde[0], hasta[0], chkPendientes.Checked, chkRecados.Checked, chkNovedades.Checked, chkVigente.Checked, chkCerrado.Checked).Tables[0].Rows)
            {
                gvRecados.Rows.Add(r["id_recado_cab"].ToString(), r["fecha"].ToString(), r["tipo"].ToString(), r["titulo"].ToString(), r["estado"].ToString(), r["operadora_creador"].ToString());
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
    }
}
