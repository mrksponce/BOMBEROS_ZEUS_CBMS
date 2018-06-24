using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using System.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class Frm614 : Form
    {
        public static string LblCarro { get; set; }
        public static int IDCarro { get; set; }

        public Frm614(string lblCarro, int idCarro)
        {
            InitializeComponent();
            ListarUbicacionesAll();
            LblCarro = lblCarro;
            IDCarro = idCarro;
        }



        private void txtLugar_KeyPress(object sender, KeyPressEventArgs e)
        {
            z_carros carros = new z_carros();
            if (txtLugar.Text == "")
            {
                ListarUbicacionesAll();
            }
            else
            {
                lbResultados.Items.Clear();
                foreach (DataRow row in carros.FiltroUbicacion614(txtLugar.Text.ToUpper()).Tables[0].Rows)
                {
                    lbResultados.Items.Add(row["ubicacion"].ToString());
                }
            }
        }

        private void txtLugar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ListarUbicacionesAll()
        {
            z_carros carros = new z_carros();
            lbResultados.Items.Clear();
            foreach (DataRow row in carros.ListadoUbicaciones614().Tables[0].Rows)
            {
                lbResultados.Items.Add(row["ubicacion"].ToString());
            }
        }

        private void btn614_Click(object sender, EventArgs e)
        {
            z_carros carros = new z_carros();
            
            string check = "";

            if (chk08.Checked)
            {
                check = "0-8";
            }

            if (chk09.Checked)
            {
                check = "0-9";
            }

            if (lbResultados.SelectedItem != null)
            {
                if(carros.UpdateCarros614(LblCarro, IDCarro, check, lbResultados.SelectedItem.ToString()) > 0)
                {
                    ExpedientesTreeView ext = new ExpedientesTreeView();
                    ext.CargarExpedientes(DatosLogin.LoginUsuario);
                    
                    BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, DatosLogin.LoginUsuario,
                                            "Carro: " + LblCarro + " 6-14 Despachado a " + lbResultados.SelectedItem.ToString());
                    
                    MessageBox.Show("6-14 asignado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    //### Agregar Ubicación de 6-13, 614 o 6-15
                    Carro.SetUbicacion613(Convert.ToInt32(IDCarro), lbResultados.SelectedItem.ToString());

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ubicacion", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);           
            }
        }

        private void lbResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLugar.Text = lbResultados.SelectedItem.ToString();
        }   
    }
}
