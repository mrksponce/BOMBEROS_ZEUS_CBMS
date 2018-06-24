using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.UIElements.Properties;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminVoluntarios : AdminBase
    {
        //#f
        private string UrlImagen = string.Empty;
        private string Path = string.Empty;
        
        public AdminVoluntarios()
        {
            InitializeComponent();
        }

        private void AdminVoluntarios_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new z_voluntarios().Getz_voluntariosLista();
                listActuales.DisplayMember = "nombre_completo";
                listActuales.ValueMember = "id_voluntario";
                Source = ds.Tables[0];
                comboCompania.DisplayMember = "id_compania";
                comboCompania.ValueMember = "id_compania";
                comboCompania.DataSource = new z_companias().Getz_companias().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Mostrar(int id)
        {
            try
            {
                z_voluntarios vol = new z_voluntarios().getObjectz_voluntarios(id);
                textRut.Text = vol.rut;
                textFechaNac.Text = vol.fecha_nacimiento.ToShortDateString();
                textApellidos.Text = vol.apellidos;
                textNombres.Text = vol.nombres;
                //textSangre.Text = vol.tipo_sangre;
                //textAlergia.Text = vol.alergia;
                //textPadece.Text = vol.padece;
                
                //#f   Comentar estas 3 Lineas
                //Image img = vol.getImagen(id);
                //pictureFoto.Image = img ?? Resources.cbms2;   //cbqn_logo;
                //pictureFoto.ImageLocation = null;

                //#f
                if (System.IO.File.Exists(vol.urlimagen))
                {
                    pictureFoto.ImageLocation = vol.urlimagen == string.Empty ? @"C:\ZEUS\Resources\Voluntarios\comodin.jpg" : vol.urlimagen;
                }
                else
                {
                    pictureFoto.ImageLocation = @"C:\ZEUS\Resources\Voluntarios\comodin.jpg";
                }


                textDireccion.Text = vol.direccion;
                textComuna.Text = vol.comuna;
                textFono.Text = vol.telefono;
                textMovil.Text = vol.celular;
                comboCompania.SelectedValue = vol.id_compania;
                textFechaIng.Text = vol.ingreso.ToShortDateString();
                textNumLlamado.Text = vol.num_llamado.ToString();
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Limpiar()
        {
            textRut.Text = "";
            textFechaNac.Text = "";
            textApellidos.Text = "";
            textNombres.Text = "";
            //textSangre.Text = "";
            //textAlergia.Text = "";
            //textPadece.Text = "";
            pictureFoto.Image = null;
            pictureFoto.ImageLocation = null;

            textDireccion.Text = "";
            textComuna.Text = "";
            textFono.Text = "";
            textMovil.Text = "";
            comboCompania.SelectedIndex = -1;
            textFechaIng.Text = "";
            textNumLlamado.Text = "";
        }

        protected override bool Validar()
        {
            string msg = "La siguiente información falta o tiene formato incorrecto:\n";
            bool ok = true;
            DateTime d;
            int x;

            if (textRut.Text == "")
            {
                msg += "* Rut" + "\n";
                ok = false;
            }
            if (textFechaNac.Text == "" || !DateTime.TryParse(textFechaNac.Text, out d))
            {
                msg += "* Fecha Nacimiento" + "\n";
                ok = false;
            }
            if (textApellidos.Text == "")
            {
                msg += "* Apellidos" + "\n";
                ok = false;
            }
            if (textNombres.Text == "")
            {
                msg += "* Nombres" + "\n";
                ok = false;
            }
            //if (textSangre.Text == "")
            //{
            //    msg += "* Tipo de sangre" + "\n";
            //    ok = false;
            //}
            //if (textAlergia.Text == "")
            //{
            //    msg += "* Alergias" + "\n";
            //    ok = false;
            //}
            //if (textPadece.Text == "")
            //{
            //    msg += "* Voluntario Padece" + "\n";
            //    ok = false;
            //}

            if (textDireccion.Text == "")
            {
                msg += "* Dirección" + "\n";
                ok = false;
            }
            if (textComuna.Text == "")
            {
                msg += "* Comuna" + "\n";
                ok = false;
            }
            if (textFono.Text == "")
            {
                msg += "* Teléfono fijo" + "\n";
                ok = false;
            }
            if (textMovil.Text == "")
            {
                msg += "* Teléfono móvil" + "\n";
                ok = false;
            }

            if (comboCompania.SelectedIndex == -1)
            {
                msg += "* Compañía" + "\n";
                ok = false;
            }
            if (textFechaIng.Text == "" || !DateTime.TryParse(textFechaIng.Text, out d))
            {
                msg += "* Fecha Ingreso" + "\n";
                ok = false;
            }

            if (textNumLlamado.Text == "" || !int.TryParse(textNumLlamado.Text, out x))
            {
                msg += "* Número Llamado" + "\n";
                ok = false;
            }

            if (!ok)
            {
                MessageBox.Show(msg, "Error en validación");
            }
            return ok;
        }

        //#f
        protected override void Insertar()
        {
            try
            {
                var vol = new z_voluntarios
                              {
                                  rut = textRut.Text,
                                  fecha_nacimiento = DateTime.Parse(textFechaNac.Text),
                                  apellidos = textApellidos.Text,
                                  nombres = textNombres.Text,
                                  direccion = textDireccion.Text,
                                  comuna = textComuna.Text,
                                  telefono = textFono.Text,
                                  celular = textMovil.Text,
                                  id_compania = ((int) ((DataRowView) comboCompania.SelectedItem).Row["id_compania"]),
                                  ingreso = DateTime.Parse(textFechaIng.Text),
                                  num_llamado = int.Parse(textNumLlamado.Text),
                                  urlimagen = UrlImagen
                              };

                vol.addz_voluntarios(vol, pictureFoto.ImageLocation);
                Source = vol.Getz_voluntariosLista().Tables[0];
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Actualizar()
        {
            try
            {
                z_voluntarios vol = new z_voluntarios().getObjectz_voluntarios((int) listActuales.SelectedValue);
                vol.rut = textRut.Text;
                vol.fecha_nacimiento = DateTime.Parse(textFechaNac.Text);
                vol.apellidos = textApellidos.Text;
                vol.nombres = textNombres.Text;
                //vol.tipo_sangre = textSangre.Text;
                //vol.alergia = textAlergia.Text;
                //vol.padece = textPadece.Text;
                //pictureFoto.Image = null;

                vol.direccion = textDireccion.Text;
                vol.comuna = textComuna.Text;
                vol.telefono = textFono.Text;
                vol.celular = textMovil.Text;
                vol.id_compania = (int) ((DataRowView) comboCompania.SelectedItem).Row["id_compania"];
                vol.ingreso = DateTime.Parse(textFechaIng.Text);
                vol.num_llamado = int.Parse(textNumLlamado.Text);
                //#f
                vol.urlimagen = UrlImagen;
                //#f
                //vol.modifyz_voluntarios(vol, pictureFoto.ImageLocation);
                vol.modifyz_voluntarios(vol, null);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Eliminar()
        {
            try
            {
                var vol = new z_voluntarios();
                vol.deletez_voluntarios((int) listActuales.SelectedValue);
                Source = vol.Getz_voluntariosLista().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnCambiarFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //#f   pictureFoto.ImageLocation = openFileDialog1.FileName;
                System.IO.FileInfo info = new System.IO.FileInfo(openFileDialog1.FileName);
                long tamano = info.Length;

                if (tamano > 600000)
                {
                    MessageBox.Show("El tamaño de la imagen debe ser inferior a 60 KB.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                pictureFoto.ImageLocation = openFileDialog1.FileName;

                // Construct a bitmap from the button image resource.
                Bitmap bmp1 = new Bitmap(openFileDialog1.FileName);

                //#f
                // Save the image as a GIF.
                UrlImagen = "C:\\ZEUS\\Resources\\Voluntarios\\voluntario_" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
                bmp1.Save(UrlImagen, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void btnFicha_Click(object sender, EventArgs e)
        {
#if CBQN
            MessageBox.Show("Este módulo no se encuentra disponible en esta versión del Sistema Zeus",
                            "Módulo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
            AdminVoluntarioFichaMedica fm = new AdminVoluntarioFichaMedica();
            fm.Id_voluntario = (int)listActuales.SelectedValue;
            fm.ShowDialog();
#endif
        }
    }
}