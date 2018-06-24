using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class AgendaCategoria : Form
    {
        public AgendaCategoria(int id_cat)
        {
            InitializeComponent();
            this.id_cat = id_cat;
            Datos = new PostgresDataAccess.DataAccess();
        }

        public AgendaCategoria(int id_subcat, bool edit)
            : this(0)
        {
            this.id_subcat=id_subcat;
            KeyValuePair<int, string> k = Datos.ObtenerSubCat(id_subcat);
            textNombre.Text = k.Value;
            this.Text = "Editar Subcategoría";
            this.edit = true;
        }

        private int id_cat, id_subcat;
        private PostgresDataAccess.DataAccess Datos;
        bool edit;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text=="")
            {
                MessageBox.Show("Debe ingresar un nombre válido", "Error");
            }
            else
            {
                bool res;
                if (edit)
                {
                    res = Datos.ActualizarSubCat(id_subcat, textNombre.Text);
                }
                else
                {
                    res = Datos.InsertarSubCat(id_cat, textNombre.Text);
                }
                if (res == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al ingresar la nueva subcategoría.", "Error");
                }
            }
        }
    }
}