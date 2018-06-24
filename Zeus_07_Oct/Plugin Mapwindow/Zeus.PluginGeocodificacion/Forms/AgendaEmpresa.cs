using System;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class AgendaEmpresa : Form
    {
        public AgendaEmpresa(int id_subcat)
        {
            InitializeComponent();
            this.id_subcat = id_subcat;
            Datos = new PostgresDataAccess.DataAccess();

        }

        public AgendaEmpresa(int id_empresa, bool edit)
            : this(0)
        {
            this.id_empresa = id_empresa;
            PostgresDataAccess.Empresa e = Datos.ObtenerEmpresa(id_empresa);
            textNombre.Text = e.Nombre;
            textTelefono.Text = e.Telefono;
            this.edit = true;
        }

        private int id_subcat, id_empresa;
        private PostgresDataAccess.DataAccess Datos;
        private bool edit;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text != "" /*&& int.TryParse(textTelefono.Text, out d) != false*/)
            {
                bool res;
                if (edit)
                {
                    res = Datos.ActualizarEmpresa(id_empresa, textNombre.Text, textTelefono.Text);
                }
                else
                {
                    res = Datos.InsertarEmpresa(id_subcat, textNombre.Text, textTelefono.Text);
                }
                if (res == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al ingresar la nueva Empresa.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar datos válidos", "Error");
            }
        }

    }
}