using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;
using System.Collections;

namespace Zeus.UIElements
{
    public partial class CarroDisponible2 : Form
    {
        private List<int> idCarros;

        public CarroDisponible2(ArrayList ArrayCarros)
        {
            InitializeComponent();
            ListadoCarros = ArrayCarros;
            CargarListadoCarros();
        }

        public ArrayList ListadoCarros { get; set; }

        public List<int> IdCarros
        {
            get { return idCarros; }
            set { idCarros = value; }
        }

        private void CargarListadoCarros()
        {
            DataTable dt = new DataTable();
            DataRow row = null;
            z_carros carros = new z_carros();
            dt.Columns.Add(new DataColumn("NombreCarro", typeof(string)));
            dt.Columns.Add(new DataColumn("IdCarro", typeof(string)));

            for (int i = 0; i < ListadoCarros.Count; i++)
            {
                carros = carros.getObjectz_carros(Convert.ToInt32(ListadoCarros[i]));
                row = dt.NewRow();
                row["NombreCarro"] = carros.nombre;
                row["IdCarro"] = carros.id_carro;
                dt.Rows.Add(row);
            }

            listCarros.DataSource = dt;
            listCarros.DisplayMember = "NombreCarro";
            listCarros.ValueMember = "IdCarro";
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            DatosLogin.InvokeTwitter = "FT2";
            if (listCarros.SelectedIndex != -1)
            {
                var carro = new z_carros();
                carro = carro.getObjectz_carros(Convert.ToInt32(listCarros.SelectedValue));
                if (!Carro.EstaDisponible(carro))
                {
                    MessageBox.Show("El carro ya no está disponible. Seleccione otro carro.", "Mensaje de ZEUS");
                }
                else
                {
                    // marcar y asignar
                    //carro.estado = 4;
                    //carro.modifyz_carros(carro);
                    
                    //string strExp = DatosLogin.LoginExp.ToString();
                    //MessageBox.Show("El Expediente..." + strExp, "Mensaje de ZEUS");

                    int id_carro_seleccionado = carro.id_carro;

                    //### Agregar Carro en tabla z_carros_llamado
                    if (carro.existenciaZcarrosLlamado(id_carro_seleccionado, DatosLogin.LoginExp) == 0)
                    {
                        carro.insertZcarrosLlamado(id_carro_seleccionado, DatosLogin.LoginGrp != 0 ? DatosLogin.LoginGrp : Convert.ToInt32(DatosLogin.LoginGrp), DatosLogin.LoginExp);
                        StaticClass.ArrGrupoCarros.Add(id_carro_seleccionado + "/" + DatosLogin.LoginGrp);
                    }


                    //### Asignar el Carro Seleccionado
                    Carro.Despachar(carro);

                    idCarros.Add(id_carro_seleccionado);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un carro.", "Mensaje de ZEUS");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}