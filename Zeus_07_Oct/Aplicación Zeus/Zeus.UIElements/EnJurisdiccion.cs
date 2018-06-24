using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class EnJurisdiccion : Form
    {
        private IZeusWin zeusWin;

        public EnJurisdiccion()
        {
            InitializeComponent();
        }

        public int IdCarro { get; set; }

        public bool CarroEnJurisdiccion { get; set; }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }


        private void EnJurisdiccion_Load(object sender, EventArgs e)
        {
            try
            {
                e_carros_usados cu = new e_carros_usados().getObjecte_carros_usados(IdCarro);
                if (!cu.en_jurisdiccion)
                {
                    radio617r.Checked = true;
                }
                else
                {
                    radio617v.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                CarroEnLlamado cel=new CarroEnLlamado(IdCarro);
                cel.EstablecerEnJurisdiccion(radio617v.Checked);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }
    }
}