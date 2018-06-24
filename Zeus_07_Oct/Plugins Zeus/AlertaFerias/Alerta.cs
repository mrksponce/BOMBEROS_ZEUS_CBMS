using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AlertaFerias
{
    public partial class Alerta : Form
    {
        private int radio;

        public Alerta()
        {
            InitializeComponent();
        }

        public DataSet DataSet { get; set; }

        public int Radio
        {
            get { return radio; }
            set { radio = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Alerta_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.ferias_32_1.GetHicon());
            label1.Text = string.Format(label1.Text, radio);
            foreach (DataRow dr in DataSet.Tables[0].Rows)
            {
                if ((int) dr["d1"] == (int) DateTime.Now.DayOfWeek || (int) dr["d2"] == (int) DateTime.Now.DayOfWeek)
                {
                    var li = new ListViewItem((string) dr["nombre"]);
                    li.SubItems.Add((string) dr["desde"]);
                    li.SubItems.Add((string) dr["hasta"]);
                    listFerias.Items.Add(li);
                }
            }
        }
    }
}