using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class Expediente : Form
    {
        public Expediente()
        {
            InitializeComponent();
            Datos = new PostgresDataAccess.DataAccess();
            // rellenar combos
            ComunasCuerpo = Datos.ObtenerComunasCuerpo();
            Comunas = Datos.ObtenerComunas();
            comboComuna.Items.AddRange(ComunasCuerpo.ToArray());

            // agregar datos desde geocodificacion
            textHora.Text = DateTime.Now.ToString("HH:mm:ss");
            dtFecha.Value = DateTime.Now;
            textDireccion.Text = PlugData.Direccion.Calle1;
            textEsquina.Text = PlugData.Direccion.Calle2;
            if (PlugData.Direccion.Altura != 0)
                textCasa.Text = PlugData.Direccion.Altura.ToString();
            comboComuna.SelectedItem = PlugData.Direccion.Comuna;
            // servicio
            btnClaves.Blink = true;
            int ar_txt = Datos.ObtenerArea(PlugData.Direccion.Ubicacion.ToString());
            label15.Text = ar_txt.ToString() == "0" ? "" : ar_txt.ToString();
        }

        public Expediente(PostgresDataAccess.Expediente exp)
        {
            // rellenar :(
            InitializeComponent();
            Datos = new PostgresDataAccess.DataAccess();
            // rellenar combo
            ComunasCuerpo = Datos.ObtenerComunasCuerpo();
            Comunas = Datos.ObtenerComunas();
            comboComuna.Items.AddRange(Comunas.ToArray());
            checkRM.Checked = true;

            //!!!!!!!!!!!!!!!!!comboServicio.SelectedItem = exp.Servicio;
            textClave.Text = Datos.ObtenerTipoLlamado(exp.Codigo_llamado);
            textClave.Tag = exp.Codigo_llamado;
            textHora.Text = exp.Hora.ToShortTimeString();
            dtFecha.Value = exp.Fecha;
            textDireccion.Text = exp.Seis2;
            comboComuna.SelectedItem = exp.Comuna;
            textEsquina.Text = exp.Cero5;
            textPoblacion.Text = exp.Poblacion_villa;
            textBlock.Text = exp.Block;
            textCasa.Text = exp.Casa;
            textTelefono.Text = exp.Telefono;
            textQuienLlama.Text = exp.Quien_llama;
            comboCompañia.SelectedItem = exp.Compania;
            textDescripcion.Text = exp.Descripcion;
            edicion = true;
            EditExp = exp;
            btnIngresar.Text = "Actualizar";
        }

        private bool Validar()
        {
            // si es exploracion no se valida


            // validar los controles necesarios y su formato!
            //long d = 0;
            DateTime t = new DateTime();
            StringBuilder sb = new StringBuilder("Los datos ingresados contienen los siguientes errores:\n");
            if (textHora.Text == "" || DateTime.TryParse(textHora.Text, out t) == false)
            {
                sb.Append("\n* El formato de la hora no es correcto.");
                MessageBox.Show(sb.ToString(), "Error en parámetros");
                return false;
            }
            if (exploracion)
                return true;

            // datos básicos
            //if (comboServicio.SelectedIndex == -1)
            //{
            //    sb.Append("\n* No ha seleccionado un servicio.");
            //    MessageBox.Show(sb.ToString(), "Error en parámetros");
            //    return false;
            //}

            if (textClave.Text == "")
            {
                sb.Append("\n* No ha seleccionado una clave.");
                MessageBox.Show(sb.ToString(), "Error en parámetros");
                return false;
            }
            // todo: fecha en el futuro??

            // Localización
            if (textDireccion.Text == "")
            {
                sb.Append("\n* No ha ingresado la dirección.");
                MessageBox.Show(sb.ToString(), "Error en parámetros");
                return false;
            }
            if (comboComuna.SelectedIndex == -1)
            {
                sb.Append("\n* No ha seleccionado una comuna.");
                MessageBox.Show(sb.ToString(), "Error en parámetros");
                return false;
            }
            if (textEsquina.Text == "")
            {
                sb.Append("\n* No ha ingresado la esquina de referencia.");
                MessageBox.Show(sb.ToString(), "Error en parámetros");
                return false;
            }
            //// formatos de numeros y telefono
            //if (long.TryParse(textTelefono.Text, out d) == false)
            //{
            //    sb.Append("\n* El formato de teléfono no es correcto.");
            //    MessageBox.Show(sb.ToString(), "Error en parámetros");
            //    return false;
            //}

            //// datos finales
            //if (textQuienLlama.Text == "")
            //{
            //    sb.Append("\n* No ha ingresado datos de quién llama.");
            //    MessageBox.Show(sb.ToString(), "Error en parámetros");
            //    return false;
            //}
            //if (comboCompañia.SelectedIndex == -1)
            //{
            //    sb.Append("\n* No ha seleccionado una compañía.");
            //    MessageBox.Show(sb.ToString(), "Error en parámetros");
            //    return false;
            //}
            //if (textDescripcion.Text == "")
            //{
            //    sb.Append("\n* No ha ingresado una descripción.");
            //    MessageBox.Show(sb.ToString(), "Error en parámetros");
            //    return false;
            //}



            //if (error == true)
            //    MessageBox.Show(sb.ToString(), "Error en parámetros");
            return true;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                
                // hacer lo k hay k hacer :)
                if (Ingresar() != true)
                {
                    MessageBox.Show("ha ocurrido un error al ingresar el nuevo expediente. Inténtelo nuevamente", "Error");
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private PostgresDataAccess.DataAccess Datos;
        private List<string> ComunasCuerpo;
        private List<string> Comunas;
        private bool exploracion = false;
        private bool edicion = false;
        private PostgresDataAccess.Expediente EditExp;
        
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

        //private void comboServicio_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboServicio.SelectedIndex == 0)
        //    {
        //        exploracion = true;
        //        btnRedTic.Enabled = false;
        //    }
        //    else
        //    {
        //        exploracion = false;
        //        btnRedTic.Enabled = true;
        //    }
        //}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private string TextoFormateado(string dato)
        {
            string consignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ";
            string sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC";
            string texto = "";
            for (int v = 0; v < sinsignos.Length; v++)
            {
                string i = consignos.Substring(v, 1);
                string j = sinsignos.Substring(v, 1);
                texto = dato.Replace(i, j);
            }
            return texto;
        }

        private bool Ingresar()
        {
            PostgresDataAccess.Expediente exp = new PostgresDataAccess.Expediente();
            bool res;
            // agregar datos
            exp.Activo = true;
            exp.Block = textBlock.Text;
            exp.Casa = textCasa.Text;
            exp.Cero5 = /*textDireccion.Text + " / " + */TextoFormateado(textEsquina.Text);
            exp.Compania = comboCompañia.SelectedItem == null ? "" : comboCompañia.SelectedItem.ToString();
            exp.Comuna = comboComuna.SelectedItem == null ? "" : comboComuna.SelectedItem.ToString();
            exp.Descripcion = textDescripcion.Text;
            exp.Fecha = dtFecha.Value;
            exp.Hora = DateTime.Parse(textHora.Text);
            exp.Poblacion_villa = textPoblacion.Text;
            exp.Quien_llama = textQuienLlama.Text;
            exp.Seis2 = TextoFormateado(textDireccion.Text);
            //exp.Servicio = comboServicio.SelectedItem == null ? "" : comboServicio.SelectedItem.ToString();
            exp.Codigo_llamado = (int)textClave.Tag;
            exp.Codigo_principal = exp.Codigo_llamado < 100 ? exp.Codigo_llamado : (exp.Codigo_llamado - (exp.Codigo_llamado % 100)) / 100;
            exp.Telefono = textTelefono.Text;
            if (edicion)
            {
                exp.Ubicacion = EditExp.Ubicacion;
                exp.Geoz = EditExp.Geoz;
                exp.Id_area = EditExp.Id_area;
            }
            else
            {
                exp.Ubicacion = PlugData.Direccion.Ubicacion.Value;
                exp.Geoz = Datos.ObtenerGeoz(exp.Ubicacion.ToString());
                exp.Id_area = Datos.ObtenerArea(exp.Ubicacion.ToString());
            }

            this.UseWaitCursor = true;
            if (edicion)
            {
                exp.Id_expediente = EditExp.Id_expediente;
                res = Datos.ActualizarExpediente(exp);
            }
            else
                res = Datos.InsertarExpediente(exp);
            this.UseWaitCursor = false;

            return res;

            /*else
            {
                this.Close();
            }*/
        }

        private void btnRedTic_Click(object sender, EventArgs e)
        {
            // generar string
            StringBuilder sb = new StringBuilder(DatosSGC.RedTicURL + "?");
            sb.Append("id_sgc=" + DatosSGC.IdSGC);
            sb.Append("&servicio=" + textClave.Text);
            sb.Append("&hora=" + DateTime.Parse(textHora.Text).ToString("t", new System.Globalization.CultureInfo("EN-us")).Replace(" ", "").ToLower());
            sb.Append("&fecha=" + dtFecha.Value.ToShortDateString());
            sb.Append("&direccion=" + textDireccion.Text);
            sb.Append("&comuna=" + comboComuna.Text);
            sb.Append("&esqina_ref=" + textEsquina.Text);
            sb.Append("&villa=" + textPoblacion.Text);
            sb.Append("&block=" + textBlock.Text);
            sb.Append("&casa=" + textCasa.Text);
            sb.Append("&telefono=" + textTelefono.Text);
            sb.Append("&quien_llama=" + textQuienLlama.Text);
            sb.Append("&cia_termina=" + ((int)comboCompañia.SelectedIndex + 1).ToString());
            sb.Append("&descripcion=" + textDescripcion.Text);

            HttpWebRequest RedTicReq = (HttpWebRequest)WebRequest.Create(Uri.EscapeUriString(sb.ToString()));
            RedTicReq.Timeout = 30000;
            try
            {
                this.UseWaitCursor = true;
                WebResponse resp = RedTicReq.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();
                resp.Close();
                // tratar
                if (result == "expediente_ok")
                {
                    MessageBox.Show("Expediente enviado a REDTIC.", "Envío Exitoso");
                    btnRedTic.Image = Iconos.success.ToBitmap();
                    btnRedTic.Enabled = false;
                }
                else
                {
                    throw new WebException(result);
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show("El envío ha fallado debido al siguiente error:\n" + ex.Message, "Envío Fallido");
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private void btnEsquina_Click(object sender, EventArgs e)
        {
            if (textDireccion.Text != "")
            {
                Esquinas esq = new Esquinas(textDireccion.Text.ToUpper());
                if (esq.ShowDialog() == DialogResult.OK)
                {
                    textEsquina.Text = esq.Esquina;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre de calle primero.", "Mostrar Esquinas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Text_lostfocus(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t != null)
            {
                t.BackColor = SystemColors.Window;
            }
        }

        private void Text_gotfocus(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t != null)
            {
                t.BackColor = Color.LightGreen;
            }
        }

        private void btnClaves_Click(object sender, EventArgs e)
        {
            Forms.Claves claves = new Claves();
            //claves.StartPosition = FormStartPosition.CenterParent;
            if (claves.ShowDialog() == DialogResult.OK)
            {
                textClave.Text = claves.Clave;
                textClave.Tag = claves.Codigo_llamado;
                btnClaves.Blink = false;
                if (!edicion)
                {
                    btnIngresar.Blink = true;
                }
            }
        }

        private void Expediente_Load(object sender, EventArgs e)
        {
            
        }
    }
}