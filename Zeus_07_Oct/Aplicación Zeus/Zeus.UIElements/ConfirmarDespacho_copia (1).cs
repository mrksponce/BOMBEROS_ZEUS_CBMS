using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;
using System.Drawing;
using System.Collections;

namespace Zeus.UIElements
{
    public partial class ConfirmarDespacho : Form
    {
        private bool confirmado;
        private z_carros carros = new z_carros();
        private e_expedientes exp = new e_expedientes();
        private Twitter twitt = new Twitter();

        public ConfirmarDespacho()
        {
            InitializeComponent();
        }

        public List<int> IdCarros { get; set; }
        public int IdExpediente { get; set; }
        public int IdArea { get; set; }
        public int Batallon { get; set; }
        public bool Agregando { get; set; }
        public bool AlarmaGeneral { get; set; }

        private void btnDespachar_Click(object sender, EventArgs e)
        {
            z_carros carros = new z_carros();
            exp = exp.getObjecte_expedientes(IdExpediente);

            DatosLogin.LogPrimerDespacho = false;

            //### Sólo Si es el Primer Despacho, Actualiza la Hora del Expediente.
            if (exp.material_despachado == "")
            {
                exp.ActualizarFechaExpediente(IdExpediente);
                DatosLogin.LogPrimerDespacho = true;
            }

            //### Asigna el Estado NOTEMPORAL a los Carros que se Despacharán.
            for (int a = 0; a < IdCarros.Count; a++)
            {
                carros.actualizarZcarrosLlamadoEspecifico(IdCarros[a], IdExpediente);
            }
            

            if (confirmado)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            try
            {
                if (AlarmaGeneral)
                {
                    Despacho.ConfirmarDespacho(IdCarros, IdExpediente, true);
                }
                else
                {
                    if (Batallon != 0)
                    {
                        Despacho.ConfirmarDespacho(IdCarros, IdExpediente, Batallon);
                    }
                    else
                    {
                        Despacho.ConfirmarDespacho(IdCarros, IdExpediente);
                    }
                }
                confirmado = true;
                btnDespachar.Text = "Cerrar";
                btnAgregar.Enabled = false;
                btnCancelar.Enabled = false;

            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }

            //### Asigna la Hora de 6-0 a los Carros Despachados
            for (int i = 0; i < IdCarros.Count; i++)
            {
                BitacoraLlamado.NuevoEvento(exp.id_expediente, IdCarros[i],
                                                    BitacoraLlamado.Carro,
                                                    "6-0");
            }
            string CDString = "";
            string CDStringFinal = "";
            for (int x = 0; x < IdCarros.Count; x++)
            {
                CDString += carros.ObtenerNombreCarro(IdCarros[x]) + ",";
            }
            CDString += "#";
            CDStringFinal = CDString.Replace(",#", "");
            int TipoTw = 2; //### Para Despachos debe ser Valor 2

            // #Publicar en Twitter#
            // #Alexy2411#
            //if (CDStringFinal != "#")
            //{
            //    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
            //    proceso.StartInfo.FileName = @"C:\comander\app_twitter\App_Twitter_Mod.exe";
            //    proceso.StartInfo.Arguments = TipoTw.ToString() + " " + IdExpediente.ToString() + " " + DatosLogin.InvokeTwitter.ToString() + " " + CDStringFinal;
            //    proceso.Start();
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
                // Se debe hacer una limpieza de los carros al momento de cerrar la ventana, cosa de que cuando se habra n veses, estos siempre se inserten o se borren
                // esto evita que el tema de la resta falle siempre, al momento de confirmar el despacho los registros no pueden ser borrados.
                
                for (int i = 0; i < IdCarros.Count; i++)
                {
                    carros.eliminarZcarrosLlamadoEspecifico(IdCarros[i], IdExpediente);
                }

                DialogResult = DialogResult.Cancel;
                Close();
        }

