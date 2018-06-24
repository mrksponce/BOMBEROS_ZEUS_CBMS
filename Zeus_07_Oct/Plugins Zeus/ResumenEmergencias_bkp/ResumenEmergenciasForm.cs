using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using Zeus.Data;
using Zeus.Util;
using Font=System.Drawing.Font;
using Orientation=MigraDoc.DocumentObjectModel.Orientation;

namespace ResumenEmergencias
{
    public partial class ResumenEmergenciasForm : Form
    {
        private DateTime fechaGeneracion;

        public ResumenEmergenciasForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResumenEmergenciasForm_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.resumen_actos_servicios_32.GetHicon());
            radio24Horas.Checked = true;

            CargarDatos(true);
        }

        private void CargarDatos(bool dia)
        {
            try
            {
                DataSet ds;
                if (dia)
                {
                    ds = new e_expedientes().GetExpedientes24Horas();
                    fechaGeneracion = DateTime.Now;
                }
                else
                {
                    ds = new e_expedientes().GetExpedientes24Horas(dateDesde.Value, dateHasta.Value);
                }
                listEmergencias.Items.Clear();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    // informacion del llamado
                    var li = new ListViewItem
                                 {
                                     BackColor = SystemColors.Info,
                                     Font = new Font(Font, FontStyle.Bold),
                                     Text = ((DateTime) dr["fecha"]).ToString("dd/MM/yyy HH:mm")
                                 };
                    li.SubItems.Add(" " + (string) dr["clave"]);
                    li.SubItems.Add((string) dr["esquina"]);
                    li.SubItems.Add(((int) dr["correlativo"]).ToString());
                    if ((int) dr["correlativo_iioo"] != 0)
                    {
                        li.SubItems.Add(((int) dr["correlativo_iioo"]).ToString());
                    }
                    else
                    {
                        li.SubItems.Add("-");
                    }
                    if ((int) dr["correlativo_redtic"] != 0)
                    {
                        li.SubItems.Add(((int) dr["correlativo_redtic"]).ToString());
                    }
                    else
                    {
                        li.SubItems.Add("-");
                    }
                    li.SubItems.Add(Convert.ToString(dr["voluntario"]));
                    listEmergencias.Items.Add(li);

                    // informacion de los carros
                    DataSet bitacora = new bitacora_llamados().Getbitacora_llamados_expediente((int) dr["id_expediente"]);
                    foreach (string carro in ((string) dr["material_despachado"]).Split(','))
                    {
                        var lv = new ListViewItem(new[] {"", "", "", "", "", "", ""});
                        // nombre
                        lv.SubItems.Add(carro);
                        // 6-0
                        DataRow[] row = bitacora.Tables[0].Select("nombre='" + carro + "' and evento like '6-0%'");
                        if (row.Length > 0)
                        {
                            lv.SubItems.Add(((DateTime) row[0]["fecha"]).ToShortTimeString());
                        }
                        else
                        {
                            lv.SubItems.Add("-");
                        }

                        // 6-3
                        row = bitacora.Tables[0].Select("nombre='" + carro + "' and evento='6-3'");
                        if (row.Length > 0)
                        {
                            lv.SubItems.Add(((DateTime) row[0]["fecha"]).ToShortTimeString());
                        }
                        else
                        {
                            lv.SubItems.Add("-");
                        }
                        //6-7
                        row = bitacora.Tables[0].Select("nombre='" + carro + "' and evento='6-7'");
                        if (row.Length > 0)
                        {
                            lv.SubItems.Add(((DateTime) row[0]["fecha"]).ToShortTimeString());
                        }
                        else
                        {
                            lv.SubItems.Add("-");
                        }

                        // 6-8
                        row = bitacora.Tables[0].Select("nombre='" + carro + "' and evento='6-8'");
                        if (row.Length > 0)
                        {
                            lv.SubItems.Add(((DateTime) row[0]["fecha"]).ToShortTimeString());
                        }
                        else
                        {
                            lv.SubItems.Add("-");
                        }

                        // 6-9
                        row = bitacora.Tables[0].Select("nombre='" + carro + "' and evento='6-9'");
                        if (row.Length > 0)
                        {
                            lv.SubItems.Add(((DateTime) row[0]["fecha"]).ToShortTimeString());
                        }
                        else
                        {
                            lv.SubItems.Add("-");
                        }

                        // 6-10
                        row = bitacora.Tables[0].Select("nombre='" + carro + "' and evento='6-10'");
                        if (row.Length > 0)
                        {
                            lv.SubItems.Add(((DateTime) row[0]["fecha"]).ToShortTimeString());
                        }
                        else
                        {
                            lv.SubItems.Add("-");
                        }

                        listEmergencias.Items.Add(lv);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void Export2Excel(string nombre)
        {
            //try
            {
                //ListEmergencias is nothing but the listview control name
                var sw = new StreamWriter(nombre, false) {AutoFlush = true};

                for (int col = 0; col < listEmergencias.Columns.Count; col++)
                {
                    sw.Write( /*"\t" + */" " + listEmergencias.Columns[col].Text + ";");
                }

                int rowIndex = 1;
                int row;
                for (row = 0; row < listEmergencias.Items.Count; row++)
                {
                    if (rowIndex <= listEmergencias.Items.Count)
                        rowIndex++;
                    string st1 = "\n";
                    for (int col = 0; col < listEmergencias.Items[row].SubItems.Count; col++)
                    {
                        st1 = st1 /*+ "\t"*/+ listEmergencias.Items[row].SubItems[col].Text + ";";
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

        private void Export2Pdf(string nombre)
        {
            var document = new Document
                               {
                                   Info =
                                       {
                                           Title = "Resumen Emergencias",
                                           Subject = "Contiene el resumen de emergencias de un período determinado.",
                                           Author = "Sistema ZEUS"
                                       }
                               };

            // estilos
            Style style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 10;
            style.Font.Bold = true;

            style = document.Styles["Heading2"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 10;
            style.Font.Bold = false;

            Section s = document.AddSection();
            s.PageSetup.PageFormat = PageFormat.Legal;
            s.PageSetup.TopMargin = Unit.FromCentimeter(1.5);
            s.PageSetup.Orientation = Orientation.Landscape;

            // Agregar inicio
#if CBMS
            Paragraph p = s.AddParagraph("Cuerpo de Bomberos Metropolitano Sur\nSistema ZEUS","Heading1");
#elif CBQN
            Paragraph p = s.AddParagraph("Cuerpo de Bomberos Quinta Normal\nSistema ZEUS", "Heading1");
#endif
            p.Format.Borders.Bottom.Width = 1;

            p = s.AddParagraph("", "Heading1");
            if (radio24Horas.Checked)
            {
                p.AddText(string.Format("\n\nResumen de Emergencias. Desde {0} hasta {1}. Generado en {2}",
                                        fechaGeneracion.AddDays(-1), fechaGeneracion, DateTime.Now));
            }
            else
            {
                p.AddText(string.Format("\n\nResumen de Emergencias. Desde {0} hasta {1}. Generado en {2}",
                                        dateDesde.Value, dateHasta.Value, DateTime.Now));
            }
            p.Format.SpaceAfter = Unit.FromCentimeter(0.5);
            // crear la tabla
            var table = new Table {Borders = {Width = 0.75}};

            // agregar headers
            for (int col = 0; col < listEmergencias.Columns.Count; col++)
            {
                switch (col)
                {
                    case 1:
                        table.AddColumn(Unit.FromCentimeter(1.6));
                        break;
                    case 2:
                    case 6:
                        table.AddColumn(Unit.FromCentimeter(5));
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        Column c = table.AddColumn(Unit.FromCentimeter(1.5));
                        c.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    default:
                        table.AddColumn();
                        break;
                }
            }

            Row row = table.AddRow();
            row.Shading.Color = Colors.LightGray;
            row.Style = "Heading2";
            for (int col = 0; col < listEmergencias.Columns.Count; col++)
            {
                row.Cells[col].AddParagraph(listEmergencias.Columns[col].Text);
            }

            // agregar datos!
            for (int rowc = 0; rowc < listEmergencias.Items.Count; rowc++)
            {
                row = table.AddRow();
                row.Style = "Heading2";
                if (listEmergencias.Items[rowc].Text != "")
                {
                    row.Shading.Color = Colors.LightYellow;
                }

                for (int col = 0; col < listEmergencias.Items[rowc].SubItems.Count; col++)
                {
                    row.Cells[col].AddParagraph(listEmergencias.Items[rowc].SubItems[col].Text);
                    if (col != 0 && col != 2 && col != 6)
                    {
                        row.Cells[col].Format.Alignment = ParagraphAlignment.Center;
                    }
                }
            }
            // agregar tabla al documento
            document.LastSection.Add(table);

            var renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always) {Document = document};

            var gpf = new GenerandoPdfForm {Nombre = nombre, Renderer = renderer};
            gpf.ShowDialog();
        }

        private void toxml()
        {
            var doc = new XmlDocument();
            doc.AppendChild(doc.CreateElement("Emergencias"));
            XmlElement root = doc.DocumentElement;
            foreach (ListViewItem li in listEmergencias.Items)
            {
                //nodo
                if (li.Text != "")
                {
                    XmlElement nodo = doc.CreateElement("Emergencia");

                    for (int i = 0; i < li.SubItems.Count; i++)
                    {
                        XmlAttribute att = doc.CreateAttribute("hola");
                        att.InnerXml = li.SubItems[i].Text;
                        nodo.Attributes.Append(att);
                    }
                    root.AppendChild(nodo);
                }
            }
            doc.Save(@"c:\doc.xls");
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos(radio24Horas.Checked);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = Path.GetTempPath() + @"\resumen.pdf";
            Export2Pdf(nombre);
            //Export2Excel(nombre);
            var em = new EnviarMailForm {Attachment = nombre};
            em.ShowDialog();
        }
    }
}