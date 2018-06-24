using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace PrestamoCarros
{
    public partial class FormularioCarrosVecinos : Form
    {
        z_carros carros = new z_carros();
        
        public FormularioCarrosVecinos()
        {
            InitializeComponent();
            CargarGrilla();
        }

        //# Agregar Registro de Cada Carro de Apoyo
        private void CargarGrilla()
        {
            dgv_Apoyos.Rows.Clear();
            string strID = "";
            string strNombre = "";
            string strTipo = "";
            string strCia = "";
            bool hab = false;
            string strIdCarro = "";
            foreach (DataRow cApoyo in carros.GetCarrosApoyo().Tables[0].Rows)
            {
                strID = cApoyo["car_apoyo"].ToString();
                strNombre = cApoyo["nombre"].ToString();
                //strTipo = cApoyo["id_tipo_carro"].ToString();
                strTipo = cApoyo["nom_apoyo"].ToString();
                strCia = cApoyo["id_compania"].ToString();
                hab = Convert.ToBoolean(cApoyo["habilitado"]);
                strIdCarro = cApoyo["id_carro"].ToString();

                dgv_Apoyos.Rows.Add(strID, strNombre, strTipo, strCia, hab, strIdCarro);
            }
        }




        private void CargaInicial()
        {

            //CargarCombos();
            //CargarGrilla();
        }


        private void FormularioCarrosVecinos_Load(object sender, EventArgs e)
        {
            //CargaInicial();
            //CargarCombos();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    z_carros carros = new z_carros();
        //    z_companias companias = new z_companias();
        //    companias.getObjectz_companias(int.Parse(cboxCompania.SelectedValue.ToString()));
        //    string coordenada_x = "";
        //    string coordenada_y = "";
        //    foreach (DataRow row_comp in companias.Getz_companias().Tables[0].Rows)
        //    {
        //        if (row_comp["id_compania"].ToString() == cboxCompania.SelectedValue.ToString())
        //        {
        //            coordenada_x = row_comp["compania_x"].ToString();
        //            coordenada_y = row_comp["compania_y"].ToString();
        //            break;
        //        }
        //    }

        //    carros.HabilitarCarroApoyo(int.Parse(cboxCarros.SelectedValue.ToString()), txtEtiqueta.Text, int.Parse(cboxCompania.SelectedValue.ToString()), int.Parse(coordenada_x), int.Parse(coordenada_y));
        //    carros.HabilitarCarroZcarrosVirtualApoyo(int.Parse(cboxCarros.SelectedValue.ToString()));
        //    carros.InsertarMaterialApoyo(int.Parse(cboxCarros.SelectedValue.ToString()), txtEtiqueta.Text, int.Parse(cboxCompania.SelectedValue.ToString()));
        //    CargarGrilla();
        //    CargarCombos();
        //    MessageBox.Show("El material de apoyo fue habilitado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        private void dgv_carros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //z_carros carros = new z_carros();
            //carros.DesactivarCarroApoyo(int.Parse(dgv_carros.CurrentRow.Cells[1].Value.ToString()));
            //carros.DesactivarCarroZcarrosVirtualApoyo(int.Parse(dgv_carros.CurrentRow.Cells[1].Value.ToString()));
            //carros.BorrarMaterialApoyo(int.Parse(dgv_carros.CurrentRow.Cells[1].Value.ToString()));
            //CargarGrilla();
            //CargarCombos();
            //MessageBox.Show("El material fue desvinculado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_Apoyos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (e.ColumnIndex == senderGrid.Columns["lnk_carro"].Index && e.RowIndex >= 0)
                {
                    int IdCar = int.Parse(dgv_Apoyos.CurrentRow.Cells[5].Value.ToString());
                    string strNewCar = "";
                    PrestamoCarros.Frm_Nombre fNomCar = new PrestamoCarros.Frm_Nombre();
                    if (fNomCar.ShowDialog() == DialogResult.OK)
                    {
                        strNewCar = fNomCar.Retorno;
                    }

                    if (strNewCar != "")
                    {
                        carros.SetNomCarroApoyo(IdCar, strNewCar);
                        
                        //### Actualiza en Web Nombre Carro Apoyo
                        JsonUpdateNombreCarroClave.ApoloUpdateNombreCarroApoyo(IdCar, strNewCar);
                    }
                }

                if (e.ColumnIndex == senderGrid.Columns["lnk_tipo"].Index && e.RowIndex >= 0)
                {
                    int IdCar = int.Parse(dgv_Apoyos.CurrentRow.Cells[5].Value.ToString());
                    int intIdTipo = 0;
                    PrestamoCarros.Frm_Tipo fTipCar = new PrestamoCarros.Frm_Tipo();
                    if (fTipCar.ShowDialog() == DialogResult.OK)
                    {
                        intIdTipo = fTipCar.RetornoInt;
                    }

                    if (intIdTipo != 0)
                    {
                        carros.SetTipoCarroApoyo(IdCar, intIdTipo);
                    }
                }

                if (e.ColumnIndex == senderGrid.Columns["lnk_compania"].Index && e.RowIndex >= 0)
                {
                    //int IdCar = int.Parse(dgv_Apoyos.CurrentRow.Cells[5].Value.ToString());
                    //int intCia = 0;
                    //PrestamoCarros.Frm_Compania fCompania = new PrestamoCarros.Frm_Compania();
                    //if (fCompania.ShowDialog() == DialogResult.OK)
                    //{
                    //    intCia = fCompania.RetornoInt;
                    //}

                    //if (intCia != 0)
                    //{
                    //    carros.SetCiaCarroApoyo(IdCar, intCia);
                    //}
                }

                if (e.ColumnIndex == senderGrid.Columns["chk_habilitar"].Index && e.RowIndex >= 0)
                {
                    string IdAp = dgv_Apoyos.CurrentRow.Cells[0].Value.ToString();
                    string stAp = "Ap_" + IdAp;
                    int IdCar = int.Parse(dgv_Apoyos.CurrentRow.Cells[5].Value.ToString());
                    DataGridViewCheckBoxCell chekear = new DataGridViewCheckBoxCell();
                    chekear = (DataGridViewCheckBoxCell)dgv_Apoyos.Rows[dgv_Apoyos.CurrentRow.Index].Cells[4];

                    if (chekear.Value == null)
                        chekear.Value = false;
                    switch (chekear.Value.ToString())
                    {
                        case "True":
                            //MessageBox.Show("FARSO FARSO FARSO");
                            carros.SetHabilitaCarroApoyo(IdCar, "FALSE");
                            carros.SetNomCarroApoyo(IdCar, stAp);
                            //carros.SetTipoCarroApoyo(IdCar, 1);
                            carros.SetCiaCarroApoyo(IdCar, 0);
                            carros.SetEstadoCarroApoyo(IdCar, 2);
                            carros.SetHabilitaCarroApoyoMatMayor(IdCar, "TRUE");
                            //### Actualiza en Web Nombre Carro Apoyo
                            JsonUpdateNombreCarroClave.ApoloUpdateNombreCarroApoyo(IdCar, stAp);
                            break;

                        case "False":
                            //MessageBox.Show("VERDADERO");
                            carros.SetHabilitaCarroApoyo(IdCar, "TRUE");
                            carros.SetHabilitaCarroApoyoMatMayor(IdCar, "FALSE");
                            break;
                    }
                }

                CargarGrilla();

            }
            catch (Exception exe)
            {
                //log.Error("Se ha generado el siguiente error: " + exe.Message);
                //log.Error("Se genera la traza del error" + exe.StackTrace);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
