using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace Reemplazos
{
    public partial class ReemplazoCarros : Form
    {
        z_carros carros = new z_carros();

        private IZeusWin zeusWin;

        public ReemplazoCarros()
        {
            InitializeComponent();
            GetCarrosReemplazo();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
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



        //### Actualizar Reemplazo de Carros
        private void gridCarrosReemplazo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                string txtHabilita = "";
                string txtHabilitaTw = "";

                if (e.ColumnIndex == senderGrid.Columns["chk_activar"].Index && e.RowIndex >= 0)
                {
                    int IdCar = int.Parse(gridCarrosReemplazo.CurrentRow.Cells[0].Value.ToString());
                    DataGridViewCheckBoxCell chekear = new DataGridViewCheckBoxCell();
                    chekear = (DataGridViewCheckBoxCell)gridCarrosReemplazo.Rows[gridCarrosReemplazo.CurrentRow.Index].Cells[4];

                    //NombreCarro
                    string strNom = gridCarrosReemplazo.CurrentRow.Cells[3].Value.ToString();


                    if (chekear.Value == null)
                        chekear.Value = false;
                    switch (chekear.Value.ToString())
                    {
                        case "True":
                            //MessageBox.Show("FALSO");
                            //MessageBox.Show("Operador(a) 39-2 Habilita " + strNom +"   Case VERDADERO", "ZEUS chk");

                            carros.ActualizarReemplazoZcarrosVirtual(IdCar, "false");
                            txtHabilita = "Operador(a) Inhabilita " + strNom;
                            txtHabilitaTw = "Inhabilitado " + strNom;
                            BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval, txtHabilita);
                            break;

                        case "False":
                            //MessageBox.Show("VERDADERO");
                            //MessageBox.Show("Operador(a) 39-2 Inhabilita " + strNom + "   Case FALSO", "ZEUS chk");

                            carros.ActualizarReemplazoZcarrosVirtual(IdCar, "true");
                            txtHabilita = "Operador(a) Habilita " + strNom;
                            txtHabilitaTw = "Habilitado " + strNom;
                            BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval, txtHabilita);
                            break;
                    }
                }
                GetCarrosReemplazo();

                //### Publicar en Twitter
                if (carros.GetParametroPrioridad(1) == "TRUE")
                {
                    txtHabilita = txtHabilita.Replace(",#", "");
                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                    proceso.StartInfo.Arguments = "1" + " " + txtHabilitaTw + " ";
                    proceso.StartInfo.CreateNoWindow = true;
                    proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    proceso.Start();

                    MessageBox.Show("Twitter publicado de forma exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception exe)
            {
                //log.Error("Se ha generado el siguiente error: " + exe.Message);
                //log.Error("Se genera la traza del error" + exe.StackTrace);
            }
        }

    }
}
