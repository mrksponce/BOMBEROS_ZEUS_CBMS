using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;

namespace Zeus.UIElements
{
    public partial class ReemplazoCarros : Form
    {
        z_carros carros = new z_carros();
        public ReemplazoCarros()
        {
            InitializeComponent();
            GetCarrosReemplazo();
        }

        //-*- Refresca la Grilla
        protected void GetCarrosReemplazo()
        {
            gridCarrosReemplazo.Rows.Clear();
            int i = 0;
            foreach (DataRow rCarrosReemplazo in carros.GetCarrosReemplazo().Tables[0].Rows)
            {
                bool est = Convert.ToBoolean(rCarrosReemplazo["boolreemplazo"].ToString());
                if (est == true)
                {
                    gridCarrosReemplazo.Rows.Add(rCarrosReemplazo["virtual"].ToString(), rCarrosReemplazo["idcarro"].ToString(), rCarrosReemplazo["nombrecarro"].ToString(), rCarrosReemplazo["carroreemplaza"].ToString(), false);
                }
                else
                {
                    gridCarrosReemplazo.Rows.Add(rCarrosReemplazo["virtual"].ToString(), rCarrosReemplazo["idcarro"].ToString(), rCarrosReemplazo["nombrecarro"].ToString(), rCarrosReemplazo["carroreemplaza"].ToString(), true);
                }
                i++;
            }
        }

        ////-*- Actualiza en z_carros_virtual el Booleano rx_2_q
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewRow row in gridCarrosReemplazo.Rows)
        //    {
        //        carros.ActualizarReemplazoZcarrosVirtual(row.Cells[0].Value.ToString(), row.Cells[4].Value.ToString());
        //    }
        //    GetCarrosReemplazo();
        //}
    }
}
