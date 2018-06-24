using System;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements.OtrosEventosForms
{
    public partial class VoluntarioAccidentado : Form
    {
        private IZeusWin zeusWin;

        public VoluntarioAccidentado()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
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

        private void btnIngresarVoluntarioAccidentado_Click(object sender, EventArgs e)
        {
            if (Validar(textNombreVoluntarioAccidentado, textDescripcionAccidente))
            {
                BitacoraGestion.NuevoEvento(zeusWin.IdOperadora, zeusWin.IdAval,
                                            "7-5 Voluntario: " + textNombreVoluntarioAccidentado.Text +
                                            ", Descripcion: " + textDescripcionAccidente.Text);
                MessageBox.Show("Operación realizada exitosamente");
                Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}