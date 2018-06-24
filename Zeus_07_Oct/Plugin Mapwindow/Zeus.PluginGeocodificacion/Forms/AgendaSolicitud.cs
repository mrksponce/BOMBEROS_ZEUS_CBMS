using System;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class AgendaSolicitud : Form
    {
        public AgendaSolicitud()
        {
            InitializeComponent();
            Datos = new PostgresDataAccess.DataAccess();
        }

        public AgendaSolicitud(int id_clave)
            : this()
        {
            this.id_clave=id_clave;
            this.Text = "Editar Categoría";
            // cargar
            PostgresDataAccess.Clave[] c = Datos.ObtenerClaves(id_clave);
            textNombre.Text = c[0].Nombre;
            checkRefEspacial.Checked = c[0].Ref_espacial;
            textTabla.Text = c[0].Tabla;
            edit = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (checkRefEspacial.Checked == true)
            {
                // verificar tabla
                if (Datos.TablaExiste(textTabla.Text))
                {
                    //ingresar
                    Ingresar();
                }
                else
                {
                    MessageBox.Show("La tabla especificada no existe.", "Error");
                }
            }
            else
            {
                Ingresar();
            }
        }

        private void Ingresar()
        {
            bool res;
            if (edit)
            {
                res = Datos.ActualizarClave(id_clave, textNombre.Text, checkRefEspacial.Checked, textTabla.Text);
            }
            else
            {
                res = Datos.InsertarClave(textNombre.Text, checkRefEspacial.Checked, textTabla.Text);
            }
            if (res != true)
            {
                MessageBox.Show("Ha ocurrido un error al ingresar la nueva clave.", "Error");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private PostgresDataAccess.DataAccess Datos;
        private bool edit;
        private int id_clave;
    }
}