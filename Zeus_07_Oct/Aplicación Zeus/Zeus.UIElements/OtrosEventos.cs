using System;
using System.Windows.Forms;
using Zeus.Interfaces;
using Zeus.UIElements.OtrosEventosForms;

namespace Zeus.UIElements
{
    public partial class OtrosEventos : Form
    {
        private IZeusWin zeusWin;

        public OtrosEventos()
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

        private void btnVoluntarioAgredido_Click(object sender, EventArgs e)
        {
            var va = new VoluntarioAgredido {ZeusWin = zeusWin};
            va.ShowDialog();
        }

        private void btnVoluntarioLesionado_Click(object sender, EventArgs e)
        {
            var vl = new VoluntarioAccidentado {ZeusWin = zeusWin};
            vl.ShowDialog();
        }

        private void btnDestrozoCarro_Click(object sender, EventArgs e)
        {
            var dc = new DestrozoEnCarro {ZeusWin = zeusWin};
            dc.ShowDialog();
        }

        private void bntDestrozoCuartel_Click(object sender, EventArgs e)
        {
            var dc = new DestrozoEnCuartel {ZeusWin = zeusWin};
            dc.ShowDialog();
        }
    }
}