        private void ConfirmarDespacho_Load(object sender, EventArgs e)
        {
            try
            {
                // cargar datos
                var exp = new e_expedientes();
                exp = exp.getObjecte_expedientes(IdExpediente);
                var llam = new z_llamados();
                llam = llam.getObjectz_llamados(exp.codigo_llamado);
                // formatear texto
                lblClave.Text = "";
                // batallon?
                if (Batallon != 0)
                {
                    switch (Batallon)
                    {
                        case 1:
#if CBMS
                            lblClave.Text = "Sale Primer Batallón de Incendio.\n";
#elif CBQN
                            lblClave.Text = "Sale Incendio.\n";
#endif
                            break;
                        case 2:
#if CBMS
                            lblClave.Text = "Sale Segundo Batallón de Incendio.\n";
#elif CBQN
                            lblClave.Text = "Sale Alarma General.\n";
#endif
                            break;
                        case 3:
                            lblClave.Text = "Sale Tercer Batallón de Incendio.\n";
                            break;
                        case 4:
                            lblClave.Text = "Sale Cuarto Batallón de Incendio.\n";
                            break;
                    }
                }
                if (AlarmaGeneral)
                {
#if CBMS
                    // TODO: poner texto para alarma
#elif CBQN
                    lblClave.Text = "Sale Alarma General.\n";
#endif
                }
                if (Agregando)
                {
                    tableLayoutPanel1.SetRow(lblArea, 4);
                    tableLayoutPanel1.SetRow(lbl05, 3);
                    tableLayoutPanel1.SetRow(lblClave, 2);
                    tableLayoutPanel1.SetRow(tableCarros, 1);
                    tableLayoutPanel1.SetRow(lblExtra, 0);
                    lblExtra.Text = "Sale:";
                    lblClave.Text = "A: ";
                }

                lblClave.Text += llam.clave; // +" " + llam.descripcion;
                lbl05.Text = ToLower(exp.seis2 + " Y " + exp.cero5);
                lblArea.Text = "Área de Referencia " + exp.id_area;
                MostrarCarros(exp.codigo_principal);

#if CBMS
                // consola
                axShockwaveFlash1.LoadMovie(0, Application.StartupPath + "\\Consola\\Consola.swf");
#elif CBQN
                int width = axShockwaveFlash1.Width;
                axShockwaveFlash1.Dispose();
                Width-=width;
#endif
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private static string ToLower(string s)
        {
            // la primera mayuscula y el resto minusculas
            string[] str = s.Split(' ');
            string ret = "";
            foreach (string st in str)
            {
                string temp;
                ret += " ";
                if (st.Length == 1)
                {
                    temp = st.ToLower();
                }
                else
                {
                    temp = st.Substring(0, 1).ToUpper() + st.Substring(1).ToLower();
                }
                ret += temp;
            }
            return ret.Trim();
        }

        private void MostrarCarros(int codigo_principal)
        {
            //-*- Asigna el ID de carro Cascada para pintar Amarillo.
            string val = "";

            //-*- Asigna el ID de Bomba que Alimenta Mecanica para pintar Rojo.
            string val2 = "";

            ArrayList arrGrupoCarros = new ArrayList();
            arrGrupoCarros = StaticClass.ArrGrupoCarros;
            
            //-*- Para Ordenar los Carros
            List<z_carros>[] lista = OrdenarCarros();

            // HACK: 10-3 y 10-4 muestran R al inicio
            if ((codigo_principal == 5 || codigo_principal == 4) && Batallon == 0)
            {
                // insertar R al principio
                List<z_carros> l = lista[6];
                for (int i = 6; i > 0; i--)
                {
                    lista[i] = lista[i - 1];
                }
                lista[0] = l;
            }

            //-*- Pinta Color Amarillo Carros Con Cascada
            // 12 => H como Cascada
            // 20 => RH1 como Cascada
            // 21 => BX como Cascada
            // 22 => B como Cascada
            for (int a = 0; a < arrGrupoCarros.Count; a++)
            {
                string[] aaa = arrGrupoCarros[a].ToString().Split('/');
                if (aaa[1].ToString() == "12" || aaa[1].ToString() == "20" || aaa[1].ToString() == "21" || aaa[1].ToString() == "22")
                {
                    val = aaa[0];
                }
            }

            // mostrar
            tableCarros.Controls.Clear();
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i] != null)
                {
                    var fl = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Fill };
                    foreach (z_carros c in lista[i])
                    {
                        if (c.id_carro.ToString() == val)
                        {
                            var cb = new CheckBox
                            {
                                Text = c.nombre,
                                AutoSize = true,
                                Appearance = Appearance.Button,
                                Tag = c.id_carro,
                                Checked = true,
                                BackColor = Color.Yellow
                            };
                            cb.CheckedChanged += cb_CheckedChanged;
                            fl.Controls.Add(cb);
                        }
                        else
                        {
                            var cb = new CheckBox
                            {
                                Text = c.nombre,
                                AutoSize = true,
                                Appearance = Appearance.Button,
                                Tag = c.id_carro,
                                Checked = true
                            };
                            cb.CheckedChanged += cb_CheckedChanged;
                            fl.Controls.Add(cb);
                        }
                    }
                    tableCarros.Controls.Add(fl);
                }
            }
            StaticClass.ArrGrupoCarros = new ArrayList();
        }

        private List<z_carros>[] OrdenarCarros()
        {
            int largo = new z_tipo_carro().getCantidad();
            var lista = new List<z_carros>[largo];
            var carro = new z_carros();

            // clasificar por tipo
            foreach (int i in IdCarros)
            {
                carro = carro.getObjectz_carros(i);
                int resto = carro.id_tipo_carro - 1;
                if (lista[resto] == null)
                {
                    lista[resto] = new List<z_carros>();
                }
                lista[resto].Add(carro);
            }

            // dejar el primero al frente, ordenar el resto por compañia ( *Deshabilitado )
            foreach (List<z_carros> l in lista)
            {
                if (l != null)
                {
                    //l.Sort(1, l.Count - 1, new z_carroComparer());
                }
            }
            
            return lista;
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            if (c != null)
            {
                int index = (c.Parent).Controls.GetChildIndex(c);

                if (c.Checked)
                {
                    // agregar el carro
                    IdCarros[index] = (int)c.Tag;
                }
                else
                {
                    // eliminar el carro
                    // MRKSPONCE: ELIMINAR CARROS DE LA LISTA.
                    Carro.Liberar((int)c.Tag);
                    z_carros carrosDelete = new z_carros();
                    carrosDelete.eliminarZcarrosLlamadoEspecifico((int)c.Tag, IdExpediente);
                    IdCarros.Remove((int)c.Tag);
                    (c.Parent).Controls.Remove((Control)sender);
                    ((Control)sender).Dispose();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var sc = new SolicitudCarros { Id_area = IdArea, IdCarros = IdCarros, Id_expediente = IdExpediente };
            sc.ShowDialog();
            MostrarCarros(0);
        }

        private void ConfirmarDespacho_FormClosed(object sender, FormClosedEventArgs e)
        {
            axShockwaveFlash1.Dispose();
            if (!confirmado)
            {
                // cancelar
                Despacho.CancelarDespacho(IdCarros);
            }
        }

        private void ConfirmarDespacho_Shown(object sender, EventArgs e)
        {
            // agregando
            if (Agregando)
            {
                btnAgregar_Click(btnAgregar, new EventArgs());
            }
        }

        private void tableLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Height = tableLayoutPanel1.Height + 25;
            if (tableLayoutPanel1.Height > Height - 150)
            {
                Height = tableLayoutPanel1.Height + 160;
            }
            lblSinDesp.Top = groupBox1.Bottom + 10;
        }

        #region Nested type: z_carroComparer

        private class z_carroComparer : IComparer<z_carros>
        {
            #region IComparer<z_carros> Members

            public int Compare(z_carros x, z_carros y)
            {
                return x.id_compania.CompareTo(y.id_compania);
            }

            #endregion
        }

        #endregion
    }
}