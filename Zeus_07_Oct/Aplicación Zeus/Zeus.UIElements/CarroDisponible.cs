using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.UIElements;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class CarroDisponible : Form
    {
        private List<int> idCarros;
        z_carros carros = new z_carros();

        public CarroDisponible()
        {
            InitializeComponent();
            GetCompaniaOrigen();
            GetFuncion();
            cmbx_funcion.SelectedIndex = -1;
        }

        protected void GetCompaniaOrigen()
        {
            cmbx_origen.DisplayMember = "nombre_compania";
            cmbx_origen.ValueMember = "id_compania";
            cmbx_origen.DataSource = carros.GetCompaniasId().Tables[0];
        }

        protected void GetCarros()
        {
            cmbx_carro.DisplayMember = "nombre";
            cmbx_carro.ValueMember = "id_carro";
            cmbx_carro.DataSource = carros.GetCarros().Tables[0];
        }

        protected void GetFuncion()
        {
            cmbx_funcion.DisplayMember = "descripcion";
            cmbx_funcion.ValueMember = "id_grupo";
            cmbx_funcion.DataSource = carros.Getz_carrosSelGrupos().Tables[0];
        }


        public List<int> IdCarros
        {
            get { return idCarros; }
            set { idCarros = value; }
        }

        //private void CarroDisponible_Load(object sender, EventArgs e)
        //{
        //    //var carro = new z_carros();
        //    //DataSet ds = carro.Getz_carrosTodosDisponibles();
        //    //listCarros.DisplayMember = "nombre";
        //    //listCarros.ValueMember = "id_carro";
        //    //listCarros.DataSource = ds.Tables[0];

        //    var carro = new z_carros();
        //    DataSet ds = carro.Getz_carrosSelGrupos();
        //    lbx_grupos.DisplayMember = "descripcion";
        //    lbx_grupos.ValueMember = "id_grupo";
        //    lbx_grupos.DataSource = ds.Tables[0];

        //}

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbx_funcion.SelectedIndex != -1)
            {
                var carro = new z_carros();
                carro = carro.getObjectz_carros(Convert.ToInt32(cmbx_carro.SelectedValue.ToString()));

                if (!Carro.EstaDisponible(carro))
                {
                    MessageBox.Show("El carro ya no está disponible. Seleccione otro carro.", "Mensaje de ZEUS");
                }
                else
                {

                    int id_carro_seleccionado = Convert.ToInt32(cmbx_carro.SelectedValue.ToString());
                    int id_Grupo = (int)cmbx_funcion.SelectedValue;

                    //### Agregar Carro en tabla z_carros_llamado
                    if (carro.existenciaZcarrosLlamado(id_carro_seleccionado, DatosLogin.LoginExp) == 0)
                    {
                        carro.insertZcarrosLlamado(id_carro_seleccionado, id_Grupo != 0 ? id_Grupo : id_Grupo, DatosLogin.LoginExp);
                        StaticClass.ArrGrupoCarros.Add(id_carro_seleccionado + "/" + id_Grupo);
                    }
                    
                    
                    
                    // marcar y asignar
                    //carro.estado = 4;
                    //carro.modifyz_carros(carro);
                    Carro.Despachar(carro);

                    idCarros.Add(carro.id_carro);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una función para el carro " + cmbx_carro.DisplayMember.ToString(), "Mensaje de ZEUS");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbx_origen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbx_origen.SelectedIndex != -1)
            {
                DataSet ds = carros.Get_Compania_SeleccionadaCarrosDisponible((int)cmbx_origen.SelectedValue);
                cmbx_carro.DisplayMember = "nombre";
                cmbx_carro.ValueMember = "id_carro";
                cmbx_carro.DataSource = ds.Tables[0];
            }
        }

    }
}