using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;

namespace Zeus.UIElements
{
    public partial class Frecuencia : Form
    {
        private int id_frecuencia;

        public Frecuencia()
        {
            InitializeComponent();
        }

        public int Id_frecuencia
        {
            get { return id_frecuencia; }
            set { id_frecuencia = value; }
        }

        private void Frecuencia_Load(object sender, EventArgs e)
        {
            DataSet ds = new e_frecuencias().Gete_frecuencias();
            int i = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var b = new Button {Text = ((string) dr["frecuencia"]), Tag = ((int) dr["id_frecuencia"])};
                b.Click += BtnClick;
                var l = new Label
                            {
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleLeft,
                                Text = ((string) dr["descripcion"])
                            };
                tableLayoutPanel1.Controls.Add(b, 0, i);
                tableLayoutPanel1.Controls.Add(l, 1, i++);
                tableLayoutPanel1.RowCount++;
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            id_frecuencia = (int) ((Control) sender).Tag;
            Close();
        }
    }
}