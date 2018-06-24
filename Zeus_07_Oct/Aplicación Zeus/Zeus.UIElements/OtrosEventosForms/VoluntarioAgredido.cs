using System;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements.OtrosEventosForms
{
    public partial class VoluntarioAgredido : Form
    {
        private IZeusWin zeusWin;

        public VoluntarioAgredido()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static bool Validar(Control t1, Control t2)
        {
            bool ret = (t1.Text != "" && t2.Text != "");
            if (!ret)
            {
                MessageBox.Show("Faltan datos necesarios.", "Mensaje de Zeus");
            }
            return ret;
        }

        private void btnIngresarAgresion_Click(object sender, EventArgs e)
        {
            if (Validar(textNombreVoluntarioAgredido, textDescripcionAgresion))
            {
                BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval,
                                            "7-5 Voluntario: " + textNombreVoluntarioAgredido.Text + ", Descripcion: " +
                                            textDescripcionAgresion.Text);
                MessageBox.Show("Operación realizada exitosamente");
                Close();
            }
        }
    }
}