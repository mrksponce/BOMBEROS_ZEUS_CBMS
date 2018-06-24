using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class GestionCarros : Form
    {
               
        private IZeusWin zeusWin;
        //string[] coordenadas_carro = null;

        public GestionCarros()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GestionCarros_Load(object sender, EventArgs e)
        {
            CargarCarros();
            //cargaComboUbicacion();
            //cargarComboClave();
        }

        private void cargaComboUbicacion()
        {
            DataSet ds = new z_carros().cargarCombo();
            comboCoordenada.DisplayMember = "ubicacion";
            comboCoordenada.ValueMember = "coordenada";
            comboCoordenada.DataSource = ds.Tables[0];
        }

        private void cargarComboClave()
        {
            DataSet ds = new z_carros().cargarComboClave();
            comboClave.DisplayMember = "descripcion_clave";
            comboClave.ValueMember = "descripcion_clave";
            comboClave.DataSource = ds.Tables[0];
        }

        private void CargarCarros()
        {
            try
            {
                DataSet ds = new z_carros().Getz_carrosDisponibles();
                comboCarro.DisplayMember = "Nombre";
                comboCarro.ValueMember = "id_carro";
                comboCarro.DataSource = ds.Tables[0];

                // llamado falso seleccionado?
                if (zeusWin.IdExpediente < 0)
                {
                    // cargar carros de ese llamado
                    DataSet ds2 = new e_carros_usados().Gete_carros_exp(zeusWin.IdExpediente);
                    listDisp.DisplayMember = "nombre";
                    listDisp.ValueMember = "id_carro";
                    listDisp.DataSource = ds2.Tables[0];
                }
                else
                {
                    groupBox2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int vCombo = 0;
            ////z_carros carros = new z_carros();
            //if (coordenadas_carro == null && comboCoordenada.SelectedIndex != -1)
            //{
            //    coordenadas_carro = comboCoordenada.SelectedValue.ToString().Split('/');
            //}

            //if (comboClave.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Debe seleccionar una clave.", "Mensaje de ZEUS");
            //    return;
            //}
            //if (comboCoordenada.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Debe seleccionar una ubiación.", "Mensaje de ZEUS");
            //    return;
            //}
            //if (comboCarro.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Debe seleccionar Material Mayor", "Mensaje de ZEUS");
            //    return;
            //}

            //try
            //{
            //    // asignación de expedientes falsos:
            //    // 6-13: -1, 6-14: -2, 6-15: -3

            //    string[] arregloClave = comboClave.SelectedValue.ToString().Split(':');

            //    if(arregloClave[0].ToString() == "6-13")
            //    {
            //        vCombo = -1;
            //    }

            //    if (arregloClave[0].ToString() == "6-14")
            //    {
            //        vCombo = -2;
            //    }

            //    if (arregloClave[0].ToString() == "6-15")
            //    {
            //        vCombo = -3;
            //    }

            //    //### Despachar
            //    Despacho.DespachoGestion((int) comboCarro.SelectedValue, radio09.Checked,
            //                             vCombo, comboClave.Text, coordenadas_carro);
            //    //### Registrar en Bitaciora
            //    BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
            //                                "Carro: " + comboCarro.Text + " Despachado a " + comboClave.Text + " -> " + comboCoordenada.Text);

            //    //### Agregar Ubicación de 6-13, 614 o 6-15
            //    Carro.SetUbicacion613(Convert.ToInt32(comboCarro.SelectedValue.ToString()), comboCoordenada.Text.ToString());


            //    //### Si se despachó fuera de servicio, poner en bitácora
            //    if (radio08.Checked)
            //    {
            //        BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
            //                                    "Carro: " + comboCarro.Text + " Fuera de Servicio (" + comboClave.Text +
            //                                    ")");
            //    }
            //    // actualizar vista
            //    CargarCarros();

            //    Close();






            if (comboClave.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una clave.", "Sistema ZEUS");
                return;
            }
            if (comboCarro.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar Material Mayor", "Sistema ZEUS");
                return;
            }

            try
            {
                // asignación de expedientes falsos:
                // 6-13: -1, 6-14: -2, 6-15: -3

                string[] arregloClave = comboClave.Text.ToString().Split(':');

                //MessageBox.Show(comboClave.Text.ToString(), "Sistema ZEUS   Antes de SPLIT");
                
                //MessageBox.Show(arregloClave[0].ToString(), "Sistema ZEUS   Split[0]");

                
                if (arregloClave[0].ToString() == "6-13")
                {
                    vCombo = -1;
                }

                if (arregloClave[0].ToString() == "6-14")
                {
                    vCombo = -2;
                }

                if (arregloClave[0].ToString() == "6-15")
                {
                    vCombo = -3;
                }


                //### Publicar en Twitter
                string strEstado = "";
                if (radio09.Checked)
                {
                    strEstado = "  0-9";
                }
                else
                {
                    strEstado = "  0-8";
                }
                string[] strClave = comboClave.Text.ToString().Split(':');
                string str6131415 = comboCarro.Text + "   " + strClave[0] + strEstado;
                //MessageBox.Show(str6131415, "GEObit");
                z_carros carros = new z_carros();
                if (carros.GetParametroPrioridad(1) == "TRUE")
                {
                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                    proceso.StartInfo.Arguments = "1" + " " + str6131415 + " ";
                    proceso.StartInfo.CreateNoWindow = true;
                    proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    proceso.Start();
                    //MessageBox.Show(str6131415, "GEObit");
                    //MessageBox.Show("Twitter publicado de forma exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }




                //### JSON SERVICIO 2 = 0-8
                z_carros carro = new z_carros();
                carro = carro.getObjectz_carros(comboCarro.Text);
                JsonServicioClaves jsc = new JsonServicioClaves(carro.id_carro);


                //### JSON APOLO EVENTO
                z_carros ca = new z_carros();
                if (ca.GetParametroPrioridad(6) == "TRUE")
                {
                    //### Generar ID de Salida
                    bitacora_gestion bit_gest = new bitacora_gestion();
                    bit_gest.InsertIdGestion(vCombo, comboCarro.Text);
                    //# Obtener ID de Gestión
                    int idSalidaCarro = bit_gest.SelectIdGestion(vCombo, comboCarro.Text);
                    
                    //### SALIDA
                    JsonGestionCarroClave JsGetCar = new JsonGestionCarroClave();
                    JsGetCar.ApoloHoraGestionCarro(vCombo, carro.id_carro, ZeusWin.IdOperadora, idSalidaCarro);

                    //### MATERIAL DISPONIBLE
                    //# Nombre de Conductor
                    string strNomConductor = new z_conductores().Getz_NombreConductor(carro.id_conductor);
                    if (radio09.Checked)
                    {
                        jsc.JsonServicioHora(carro.id_carro, 1, strNomConductor, "0-9", "VerdeClaro", true);
                    }
                    else
                    {
                        jsc.JsonServicioHora(carro.id_carro, 4, strNomConductor, "0-8", "Azul", true);
                    }

                    //### 6-0 del Carro
                    if (idSalidaCarro > 0)
                    {
                        var JsSaCl = new JsonSalidaClaves(carro.id_carro);
                        JsSaCl.ApoloHoraCarro(idSalidaCarro, "6-0", carro.id_carro, "", 0, vCombo);
                    }    


                }

                // despachar OLD
                //Despacho.DespachoGestion((int)comboCarro.SelectedValue, radio09.Checked,
                //                         (comboClave.SelectedIndex + 1) * -1, comboClave.Text);
                Despacho.DespachoGestion((int)comboCarro.SelectedValue, radio09.Checked,
                         vCombo, comboClave.Text);



                // registrar en bitaciora
                BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                            "Carro: " + comboCarro.Text + " Despachado a " + comboClave.Text);

                // si se despachó fuera de servicio, poner en bitácora
                if (radio08.Checked)
                {
                    BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                "Carro: " + comboCarro.Text + " Fuera de Servicio (" + comboClave.Text +
                                                ")");
                }
                // actualizar vista
                CargarCarros();
                Close();


            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void listDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDisp.SelectedItem != null)
            {
                try
                {
                    z_carros carro = new z_carros().getObjectz_carros((int) listDisp.SelectedValue);
                    if (Carro.EstaDisponible(carro))
                    {
                        radioDisp09.Checked = true;
                    }
                    else
                    {
                        radioDisp08.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (listDisp.SelectedItem != null)
            {
                try
                {
                    z_carros carro = new z_carros().getObjectz_carros((int) listDisp.SelectedValue);
                    e_carros_usados cu = new e_carros_usados().getObjecte_carros_usados((int) listDisp.SelectedValue);
                    if (radioDisp08.Checked)
                    {
                        //carro.estado = 2;
                        Carro.FueraServicio(carro, "Gestión");
                        cu.seis = "0-8";
                        cu.Update(cu);
                    }
                    else
                    {
                        //carro.estado = 1;
                        Carro.PonerEnServicio(carro);
                        cu.seis = "0-9";
                        cu.Update(cu);
                    }
                    //carro.modifyz_carros(carro);
                    Close();
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_011_CubrirCuartel cuartel = new _011_CubrirCuartel();  CBS
            //cuartel.Show();                                         CBS

#if CBQN
            //MessageBox.Show("Este módulo no se encuentra disponible en esta versión del Sistema Zeus",
            //                "Módulo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CubrirCuarteles cc = new CubrirCuarteles();
            cc.ZeusWin = this.zeusWin;
            cc.ShowDialog();

#else
                        CubrirCuarteles cc = new CubrirCuarteles();
                        cc.ZeusWin = this.zeusWin;
                        cc.ShowDialog();
#endif
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboCarro.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un material mayor", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Frm614 frm614 = new Frm614(comboCarro.Text, Convert.ToInt32(comboCarro.SelectedValue.ToString()));
                frm614.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboCarro.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un material mayor", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Frm615 frm615 = new Frm615(comboCarro.Text, Convert.ToInt32(comboCarro.SelectedValue.ToString()));
                frm615.ShowDialog();
            }
        }
    }
}