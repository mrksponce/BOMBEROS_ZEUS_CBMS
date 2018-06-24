using System.Windows.Forms;
using Zeus.Interfaces;

namespace Zeus.UIElements
{
    public partial class MainLlamadosCarros : BaseControl
    {
        public MainLlamadosCarros()
        {
            InitializeComponent();
            panelCarro1.Dock = DockStyle.Fill;
            panelLlamado1.Dock = DockStyle.Fill;
        }

        public override IZeusWin ZeusWin
        {
            get { return base.ZeusWin; }
            set
            {
                base.ZeusWin = value;
                panelCarro1.ZeusWin = value;
                panelLlamado1.ZeusWin = value;
            }
        }

        public void OnAsignacionHandler(object sender, DataEventArgs e)
        {
            panelLlamado1.OnAsignacionHandler(e);
        }

        public void OnSeleccionHandler(object sender, DataEventArgs e)
        {
            if (e == null)
            {
                panelCarro1.Visible = false;
                panelLlamado1.Visible = false;
                return;
            }
            switch (e.TipoElemento)
            {
                case TipoElemento.Expediente:
                    MostrarPanelLlamado();
                    panelLlamado1.MostrarInfo(e.Id);
                    break;
                case TipoElemento.Carro:
                    MostrarPanelCarro();
                    panelCarro1.MostrarInfo(e.Id);
                    break;
                default:
                    panelCarro1.Visible = false;
                    panelLlamado1.Visible = false;
                    break;
            }
        }

        private void MostrarPanelCarro()
        {
            panelCarro1.Visible = true;
            panelLlamado1.Visible = false;
        }

        private void MostrarPanelLlamado()
        {
            panelLlamado1.Visible = true;
            panelCarro1.Visible = false;
        }
    }
}