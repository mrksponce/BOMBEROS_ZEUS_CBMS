using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using PdfSharp;
using Zeus.Data;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;
using System.IO;

namespace Zeus.UIElements
{
    public partial class EntregaDeTurno : Form
    {
        public EntregaDeTurno()
        {
            InitializeComponent();
        }

        private void EntregaDeTurno_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }


        protected void CargarGrilla()
        {
            dg_EntregaTurno.Rows.Clear();
            z_carros carros = new z_carros();

            //# Estado de Carros
            if (carros.Estado_Carro().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_est in carros.Estado_Carro().Tables[0].Rows)
                {
                    string strConductor = "";
                    if (row_est["tipo_conductor"].ToString() != "")
                    {
                        strConductor = ObtieneNombreDeConductor(Convert.ToInt32(row_est["id_conductor"].ToString()), Convert.ToInt32(row_est["tipo_conductor"].ToString()));
                    }

                    dg_EntregaTurno.Rows.Add(row_est["nombre"].ToString(), row_est["estado"], row_est["codigo"], strConductor, row_est["observacion"]);
                }
            }

        }



        public static string ObtieneNombreDeConductor(int id_conductor, int tipo_conductor)
        {
            string NombeConductor = "";
            string reqSQL = "";
            z_cuarteleros zcuarteleros = new z_cuarteleros();
            z_voluntarios zvoluntarios = new z_voluntarios();

            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();

            if (tipo_conductor == 1)
            {
                //reqSQL = "SELECT nombres||' '||apellidos As nombre_completo FROM z_cuarteleros WHERE id_cuartelero=" + id_conductor + "";
                reqSQL = "SELECT nombres||' '||apellidos As nombre_completo FROM z_cuarteleros WHERE id_cuartelero IN (SELECT id_cuart_vol FROM z_conductores WHERE id_conductor=" + id_conductor + ")";
            }
            else
            {
                reqSQL = "SELECT nombres||' '||apellidos As nombre_completo FROM z_voluntarios WHERE id_voluntario IN (SELECT id_cuart_vol FROM z_conductores WHERE id_conductor=" + id_conductor + ")";
            }
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_conductor in myResult.Tables[0].Rows)
                {
                    NombeConductor = Convert.ToString(r_conductor["nombre_completo"]);
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return NombeConductor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exportar_pdf();
        }


        protected void Exportar_pdf()
        {


            try
            {
                    
                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);

                string filename = "reporteEntregaTurno.pdf";

                FileStream file = new FileStream(filename,


                                                 FileMode.OpenOrCreate,


                                                 FileAccess.ReadWrite,


                                                 FileShare.ReadWrite);

                PdfWriter.GetInstance(doc, file);

                doc.Open();

                GenerarDocumento(doc);

                doc.Close();

                Process.Start(filename);
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Función que genera el documento Pdf


        public void GenerarDocumento(iTextSharp.text.Document document)
        {


            //se crea un objeto PdfTable con el numero de columnas del 


            //dataGridView


            PdfPTable datatable = new PdfPTable(dg_EntregaTurno.ColumnCount);


            //asignamos algunas propiedades para el diseño del pdf

            datatable.DefaultCell.Padding = 3;

            float[] headerwidths = GetTamañoColumnas(dg_EntregaTurno);


            datatable.SetWidths(headerwidths);


            datatable.WidthPercentage = 100;


            datatable.DefaultCell.BorderWidth = 2;


            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;




            //SE GENERA EL ENCABEZADO DE LA TABLA EN EL PDF


            for (int i = 0; i < dg_EntregaTurno.ColumnCount; i++)
            {


                datatable.AddCell(dg_EntregaTurno.Columns[i].HeaderText);


            }




            datatable.HeaderRows = 1;


            datatable.DefaultCell.BorderWidth = 1;




            //SE GENERA EL CUERPO DEL PDF

            iTextSharp.text.Font fGrilla = new iTextSharp.text.Font();
            fGrilla.Size = 10;
            for (int i = 0; i < dg_EntregaTurno.RowCount; i++)
            {


                for (int j = 0; j < dg_EntregaTurno.ColumnCount; j++)
                {


                    datatable.AddCell(new iTextSharp.text.Paragraph(dg_EntregaTurno[j, i].Value.ToString(), fGrilla));


                }


                datatable.CompleteRow();


            }
            iTextSharp.text.Font fTitulo = new iTextSharp.text.Font();
            fTitulo.Size = 20;

            iTextSharp.text.Font fDescripcion = new iTextSharp.text.Font();
            fDescripcion.Size = 15;

            iTextSharp.text.Font fAlineacion = new iTextSharp.text.Font(Element.ALIGN_LEFT);
            fAlineacion.Size = 10;

            document.Add(new iTextSharp.text.Paragraph("Disponibilidad del Material Mayor en la Entrega de Turno " + System.DateTime.Now.ToString("dd/MM/yyyy hh:MM:ss") + "", fTitulo));
            document.Add(new iTextSharp.text.Paragraph("Cuerpo de Bomberos Metropolitano Sur", fDescripcion));
            document.Add(new iTextSharp.text.Paragraph(" "));
            document.Add(new iTextSharp.text.Paragraph("______________________________", fAlineacion));
            document.Add(new iTextSharp.text.Paragraph("     Firma Operador(a) Nº " + textBox1.Text, fAlineacion));
            document.Add(new iTextSharp.text.Paragraph(" "));
            document.Add(datatable);

        }





        //Función que obtiene los tamaños de las columnas del grid

        public float[] GetTamañoColumnas(DataGridView dg)
        {

            float[] values = new float[dg.ColumnCount];

            for (int i = 0; i < dg.ColumnCount; i++)
            {

                values[i] = (float)dg.Columns[i].Width;

            }

            return values;

        } 
    }
}
