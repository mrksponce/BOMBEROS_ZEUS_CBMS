using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ReportesGraficosEstadisticos
{
    public partial class GenerarGraficoForm : Form
    {
        private DataSet data;

        public GenerarGraficoForm()
        {
            InitializeComponent();
        }

        public DataSet Data
        {
            get { return data; }
            set { data = value; }
        }

        private void GenerarGraficoForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.statistics_32x32.GetHicon());

            foreach (DataColumn column in data.Tables[0].Columns)
            {
                comboEjeX.Items.Add(column.ColumnName);
                comboEjeY.Items.Add(column.ColumnName);
            }
            comboTipoGrafico.DataSource = Enum.GetValues(typeof (TipoGrafico));
            comboTipoGrafico.SelectedIndex = 0;
            comboEjeX.SelectedIndex = comboEjeY.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            var vf = new VerGraficoForm
                         {
                             Data = data,
                             XAxisSource = ((string) comboEjeX.SelectedItem),
                             YAxisSource = ((string) comboEjeY.SelectedItem),
                             TipoGrafico = ((TipoGrafico) comboTipoGrafico.SelectedValue),
                             Titulo = textBox1.Text
                         };
            vf.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboTipoGrafico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TipoGrafico) comboTipoGrafico.SelectedValue == TipoGrafico.Torta)
            {
                label1.Text = "Columna Datos";
                label2.Text = "Columna Etiquetas";
            }
            else
            {
                label1.Text = "Datos Abscisa (X)";
                label2.Text = "Datos Ordenada (Y)";
            }
        }
    }
}