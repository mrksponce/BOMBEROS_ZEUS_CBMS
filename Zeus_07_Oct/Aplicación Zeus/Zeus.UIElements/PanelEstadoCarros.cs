using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;
using Zeus.Interfaces;

namespace Zeus.UIElements
{
    public partial class PanelEstadoCarros : BaseControl
    {
        public static int IdCarro { get; set; }
        public PanelEstadoCarros()
        {
            InitializeComponent();
        }

        public void OnUpdateCarroHandler(object sender, ListenerEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("onUpdateCarroHandler");
            if (e.Event == "z_carros")
            {
                if (InvokeRequired)
                {
                    Invoke(new TCargarCarros(OnActualizar));
                }
                else
                {
                    OnActualizar();
                }
            }
        }

        private void PanelEstadoCarros_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (RecursosEstaticos.PrimeraCarga == 1)
                {
                    CargaInicial();
                    RecursosEstaticos.PrimeraCarga = 0;
                }
                else
                {
                    CargarCarros();
                }
                //Alternativos();
                tableLayoutPanel1.RowCount++;
                //tableLayoutPanel1.Controls.Add(groupBox1, 1, tableLayoutPanel1.RowCount);
                //tableLayoutPanel1.SetColumnSpan(groupBox1, 4);
            }

            //### Actualizar CHECK
            z_carros carro = new z_carros();

            //Twitter
            if (carro.GetParametroPrioridad(1) == "TRUE")
            {
                btnTwitter.Text = "Con Twitter";
                btnTwitter.Checked = true;
                btnTwitter.BackColor = Color.MediumBlue;
            }
            else
            {
                btnTwitter.Text = "Sin Twitter";
                btnTwitter.Checked = false;
                btnTwitter.BackColor = Color.OrangeRed;
            }

            //Central 132 o VIPER
            if (carro.GetParametroPrioridad(2) == "TRUE")
            {
                btnCentral132.Text = "Con Viper";
                btnCentral132.Checked = true;
                btnCentral132.BackColor = Color.MediumBlue;
            }
            else
            {
                btnCentral132.Text = "Sin Viper";
                btnCentral132.Checked = false;
                btnCentral132.BackColor = Color.OrangeRed;
            }

            //Tonos
            if (carro.GetParametroPrioridad(3) == "TRUE")
            {
                btnTonos.Text = "Con Tonos";
                btnTonos.Checked = true;
                btnTonos.BackColor = Color.MediumBlue;
            }
            else
            {
                btnTonos.Text = "Sin Tonos";
                btnTonos.Checked = false;
                btnTonos.BackColor = Color.OrangeRed;
            }

            //SGAS
            if (carro.GetParametroPrioridad(4) == "TRUE")
            {
                btnSgas.Text = "Con SGAS";
                btnSgas.Checked = true;
                btnSgas.BackColor = Color.MediumBlue;
            }
            else
            {
                btnSgas.Text = "Sin SGAS";
                btnSgas.Checked = false;
                btnSgas.BackColor = Color.OrangeRed;
            }

