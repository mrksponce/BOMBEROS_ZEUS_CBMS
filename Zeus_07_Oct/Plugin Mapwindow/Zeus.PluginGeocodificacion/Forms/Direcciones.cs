using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
//using Npgsql;
using PostgresDataAccess;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class Direcciones : Form
    {
        public Direcciones(MapWindow.Interfaces.IMapWin mw)
        {
            InitializeComponent();
            MapWin = mw;
            Datos = new DataAccess();
            geocodificacion = new /*Geocodificacion.*/Geocodificacion();

            // leer comunas
            Comunas = Datos.ObtenerComunas();
            ComunasCuerpo = Datos.ObtenerComunasCuerpo();
            CallesSinComuna = Datos.ObtenerCallesSinComuna();
            //CallesCuerpo = new List<string>();
            // calles con comuna
            //foreach (string s in ComunasCuerpo)
            //{
            //    CallesCuerpo.AddRange(Datos.ObtenerCallesConComuna(s));
            //}
            CallesCuerpo = Datos.ObtenerCallesCuerpo();
            
            comboComuna.Items.AddRange(ComunasCuerpo.ToArray());
        }

        private void checkAltura_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAltura.Checked == true)
            {
                // activar altura
                textAltura.Enabled = true;
                label2.Enabled = true;
                // desactivar esquina
                textEsquina.Enabled = false;
                listEsquinas.Enabled = false;
            }
            else
            {
                // desactivar altura
                textAltura.Enabled = false;
                textAltura.Text = "";
                label2.Enabled = false;
                //activar esquina
                textEsquina.Enabled = true;
                listEsquinas.Enabled = true;
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnMostrarCoincidencias_Click(object sender, EventArgs e)
        {
            int Altura = 0;
            /*Geocodificacion.*/GeoReferencia[] gr = null;
            btnMostrarCoincidencias.Blink = false;
            // verificar parámetros

            if (checkAltura.Checked == true)
            {
                if (textAltura.Text=="")
                {
                    MessageBox.Show("Debe ingresar una altura o seleccionar una esquina.", "Faltan parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // verificar calle 1 y altura
                if (listCalles.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una calle antes de proceder.", "Faltan parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!int.TryParse(textAltura.Text, out Altura) || textAltura.Text.Length > 8)
                {
                    MessageBox.Show("Debe ingresar una altura válida.", "Faltan parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                gr = geocodificacion.BuscarAltura(listCalles.SelectedItem.ToString(), Altura);
                this.Cursor = Cursors.Default;
            }
            else
            {
                // verificar ambas calles
                if (listCalles.SelectedIndex == -1 || listEsquinas.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar ambas calles antes de proceder", "Faltan parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // buscar!
                this.Cursor = Cursors.WaitCursor;
                //gr = geocodificacion.BuscarEsquina(listCalles.SelectedItem.ToString(), listEsquinas.SelectedItem.ToString(), checkRM.Checked);
                gr = geocodificacion.BuscarEsquina(listCalles.SelectedItem.ToString(), listEsquinas.SelectedItem.ToString(),comboComuna.SelectedText, checkRM.Checked);

                this.Cursor = Cursors.Default;
            }

            if (gr.Length!=0)
            {
                // filtro por comunas?
                //List<string> com = ComunasCuerpo;
                //if (checkRM.Checked)
                //{
                //    com = null;
                //}
                //if (checkComuna.Checked)
                //{
                //    com = new List<string>();
                //    com.Add(comboComuna.Text);
                //}


                Coincidencias coincidencias = new Coincidencias(gr, MapWin, /*com*/null);
                coincidencias.Location = new Point(this.Location.X + this.Width + 10, this.Location.Y);
                // mostrar y verificar
                DialogResult dr = coincidencias.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    direccion = coincidencias.Direccion;
                    if (direccion.Ubicacion.HasValue)
                    {
                        // calcular geoz
                        direccion.Geoz = Datos.ObtenerGeoz(direccion.Ubicacion.Value.ToString());
                    }
                    else
                    {
                        // borrar anterior
                        direccion.Geoz = "";
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
        }

        private DataAccess Datos;
        private Geocodificacion geocodificacion;
        private List<string> Comunas, ComunasCuerpo, CallesSinComuna, Esquinas, CallesCuerpo;
        private MapWindow.Interfaces.IMapWin MapWin;
        private Direccion direccion;
        private bool _clic = false;

        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private void checkComuna_CheckedChanged(object sender, EventArgs e)
        {
            if (checkComuna.Checked == true)
            {
                comboComuna.Enabled = true;
                //checkRM.Checked = false;
            }
            else
            {
                comboComuna.Enabled = false;
                comboComuna.SelectedIndex = -1;
            }
            
        }

        private void checkRM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRM.Checked == true)
            {
                comboComuna.Items.Clear();
                comboComuna.Items.AddRange(Comunas.ToArray());
            }
            else
            {
                comboComuna.Items.Clear();
                comboComuna.Items.AddRange(ComunasCuerpo.ToArray());
            }
        }

        private void textPrimeraCalle_TextChanged(object sender, EventArgs e)
        {
            if (textPrimeraCalle.Text == "")
                listCalles.Items.Clear();
            else
            {
                List<string> l;
                listEsquinas.Items.Clear();
                if (Esquinas != null) 
                    Esquinas.Clear();
                textEsquina.Text = "";
                lblCantidadResultados.Text = "0";
                // encontrar coincidencias
                this.Cursor = Cursors.WaitCursor;
                // por comuna
                if (checkComuna.Checked)
                {
                    if (comboComuna.SelectedIndex!=-1)
                    {
                        // buscar por comuna
                        l = Datos.ObtenerCallesConComuna(textPrimeraCalle.Text.ToUpper(), comboComuna.Text);//((List<string>)CallesConComuna[comboComuna.Text]).FindAll(delegate(string s) { return s.Contains(textPrimeraCalle.Text.ToUpper()); });
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una comuna");
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                // 
                else
                {
                    if (checkRM.Checked)
                    {
                        l = CallesSinComuna.FindAll(delegate(string s) { return s.Contains(textPrimeraCalle.Text.ToUpper()); });
                    }
                    else
                    {
                        l = CallesCuerpo.FindAll(delegate(string s) { return s.Contains(textPrimeraCalle.Text.ToUpper()); });
                    }
                }
                listCalles.Items.Clear();
                listCalles.Items.AddRange(l.ToArray());
                this.Cursor = Cursors.Default;
            }
        }

        private void textPrimeraCalle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textEsquina.BackColor = SystemColors.Window;
                textPrimeraCalle.BackColor = SystemColors.Window;
                textPrimeraCalle_TextChanged(this, new EventArgs());
            }
        }

        private void listCalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // mostrar arriba
            if (listCalles.SelectedIndex != -1)
            {
                checkAltura.Enabled = true;
                textEsquina.Enabled = true;
                textEsquina.BackColor = SystemColors.Window;
                textEsquina.Text = "";
                textPrimeraCalle.BackColor = Color.LightGreen;
                textPrimeraCalle.Text = listCalles.SelectedItem.ToString();
                // buscar esquinas
                this.Cursor = Cursors.WaitCursor;
                List<string> esquina = Datos.ObtenerEsquinas(listCalles.SelectedItem.ToString(),checkRM.Checked, checkComuna.Checked, comboComuna.Text);
                listEsquinas.Items.Clear();
                listEsquinas.Items.AddRange(esquina.ToArray());
                listEsquinas.SelectedIndex = -1;
                lblCantidadResultados.Text = esquina.Count.ToString();
                Esquinas = esquina;
                
                this.Cursor = Cursors.Default;
            }
            else
            {
                textPrimeraCalle.BackColor = SystemColors.Window;
            }
        }

        private void listEsquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // mostrar arriba
            if (listEsquinas.SelectedIndex != -1)
            {
                textEsquina.BackColor = Color.LightGreen;
                _clic = true;
                textEsquina.Text = listEsquinas.SelectedItem.ToString();
                btnMostrarCoincidencias.Blink = true;
            }
            else
            {
                textEsquina.BackColor = SystemColors.Window;
            }
        }

        private void textEsquina_TextChanged(object sender, EventArgs e)
        {
            //listCalles.Items.Clear();
            //textEsquina.Text = "";
            //lblCantidadResultados.Text = "0";
            // encontrar coincidencias
            //this.Cursor = Cursors.WaitCursor;
            if (!_clic)
            {
                List<string> l = Esquinas.FindAll(delegate(string s) { return s.Contains(textEsquina.Text.ToUpper()); });
                listEsquinas.Items.Clear();
                listEsquinas.Items.AddRange(l.ToArray());
                this.Cursor = Cursors.Default;
            }
            _clic = false;
        }

        private void Direcciones_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible==true)
            {
                checkComuna.Checked = false;
                checkRM.Checked = false;
                comboComuna.SelectedIndex = -1;
                textPrimeraCalle.BackColor = SystemColors.Window;
                textPrimeraCalle.Text = "";
                listCalles.Items.Clear();
                checkAltura.Checked = false;
                textAltura.Text = "";
                textEsquina.Text = "";
                textEsquina.BackColor = TextBox.DefaultBackColor;
                listEsquinas.Items.Clear();
                lblCantidadResultados.Text = "0";
                checkAltura.Enabled = false;
                textEsquina.Enabled = false;
            }
        }

        private void Direcciones_Load(object sender, EventArgs e)
        {
            textPrimeraCalle.Focus();
        }

        private void textAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                btnMostrarCoincidencias_Click(btnMostrarCoincidencias, new EventArgs());
            }
        }

    }
}