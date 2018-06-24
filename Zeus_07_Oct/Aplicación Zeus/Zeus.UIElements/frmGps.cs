using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

using System.IO;
using System.Windows.Forms;
using System.Xml;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using Font = System.Drawing.Font;
using Orientation = MigraDoc.DocumentObjectModel.Orientation;
using iTextSharp.text.pdf;
using System.Diagnostics;
using iTextSharp.text;




namespace Zeus.UIElements
{
    public partial class frmGps : Form
    {
        public frmGps()
        {
            InitializeComponent();
        }

        private void frmGps_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }


        //# Carros con 6-10
        private void Carros_610(bool InsertaRegistro)
        {
            z_carros carros = new z_carros();
            if (carros.GPS_610().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_610 in carros.GPS_610().Tables[0].Rows)
                {
                    if (InsertaRegistro)
                    {
                        gvGps.Rows.Add(row_610["id_carro"].ToString(), row_610["nombre"], "(6-10) -> " + row_610["id_compania"] + "", "6-10", "6-14", "6-15");
                    }
                    carros.GPS_Update_True(row_610["id_carro"].ToString());
                }
            }
        }

        //# Carros con 6-14
        private void Carros_614(bool InsertaRegistro)
        {
            z_carros carros = new z_carros();
            if (carros.GPS_614().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_614 in carros.GPS_614().Tables[0].Rows)
                {
                    if (InsertaRegistro)
                    {
                        gvGps.Rows.Add(row_614["id_carro"].ToString(), row_614["nombre"], "(6-14) -> " + row_614["id"] + "", "6-10", "6-14", "6-15");
                    }
                    carros.GPS_Update_True(row_614["id_carro"].ToString());
                }
            }
        }

        //# Carros con 6-15
        private void Carros_615(bool InsertaRegistro)
        {
            z_carros carros = new z_carros();
            if (carros.GPS_615().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_615 in carros.GPS_615().Tables[0].Rows)
                {
                    if (InsertaRegistro)
                    {
                        gvGps.Rows.Add(row_615["id_carro"].ToString(), row_615["nombre"], "(6-15) -> " + row_615["id"] + "", "6-10", "6-14", "6-15");
                    }
                    carros.GPS_Update_True(row_615["id_carro"].ToString());
                }
            }
        }

        //# Carros con 6-3
        private void Carros_63(bool InsertaRegistro)
        {
            z_carros carros = new z_carros();
            if (carros.GPS_Expedientes().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_exp in carros.GPS_Expedientes().Tables[0].Rows)
                {
                    decimal CoordenadaX = Convert.ToDecimal(row_exp["puntoX"].ToString());
                    decimal CoordenadaY = Convert.ToDecimal(row_exp["puntoY"].ToString());

                    if (carros.GPS_63(Convert.ToInt32(CoordenadaX).ToString(), Convert.ToInt32(CoordenadaY).ToString()).Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row_63 in carros.GPS_63(Convert.ToInt32(CoordenadaX).ToString(), Convert.ToInt32(CoordenadaY).ToString()).Tables[0].Rows)
                        {
                            if (InsertaRegistro)
                            {
                                gvGps.Rows.Add(row_63["id_carro"].ToString(), row_63["nombre"], "(6-3) -> " + row_exp["clave"].ToString() + "", "6-10", "6-14", "6-15");
                            }
                            carros.GPS_Update_True(row_63["id_carro"].ToString());
                        }
                    }
                    //MessageBox.Show("Llamado  [" + row_exp["clave"].ToString() + "]  " + "CoordX [" + row_exp["puntoX"].ToString() + "]", "GEObit");
                }
            }
        }

        //# Carros con Localización Indeterminada
        private void Carros_613(bool InsertaRegistro)
        {
            z_carros carros = new z_carros();
            if (carros.GPS_NoEncontrados().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_NoEn in carros.GPS_NoEncontrados().Tables[0].Rows)
                {
                    if (InsertaRegistro)
                    {
                        gvGps.Rows.Add(row_NoEn["id_carro"].ToString(), row_NoEn["nombre"], "(6-13) ó ¿?", "6-10", "6-14", "6-15");
                    }
                }
            }
        }



        protected void CargarGrilla()
        {
            gvGps.Rows.Clear();
            z_carros carros = new z_carros();
            


            //# Asigna z_carros.gps = false a todos los Carros
            carros.GPS_Update_False();
            
            //# Carros con 6-10
            if (carros.GPS_610().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_610 in carros.GPS_610().Tables[0].Rows)
                {
                    gvGps.Rows.Add(row_610["id_carro"].ToString(), row_610["nombre"], "(6-10) -> " + row_610["id_compania"] + "", "6-10", "6-14", "6-15");
                    carros.GPS_Update_True(row_610["id_carro"].ToString());
                }
            }

            //# Carros con 6-14
            if (carros.GPS_614().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_614 in carros.GPS_614().Tables[0].Rows)
                {
                    gvGps.Rows.Add(row_614["id_carro"].ToString(), row_614["nombre"], "(6-14) -> " + row_614["id"] + "", "6-10", "6-14", "6-15");
                    carros.GPS_Update_True(row_614["id_carro"].ToString());
                }
            }

            //# Carros con 6-15
            if (carros.GPS_615().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_615 in carros.GPS_615().Tables[0].Rows)
                {
                    gvGps.Rows.Add(row_615["id_carro"].ToString(), row_615["nombre"], "(6-15) -> " + row_615["id"] + "", "6-10", "6-14", "6-15");
                    carros.GPS_Update_True(row_615["id_carro"].ToString());
                }
            }

            //# Carros En Acto (6-3)
            if (carros.GPS_Expedientes().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_exp in carros.GPS_Expedientes().Tables[0].Rows)
                {
                    decimal CoordenadaX = Convert.ToDecimal(row_exp["puntoX"].ToString());
                    decimal CoordenadaY = Convert.ToDecimal(row_exp["puntoY"].ToString());

                    if (carros.GPS_63(Convert.ToInt32(CoordenadaX).ToString(), Convert.ToInt32(CoordenadaY).ToString()).Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row_63 in carros.GPS_63(Convert.ToInt32(CoordenadaX).ToString(), Convert.ToInt32(CoordenadaY).ToString()).Tables[0].Rows)
                        {
                            gvGps.Rows.Add(row_63["id_carro"].ToString(), row_63["nombre"], "(6-3) -> " + row_exp["clave"].ToString() + "", "6-10", "6-14", "6-15");
                            carros.GPS_Update_True(row_63["id_carro"].ToString());
                        }
                    }
                    //MessageBox.Show("Llamado  [" + row_exp["clave"].ToString() + "]  " + "CoordX [" + row_exp["puntoX"].ToString() + "]", "GEObit");
                }
            }

            //# Carros con Localización Indeterminada
            if (carros.GPS_NoEncontrados().Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row_NoEn in carros.GPS_NoEncontrados().Tables[0].Rows)
                {
                    gvGps.Rows.Add(row_NoEn["id_carro"].ToString(), row_NoEn["nombre"], "(6-13) ó ¿?", "6-10", "6-14", "6-15");
                }
            }
        }




        private void gvGps_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
        }

        private void gvGps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                ListadoCuarteles cuarteles = new ListadoCuarteles() { Id_carro = Convert.ToInt32(gvGps.CurrentRow.Cells[0].Value.ToString()) };
                cuarteles.ShowDialog();
                CargarGrilla();
            }

            if (e.ColumnIndex == 4)
            {
                Frm614 frm614 = new Frm614(gvGps.CurrentRow.Cells[1].Value.ToString(), Convert.ToInt32(gvGps.CurrentRow.Cells[0].Value.ToString()));
                frm614.ShowDialog();
                CargarGrilla();
            }

            if (e.ColumnIndex == 5)
            {
                Frm615 frm614 = new Frm615(gvGps.CurrentRow.Cells[1].Value.ToString(), Convert.ToInt32(gvGps.CurrentRow.Cells[0].Value.ToString()));
                frm614.ShowDialog();
                CargarGrilla();
            }
        }

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            z_carros carros = new z_carros();
            foreach (var control in grpbx_opciones.Controls)
            {
                RadioButton radio = control as RadioButton;
                if (radio != null && radio.Checked)
                {
                    //MessageBox.Show("Opción  [" + radio.Name.ToString() + "]", "GEObit");
                    carros.GPS_Update_False();

                    if (radio.Name.ToString() == "rbtn_63")
                    {
                        gvGps.Rows.Clear();
                        Carros_610(false);
                        Carros_614(false);
                        Carros_615(false);
                        Carros_613(false);
                        Carros_63(true);
                    }

                    if (radio.Name.ToString() == "rbtn_610")
                    {
                        gvGps.Rows.Clear();
                        Carros_614(false);
                        Carros_615(false);
                        Carros_613(false);
                        Carros_63(false);
                        Carros_610(true);
                    }

                    if (radio.Name.ToString() == "rbtn_614")
                    {
                        gvGps.Rows.Clear();
                        Carros_615(false);
                        Carros_613(false);
                        Carros_63(false);
                        Carros_610(false);
                        Carros_614(true);
                    }

                    if (radio.Name.ToString() == "rbtn_615")
                    {
                        gvGps.Rows.Clear();
                        Carros_613(false);
                        Carros_63(false);
                        Carros_610(false);
                        Carros_614(false);
                        Carros_615(true);
                    }

                    if (radio.Name.ToString() == "rbtn_613")
                    {
                        gvGps.Rows.Clear();
                        Carros_63(false);
                        Carros_610(false);
                        Carros_614(false);
                        Carros_615(false);
                        Carros_613(true);
                    }

                    if (radio.Name.ToString() == "rbtn_todos")
                    {
                        gvGps.Rows.Clear();
                        Carros_63(true);
                        Carros_610(true);
                        Carros_614(true);
                        Carros_615(true);
                        Carros_613(true);
                    }
                }
            }
        }

        //# Exportar Grilla a Excel
        private void Export2Excel(string nombre)
        {
            //try
            {
                const string fic = @"C:\comander\GPS\gps_10_0_1.xls";
                StreamWriter sw = new StreamWriter(fic);
                
                
                //ListEmergencias is nothing but the listview control name
                //var sw = new StreamWriter(nombre, false) { AutoFlush = true };

                //# Agregar los Nombres de Columna
                for (int col = 1; col < gvGps.Columns.Count+1; col++)
                {
                    sw.Write( /*"\t" + */" " + gvGps.Columns[col-1].HeaderText + ";");  //listEmergencias.Columns[col].Text + ";");   //gvGps.CurrentRow.Cells[1].Value.ToString()
                }

                int rowIndex = 1;
                int row;
                ////# Por cada Fila
                //for (row = 0; row < listEmergencias.Items.Count; row++)
                //{
                //    if (rowIndex <= listEmergencias.Items.Count)
                //        rowIndex++;
                //    string st1 = "\n";
                //    //# Por cada Columna
                //    for (int col = 0; col < listEmergencias.Items[row].SubItems.Count; col++)
                //    {
                //        st1 = st1 /*+ "\t"*/+ listEmergencias.Items[row].SubItems[col].Text + ";";
                //    }
                //    sw.Write(st1);
                //}

                //# Por cada Fila
                for (row = 0; row < gvGps.RowCount-1; row++)
                {
                    //if (rowIndex <= gvGps.Items.Count)
                    //    rowIndex++;
                    string st1 = "\n";
                    //# Por cada Columna
                    for (int col = 0; col < gvGps.Columns.Count; col++)
                    {
                        st1 = st1 /*+ "\t"*/+ gvGps.Rows[row].Cells[col].Value.ToString() + ";";
                    }
                    sw.Write(st1);
                }
                sw.Close();
            }
            //catch (Exception ex)
            //{
            //    Log.ShowAndLog(ex);
            //}
        }

        //# Exportar Grilla a Excel
        //private void Export2Excel_v2(string nombre)
        //{
        //    //try
        //    {

        //        // creating Excel Application
        //        Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


        //        // creating new WorkBook within Excel application
        //        Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


        //        // creating new Excelsheet in workbook
        //        Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

        //        // see the excel sheet behind the program
        //        app.Visible = true;

        //        // get the reference of first sheet. By default its name is Sheet1.
        //        // store its reference to worksheet
        //        worksheet = workbook.Sheets["Sheet1"];
        //        worksheet = workbook.ActiveSheet;

        //        // changing the name of active sheet
        //        worksheet.Name = "Exported from gridview";


        //        // storing header part in Excel
        //        //for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
        //        //{
        //        //    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
        //        //}
        //        //# Agregar los Nombres de Columna
        //        for (int col = 1; col < gvGps.Columns.Count + 1; col++)
        //        {
        //            worksheet.Cells[1, col] = gvGps.Columns[col - 1].HeaderText;
        //        }
                
                
        //        //OK const string fic = @"C:\comander\GPS\gps_10_0_1.xls";
        //        //Ok StreamWriter sw = new StreamWriter(fic);


        //        //ListEmergencias is nothing but the listview control name
        //        //var sw = new StreamWriter(nombre, false) { AutoFlush = true };

        //        //# Agregar los Nombres de Columna
        //        //for (int col = 1; col < gvGps.Columns.Count + 1; col++)
        //        //{
        //        //    sw.Write( /*"\t" + */" " + gvGps.Columns[col - 1].HeaderText + ";");  //listEmergencias.Columns[col].Text + ";");   //gvGps.CurrentRow.Cells[1].Value.ToString()
        //        //}

        //        int rowIndex = 1;
        //        int row;


        //        //# Por cada Fila
        //        for (row = 0; row < gvGps.RowCount - 1; row++)
        //        {
        //            //if (rowIndex <= gvGps.Items.Count)
        //            //    rowIndex++;
        //            string st1 = "\n";
        //            //# Por cada Columna
        //            for (int col = 0; col < gvGps.Columns.Count; col++)
        //            {
        //                worksheet.Cells[row + 2, col + 1] = gvGps.Rows[row].Cells[col].Value.ToString();
        //            }
        //        }

        //        // save the application
        //        workbook.SaveAs(@"C:\comander\GPS\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        //        // Exit from the application
        //        app.Quit();


        //    }
        //    //catch (Exception ex)
        //    //{
        //    //    Log.ShowAndLog(ex);
        //    //}
        //}



        private void btn_Exportar_Excel_Click(object sender, EventArgs e)
        {
            string nombre = Path.GetTempPath() + @"\resumen.xls";
            //Export2Pdf(nombre);
            //Export2Excel_v2(nombre);
            //var em = new EnviarMailForm { Attachment = nombre };
            //em.ShowDialog();
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

                string filename = "ReporteGPS.pdf";

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


            PdfPTable datatable = new PdfPTable(gvGps.ColumnCount);


            //asignamos algunas propiedades para el diseño del pdf

            datatable.DefaultCell.Padding = 3;

            float[] headerwidths = GetTamañoColumnas(gvGps);


            datatable.SetWidths(headerwidths);


            datatable.WidthPercentage = 100;


            datatable.DefaultCell.BorderWidth = 2;


            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;




            //SE GENERA EL ENCABEZADO DE LA TABLA EN EL PDF


            for (int i = 0; i < gvGps.ColumnCount; i++)
            {


                datatable.AddCell(gvGps.Columns[i].HeaderText);


            }




            datatable.HeaderRows = 1;


            datatable.DefaultCell.BorderWidth = 1;




            //SE GENERA EL CUERPO DEL PDF

            iTextSharp.text.Font fGrilla = new iTextSharp.text.Font();
            fGrilla.Size = 10;
            for (int i = 0; i < gvGps.RowCount; i++)
            {


                for (int j = 0; j < gvGps.ColumnCount; j++)
                {


                    datatable.AddCell(new iTextSharp.text.Paragraph(gvGps[j, i].Value.ToString(), fGrilla));


                }


                datatable.CompleteRow();


            }
            iTextSharp.text.Font fTitulo = new iTextSharp.text.Font();
            fTitulo.Size = 20;

            iTextSharp.text.Font fDescripcion = new iTextSharp.text.Font();
            fDescripcion.Size = 10;

            document.Add(new iTextSharp.text.Paragraph("Cuerpo de Bomberos de Santiago", fTitulo));
            document.Add(new iTextSharp.text.Paragraph("Texto chico", fDescripcion));
            document.Add(new iTextSharp.text.Paragraph(" "));
            document.Add(datatable);


            document.Add(new iTextSharp.text.Paragraph(" "));
            document.Add(new iTextSharp.text.Paragraph("______________________________"));
            document.Add(new iTextSharp.text.Paragraph("     Firma Operadora Nº " + textBox1.Text));

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
