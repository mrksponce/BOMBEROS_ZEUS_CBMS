using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using ExcelUtil;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace ReportesGraficosEstadisticos
{
    public partial class ReportesGraficosForm : Form
    {
        private IZeusWin zeusWin;


        public ReportesGraficosForm()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        private void ReportesGraficosForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.statistics_32x32.GetHicon());

            // cargar tablas disponibles
            listTablas.DataSource = new est_tablas().GetTablas().Tables[0];

            // fecha y hora
            comboMes.SelectedIndex = DateTime.Now.Month - 1;
            textAño.Text = DateTime.Now.Year.ToString();
        }

        private void listTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // mostrar columnas
            listCampos.DataSource = new est_tablas().GetColumnas((string) listTablas.SelectedValue).Tables[0];

            // mostrar descripcion
            textDescripcion.Text = ((DataRowView) listTablas.SelectedItem).Row["descripcion"].ToString();
            if (textDescripcion.Text == "")
            {
                textDescripcion.Text = "(Sin descripción disponible)";
            }
        }

        private void listCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // mostrar descripcion
            textDescripcion.Text = ((DataRowView) listCampos.SelectedItem).Row["descripcion"].ToString();
            if (textDescripcion.Text == "")
            {
                textDescripcion.Text = "(Sin descripción disponible)";
            }
        }

        private void listCampos_DoubleClick(object sender, EventArgs e)
        {
            if (listCampos.SelectedItem != null)
            {
                // item seleccionado y doble clickeado, mostrar distintos
                listUnicos.DataSource =
                    new est_tablas().GetDistincts((string) listTablas.SelectedValue, (string) listCampos.SelectedValue).
                        Tables[0];
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                dataSet1 = Util.Query(textSQL.Text);
                dgResultados.DataSource = dataSet1.Tables[0];
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
            Cursor = Cursors.Default;
        }

        private void btnBiblioteca_Click(object sender, EventArgs e)
        {
            var bib = new BibliotecaConsultasForm {ZeusWin = zeusWin};
            if (bib.ShowDialog() == DialogResult.OK)
            {
                textSQL.Text = bib.Consulta;
            }
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            int año;
            DataSet ds;
            if (comboTipoReporte.SelectedIndex != -1 && comboMes.SelectedIndex != -1 &&
                int.TryParse(textAño.Text, out año))
            {
                var vr = new VerReporteForm();
                // mostrar reporte
                switch (comboTipoReporte.SelectedIndex)
                {
                        // Frecuencias por acto
                    case 0:
                        try
                        {
                            vr.Report = new ReporteFrecuenciasPorActo();
                            ds = new Reportes().ReporteFrecuenciasPorActo(comboMes.SelectedIndex + 1, año);
                            // textos
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text =
                                string.Format(((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text,
                                              " " + comboMes.SelectedItem + " " + año);
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Frecuencia_Ant"]).Text =
                                string.Format(
                                    ((TextObject) vr.Report.ReportDefinition.ReportObjects["Frecuencia_Ant"]).Text,
                                    (comboMes.SelectedIndex + 1) + "/" + (año - 1));
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Frecuencia_Act"]).Text =
                                string.Format(
                                    ((TextObject) vr.Report.ReportDefinition.ReportObjects["Frecuencia_Act"]).Text,
                                    (comboMes.SelectedIndex + 1) + "/" + año);
                            // suma de tiempos
                            var ts = new TimeSpan();
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                if (dr["duracion_llamados"] != DBNull.Value)
                                {
                                    // dividir, transformar a timespan y sumar
                                    string duracion = (string) dr["duracion_llamados"];
                                    ts += IntervalToTimeSpan(duracion);
                                }
                            }
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Duracion_Llamados"]).Text =
                                (ts.Days*24 + ts.Hours) + ":" + ts.Minutes + ":" + ts.Seconds + "." + ts.Milliseconds;

                            Cursor.Current = Cursors.WaitCursor;
                            vr.Report.SetDataSource(ds);
                            vr.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            Log.ShowAndLog(ex);
                        }
                        break;
                        // Frecuencias por llamado
                    case 1:
                        try
                        {
                            vr.Report = new ReporteFrecuenciasPorLlamado();
                            ds = new Reportes().ReporteFrecuenciasPorLlamado(comboMes.SelectedIndex + 1, año);
                            // textos
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text =
                                string.Format(((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text,
                                              " " + comboMes.SelectedItem + " " + año);
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Frecuencia_Ant"]).Text =
                                string.Format(
                                    ((TextObject) vr.Report.ReportDefinition.ReportObjects["Frecuencia_Ant"]).Text,
                                    (comboMes.SelectedIndex + 1) + "/" + (año - 1));
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Frecuencia_Act"]).Text =
                                string.Format(
                                    ((TextObject) vr.Report.ReportDefinition.ReportObjects["Frecuencia_Act"]).Text,
                                    (comboMes.SelectedIndex + 1) + "/" + año);
                            // suma de tiempos
                            var ts = new TimeSpan();
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                if (dr["duracion_llamados"] != DBNull.Value)
                                {
                                    // dividir, transformar a timespan y sumar
                                    string duracion = (string) dr["duracion_llamados"];
                                    ts += IntervalToTimeSpan(duracion);
                                }
                            }
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Duracion_Llamados"]).Text =
                                (ts.Days*24 + ts.Hours) + ":" + ts.Minutes + ":" + ts.Seconds + "." + ts.Milliseconds;

                            Cursor.Current = Cursors.WaitCursor;
                            vr.Report.SetDataSource(ds);
                            vr.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            Log.ShowAndLog(ex);
                        }
                        break;
                        // Actos por compañia
                    case 2:
                        try
                        {
                            vr.Report = new ReporteFrecuenciaActosPorCompañia();
                            ds = new Reportes().ReporteFrecuenciaActosPorCompañia(comboMes.SelectedIndex + 1, año);
                            // textos
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text =
                                string.Format(((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text,
                                              " " + comboMes.SelectedItem + " " + año);

                            Cursor.Current = Cursors.WaitCursor;
                            vr.Report.SetDataSource(ds);
                            vr.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            Log.ShowAndLog(ex);
                        }
                        break;
                        // Llamados por compañia
                    case 3:
                        try
                        {
                            vr.Report = new ReporteFrecuenciaLlamadosPorCompañia();
                            ds = new Reportes().ReporteFrecuenciaLlamadosPorCompañia(comboMes.SelectedIndex + 1, año);
                            // textos
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text =
                                string.Format(((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text,
                                              " " + comboMes.SelectedItem + " " + año);

                            Cursor.Current = Cursors.WaitCursor;
                            vr.Report.SetDataSource(ds);
                            vr.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            Log.ShowAndLog(ex);
                        }
                        break;
                        // Actos por comuna
                    case 4:
                        try
                        {
                            vr.Report = new ReporteFrecuenciaActosPorComuna();
                            ds = new Reportes().ReporteFrecuenciaActosPorComuna(comboMes.SelectedIndex + 1, año);
                            // textos
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text =
                                string.Format(((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text,
                                              " " + comboMes.SelectedItem + " " + año);

                            Cursor.Current = Cursors.WaitCursor;
                            vr.Report.SetDataSource(ds);
                            vr.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            Log.ShowAndLog(ex);
                        }
                        break;
                    case 5:
                        try
                        {
                            vr.Report = new ReporteFrecuenciaLlamadosPorComuna();
                            ds = new Reportes().ReporteFrecuenciaLlamadosPorComuna(comboMes.SelectedIndex + 1, año);
                            // textos
                            ((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text =
                                string.Format(((TextObject) vr.Report.ReportDefinition.ReportObjects["Titulo"]).Text,
                                              " " + comboMes.SelectedItem + " " + año);

                            Cursor.Current = Cursors.WaitCursor;
                            vr.Report.SetDataSource(ds);
                            vr.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            Log.ShowAndLog(ex);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los datos solicitados antes de poder ver el reporte", "Mensaje de Zeus",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static TimeSpan IntervalToTimeSpan(string duracion)
        {
            string[] hms = duracion.Split(':');
            // pasar de xxx horas a x dias, x horas
            hms[0] = (int.Parse(hms[0])/24) + "." + (int.Parse(hms[0])%24);
            TimeSpan t = TimeSpan.Parse(string.Join(":", hms));
            return t;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dataSet1.Tables.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos en la sección de resultados. Realice una consulta antes de intentar exportar",
                    "No se puede exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fs = new StreamWriter(saveFileDialog1.FileName);
                    fs.Write(WorkbookEngine.CreateWorkbook(dataSet1));
                    fs.Close();
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            if (dataSet1.Tables.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos en la sección de resultados. Realice una consulta antes de intentar generar un gráfico",
                    "No se puede generar gráfico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var gf = new GenerarGraficoForm {Data = dataSet1};
            gf.ShowDialog();
        }
    }
}