using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.UIElements.Properties;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class PanelCarro : BaseControl
    {
        private bool _clic;
        private DataSet ds;
        private int idCarro;
        private List<object> nombres;

        public PanelCarro()
        {
            InitializeComponent();
            listVoluntarios.DisplayMember = "Key";
            listPreinforme.DisplayMember = "preinforme";
            listPreinforme.ValueMember = "preinforme";
            // Diferencias de UI
#if !CBQN
            //lblEsp.Dispose();
            //textEsp.Dispose();
            //listExp.Dispose();
            //tlVoluntarios.ColumnCount--;
#endif
        }

        public void MostrarInfo(int id_carro)
        {
            try
            {
                idCarro = id_carro;
                _clic = true;
                // limpiar
                listVoluntarios.Items.Clear();
                listNum.SelectedIndex = -1;
                textNum.Text = "";
                listExp.SelectedIndex = -1;
                textEsp.Text = "";
                textVoluntarios.Text = "";
                pictureVoluntario.Image = null;
                pictureCarro.Image = null;
                checkNuevo.Checked = false;

                // obtener voluntarios
                z_carros carro;
                e_carros_usados cu;
                CargarVoluntarios(id_carro, out carro, out cu);

                // oficiales
                CargarOficiales(carro);


                // datos actuales carro
                if (cu.id_voluntario != 0)
                {
                    DataRow da = ds.Tables[0].Select("id_voluntario =" + cu.id_voluntario)[0];
                    listVoluntarios.SelectedItem =
                        nombres.Find(
                            o => (((KeyValuePair<string, int>)o).Value == (int)da["id_voluntario"]));
                    listNum.SelectedItem = cu.num_voluntarios.ToString();
                    textNum.Text = cu.num_voluntarios.ToString();
                }

                //#f   Comentar estas Lineas y reemplazar por los IF
                //Image img = carro.getImagen(carro.id_carro);
                //pictureCarro.Image = img ?? Resources.cbms2;   //cbqn_logo;
                //lblCarro.Text = carro.nombre;
                //btn617.BackColor = cu.en_jurisdiccion ? Color.LightGreen : Color.Salmon;
                if (System.IO.File.Exists(carro.urlimagen))
                {
                    pictureCarro.ImageLocation = carro.urlimagen == string.Empty ? @"C:\ZEUS\Resources\Carros\comodin.jpg" : carro.urlimagen;
                }
                else
                {
                    pictureCarro.ImageLocation = @"C:\ZEUS\Resources\Carros\comodin.jpg";
                }

                lblCarro.Text = carro.nombre;
                btn617.BackColor = cu.en_jurisdiccion ? Color.LightGreen : Color.Salmon;


                // preinforme
                e_expedientes exp = new e_expedientes().getObjecte_expedientes(cu.id_expediente);
                listPreinforme.DataSource = new z_preinforme().Getz_preinforme(exp.codigo_llamado).Tables[0];
                textPreinforme.Text = cu.preinforme;
                textPreinforme.BackColor = Color.White;

                //### Ubicación de 6-13, 6-14 o 6-15
                tbx_613.Text = carro.ubicacion_613;

            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void CargarVoluntarios(int id_carro, out z_carros carro, out e_carros_usados cu)
        {
            carro = new z_carros();
            carro = carro.getObjectz_carros(id_carro);
            var vol = new z_voluntarios();
            cu = new e_carros_usados();
            cu = cu.getObjecte_carros_usados(id_carro);
            vol = vol.getObjectz_voluntarios(cu.id_voluntario);
            if (cu.id_voluntario != 0 && vol.id_compania != carro.id_compania)
            {
                ds = vol.Getz_voluntarios();
                checkMostrarTodos.Checked = true;
            }
            else
            {
                ds = vol.Getz_voluntarios(carro.id_compania);
                checkMostrarTodos.Checked = false;
            }

            nombres = new List<object>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var p =
                    new KeyValuePair<string, int>((string)dr["apellidos"] + " " + dr["nombres"],
                                                  (int)dr["id_voluntario"]);
                nombres.Add(p);
            }
            listVoluntarios.Items.AddRange(nombres.ToArray());
        }

        private void CargarOficiales(z_carros carro)
        {
            DataSet off = new z_cargos().getz_cargos_oficial(carro.id_compania);
            listOficiales.Items.Clear();
            foreach (DataRow dr in off.Tables[0].Rows)
            {
                if (dr["id_voluntario"].ToString() != "")
                {
                    var li = new ListViewItem(dr["tipo"].ToString())
                    {
                        Name = dr["tipo"].ToString(),
                        Tag = dr["id_voluntario"]
                    };
                    li.SubItems.Add(dr["llamado_oficial"].ToString());
                    li.SubItems.Add(dr["orden"].ToString());
                    listOficiales.Items.Add(li);
                }
            }
            // Resto
            //off = new z_oficial_cia().Getz_oficial_cia(carro.id_compania);
            //foreach (DataRow dr in off.Tables[0].Rows)
            //{
            //    var li = new ListViewItem(dr["tipo"].ToString())
            //                 {
            //                     Name = dr["tipo"].ToString(),
            //                     Tag = dr["id_voluntario"]
            //                 };
            //    li.SubItems.Add(dr["num_llamado"].ToString());
            //    li.SubItems.Add(dr["orden"].ToString());
            //    if (!listOficiales.Items.ContainsKey(li.Name))
            //    {
            //        listOficiales.Items.Add(li);
            //    }
            //}

            //// ordenar
            //for (int i = 0; i < listOficiales.Items.Count; i++)
            //{
            //    for (int j = i; j < listOficiales.Items.Count; j++)
            //    {
            //        if (int.Parse(listOficiales.Items[j].SubItems[2].Text) <
            //            int.Parse(listOficiales.Items[i].SubItems[2].Text))
            //        {
            //            ListViewItem temp1 = listOficiales.Items[i];
            //            ListViewItem temp2 = listOficiales.Items[j];
            //            listOficiales.Items.RemoveAt(i);
            //            listOficiales.Items.RemoveAt(j - 1);
            //            listOficiales.Items.Insert(i, temp2);
            //            listOficiales.Items.Insert(j, temp1);
            //        }
            //    }
            //}
        }

        private void textVoluntarios_TextChanged(object sender, EventArgs e)
        {
            if (!_clic)
            {
                var o = new ListBox.ObjectCollection(listVoluntarios);
                foreach (KeyValuePair<string, int> k in nombres)
                {
                    if (k.Key.ToUpper().Contains(textVoluntarios.Text.ToUpper()))
                    {
                        o.Add(k);
                    }
                }
                listVoluntarios.Items.Clear();
                listVoluntarios.Items.AddRange(o);
                listVoluntarios.SelectedIndex = -1;
            }
            _clic = false;
        }

        private void listVoluntarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listVoluntarios.SelectedIndex != -1)
                {
                    _clic = true;
                    textVoluntarios.Text = ((KeyValuePair<string, int>)listVoluntarios.SelectedItem).Key;
                    // numero de radio
                    DataRow[] dr =
                        ds.Tables[0].Select("id_voluntario=" +
                                            ((KeyValuePair<string, int>)listVoluntarios.SelectedItem).Value);
                    if (dr.Length != 0)
                    {
                        lblRadio.Text = dr[0]["num_llamado"].ToString();
                        var vol = new z_voluntarios();
                        //#f
                        //Image img = vol.getImagen(((KeyValuePair<string, int>)listVoluntarios.SelectedItem).Value);
                        //pictureVoluntario.Image = img ?? Resources.cbms2;   //cbqn_logo;
                        if (System.IO.File.Exists(vol.urlimagen))
                        {
                            pictureVoluntario.ImageLocation = vol.urlimagen == string.Empty ? @"C:\ZEUS\Resources\Voluntarios\comodin.jpg" : vol.urlimagen;
                        }
                        else
                        {
                            pictureVoluntario.ImageLocation = @"C:\ZEUS\Resources\Voluntarios\comodin.jpg";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void listNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            textNum.Text = listNum.Text;
        }

        private void textVoluntarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    int d;
                    if (int.TryParse(textVoluntarios.Text, out d))
                    {
                        // oficial
                        DataRow[] of = new z_cargos().Getz_cargos().Tables[0].Select("llamado_oficial=" + d);
                        if (of != null && of.GetLength(0) > 0)
                        {
                            DataRow[] a = ds.Tables[0].Select("id_voluntario=" + (int)of[0]["id_voluntario"]);
                            if (a.Length > 0)
                            {
                                textVoluntarios.Text = a[0]["apellidos"] + " " + a[0]["nombres"];
                                listVoluntarios.SelectedItem =
                                    nombres.Find(
                                        o => (((KeyValuePair<string, int>)o).Key == textVoluntarios.Text));
                            }
                        }
                        else
                        {
                            // obtener nombre por num radio
                            DataRow[] dr = ds.Tables[0].Select("num_llamado=" + d);
                            if (dr != null && dr.GetLength(0) > 0)
                            {
                                textVoluntarios.Text = dr[0]["apellidos"] + " " + dr[0]["nombres"];
                                listVoluntarios.SelectedItem =
                                    nombres.Find(
                                        o => (((KeyValuePair<string, int>)o).Key == textVoluntarios.Text));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void checkMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var vol = new z_voluntarios();

                if (checkMostrarTodos.Checked)
                {
                    // cargar todos los tipos
                    ds = vol.Getz_voluntarios();
                    listVoluntarios.Items.Clear();
                    nombres = new List<object>();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var p =
                            new KeyValuePair<string, int>((string)dr["apellidos"] + " " + dr["nombres"],
                                                          (int)dr["id_voluntario"]);
                        nombres.Add(p);
                    }
                    listVoluntarios.Items.AddRange(nombres.ToArray());
                }
                else
                {
                    // cargar los de la compañia
                    var carro = new z_carros();
                    carro = carro.getObjectz_carros(idCarro);
                    ds = vol.Getz_voluntarios(carro.id_compania);
                    listVoluntarios.Items.Clear();
                    nombres = new List<object>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var p =
                            new KeyValuePair<string, int>((string)dr["apellidos"] + " " + dr["nombres"],
                                                          (int)dr["id_voluntario"]);
                        nombres.Add(p);
                    }
                    listVoluntarios.Items.AddRange(nombres.ToArray());
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void textPreinforme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textPreinforme.Text != "")
                {
                    try
                    {
                        // almacenar
                        e_carros_usados cu = new e_carros_usados().getObjecte_carros_usados(idCarro);
                        cu.preinforme = textPreinforme.Text;
                        cu.Update(cu);
                        // bitacora
                        BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro,
                                                    BitacoraLlamado.Carro, "PREINFORME: " + textPreinforme.Text);
                        // color
                        textPreinforme.BackColor = Color.LightGreen;
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar información del preinforme");
                }
            }
        }

        private void btn126_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("12-6").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                            "12-6");
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void listPreinforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPreinforme.SelectedItem != null)
            {
                textPreinforme.Text = (string)listPreinforme.SelectedValue;
                textPreinforme.BackColor = Color.Yellow;
            }
        }

        private void btn617_Click(object sender, EventArgs e)
        {
            var ej = new EnJurisdiccion { IdCarro = idCarro, ZeusWin = ZeusWin };
            //if (ej.ShowDialog() == DialogResult.OK)
            //{
            //    btn617.BackColor = ej.CarroEnJurisdiccion ? Color.LightGreen : Color.Salmon;
            //}
            

            e_carros_usados cu = new e_carros_usados().getObjecte_carros_usados(idCarro);
            var JsCiaAcago = new JsonCompaniaAcargoClave();
            JsCiaAcago.ApoloCompaniaAcargo(cu.id_expediente, cu.id_carro);

            MessageBox.Show("Se ha asignado una Compañía a cargo del parte", "ZEUS");
        }

        private void listOficiales_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            if (listOficiales.SelectedItems.Count != 0 && int.TryParse(listOficiales.SelectedItems[0].Tag.ToString(),out id))
            {
                // obtener voluntario por id y mostrarlo
                listVoluntarios.SelectedItem =
                    nombres.Find(
                        o => (((KeyValuePair<string, int>)o).Value == id));
            }
            else
            {
                listVoluntarios.SelectedIndex = -1;
            }
        }

        //### 6-2 (Fuera de Servicio Temporal del Carro)
        private void btn6_2_Click(object sender, EventArgs e)
        {
            try
            {
                //### JSON SERVICIO 2 = 0-8
                z_carros carro = new z_carros();
                carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                JsonServicioClaves jsc = new JsonServicioClaves(carro.id_carro);

                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-2").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                e_carros_usados cu = new e_carros_usados().getObjecte_carros_usados(idCarro);
                cu.seis = "6-2";
                cu.Update(cu);
                Carro.FueraServicio62(idCarro, "6-2");
                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                            "6-2");

                //### JSON SERVICIO 2 = 0-8
                if (carro.GetParametroPrioridad(6) == "TRUE")
                {
                    jsc.JsonServicioHora(carro.id_carro, 2, "", "0-8", "Rojo", true);
                }

            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        #region CODIGO BOTONES SUPERIORES


        //### 6-3
        private void tool6_3_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-3").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Protocolo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);

                //### Revisar si ya tiene un 6-3
                if (cu.seis != "6-3")
                {

                    // verificar 
                    if (cu.id_voluntario != 0 && cu.seis != "6-1" && cu.id_expediente > 0)
                    {
                        if (cu.seis == "6-0V" || cu.seis == "6-1")
                        {
                            // verificar nuevo oficial a cargo
                            var exp = new e_expedientes();
                            exp = exp.getObjecte_expedientes(cu.id_expediente);

                            if (exp.id_voluntario == 0)
                            {
                                // el que llega es el of a cargo
                                exp.id_voluntario = cu.id_voluntario;
                                var vol = new z_voluntarios();
                                // todo: verificar correspondencia!
                                vol = vol.getObjectz_voluntarios(cu.id_voluntario);
                                exp.cargo_llamado = vol.apellidos + " " + vol.nombres;

                                exp.Update(exp);
                                MessageBox.Show(
                                    "Nuevo oficial a cargo para esta emergencia es:\n" +
                                    ((KeyValuePair<string, int>)listVoluntarios.SelectedItem).Key, "Nuevo Oficial a Cargo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // todo: verificar si no existe en cargos, y usar llamado voluntario
                                // todo:interinaje
                                var actual = new z_cargos();
                                actual = actual.getObjectz_cargos_vol(exp.id_voluntario);
                                z_cargos nuevo = actual.getObjectz_cargos_vol(cu.id_voluntario);

                                // voluntarios??
                                if (nuevo.grado == 0)
                                {
                                    nuevo.id_voluntario = exp.id_voluntario;
                                    nuevo.grado = 1000;
                                }

                                if (actual.grado == 0)
                                {
                                    actual.id_voluntario = cu.id_voluntario;
                                    actual.grado = 1000;
                                }


                                // interinaje
                                if (actual.reemplaza_a != 0)
                                {
                                    // obtener grado efectivo
                                    actual.grado = actual.getObjectz_cargos_vol(actual.reemplaza_a).grado;
                                }

                                if (nuevo.reemplaza_a != 0)
                                {
                                    // obtener grado efectivo
                                    nuevo.grado = nuevo.getObjectz_cargos_vol(nuevo.reemplaza_a).grado;
                                }

                                // si es menor, este manda
                                if (nuevo.grado < actual.grado)
                                {
                                    exp.id_voluntario = nuevo.id_voluntario;
                                    exp.Update(exp);
                                    MessageBox.Show(
                                        "Nuevo oficial a cargo para esta emergencia es:\n" +
                                        ((KeyValuePair<string, int>)listVoluntarios.SelectedItem).Key, "Nuevo Oficial a Cargo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                // si son iguales, comparar orden
                                if (nuevo.grado == actual.grado)
                                {
                                    // preguntar bien
                                    // todo: funciona???
                                    if (nuevo.orden_antiguedad < actual.orden_antiguedad)
                                    {
                                        exp.id_voluntario = nuevo.id_voluntario;
                                        exp.Update(exp);
                                        MessageBox.Show(
                                            "Nuevo oficial a cargo para esta emergencia es:\n" + listVoluntarios.SelectedItem,
                                            "Nuevo Oficial a Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cu.seis == "6-3")
                            {
                                MessageBox.Show("Para este carro ya ha ingresado el 6-3", "ZEUS");
                            }
                        }
                    } // Fin 6-3 de Expediente Verifica Antiguedad
                
                    //-* Algún tramite, agregar a bitácora
                    z_carros ca = new z_carros();



                    if (cu.id_expediente < 0)
                    {
                        switch (cu.id_expediente)
                        {
                            case -1:
                                BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                            lblCarro.Text + ": 6-3, Llegada a lugar de ejercicio.");
                            
                                //# Asigna Coordenada en el 6-3
                                //ca.GenerarActualizacionCasosEspeciales(lblCarro.Text);
                                break;
                            case -2:
                                BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                            lblCarro.Text + ": 6-3, Llegada a Servicentro.");
                                //# Asigna Coordenada en el 6-3
                                //ca.GenerarActualizacionCasosEspeciales(lblCarro.Text);
                                break;
                            case -3:
                                BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                            lblCarro.Text + ": 6-3, Llegada a Servicio de Salud.");
                                //# Asigna Coordenada en el 6-3
                                //ca.GenerarActualizacionCasosEspeciales(lblCarro.Text);
                                break;
                            default:
                                break;
                        }
                    }


                    //### Asigna el 6-3 y Agrega a Bitacora
                    cu.seis = "6-3";
                    cu.Update(cu);
                    BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                                "6-3");

                    //### JSON APOLO EVENTO
                    if (ca.GetParametroPrioridad(6) == "TRUE")
                    {
                        if (cu.id_expediente < 0)
                        {
                            //# Obtener ID de Gestión
                            bitacora_gestion bit_gest = new bitacora_gestion();
                            int idSalidaCarro = bit_gest.SelectIdGestion(cu.id_expediente, lblCarro.Text);
                            var JsSaCl = new JsonSalidaClaves(idCarro);
                            JsSaCl.ApoloHoraCarro(idSalidaCarro, "6-3", idCarro, "", 0, cu.id_expediente);
                        }
                        else
                        {
                            var JsBiCl = new JsonBitacoraClaves(idCarro);
                            JsBiCl.ApoloHoraCarro("6-3", idCarro, "", 0, cu.id_expediente);
                        }
                    } //# Fin Apolo
                }
                else
                {
                    MessageBox.Show("Para este carro ya ingresó el 6-3", "ZEUS");
                }

            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-0 ###
        private void tool6_0_Click(object sender, EventArgs e)
        {
            Protocolo frmProtocolo = new Protocolo();
            foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-0").Tables[0].Rows)
            {
                if (row["activo"].ToString() == "ACTIVO")
                {
                    MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            int cant;
            // verificar y guardar!
            if ((listVoluntarios.SelectedIndex != -1 || listOficiales.SelectedItems.Count != 0 || checkNuevo.Checked) &&
                textNum.Text != "" && int.TryParse(textNum.Text, out cant))
            {
                try
                {
                    //guardar
                    int idVolCargo;
                    if (!checkNuevo.Checked)
                    {
                        if (listOficiales.SelectedItems.Count != 0)
                        {
                            idVolCargo = (int) listOficiales.SelectedItems[0].Tag;
                        }
                        else
                        {
                            idVolCargo = ((KeyValuePair<string, int>) listVoluntarios.SelectedItem).Value;
                        }
                    }
                    else
                    {
                        idVolCargo = 99999999;
                    }

                    // obtener nombre de a cargo: oficial si está seleccionado, voluntario si es que está seleccionado
                    // o nuevo voluntario
                    string aCargo = listOficiales.SelectedItems.Count != 0
                                        ? listOficiales.SelectedItems[0].Text
                                        : checkNuevo.Checked
                                              ? textVoluntarios.Text == "" ? "Nuevo" : textVoluntarios.Text
                                              : ((KeyValuePair<string, int>)listVoluntarios.SelectedItem).Key;
                    var cen = new CarroEnLlamado(idCarro);
                    // verificar a qué función llamar de acuerdo a si hay especialistas o no
                    int cantEsp;
                    if (int.TryParse(textEsp.Text, out cantEsp))
                    {
                        cen.Clave6_0(idVolCargo, cant, int.Parse(textEsp.Text), aCargo);
                    }
                    else
                    {
                        cen.Clave6_0(idVolCargo, cant, aCargo);
                    }


                    //### JSON APOLO EVENTO
                    z_carros carros = new z_carros();
                    if (carros.GetParametroPrioridad(6) == "TRUE")
                    {
                        var cu = new e_carros_usados();
                        cu = cu.getObjecte_carros_usados(idCarro);

                        if (cu.id_expediente < 0)
                        {
                            ////# Obtener ID de Gestión
                            //bitacora_gestion bit_gest = new bitacora_gestion();
                            //int idSalidaCarro = bit_gest.SelectIdGestion(cu.id_expediente, lblCarro.Text);
                            //if (idSalidaCarro > 0)
                            //{
                            //    var JsSaCl = new JsonSalidaClaves(idCarro);
                            //    JsSaCl.ApoloHoraCarro(idSalidaCarro, "6-0", idCarro, aCargo, cant, cu.id_expediente);
                            //}                            
                        }
                        else
                        {
                            var JsBiCl = new JsonBitacoraClaves(idCarro);
                            JsBiCl.ApoloHoraCarro("6-0", idCarro, aCargo, cant, cu.id_expediente);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar persona a cargo y número de ocupantes", "Mensaje de ZEUS");
            }
        }


        //### Clave 6-1 ###
        private void btn6_1_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-1").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cen = new CarroEnLlamado(idCarro);
                cen.Clave6_1();


                //### JSON APOLO EVENTO
                z_carros carros = new z_carros();
                if (carros.GetParametroPrioridad(6) == "TRUE")
                {
                    var cu = new e_carros_usados();
                    cu = cu.getObjecte_carros_usados(idCarro);
                    if (cu.id_expediente < 0)
                    {
                        //# Obtener ID de Gestión
                        bitacora_gestion bit_gest = new bitacora_gestion();
                        int idSalidaCarro = bit_gest.SelectIdGestion(cu.id_expediente, lblCarro.Text);
                        var JsSaCl = new JsonSalidaClaves(idCarro);
                        JsSaCl.ApoloHoraCarro(idSalidaCarro, "6-0", idCarro, "6-1", 0, cu.id_expediente);
                    }
                    else
                    {
                        var JsBiCl = new JsonBitacoraClaves(idCarro);
                        JsBiCl.ApoloHoraCarro("6-0", idCarro, "6-1", 0, cu.id_expediente);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-7 ###
        private void tool6_7_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-7").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //### Referencia a Carro y Expediente
                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                var exp = new e_expedientes();
                exp = exp.getObjecte_expedientes(cu.id_expediente);

                //### Publicar en Tw y Agrehar en Bitacora sólo si es el primer 6-7
                if (!(exp.sit_controlada))
                {

                    //### Publicar 6-7 en Twitter
                    int IdExp = Convert.ToInt32(cu.id_expediente);
                    if (IdExp > 0)
                    {
                        var llam = new z_llamados();
                        llam = llam.getObjectz_llamados(exp.codigo_llamado);
                        string str67 = "6-7 del " + llam.clave.ToString() + " " + exp.seis2.ToString() + " / " + exp.cero5.ToString();
                        //MessageBox.Show(str67, "GEObit");
                        z_carros carros = new z_carros();
                        if (carros.GetParametroPrioridad(1) == "TRUE")
                        {
                            System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                            proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                            proceso.StartInfo.Arguments = "1" + " " + str67 + " ";
                            proceso.StartInfo.CreateNoWindow = true;
                            proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            proceso.Start();

                            //MessageBox.Show("Twitter publicado de forma exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        //ZeusWin.Actualizar();
                        //DBNotifyListeners.Notify("despacho");
                        BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                                "6-7");

                        //### JSON APOLO EVENTO
                        if (carros.GetParametroPrioridad(6) == "TRUE")
                        {
                            var JsBiCl = new JsonBitacoraClaves(idCarro);
                            JsBiCl.ApoloHoraCarro("6-7", idCarro, "", 0, cu.id_expediente);
                        }
                    }


                    //### Agregar Situación Controlada
                    exp.sit_controlada = true;
                    exp.Update(exp);

                }
                else
                {
                    MessageBox.Show("En esta emergencia ya se ha ingresado el 6-7", "ZEUS");
                }


            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-8 ###
        private void tool6_8_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-8").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cen = new CarroEnLlamado(idCarro);
                cen.Clave6_8();


                //### JSON APOLO EVENTO
                z_carros carros = new z_carros();
                if (carros.GetParametroPrioridad(6) == "TRUE")
                {
                    var cu = new e_carros_usados();
                    cu = cu.getObjecte_carros_usados(idCarro);
                    var JsBiCl = new JsonBitacoraClaves(idCarro);
                    JsBiCl.ApoloHoraCarro("6-8", idCarro, "", 0, cu.id_expediente);

                    z_carros carro = new z_carros();
                    carro = carro.getObjectz_carros(RecursosEstaticos.NombreCarro);
                    JsonServicioClaves jsc = new JsonServicioClaves(carro.id_carro);
                    //# Nombre de Conductor
                    string strNomConductor = new z_conductores().Getz_NombreConductor(carro.id_conductor);
                    jsc.JsonServicioHora(idCarro, 1, strNomConductor, "0-9", "VerdeClaro", false);
                }


            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-9 ###
        private void tool6_9_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-9").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);

                //:) Elimina registro en z_carros_llamado
                e_expedientes expediente = new e_expedientes();
                expediente.limpiarRegistroZcarrosLlamado(cu.id_expediente, cu.id_carro);


                // 0-8 o 0-9
                if (cu.seis != "6-8")
                {
                    z_carros carro = new z_carros().getObjectz_carros(idCarro);
                    if (
                        MessageBox.Show(
                            "¿Se retira el carro como disponible (0-9)?\nSi selecciona 'Sí', el carro se retira 0-9.\nSi selecciona 'No', el carro se retira 0-8",
                            "Retiro de carro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Carro.DisponibleEnActo(carro);
                    }
                    else
                    {
                        //Carro.FueraServicio(carro, "Retirado 6-9");
                        Carro.AunEnActo(carro);
                    }
                }
                cu.seis = "6-9";
                cu.Update(cu);
                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,"6-9");

                //### Agregar Esto
                z_carros ca = new z_carros();
                ca = ca.getObjectz_carros(idCarro);

                z_servicio servicio = new z_servicio(idCarro, System.DateTime.Now, 6, ca.id_conductor, "Asignación de claves: Se asigna clave 6-9 al carro " + ca.nombre + "");
                servicio.Insert(servicio);


                //### JSON APOLO EVENTO
                if (ca.GetParametroPrioridad(6) == "TRUE")
                {
                    if (cu.id_expediente < 0)
                    {
                        //# Obtener ID de Gestión
                        bitacora_gestion bit_gest = new bitacora_gestion();
                        int idSalidaCarro = bit_gest.SelectIdGestion(cu.id_expediente, lblCarro.Text);
                        var JsSaCl = new JsonSalidaClaves(idCarro);
                        JsSaCl.ApoloHoraCarro(idSalidaCarro, "6-9", idCarro, "", 0, cu.id_expediente);
                    }
                    else
                    {
                        var JsBiCl = new JsonBitacoraClaves(idCarro);
                        JsBiCl.ApoloHoraCarro("6-9", idCarro, "", 0, cu.id_expediente);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-10 ###
        private void tool6_10_Click(object sender, EventArgs e)
        {
            // MODIFICACION MRKSPONCE: CBSBTN6-10
            // SE QUITA EL BOTON 6-10 YA QUE ESTA FUNCIONALIDAD ES PARA CBS
            /*ListadoCuarteles l_cuarteles = new ListadoCuarteles { Id_carro = idCarro };
            if(l_cuarteles.ShowDialog() == DialogResult.OK)
            {*/
                try
                {
                    Protocolo frmProtocolo = new Protocolo();
                    foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-10").Tables[0].Rows)
                    {
                        if (row["activo"].ToString() == "ACTIVO")
                        {
                            MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    var cu = new e_carros_usados();
                    cu = cu.getObjecte_carros_usados(idCarro);


                    ////# Validar que han ingresado el 6-0
                    //if (cu.seis != "6-0R")
                    //{
                        BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                                    "6-10");

                        BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                            lblCarro.Text + ": 6-10");

                        //### JSON APOLO EVENTO
                        z_carros carros = new z_carros();
                        JsonServicioClaves jsc = new JsonServicioClaves(carros.id_carro);
                        if (carros.GetParametroPrioridad(6) == "TRUE")
                        {
                            if (cu.id_expediente < 0)
                            {
                                //# Obtener ID de Gestión
                                bitacora_gestion bit_gest = new bitacora_gestion();
                                int idSalidaCarro = bit_gest.SelectIdGestion(cu.id_expediente, lblCarro.Text);
                                var JsSaCl = new JsonSalidaClaves(idCarro);
                                JsSaCl.ApoloHoraCarro(idSalidaCarro, "6-10", idCarro, "", 0, cu.id_expediente);
                            }
                            else
                            {
                                var JsBiCl = new JsonBitacoraClaves(idCarro);
                                JsBiCl.ApoloHoraCarro("6-10", idCarro, "", 0, cu.id_expediente);
                            }

                            //### JSON SERVICIO 1 = 0-9
                            //# Nombre de Conductor

                            //# Objeto Carro
                            var ccarros = new z_carros();
                            ccarros = ccarros.getObjectz_carros(idCarro);
                            string strCarro = ccarros.nombre;
                            string strNomConductor = new z_conductores().Getz_NombreConductor(ccarros.id_conductor).ToString();
                            strNomConductor = strNomConductor.Replace("Ñ", "N");
                            //string strNomConductor = new z_conductores().Getz_NombreConductor(carros.id_conductor).ToString();
                            jsc.JsonServicioHora(idCarro, 1, strNomConductor, "0-9", "Verde", false);
                        }



                        cu.freee_carros_usados(cu.id_carro);
                        Carro.Liberar(idCarro);


                        //### Twitter del 6-10
                        string str610 = lblCarro.Text + "   6-10";
                        //MessageBox.Show(str610, "GEObit");
                        if (carros.GetParametroPrioridad(1) == "TRUE")
                        {
                            System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                            proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                            proceso.StartInfo.Arguments = "1" + " " + str610 + " ";
                            proceso.StartInfo.CreateNoWindow = true;
                            proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            proceso.Start();
                        }


                        //### Borrar Ubicación 6-13, 6-14 o 6-15
                        var carro = new z_carros();
                        carro.SetDestino613(cu.id_carro, "");


                        //### Eliminar Registro en Tabla Bitacora_Gestion_ID
                        if (cu.id_expediente == -1 || cu.id_expediente == -2 || cu.id_expediente == -3)
                        {
                            //# Obtener ID de Gestión
                            bitacora_gestion bit_gest = new bitacora_gestion();
                            int idSalidaCarro = bit_gest.SelectIdGestion(cu.id_expediente, lblCarro.Text);
                            if (idSalidaCarro > 0)
                            {
                                //# Eliminar Registro
                                bit_gest.DeleteIdGestion(idSalidaCarro);
                            }
                        }

                    //}
                    //else
                    //{
                    //    MessageBox.Show("Para este carro no ha ingresado Of. o Vol. a Cargo y Tripulación", "Mensaje de ZEUS");
                    //}

                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            /*}*/
        }


        //### Clave 6-11 ###
        private void tool6_11_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-11").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                cu.seis = "6-11";
                cu.Update(cu);
                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                            "6-11");
                /*MessageBox.Show(
                    "1º Si el carro se dirigía a un llamado, debe despachar otro carro del mismo tipo.\n2º Avisar al Comandante de Guardia.\n3º Avisar al Departamento de Material Mayor.\n4º Avisar al Capitán de la Compañía.",
                    "Protocolo 6-11");*/
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-12 ###
        private void tool6_12_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-12").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                cu.seis = "6-12";
                cu.Update(cu);

                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                            "6-12");
                MessageBox.Show(
                    "1º Si el carro se dirigía a un llamado, debe despachar otro carro del mismo tipo.\n2º Avisar al Comandante de Guardia.\n3º Avisar al Departamento de Material Mayor.\n4º Avisar al Capitán de la Compañía.",
                    "Protocolo 6-12");
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-13 ###
        private void toolStripMenu613_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-13").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                cu.seis = "6-13";
                cu.Update(cu);
                //ZeusWin.Actualizar();

                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                            "6-13: " + ((ToolStripMenuItem)sender).Text);
                //DBNotifyListeners.Notify("despacho");


                //### Publicar en Twitter
                z_carros carros = new z_carros();
                string strSeRetiraA = carros.ObtenerNombreCarro(cu.id_carro) + " 6-13";
                if (carros.GetParametroPrioridad(1) == "TRUE")
                {
                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                    proceso.StartInfo.Arguments = "1" + " " + strSeRetiraA + " ";
                    proceso.StartInfo.CreateNoWindow = true;
                    proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    proceso.Start();
                }


            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-14 ###
        private void tool6_14_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-14").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                cu.seis = "6-14";
                cu.Update(cu);
                //ZeusWin.Actualizar();

                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                            "6-14");
                //DBNotifyListeners.Notify("despacho");


                //### Publicar en Twitter
                z_carros carros = new z_carros();
                string strSeRetiraA = carros.ObtenerNombreCarro(cu.id_carro) + " 6-14";
                if (carros.GetParametroPrioridad(1) == "TRUE")
                {
                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                    proceso.StartInfo.Arguments = "1" + " " + strSeRetiraA + " ";
                    proceso.StartInfo.CreateNoWindow = true;
                    proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    proceso.Start();
                }

            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-15 ###
        private void tool6_15_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-15").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                cu.seis = "6-15";
                cu.Update(cu);
                //ZeusWin.Actualizar();

                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                            "6-15");
                //DBNotifyListeners.Notify("despacho");

                //### Publicar en Twitter
                z_carros carros = new z_carros();
                string strSeRetiraA = carros.ObtenerNombreCarro(cu.id_carro) + " 6-15";
                if (carros.GetParametroPrioridad(1) == "TRUE")
                {
                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                    proceso.StartInfo.Arguments = "1" + " " + strSeRetiraA + " ";
                    proceso.StartInfo.CreateNoWindow = true;
                    proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    proceso.Start();
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-16 ###
        private void tool6_16_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-16").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                cu.seis = "6-16";
                cu.Update(cu);
                //ZeusWin.Actualizar();


                //### Referencia a Carro y Expediente
                var exp = new e_expedientes();
                exp = exp.getObjecte_expedientes(cu.id_expediente);

                //### Publicar en Tw y Agrehar en Bitacora sólo si es el primer 6-7
                if (!(exp.seis16))
                {

                    BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                                "6-16");
                    //DBNotifyListeners.Notify("despacho");

                    //### Publicar en Twitter
                    z_carros carros = new z_carros();
                    string strSeRetiraA = carros.ObtenerNombreCarro(cu.id_carro) + " 6-16";
                    if (carros.GetParametroPrioridad(1) == "TRUE")
                    {
                        System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                        proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                        proceso.StartInfo.Arguments = "1" + " " + strSeRetiraA + " ";
                        proceso.StartInfo.CreateNoWindow = true;
                        proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        proceso.Start();
                    }

                    //# Agregar el 6-16
                    exp.seis16 = true;
                    exp.Update(exp);

                }
                else
                {
                    MessageBox.Show("En esta emergencia ya se ha ingresado el 6-16", "ZEUS");
                }

            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-17 ###
        private void tool6_17_Click(object sender, EventArgs e)
        {
            try
            {
                Protocolo frmProtocolo = new Protocolo();
                foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-17").Tables[0].Rows)
                {
                    if (row["activo"].ToString() == "ACTIVO")
                    {
                        MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                cu.seis = "6-17";
                cu.Update(cu);
                //ZeusWin.Actualizar();

                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                            "6-17");
                //DBNotifyListeners.Notify("despacho");
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnOtro_Click(object sender, EventArgs e)
        {
            cmOtro.Show(btnOtro, 0, btnOtro.Height);
        }

        #endregion

        private void listExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            textEsp.Text = listExp.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);
                if (cu.id_expediente < 0)
                {
                    switch (cu.id_expediente)
                    {
                        case -1:
                            BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                        lblCarro.Text + ": 6-3, Llegada a lugar de ejercicio.");
                            break;
                        case -2:
                            BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                        lblCarro.Text + ": 6-3, Llegada a Servicentro.");
                            break;
                        case -3:
                            BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                        lblCarro.Text + ": 6-3, Llegada a Servicio de Salud.");
                            break;
                        default:
                            break;
                    }
                }
                cu.seis = "6-3";
                cu.Update(cu);
                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro,
                                            "6-3");
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }


        //### Clave 6-14 ###
        private void btn614_Click(object sender, EventArgs e)
        {
            Protocolo frmProtocolo = new Protocolo();
            foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-14").Tables[0].Rows)
            {
                if (row["activo"].ToString() == "ACTIVO")
                {
                    MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Frm614 frm614 = new Frm614(lblCarro.Text, idCarro);
            frm614.ShowDialog();
        }


        //### Clave 6-15 ###
        private void btn615_Click(object sender, EventArgs e)
        {
            Protocolo frmProtocolo = new Protocolo();
            foreach (DataRow row in frmProtocolo.GetProtocoloPorTipo("6-15").Tables[0].Rows)
            {
                if (row["activo"].ToString() == "ACTIVO")
                {
                    MessageBox.Show(row["descripcion"].ToString(), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Frm615 frm615 = new Frm615(lblCarro.Text, idCarro);
            frm615.ShowDialog();
        }


        //### Clave 6-9 y 6-10 Sin Coordenada de Carro ###
        private void btn_69_619_Click(object sender, EventArgs e)
        {
            try
            {
                var cu = new e_carros_usados();
                cu = cu.getObjecte_carros_usados(idCarro);

                cu.seis = "6-9";
                cu.Update(cu);
                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro, "6-9");

                //# Elimina registro en z_carros_llamado
                e_expedientes expediente = new e_expedientes();
                expediente.limpiarRegistroZcarrosLlamado(cu.id_expediente, cu.id_carro);

                BitacoraLlamado.NuevoEvento(cu.id_expediente, cu.id_carro, BitacoraLlamado.Carro, "6-10");

                BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval, lblCarro.Text + ": 6-10");

                MessageBox.Show("Se han asignado las horas de 6-9 y 6-10 al Carro " + lblCarro.Text, "Sistema ZEUS");
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void protocoloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioProtocolos frmProtocolo = new FormularioProtocolos();
            frmProtocolo.ShowDialog();
        }
    }
}