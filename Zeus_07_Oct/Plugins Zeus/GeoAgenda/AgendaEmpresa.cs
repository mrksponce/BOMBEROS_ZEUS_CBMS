using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace GeoAgenda
{
    public partial class AgendaEmpresa : Form
    {
        private bool editar;
        private int id_empresa;
        private int id_subcat;

        public AgendaEmpresa()
        {
            InitializeComponent();
        }

        public int Id_empresa
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }

        public int Id_subcat
        {
            get { return id_subcat; }
            set { id_subcat = value; }
        }

        //private PostgresDataAccess.DataAccess Datos;

        public bool Editar
        {
            get { return editar; }
            set { editar = value; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text != "" && textTelefono.Text != "")
            {
                try
                {
                    a_agenda_detalle det = new a_agenda_detalle().getObjecta_agenda_detalle(id_empresa);
                    det.nombre = textNombre.Text;
                    det.telefono = textTelefono.Text;

                    if (editar)
                    {
                        det.Update(det);
                    }
                    else
                    {
                        det.id_subcat = id_subcat;
                        det.Insert(det);
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
            else
            {
                MessageBox.Show("Debe ingresar datos válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgendaEmpresa_Load(object sender, EventArgs e)
        {
            if (editar)
            {
                a_agenda_detalle det = new a_agenda_detalle().getObjecta_agenda_detalle(id_empresa);
                textNombre.Text = det.nombre;
                textTelefono.Text = det.telefono;
            }
        }
    }
}