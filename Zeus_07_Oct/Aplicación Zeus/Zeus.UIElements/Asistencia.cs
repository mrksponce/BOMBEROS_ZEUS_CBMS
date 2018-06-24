using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeus.UIElements
{
    public partial class Asistencia : Form
    {
        private int id_expediente;
        
        public Asistencia()
        {
            InitializeComponent();
        }

        public int Id_expediente
        {
            get { return id_expediente; }
            set { id_expediente = value; }
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            tbx_Asisten.Text = "Hola Mundo  :)";
        }




    }
}
