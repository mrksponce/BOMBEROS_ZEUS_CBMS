using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;
using System.Collections;

namespace Zeus.UIElements
{
    public partial class SolicitudCarros : Form
    {
        private int id_area;
        private List<int> idCarros;
        private int id_expediente;

        public SolicitudCarros()
        {
            InitializeComponent();
        }

        public int Id_expediente
        {
            get { return id_expediente; }
            set { id_expediente = value; }
        }

        public List<int> IdCarros
        {
            get { return idCarros; }
            set { idCarros = value; }
        }

        public int Id_area
        {
            get { return id_area; }
            set { id_area = value; }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var exp = new e_expedientes();
            z_carros carro;
            PanelLlamado llamado = new PanelLlamado();
            e_expedientes expediente = new e_expedientes();
            int id_carro = 0;
            int bloque = expediente.recFechaExpediente(this.Id_expediente);
            ArrayList listado_carros_disponibles = new ArrayList();

            DatosLogin.LoginExp = this.Id_expediente;


            // ################################
            // ### Coordenadas para Twitter ###
            // ################################
            exp = exp.getObjecte_expedientes(this.Id_expediente);
            string strTw_X = (Math.Truncate(exp.puntoX)).ToString();
            string strTw_Y = (Math.Truncate(exp.puntoY)).ToString();
            string strLatLong = exp.Utm_2_LatLong(strTw_X, strTw_Y);
            string strURL = "https://maps.google.cl/maps?q=";
            string strZOOM = "&t=m&z=17";
            string strPlano = strURL + strLatLong + strZOOM;

            // ### Agregar en el expediente el link del Plano
            exp.AgregarPlanoTwitter(this.Id_expediente, strPlano);

            // ### Agregar en el expediente las coordenadas Lat Long
            exp.AgregarLatLongWeb(id_expediente, strLatLong);


            DatosLogin.InvokeTwitter = "FT2";
            int arrra = 0;
            CarroDisponible2 cd2;
            //InformacionExpediente expe = new InformacionExpediente();
            switch (((Button)sender).Name)
            {
                case "btn20":
                    //carro = Despacho.ObtenerCarro(1, id_area);

                    DatosLogin.LoginGrp = 1;
                    arrra = id_area;
                    listado_carros_disponibles = llamado.Un_Carro_X_Clave_All(1, bloque, Id_expediente);
                    cd2 = new CarroDisponible2(listado_carros_disponibles) { IdCarros = idCarros };
                    cd2.ShowDialog();
                    /*carro = new z_carros().getObjectz_carros(id_carro);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }*/
                    break;
                case "btn21":
                    //carro = Despacho.ObtenerCarro(5, id_area);
                    //int arrra = id_area;

                    DatosLogin.LoginGrp = 2;
                    arrra = id_area;
                    listado_carros_disponibles = llamado.Un_Carro_X_Clave_All(2, bloque, Id_expediente);
                    cd2 = new CarroDisponible2(listado_carros_disponibles) { IdCarros = idCarros };
                    cd2.ShowDialog();

                    /*id_carro = llamado.Un_Carro_X_Clave(2, bloque, Id_expediente);
                    carro = new z_carros().getObjectz_carros(id_carro);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }*/
                    break;
                case "btn22":
                    //carro = Despacho.ObtenerCarro(7, id_area);

                    DatosLogin.LoginGrp = 4;
                    arrra = id_area;
                    listado_carros_disponibles = llamado.Un_Carro_X_Clave_All(4, bloque, Id_expediente);
                    cd2 = new CarroDisponible2(listado_carros_disponibles) { IdCarros = idCarros };
                    cd2.ShowDialog();

                    /*id_carro = llamado.Un_Carro_X_Clave(10, bloque, Id_expediente);
                    carro = new z_carros().getObjectz_carros(id_carro);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }*/
                    break;
                case "btn23":
                    //carro = Despacho.ObtenerCarro(13, id_area);
                    //int arrra = id_area;

                    DatosLogin.LoginGrp = 9;
                    arrra = id_area;
                    listado_carros_disponibles = llamado.Un_Carro_X_Clave_All(9, bloque, Id_expediente);
                    cd2 = new CarroDisponible2(listado_carros_disponibles) { IdCarros = idCarros };
                    cd2.ShowDialog();


                    /*id_carro = llamado.Un_Carro_X_Clave(7, bloque, Id_expediente);
                    carro = new z_carros().getObjectz_carros(id_carro);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }*/
                    break;
                case "btn24":
                    //carro = Despacho.ObtenerCarro(10, id_area);
                    //int arrra = id_area;

                    DatosLogin.LoginGrp = 6;
                    arrra = id_area;
                    listado_carros_disponibles = llamado.Un_Carro_X_Clave_All(6, bloque, Id_expediente);
                    cd2 = new CarroDisponible2(listado_carros_disponibles) { IdCarros = idCarros };
                    cd2.ShowDialog();

                    /*
                    id_carro = llamado.Un_Carro_X_Clave(4, bloque, Id_expediente);
                    carro = new z_carros().getObjectz_carros(id_carro);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }*/
                    break;
                case "btn25":
                    //carro = Despacho.ObtenerCarro(9, id_area);

                    DatosLogin.LoginGrp = 5;
                    arrra = id_area;
                    listado_carros_disponibles = llamado.Un_Carro_X_Clave_All(5, bloque, Id_expediente);
                    cd2 = new CarroDisponible2(listado_carros_disponibles) { IdCarros = idCarros };
                    cd2.ShowDialog();

                    /*
                    id_carro = llamado.Un_Carro_X_Clave(6, bloque, Id_expediente);
                    carro = new z_carros().getObjectz_carros(id_carro);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }*/
                    break;
                case "btn26":
                    var cd = new CarroDisponible { IdCarros = idCarros };
                    cd.ShowDialog();
                    break;
                case "btn27":
                    //carro = Despacho.ObtenerCarro(6, id_area);
                    //int arrra = id_area;

                    DatosLogin.LoginGrp = 3;
                    arrra = id_area;
                    listado_carros_disponibles = llamado.Un_Carro_X_Clave_All(3, bloque, Id_expediente);
                    cd2 = new CarroDisponible2(listado_carros_disponibles) { IdCarros = idCarros };
                    cd2.ShowDialog();

                    /*
                    id_carro = llamado.Un_Carro_X_Clave(15, bloque, Id_expediente);
                    carro = new z_carros().getObjectz_carros(id_carro);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }*/
                    break;
                case "btn28":
                    //carro = Despacho.ObtenerCarro(15, id_area);
                    //int arrra = id_area;

                    DatosLogin.LoginGrp = 10;
                    arrra = id_area;
                    listado_carros_disponibles = llamado.Un_Carro_X_Clave_All(10, bloque, Id_expediente);
                    cd2 = new CarroDisponible2(listado_carros_disponibles) { IdCarros = idCarros };
                    cd2.ShowDialog();


                    /*id_carro = llamado.Un_Carro_X_Clave(17, bloque, Id_expediente);
                    carro = new z_carros().getObjectz_carros(id_carro);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }*/
                    break;
                case "btn29":
                    //carro = Despacho.ObtenerCarro(15, id_area);
                    //int arrra = id_area;

                    DatosLogin.LoginGrp = 16;
                    arrra = id_area;
                    listado_carros_disponibles = llamado.Un_Carro_X_Clave_All(16, bloque, Id_expediente);
                    cd2 = new CarroDisponible2(listado_carros_disponibles) { IdCarros = idCarros };
                    cd2.ShowDialog();

                    /*
                    id_carro = llamado.Un_Carro_X_Clave(16, bloque, Id_expediente);
                    carro = new z_carros().getObjectz_carros(id_carro);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }*/
                    break;
                case "btn210":
                    MessageBox.Show("Motobomba");
                    break;
                case "btn211":
                    MessageBox.Show("Grupo Electrógeno");
                    break;
                case "btn212":
                    MessageBox.Show("Equipo compresor");
                    break;
                case "btn213":
                    carro = Despacho.ObtenerCarro(16, id_area);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }
                    break;
                case "btn214":
                    carro = Despacho.ObtenerCarro(17, id_area);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }
                    break;
                case "btn215":
                    carro = Despacho.ObtenerCarro(18, id_area);
                    if (carro.id_carro != 0)
                    {
                        idCarros.Add(carro.id_carro);
                    }
                    else
                    {
                        MessageBox.Show("No hay carros disponibles del tipo seleccionado");
                    }
                    break;
                default:
                    break;
            }
            //if (idCarros.Count == 0)
            //{
            //    MessageBox.Show("No hay carros disponibles de este tipo.");
            //}
            Close();
        }

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}