using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class LiberarConductores : Form
    {
        private readonly List<int> IdConductores;
        private bool _clic;
        private List<int> ConductoresCheck;
        private z_conductores conductor;


        public LiberarConductores()
        {
            InitializeComponent();
            IdConductores = new List<int>();
            ConductoresCheck = new List<int>();
        }

        
        private void LiberarConductores_Load(object sender, EventArgs e)
        {
            FillConductores();
        }


        //### Actualiza Listado de Conductores
        private void FillConductores()
        {
            try
            {
                string strCndCod;
                chkList_LiberarConductores.Items.Clear();
                ConductoresCheck = new List<int>();
                var ObjConductor = new z_conductores();
                DataSet set = ObjConductor.GetListz_conductoresBloqueados();
                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    IdConductores.Add((int)dr["id_conductor"]);
                    strCndCod = dr["nombre_completo"].ToString() + " (" + dr["codigo_conductor"].ToString() + ")";
                    chkList_LiberarConductores.Items.Add(strCndCod);
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Actualizar para Liberar Conductuores
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (
    MessageBox.Show("¿Está seguro(a) que desea liberar este Conductor?", "Confirmar Actualización",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Libera Cada Conductor Checkeado
                    foreach (int i in ConductoresCheck)
                    {
                        LiberaConductorBloqueado(i);
                    }
                    FillConductores();
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }


        //### Libera Conductor Bloqueado
        public static void LiberaConductorBloqueado(int id_conductor)
        {
            z_conductores cond = new z_conductores().getObjectz_conductores(id_conductor);
            cond.disponible = true;
            cond.modifyz_conductores(cond);
        }


        //### Administar Lista de IdConductores
        private void chkList_LiberarConductores_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                //Quitar
                ConductoresCheck.Remove(IdConductores[e.Index]);
            }
            else
            {
                //Agregar
                ConductoresCheck.Add(IdConductores[e.Index]);
            }
        }

    }        
}
