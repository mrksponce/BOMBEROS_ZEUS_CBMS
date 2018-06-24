using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace ReportesGraficosEstadisticos
{
    public partial class VerGraficoForm : Form
    {
        private DataSet data;
        private TipoGrafico tipoGrafico;
        private string titulo;

        private string xAxisSource;

        private string yAxisSource;

        public VerGraficoForm()
        {
            InitializeComponent();
        }

        public DataSet Data
        {
            get { return data; }
            set { data = value; }
        }

        public string XAxisSource
        {
            get { return xAxisSource; }
            set { xAxisSource = value; }
        }

        public string YAxisSource
        {
            get { return yAxisSource; }
            set { yAxisSource = value; }
        }

        internal TipoGrafico TipoGrafico
        {
            get { return tipoGrafico; }
            set { tipoGrafico = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        private void CreateGraph_DataSource(ZedGraphControl z1)
        {
            GraphPane myPane = z1.GraphPane;

            // Set the titles
            myPane.Title.Text = titulo;
            myPane.XAxis.Title.Text = xAxisSource;
            myPane.YAxis.Title.Text = yAxisSource;

            // Create a new DataSourcePointList to handle the database connection
            var dspl = new DataSourcePointList
                           {
                               DataSource = data.Tables[0],
                               XDataMember = xAxisSource,
                               YDataMember = yAxisSource,
                               ZDataMember = null
                           };

            // Specify the table as the data source
            // The X data will come from the "OrderDate" column
            // The Y data will come from the "Freight" column
            // The Z data are not used

            if (tipoGrafico == TipoGrafico.Torta)
            {
                // dibujar torta
                var values = new List<double>();
                var labels = new List<string>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    if (dr[xAxisSource] != DBNull.Value)
                    {
                        values.Add(Convert.ToDouble(dr[xAxisSource]));
                    }
                    else
                    {
                        values.Add(0);
                    }
                    if (dr[yAxisSource] != DBNull.Value)
                    {
                        labels.Add(Convert.ToString(dr[yAxisSource]));
                    }
                    else
                    {
                        labels.Add(string.Empty);
                    }
                }
                myPane.AddPieSlices(values.ToArray(), labels.ToArray());
            }
            else
            {
                // formatear strings
                if (data.Tables[0].Columns[xAxisSource].DataType == typeof (string))
                {
                    myPane.XAxis.Scale.FontSpec.Angle = 90;
                    myPane.XAxis.Scale.FontSpec.Size = myPane.XAxis.Scale.FontSpec.Size/2;
                    // agregar datos como textlabels
                    var labels = new List<string>();
                    foreach (DataRow dr in data.Tables[0].Rows)
                    {
                        if (dr[xAxisSource] != DBNull.Value)
                        {
                            labels.Add((string) dr[xAxisSource]);
                        }
                        else
                        {
                            labels.Add("");
                        }
                    }
                    myPane.XAxis.Scale.TextLabels = labels.ToArray();
                    myPane.XAxis.Type = AxisType.Text;
                }

                if (data.Tables[0].Columns[yAxisSource].DataType == typeof (string))
                {
                    myPane.YAxis.Scale.FontSpec.Size = myPane.YAxis.Scale.FontSpec.Size/2;
                    // agregar datos como textlabels
                    var labels = new List<string>();
                    foreach (DataRow dr in data.Tables[0].Rows)
                    {
                        if (dr[yAxisSource] != DBNull.Value)
                        {
                            labels.Add((string) dr[yAxisSource]);
                        }
                        else
                        {
                            labels.Add("");
                        }
                    }
                    myPane.YAxis.Scale.TextLabels = labels.ToArray();
                    myPane.YAxis.Type = AxisType.Text;
                }

                // formatear fechas
                if (data.Tables[0].Columns[xAxisSource].DataType == typeof (DateTime))
                {
                    myPane.XAxis.Type = AxisType.Date;
                }
                if (data.Tables[0].Columns[yAxisSource].DataType == typeof (DateTime))
                {
                    myPane.YAxis.Type = AxisType.Date;
                }

                switch (tipoGrafico)
                {
                    case TipoGrafico.Puntos:
                        myPane.AddCurve(yAxisSource, dspl, Color.Blue).Line.IsVisible = false;
                        break;
                    case TipoGrafico.Lineas:
                        myPane.AddCurve(yAxisSource, dspl, Color.Blue);
                        break;
                    case TipoGrafico.Barras:
                        myPane.AddBar(yAxisSource, dspl, Color.Blue);
                        break;
                    default:
                        break;
                }
                myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
                myPane.XAxis.MajorGrid.IsVisible = true;
                myPane.YAxis.MajorGrid.IsVisible = true;
            }

            // Auto set the scale ranges
            z1.AxisChange();
        }

        private void VerGraficoForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.statistics_32x32.GetHicon());

            CreateGraph_DataSource(zedGraphControl1);
        }
    }
}