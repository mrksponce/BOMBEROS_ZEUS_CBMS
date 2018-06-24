using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace ReportesGraficosEstadisticos
{
    public partial class VerReporteForm : Form
    {
        public VerReporteForm()
        {
            InitializeComponent();
        }

        public ReportClass Report
        {
            get { return crystalReportViewer1.ReportSource as ReportClass; }
            set { crystalReportViewer1.ReportSource = value; }
        }
    }
}