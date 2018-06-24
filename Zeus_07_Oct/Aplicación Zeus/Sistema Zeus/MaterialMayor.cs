using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.UIElements;
using Zeus.Util;

namespace Zeus.Application
{
    public partial class MaterialMayor : Form
    {
        private IZeusWin zeusWin;

        public MaterialMayor()
        {
            InitializeComponent();
            //timer1.Enabled = true;
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set
            {
                zeusWin = value;
                panelEstadoCarros1.ZeusWin = value;
            }
        }

        private void MaterialMayor_Load(object sender, EventArgs e)
        {
            DBNotifyListeners.RegisterListener(panelEstadoCarros1.OnUpdateCarroHandler);
        }

        private void MaterialMayor_FormClosed(object sender, FormClosedEventArgs e)
        {
            RecursosEstaticos.PrimeraCarga = 1;
            DBNotifyListeners.UnregisterListener(panelEstadoCarros1.OnUpdateCarroHandler);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _011_CubrirCuartel cuartel = new _011_CubrirCuartel();
            if (cuartel.ShowDialog() == DialogResult.OK)
            {
                DBNotifyListeners.RegisterListener(panelEstadoCarros1.OnUpdateCarroHandler);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}