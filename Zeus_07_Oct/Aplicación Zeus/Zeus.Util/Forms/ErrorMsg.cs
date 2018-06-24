using System;
using System.Windows.Forms;

namespace Zeus.Util.Forms
{
    public partial class ErrorMsg : Form
    {
        private readonly Exception exception;

        public ErrorMsg(Exception e)
        {
            InitializeComponent();
            exception = e;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkDatos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblDatosError.Text == "")
            {
                // mostrar datos
                lblDatosError.Text = exception.StackTrace;
                linkDatos.Text = "Ocultar Datos de Error";

                CenterToScreen();
            }
            else
            {
                // ocultar datos
                lblDatosError.Text = "";
                linkDatos.Text = "Ver Datos de Error";

                CenterToScreen();
            }
        }

        private void ErrorMsg_Load(object sender, EventArgs e)
        {
            lblError.Text = exception.Message;
        }
    }
}