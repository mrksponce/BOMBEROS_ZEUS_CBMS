using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace PreparaMaterialMayor
{
    public partial class EntregaDeTurno : Form
    {
        private List<int> idCarros;
        z_carros carros = new z_carros();

        
        
        #region ***** Cargar Controles *****

        public EntregaDeTurno()
        {
            InitializeComponent();
            GetCompaniaOrigen();
            GetEstado();
        }

        protected void GetCompaniaOrigen()
        {
            cmb_Compania.DisplayMember = "nombre_compania";
            cmb_Compania.ValueMember = "id_compania";
            cmb_Compania.DataSource = carros.GetCompaniasId().Tables[0];
        }

        private void cmb_Compania_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Compania.SelectedIndex != -1)
            {
                DataSet ds = carros.Get_Compania_SeleccionadaCarros((int)cmb_Compania.SelectedValue);
                cmb_Material.DisplayMember = "nombre";
                cmb_Material.ValueMember = "id_carro";
                cmb_Material.DataSource = ds.Tables[0];
            }
        }

        protected void GetCarros()
        {
            cmb_Material.DisplayMember = "nombre";
            cmb_Material.ValueMember = "id_carro";
            cmb_Material.DataSource = carros.GetCarros().Tables[0];
        }

        protected void GetEstado()
        {
            cmb_Estado.DisplayMember = "descripcion";
            cmb_Estado.ValueMember = "id_estado";
            cmb_Estado.DataSource = carros.Getz_EstadoCarro().Tables[0];
        }

        private void cmb_Material_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Material.SelectedIndex != -1)
            {
                DataSet ds = new z_conductores().Getz_conductoresCarro((int)cmb_Material.SelectedValue);
                cmb_Conductores.DisplayMember = "nombre_completo";
                cmb_Conductores.ValueMember = "id_conductor";
                cmb_Conductores.DataSource = ds.Tables[0];
            }
        }


        #endregion



        private void EntregaDeTurno_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }


        protected void CargarGrilla()
        {
            dg_EntregaTurno.Rows.Clear();
            z_carros_prep carros = new z_carros_prep();
            

            //# Estado de Carros Config
            if (carros.Estado_Carro_Prep().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_est in carros.Estado_Carro_Prep().Tables[0].Rows)
                {
                    string strConductor = "";
                    if (row_est["tipo_conductor"].ToString() != "")
                    {
                        strConductor = ObtieneNombreDeConductor(Convert.ToInt32(row_est["id_conductor"].ToString()), Convert.ToInt32(row_est["tipo_conductor"].ToString()));
                    }

                    dg_EntregaTurno.Rows.Add(row_est["nombre"].ToString(), row_est["estado"], row_est["codigo"], strConductor, row_est["observacion"]);
                }
            }

        }


        //### Obtiene Nombres de Conductor
        public static string ObtieneNombreDeConductor(int id_conductor, int tipo_conductor)
        {
            string NombeConductor = "";
            string reqSQL = "";
            z_cuarteleros zcuarteleros = new z_cuarteleros();
            z_voluntarios zvoluntarios = new z_voluntarios();

            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();

            if (tipo_conductor == 1)
            {
                reqSQL = "SELECT nombres||' '||apellidos As nombre_completo FROM z_cuarteleros WHERE id_cuartelero IN (SELECT id_cuart_vol FROM z_conductores WHERE id_conductor=" + id_conductor + ")";
            }
            else
            {
                reqSQL = "SELECT nombres||' '||apellidos As nombre_completo FROM z_voluntarios WHERE id_voluntario IN (SELECT id_cuart_vol FROM z_conductores WHERE id_conductor=" + id_conductor + ")";
            }
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_conductor in myResult.Tables[0].Rows)
                {
                    NombeConductor = Convert.ToString(r_conductor["nombre_completo"]);
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return NombeConductor;
        }

        //# Agregar Registro en z_carros_prep
        private void btn_AgregaCarro_Click(object sender, EventArgs e)
        {
            var carros_prep = new z_carros_prep();
            var carro = new z_carros();
            carro = carro.getObjectz_carros(Convert.ToInt32(cmb_Material.SelectedValue.ToString()));

            int IdPreparado = carros_prep.CarroEstaPreparado(Convert.ToInt32(cmb_Material.SelectedValue.ToString()));
            if (IdPreparado == 0)
            {
                int IConductorPrep = Convert.ToInt32(cmb_Conductores.SelectedValue.ToString());
                int EstadoPrep = Convert.ToInt32(cmb_Estado.SelectedValue.ToString());
                if (EstadoPrep == 2 || EstadoPrep == 3)
                {
                    IConductorPrep = 0;
                }
                carros_prep.insertZcarrosPrep(carro.id_carro, carro.nombre, carro.id_compania, EstadoPrep, IConductorPrep, carro.id_compania_orig, txb_Observacion.Text, "Juanita");

                MessageBox.Show("Se ha agregado el Carro " + carro.nombre.ToString(), "Sistema de ZEUS");
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("El Carro " + carro.nombre.ToString() + " ya se encuentra preparado.", "Sistema de ZEUS");
            }

        }

        //# Seleccionar Fila del Listado Preparar Carro
        private void dg_EntregaTurno_Click(object sender, EventArgs e)
        {
            var carros_prep = new z_carros_prep();

            if (Convert.ToInt32(this.dg_EntregaTurno.Rows.Count) >= 1)
            {
                int filaseleccionada = Convert.ToInt32(this.dg_EntregaTurno.CurrentRow.Index);
                string strValor = this.dg_EntregaTurno.Rows[filaseleccionada].Cells[0].Value + "";
                //MessageBox.Show("Maquina " + strValor.ToString(), "Sistema de ZEUS");
                if (MessageBox.Show(
        "Desea eliminar el Carro " + strValor + " ?", "Eliminar Preparación de Carro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //MessageBox.Show("La Respuesta es YES", "Sistema de ZEUS");
                    carros_prep.EliminarCarroPrep(strValor);
                    CargarGrilla();
                }
            }
        }

        private void btn_AsignacionMasiva_Click(object sender, EventArgs e)
        {
            var carros_prep = new z_carros_prep();
            z_conductores conductor = new z_conductores();
            z_carros carro = new z_carros();

            if (Convert.ToInt32(this.dg_EntregaTurno.Rows.Count) >= 1)
            {
                if (MessageBox.Show(
        "Está segura(o) que desea asignar los Conductores ?", "Asignación Automática de Conductores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //MessageBox.Show("La Respuesta es YES", "Sistema de ZEUS");
                    //carros_prep.AsignacionMasivaDeConductores();
                    
                    
                    //# Carros Preparados para ser Asignados
                    if (carros_prep.CarrosPreparados().Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row_est in carros_prep.CarrosPreparados().Tables[0].Rows)
                        {
                            //string strConductor = "";
                            //if (row_est["tipo_conductor"].ToString() != "")
                            //{
                            //    strConductor = ObtieneNombreDeConductor(Convert.ToInt32(row_est["id_conductor"].ToString()), Convert.ToInt32(row_est["tipo_conductor"].ToString()));
                            //}
                            
                            //# Poner en Servicio el Carro con el Conductor Asignado
                            if (Convert.ToInt32(row_est["estado"].ToString()) == 1)
                            {
                                int id_conductor = Convert.ToInt32(row_est["id_conductor"].ToString());
                                carro = carro.getObjectz_carros(row_est["nombre"].ToString());
                                var carros = new List<int> { carro.id_carro };

                                if (carro.estado == 1 && carro.id_conductor != 0)
                                {
                                    // Fuera de Servicio con este Conductor
                                    Conductor.FueraServicio(carro.id_conductor, carros);
                                }
                                Conductor.PuestaEnServicio(id_conductor, carros, null);
                            }

                            //# Poner Fuera de Servicio
                            if (Convert.ToInt32(row_est["estado"].ToString()) == 2)
                            {
                                carro = carro.getObjectz_carros(row_est["nombre"].ToString());
                                Carro.FueraServicio(carro.id_carro, row_est["observacion2"].ToString());
                                //Estado = 2;
                                BitacoraGestion.NuevoEvento(1, 1, "Carro: " + carro.nombre + " Fuera de Servicio.");
                            }

                            //# Poner Sin Conductor
                            if (Convert.ToInt32(row_est["estado"].ToString()) == 3)
                            {
                                carro = carro.getObjectz_carros(row_est["nombre"].ToString());
                                Carro.SinConductor(carro.id_carro, row_est["observacion2"].ToString());
                                BitacoraGestion.NuevoEvento(DatosLogin.LoginUsuario, DatosLogin.LoginUsuario,
                                            "Carro: " + carro.nombre + " Sin coductor");

                            }
                        }

                        //################################################################
                        //### Actualizar Todos los Carros Despues de Preparar Material ###
                        //### JSON Multiple en servicio                                ###
                        //################################################################
                        if (carro.GetParametroPrioridad(6) == "TRUE")
                        {
                            //### Actualiz Todos los Carros   :)
                            JsonServicioClaves jsc = new JsonServicioClaves();
                            jsc.JsonServicioHoraMultipleJSON_TodosLosCarros();
                        }


                    }
                   
                    
                    carros_prep.EliminarTosLosConductores();
                    CargarGrilla();
                    MessageBox.Show(":)   Se han asignado todos los conductores...", "Sistema de ZEUS");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("No ha ingresado conductores para ser asignados...", "Sistema de ZEUS");
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
