using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Zeus.Data;

namespace BoletinInformativo
{
    public partial class BoletinInformativoForm : Form
    {
        public BoletinInformativoForm()
        {
            InitializeComponent();
            // Report MUST BE set before running repViewer_Load
            // I hate CR
#if CBMS
            crystalReportViewer1.ReportSource = BoletinCBMS1;
#elif CBQN
            crystalReportViewer1.ReportSource = BoletinCBQN1;
#endif
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DateTime hora = DateTime.Now.AddMinutes(-DateTime.Now.Minute);
            var Boletin = (ReportClass) crystalReportViewer1.ReportSource;
            var exp = new e_expedientes();
            DataSet ds = exp.GetIncendios24Horas();
            if (ds.Tables[0].Rows.Count == 0)
            {
                Boletin.OpenSubreport("Incendios").ReportDefinition.Sections["DetailSection1"].SectionFormat.
                    EnableSuppress = true;
            }
            Boletin.OpenSubreport("Incendios").SetDataSource(ds);
            ds = exp.GetApoyos24Horas();
            if (ds.Tables[0].Rows.Count == 0)
            {
                Boletin.OpenSubreport("Apoyos").ReportDefinition.Sections["DetailSection1"].SectionFormat.EnableSuppress
                    = true;
            }

            Boletin.OpenSubreport("Apoyos").SetDataSource(ds);

            // textos
#if CBQN
            const string text = "CUERPO DE BOMBEROS QUINTA NORMAL";
            ((TextObject) Boletin.ReportDefinition.ReportObjects["Titulo"]).Text =
                string.Format(((TextObject) Boletin.ReportDefinition.ReportObjects["Titulo"]).Text, text,
                              hora.ToShortTimeString());
            ((TextObject) Boletin.ReportDefinition.ReportObjects["Introduccion"]).Text =
                string.Format(((TextObject) Boletin.ReportDefinition.ReportObjects["Introduccion"]).Text,
                              hora.ToShortTimeString());
            ((TextObject) Boletin.ReportDefinition.ReportObjects["Finaliza"]).Text =
                string.Format(((TextObject) Boletin.ReportDefinition.ReportObjects["Finaliza"]).Text,
                              hora.ToShortTimeString());
            ((TextObject) Boletin.ReportDefinition.ReportObjects["Total"]).Text =
                string.Format(((TextObject) Boletin.ReportDefinition.ReportObjects["Total"]).Text,
                              exp.GetAlarmas24Horas());
            ((TextObject) Boletin.ReportDefinition.ReportObjects["Saludo"]).Text = hora.IsDaylightSavingTime()
                                                                                       ? "BUENAS TARDES"
                                                                                       : "BUENAS NOCHES";
            ((TextObject) Boletin.ReportDefinition.ReportObjects["MaterialFueraServicio"]).Text +=
                ObtenerCarrosFueraServicio(); //new z_carros().Getz_carrosFueraServicio();
            ((TextObject) Boletin.ReportDefinition.ReportObjects["OficialGuardia"]).Text +=
                new z_guardia().getObjectz_guardia("OFICIAL DE GUARDIA").oficial;

#elif CBMS
            const string text = "CUERPO DE BOMBEROS METROPOLITANO SUR";
            ((TextObject)Boletin.ReportDefinition.ReportObjects["Titulo"]).Text = string.Format(((TextObject)Boletin.ReportDefinition.ReportObjects["Titulo"]).Text, hora.ToShortTimeString());
            ((TextObject)Boletin.ReportDefinition.ReportObjects["Introduccion"]).Text = string.Format(((TextObject)Boletin.ReportDefinition.ReportObjects["Introduccion"]).Text, text, hora.ToShortTimeString());
            ((TextObject)Boletin.ReportDefinition.ReportObjects["Finaliza"]).Text = string.Format(((TextObject)Boletin.ReportDefinition.ReportObjects["Finaliza"]).Text, hora.ToShortTimeString());
            ((TextObject)Boletin.ReportDefinition.ReportObjects["Total"]).Text = string.Format(((TextObject)Boletin.ReportDefinition.ReportObjects["Total"]).Text, exp.GetAlarmas24Horas());
            ((TextObject)Boletin.ReportDefinition.ReportObjects["Saludo"]).Text = hora.IsDaylightSavingTime() ? "BUENAS TARDES" : "BUENAS NOCHES";
            ((TextObject)Boletin.ReportDefinition.ReportObjects["MaterialFueraServicio"]).Text += ObtenerCarrosFueraServicio();//new z_carros().Getz_carrosFueraServicio();
            ((TextObject)Boletin.ReportDefinition.ReportObjects["OficialGuardia"]).Text += new z_guardia().getObjectz_guardia("OFICIAL DE GUARDIA").oficial;

#endif
        }

        private static string ObtenerCarrosFueraServicio()
        {
            string lista = "";
            DataSet ds = new z_carros().Getz_carrosNoDisponibles();
            // utilizar lista
            var carros = new List<DataRow>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                carros.Add(dr);
            }

            if (Settings1.Default.UsarCarros)
            {
                // filtrar por tipo de carro
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!Settings1.Default.CarrosSeleccionados.Contains((int) dr["id_tipo_carro"]))
                    {
                        if (carros.Contains(dr))
                        {
                            carros.Remove(dr);
                        }
                    }
                }
            }

            if (Settings1.Default.UsarDias)
            {
                // filtrar por tipo de carro
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (((DateTime) dr["fecha_fuera_servicio"]).Date <
                        DateTime.Now.AddDays(Settings1.Default.NumDias*-1).Date)
                    {
                        if (carros.Contains(dr))
                        {
                            carros.Remove(dr);
                        }
                    }
                }
            }

            foreach (DataRow dr in carros)
            {
                // concatenar string
                lista += ", " + dr["nombre"];
            }
            return lista.Trim(',', ' ');
        }

        private void BoletinInformativoForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.boletin_informativo_32.GetHicon());
            Cursor = Cursors.Default;
        }
    }
}