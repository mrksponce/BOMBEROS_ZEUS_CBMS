using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace GeoAgenda
{
    public partial class AgendaSolicitud : Form
    {
        private bool editar;

        private int id_cat;

        public AgendaSolicitud()
        {
            InitializeComponent();
        }

        public bool Editar
        {
            get { return editar; }
            set { editar = value; }
        }

        public int Id_cat
        {
            get { return id_cat; }
            set { id_cat = value; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (checkRefEspacial.Checked)
            {
                // verificar tabla
                if (!CnxBase.tablaExiste(textTabla.Text))
                {
                    MessageBox.Show("La tabla especificada no existe.", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
            }
            if (textNombre.Text == "")
            {
                MessageBox.Show("No ha especificado un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Ingresar();
        }

        private void Ingresar()
        {
            try
            {
                a_agenda_cat cat = new a_agenda_cat().getObjecta_agenda_cat(id_cat);
                cat.nombre = textNombre.Text;
                cat.ref_espacial = checkRefEspacial.Checked;
                cat.tabla = textTabla.Text;
                if (editar)
                {
                    cat.Update(cat);
                }
                else
                {
                    cat.Insert(cat);
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

        private void checkRefEspacial_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRefEspacial.Checked)
            {
                label2.Enabled = true;
                textTabla.Enabled = true;
            }
            else
            {
                label2.Enabled = false;
                textTabla.Enabled = false;
            }
        }

        private void AgendaSolicitud_Load(object sender, EventArgs e)
        {
            if (editar)
            {
                Text = "Editar Categoría";
                a_agenda_cat cat = new a_agenda_cat().getObjecta_agenda_cat(id_cat);
                textNombre.Text = cat.nombre;
                checkRefEspacial.Checked = cat.ref_espacial;
                textTabla.Text = cat.tabla;
            }
        }
    }
}