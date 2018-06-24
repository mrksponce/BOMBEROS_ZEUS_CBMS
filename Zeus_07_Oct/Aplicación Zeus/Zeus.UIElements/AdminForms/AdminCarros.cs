using System;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.UIElements.Properties;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminCarros : AdminBase
    {
        //#f
        private string UrlImagen = string.Empty;
        
        public AdminCarros()
        {
            InitializeComponent();
        }

        private void AdminCarros_Load(object sender, EventArgs e)
        {
            try
            {
                listActuales.DisplayMember = "nombre";
                listActuales.ValueMember = "id_carro";
                //listActuales.DataSource = new z_carros().Getz_carros().Tables[0];
                Source = new z_carros().Getz_carros().Tables[0];
                comboCompañia.DisplayMember = "id_compania";
                comboCompañia.ValueMember = "id_compania";
                comboCompañia.DataSource = new z_companias().Getz_companias().Tables[0];
                comboTipo.DisplayMember = "tipo_carro_letra";
                comboTipo.ValueMember = "id_tipo_carro";
                comboTipo.DataSource = new z_tipo_carro().Getz_tipo_carro().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        //protected override void Mostrar(int id)
        //{
        //    try
        //    {
        //        z_carros carro = new z_carros().getObjectz_carros(id);
        //        textNombre.Text = carro.nombre;
        //        comboTipo.SelectedValue = carro.id_tipo_carro;
        //        comboCompañia.SelectedValue = carro.id_compania_orig;
        //        Image img = carro.getImagen(id);
        //        pictureFoto.Image = img ?? Resources.cbms2;    //cbqn_logo;
        //        pictureFoto.ImageLocation = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.ShowAndLog(ex);
        //    }
        //}

        //#f
        protected override void Mostrar(int id)
        {
            try
            {
                z_carros carro = new z_carros().getObjectz_carros(id);
                textNombre.Text = carro.nombre;
                comboTipo.SelectedValue = carro.id_tipo_carro;
                comboCompañia.SelectedValue = carro.id_compania_orig;

                if (System.IO.File.Exists(carro.urlimagen))
                {
                    pictureFoto.ImageLocation = carro.urlimagen == string.Empty ? @"C:\ZEUS\Resources\Carros\comodin.jpg" : carro.urlimagen;
                }
                else
                {
                    pictureFoto.ImageLocation = @"C:\ZEUS\Resources\Carros\comodin.jpg";
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override bool Validar()
        {
            string msg = "La siguiente información falta o tiene formato incorrecto:\n";
            bool ok = true;
            if (textNombre.Text == "")
            {
                msg += "* Nombre del carro";
                ok = false;
            }
            if (!ok)
            {
                MessageBox.Show(msg, "Error en validación");
            }
            return ok;
        }

        protected override void Insertar()
        {
            try
            {
                var carro = new z_carros { nombre = textNombre.Text, id_compania_orig = (int)comboCompañia.SelectedValue, id_tipo_carro = (int)comboTipo.SelectedValue };
                carro.addz_carros(carro, pictureFoto.ImageLocation);
                carro.estado = 3;
                Source = carro.Getz_carros().Tables[0];
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
                z_carros carro = new z_carros().getObjectz_carros((int) listActuales.SelectedValue);
                carro.nombre = textNombre.Text;
                carro.id_compania_orig = (int) comboCompañia.SelectedValue;
                carro.id_tipo_carro = (int) comboTipo.SelectedValue;
                //#f
                carro.urlimagen = UrlImagen;
                //#f
                //carro.modifyz_carros(carro, pictureFoto.ImageLocation);
                carro.modifyz_carros(carro, null);
                Source = carro.Getz_carros().Tables[0];
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
                var carro = new z_carros();
                carro.deletez_carros((int) listActuales.SelectedValue);
                Source = carro.Getz_carros().Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        protected override void Limpiar()
        {
            textNombre.Text = "";
            comboTipo.SelectedIndex = -1;
            comboCompañia.SelectedIndex = -1;
            pictureFoto.ImageLocation = null;
            pictureFoto.Image = null;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //pictureFoto.ImageLocation = openFileDialog1.FileName;

                //#f
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

                // Save the image as a GIF.
                UrlImagen = "C:\\ZEUS\\Resources\\Carros\\carro_" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
                bmp1.Save(UrlImagen, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

    }
}