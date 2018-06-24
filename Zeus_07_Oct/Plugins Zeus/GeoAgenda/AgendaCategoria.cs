using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace GeoAgenda
{
    public partial class AgendaCategoria : Form
    {
        //public AgendaCategoria(int id_subcat, bool edit)
        //    : this(0)
        //{
        //    this.id_subcat=id_subcat;
        //    //KeyValuePair<int, string> k = Datos.ObtenerSubCat(id_subcat);
        //    //textNombre.Text = k.Value;
        //    this.Text = "Editar Subcategoría";
        //    this.edit = true;
        //}

        private bool editar;
        private int id_cat, id_subcat;

        public AgendaCategoria()
        {
            InitializeComponent();
        }

        public int Id_subcat
        {
            get { return id_subcat; }
            set { id_subcat = value; }
        }

        public int Id_cat
        {
            get { return id_cat; }
            set { id_cat = value; }
        }

        //private PostgresDataAccess.DataAccess Datos;

        public bool Editar
        {
            get { return editar; }
            set { editar = value; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    a_agenda_subcat sc = new a_agenda_subcat().getObjecta_agenda_subcat(id_subcat);
                    sc.nombre = textNombre.Text;
                    if (editar)
                    {
                        sc.Update(sc);
                    }
                    else
                    {
                        sc.id_cat = id_cat;
                        sc.Insert(sc);
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    Log.Write(ex);
                    MessageBox.Show("No se pudo completar la operación debido a un error de Base de Datos.",
                                    "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void AgendaCategoria_Load(object sender, EventArgs e)
        {
            if (editar)
            {
                a_agenda_subcat subcat = new a_agenda_subcat().getObjecta_agenda_subcat(id_subcat);
                textNombre.Text = subcat.nombre;
                Text = "Editar subcategoría";
            }
        }
    }
}