            //TwitterLogin
            if (carro.GetParametroPrioridad(5) == "TRUE")
            {
                btnOperadora.Text = "Con TwLogin";
                btnOperadora.Checked = true;
                btnOperadora.BackColor = Color.MediumBlue;
            }
            else
            {
                btnOperadora.Text = "Sin TwLogin";
                btnOperadora.Checked = false;
                btnOperadora.BackColor = Color.OrangeRed;
            }

        }

        private void OnActualizar()
        {
            //if (RecursosEstaticos.PrimeraCarga == 1)
            //{
            //    CargaInicial();
            //    RecursosEstaticos.PrimeraCarga = 0;
            //}
            //else
            //{
            //    CargarCarros();
            //}
            ////Alternativos();
            //tableLayoutPanel1.RowCount++;
            ////tableLayoutPanel1.Controls.Add(groupBox1, 1, tableLayoutPanel1.RowCount);
            ////tableLayoutPanel1.SetColumnSpan(groupBox1, 4);


            //### Marcos
            CargarCarros();
            //Alternativos();
            tableLayoutPanel1.RowCount++;
            //tableLayoutPanel1.Controls.Add(groupBox1, 1, tableLayoutPanel1.RowCount);
            //tableLayoutPanel1.SetColumnSpan(groupBox1, 4);




        }

        private void CargarCarros()
        {
            //MessageBox.Show("1");
            try
            {
                //SuspendLayout();
                //tableLayoutPanel1.SuspendLayout();
                //tableLayoutPanel1.Controls.Clear();
                var carro = new z_carros();

                var tipo = new z_tipo_carro();
                int valor1 = 0;
                int valor2 = 0;
                //tableLayoutPanel1.ColumnCount = carro.GetMaxCarros() + 1;

                //tableLayoutPanel1.RowCount = tipo.getCantidad();

                // cargar tipos de carro y ponerlos

                DataSet ds = tipo.Getz_tipo_carro();
                DataRow[] dr = ds.Tables[0].Select("", "orden");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    DataSet dc = carro.GetCarrosTipo((int)dr[i]["id_tipo_carro"]);

                    if (dc.Tables[0].Rows.Count > 0)
                    {
                        if (RecursosEstaticos.PrimeraCarga == 1)
                        {
                            var lbl = new Label
                            {
                                Text = ((string)dr[i]["tipo_carro_letra"]),
                                Font = new Font(new FontFamily("Arial"), 12),
                                Size = new Size(45, 40),
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            tableLayoutPanel1.Controls.Add(lbl, i, 0);
                        }

                        // carros

                        for (int j = 0; j < dc.Tables[0].Rows.Count; j++)
                        {
                            //if (((int)dc.Tables[0].Rows[j]["estado"]) == carro.GetEstadoCarros(((int)dc.Tables[0].Rows[j]["id_carro"])))
                            if (1 == 2)
                            {
                                // No hay operación porque el carro esta identico
                                string mensaje = "IDENTICO!!";
                            }
                            else
                            {
                                //Control[] control_table;
                                string nombre = ((string)dc.Tables[0].Rows[j]["nombre"]);
                                //control_table = tableLayoutPanel1.Controls.Find("c_" + ((string)dc.Tables[0].Rows[j]["nombre"]), true);
                                //Button btn_table = control_table[0] as Button;

                                foreach (Control c in tableLayoutPanel1.Controls)
                                {
                                    if (c is Button)
                                    {
                                        var est2 = c;
                                        //est2.Text = ((string)dc.Tables[0].Rows[j]["nombre"]);
                                        //Control[] ctrl2;
                                        //ctrl2 = est2.Controls.Find("c_" + ((string)dc.Tables[0].Rows[j]["nombre"]), true);

                                        if (est2.Text.Equals(nombre))
                                        {
                                            //MessageBox.Show(((int)dc.Tables[0].Rows[j]["estado"]).ToString() + "-" + ((int)dc.Tables[0].Rows[j]["id_carro"]).ToString() + "-" + est2.Text);
                                            switch ((int)dc.Tables[0].Rows[j]["estado"])
                                            {
                                                case 1:
                                                    est2.BackColor = Color.PaleGreen;
                                                    break;
                                                case 2:
                                                    est2.BackColor = Color.Tomato;
                                                    break;
                                                case 3:
                                                    est2.BackColor = Color.Yellow;
                                                    break;
                                                case 4:
                                                case 5:
                                                    est2.BackColor = Color.LightBlue;
                                                    break;
                                                default:
                                                    break;
                                            }

                                            // MessageBox.Show(((int)dc.Tables[0].Rows[j]["estado"]).ToString() + "-" + ((int)dc.Tables[0].Rows[j]["id_carro"]).ToString());

                                            carro.ActualizarEstadosCarros(((int)dc.Tables[0].Rows[j]["estado"]), ((int)dc.Tables[0].Rows[j]["id_carro"]));

                                            /*valor1 = tableLayoutPanel1.GetCellPosition(est2).Column;
                                            valor2 = tableLayoutPanel1.GetCellPosition(est2).Row;
                                            tableLayoutPanel1.Controls.Remove(est2);*/
                                        }
                                    }
                                }

                                /*var est = new BtnEstadoCarro
                                {
                                    Id_carro = ((int)dc.Tables[0].Rows[j]["id_carro"]),
                                    Estado = ((int)dc.Tables[0].Rows[j]["estado"]),
                                    Text = ((string)dc.Tables[0].Rows[j]["nombre"]),
                                    ZeusWin = ZeusWin
                                };

                                Control[] ctrl;
                                Random r = new Random();
                                ctrl = est.Controls.Find("c_" + ((string)dc.Tables[0].Rows[j]["nombre"]), true);
                                
                                Button btn_evento = ctrl[0] as Button;
                                btn_evento.Name = "btn_" + System.DateTime.Now.ToString("yyyyMMddHHmmssFFF");
                                btn_evento.Click += new EventHandler(btn_evento_Click);

                                tableLayoutPanel1.Controls.Add(est, valor1, valor2);*/
                                //carro.ActualizarEstadosCarros(((int)dc.Tables[0].Rows[j]["estado"]), ((int)dc.Tables[0].Rows[j]["id_carro"]));
                            }

                        }
                    }

                }
                tableLayoutPanel1.ResumeLayout();
                ResumeLayout();
            }
            catch (Exception exe)
            {
                MessageBox.Show("Exception: " + exe.Message);
            }




        }

        private void CargaInicial()
        {
            try
            {
                int valor1 = 0;
                int valor2 = 0;
                int resto = 0;
                SuspendLayout();
                tableLayoutPanel1.SuspendLayout();
                tableLayoutPanel1.Controls.Clear();
                var carro = new z_carros();

                var tipo = new z_tipo_carro();

                tableLayoutPanel1.ColumnCount = carro.GetMaxCarros() + 1;

                tableLayoutPanel1.RowCount = tipo.getCantidad();

                // cargar tipos de carro y ponerlos

                DataSet ds = tipo.Getz_tipo_carro();
                DataRow[] dr = ds.Tables[0].Select("", "orden");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    DataSet dc = carro.GetCarrosTipo((int)dr[i]["id_tipo_carro"]);

                    if (dc.Tables[0].Rows.Count > 0)
                    {

                        var lbl = new Label
                        {
                            Text = ((string)dr[i]["tipo_carro_letra"]),
                            Font = new Font(new FontFamily("Arial"), 12),
                            Size = new Size(45, 40),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        tableLayoutPanel1.Controls.Add(lbl, i, 0);

                        // carros

                        for (int j = 0; j < dc.Tables[0].Rows.Count; j++)
                        {
                            /*var est = new BtnEstadoCarro
                            {
                                Id_carro = ((int)dc.Tables[0].Rows[j]["id_carro"]),
                                Estado = ((int)dc.Tables[0].Rows[j]["estado"]),
                                Text = ((string)dc.Tables[0].Rows[j]["nombre"]),
                                ZeusWin = ZeusWin
                            };*/

                            Button boton = new Button();
                            boton.Name = Guid.NewGuid().ToString();
                            Size size = new Size(61, 25);
                            boton.Size = size;
                            boton.Text = ((string)dc.Tables[0].Rows[j]["nombre"]);
                            boton.Click += new EventHandler(btn_evento_Click);

                            switch (((int)dc.Tables[0].Rows[j]["estado"]))
                            {
                                case 1:
                                    boton.BackColor = Color.PaleGreen;
                                    break;
                                case 2:
                                    boton.BackColor = Color.Tomato;
                                    break;
                                case 3:
                                    boton.BackColor = Color.Yellow;
                                    break;
                                case 4:
                                case 5:
                                    boton.BackColor = Color.LightBlue;
                                    break;
                                default:
                                    break;
                            }

                            /*Control[] ctrl;
                            Random r = new Random();
                            ctrl = est.Controls.Find("c_" + ((string)dc.Tables[0].Rows[j]["nombre"]), true);
                            Button btn_evento = ctrl[0] as Button;
                            btn_evento.Name = "btn_" + System.DateTime.Now.ToString("yyyyMMddHHmmssFFF");
                            btn_evento.Click += new EventHandler(btn_evento_Click);*/
                            tableLayoutPanel1.Controls.Add(boton, i, j + 1);
                        }
                    }

                }
                tableLayoutPanel1.ResumeLayout();
                ResumeLayout();
            }
            catch (Exception exe)
            {
                MessageBox.Show("Exception: " + exe.Message);
            }
        }

        void btn_evento_Click(object sender, EventArgs e)
        {
            try
            {
                ControlCollection coleccionControles = splitContainer1.Panel2.Controls;

                if (coleccionControles.Count > 0)
                {
                    foreach (Control control2 in coleccionControles)
                    {
                        if (control2 is ucEst)
                        {
                            Button btn_sender = sender as Button;
                            ucEst pa = control2 as ucEst;
                            pa.NombreCarro = btn_sender.Text;
                            RecursosEstaticos.NombreCarro = btn_sender.Text;

                            Control[] control;
                            control = pa.Controls.Find("label1", true);
                            Label lbl = control[0] as Label;
                            lbl.Text = btn_sender.Text;
                            pa.LlenarControles();
                            CargarCarros();
                        }
                    }
                }
                else
                {
                    Button btn_sender = sender as Button;

                    ucEst est = new ucEst();
                    est.Name = Guid.NewGuid().ToString();
                    est.NombreCarro = btn_sender.Text;

                    RecursosEstaticos.NombreCarro = btn_sender.Text;

                    Control[] control;
                    control = est.Controls.Find("label1", true);
                    Label lbl = control[0] as Label;
                    lbl.Text = btn_sender.Text;
                    splitContainer1.Panel2.Controls.Add(est);
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show("Exception: " + exe.Message);
            }
        }



        //private void Alternativos()
        //{
        //    var carro = new z_carros();
        //    DataSet ds = carro.Getz_carros();
        //    listView1.Items.Clear();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        if ((int) dr["id_tipo_alternativo"] != 0)
        //        {
        //            var li = new ListViewItem((string) dr["nombre"]);
        //            li.SubItems.Add((string) ds.Tables[0].Select("id_carro=" + dr["id_tipo_alternativo"])[0]["nombre"]);
        //            li.Tag = (int) dr["id_carro"];
        //            listView1.Items.Add(li);
        //        }
        //    }
        //}

        private void btnServicio_Click(object sender, EventArgs e)
        {
#if CBQN
            //MessageBox.Show("Este módulo no se encuentra disponible en esta versión del Sistema Zeus",
            //                "Módulo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);



#else
            PuestaServicio ps = new PuestaServicio();
            ps.IZeusWin = this.ZeusWin;
            ps.ShowDialog();
            CargarCarros();
#endif
        }

        #region Nested type: TCargarCarros

        private delegate void TCargarCarros();

        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            /*((Form) Parent).Close();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*_011_CubrirCuartel cuartel = new _011_CubrirCuartel();
            PanelEstadoCarros pec = new PanelEstadoCarros();
            if (cuartel.ShowDialog() == DialogResult.OK)
            {
                DBNotifyListeners.RegisterListener(pec.OnUpdateCarroHandler);
            }*/
        }

        private void btnServicio_Click_1(object sender, EventArgs e)
        {

        }

        private void toolMódulos_Click(object sender, EventArgs e)
        {
            
        }

        private void toolModulos3_Click(object sender, EventArgs e)
        {
            _011_CubrirCuartel cuartel = new _011_CubrirCuartel();
            PanelEstadoCarros pec = new PanelEstadoCarros();
            if (cuartel.ShowDialog() == DialogResult.OK)
            {
                DBNotifyListeners.RegisterListener(pec.OnUpdateCarroHandler);   //### No Estaba Comentado CBPA
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //((Form)Parent).Close();
            EntregaDeTurno et = new EntregaDeTurno();
            //ps.IZeusWin = this.ZeusWin;
            et.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Este módulo no se encuentra disponible en esta versión del Sistema Zeus",
            //               "Módulo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            //### Cerrar Material Mayor
            RecursosEstaticos.PrimeraCarga = 1;
            ((Form)Parent).Close();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            LiberarConductores lc = new LiberarConductores();
            //ps.IZeusWin = this.ZeusWin;
            lc.ShowDialog();
        }

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            if (ZeusWin.TipoOperadora == TipoOperadora.Administrador)
            {
                z_carros carros = new z_carros();
                if (btnTwitter.Checked == true)
                {
                    carros.UpdateParametroPrioridad("TRUE", 1);
                    btnTwitter.Text = "Con Twitter";
                    btnTwitter.Checked = true;
                    btnTwitter.BackColor = Color.MediumBlue;
                }
                else
                {
                    carros.UpdateParametroPrioridad("FALSE", 1);
                    btnTwitter.Text = "Sin Twitter";
                    btnTwitter.Checked = false;
                    btnTwitter.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                MessageBox.Show("Sólo puede ser modificado por el Administrador",
                                "Sistema ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTonos_Click(object sender, EventArgs e)
        {
            if (ZeusWin.TipoOperadora == TipoOperadora.Administrador)
            {
                z_carros carros = new z_carros();
                if (btnTonos.Checked == true)
                {
                    carros.UpdateParametroPrioridad("TRUE", 3);
                    btnTonos.Text = "Con Tonos";
                    btnTonos.Checked = true;
                    btnTonos.BackColor = Color.MediumBlue;
                }
                else
                {
                    carros.UpdateParametroPrioridad("FALSE", 3);
                    btnTonos.Text = "Sin Tonos";
                    btnTonos.Checked = false;
                    btnTonos.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                MessageBox.Show("Sólo puede ser modificado por el Administrador",
                                "Sistema ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCentral132_Click(object sender, EventArgs e)
        {
            if (ZeusWin.TipoOperadora == TipoOperadora.Administrador)
            {
                z_carros carros = new z_carros();
                if (btnCentral132.Checked == true)
                {
                    carros.UpdateParametroPrioridad("TRUE", 2);
                    btnCentral132.Text = "Con viper";
                    btnCentral132.Checked = true;
                    btnCentral132.BackColor = Color.MediumBlue;

                }
                else
                {
                    carros.UpdateParametroPrioridad("FALSE", 2);
                    btnCentral132.Text = "Sin viper";
                    btnCentral132.Checked = false;
                    btnCentral132.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                MessageBox.Show("Sólo puede ser modificado por el Administrador",
                                "Sistema ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSgas_Click(object sender, EventArgs e)
        {
            if (ZeusWin.TipoOperadora == TipoOperadora.Administrador)
            {
                z_carros carros = new z_carros();
                if (btnSgas.Checked == true)
                {
                    carros.UpdateParametroPrioridad("TRUE", 4);
                    btnSgas.Text = "Con SGAS";
                    btnSgas.Checked = true;
                    btnSgas.BackColor = Color.MediumBlue;

                }
                else
                {
                    carros.UpdateParametroPrioridad("FALSE", 4);
                    btnSgas.Text = "Sin SGAS";
                    btnSgas.Checked = false;
                    btnSgas.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                MessageBox.Show("Sólo puede ser modificado por el Administrador",
                                "Sistema ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOperadora_Click(object sender, EventArgs e)
        {
            if (ZeusWin.TipoOperadora == TipoOperadora.Administrador)
            {
                z_carros carros = new z_carros();
                if (btnOperadora.Checked == true)
                {
                    carros.UpdateParametroPrioridad("TRUE", 5);
                    btnOperadora.Text = "Con TwLogin";
                    btnOperadora.Checked = true;
                    btnOperadora.BackColor = Color.MediumBlue;

                }
                else
                {
                    carros.UpdateParametroPrioridad("FALSE", 5);
                    btnOperadora.Text = "Sin TwLogin";
                    btnOperadora.Checked = false;
                    btnOperadora.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                MessageBox.Show("Sólo puede ser modificado por el Administrador",
                                "Sistema ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}