using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace CarroEspecialidades
{
    public partial class EditSector : UserControl
    {
        public EditSector()
        {
            InitializeComponent();
        }

        public string Descripcion
        {
            get { return textDescripcion.Text; }
            set { textDescripcion.Text = value; }
        }

        public string Areas
        {
            get { return textAreas.Text; }
            set { textAreas.Text = value; }
        }

        public int IdSector { get; set; }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Seguro desea eliminar este sector?", "Eliminar Sector", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (IdSector != 0)
                    {
                        new s_sector().deletes_sector(IdSector);
                    }
                    Parent.Controls.Remove(this);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        public new void Focus()
        {
            textDescripcion.Focus();
        }
    }
}