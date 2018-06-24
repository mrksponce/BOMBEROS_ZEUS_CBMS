using System;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace LibroNovedades
{
    public partial class FormNovedades : Form
    {
        private IZeusWin zeusWin;

        public FormNovedades()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        private void FormNovedades_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.libro_novedades_32.GetHicon());

            textFecha.Text = DateTime.Now.ToString("g");

            dataGridView1.DataSource = new bitacora_gestion().GetBitacorasCombinadas().Tables[0];
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                //z_novedad nov = new z_novedad();
                //nov.id_operadora = zeusWin.IdOperadora;
                //nov.novedad = textNovedad.Text;
                //nov.descripcion = textDescripcion.Text;
                //nov.addz_novedad(nov);
                if (radioLlamados.Checked)
                {
                    BitacoraLlamado.NuevoEvento(zeusWin.IdExpediente, BitacoraLlamado.Llamado,
                                                textDescripcion.Text, DateTime.Parse(textFecha.Text));
                }
                else
                {
                    BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval, textDescripcion.Text,
                                                DateTime.Parse(textFecha.Text));
                }
                MessageBox.Show("Datos ingresados correctamente.", "Mensaje de ZEUS", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private bool Validar()
        {
            DateTime d;
            if (!DateTime.TryParse(textFecha.Text, out d) || textDescripcion.Text == "")
            {
                MessageBox.Show("Debe ingresar Fecha/Hora y Novedad.", "Faltan Datos", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                // agregar texto seleccionado al textbox
                textDescripcion.Text = ">> " + dataGridView1.SelectedRows[0].Cells["evento"].Value + Environment.NewLine;
            }
        }
    }
}