using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class Coincidencias : Form
    {
        private static int p1;
        private static int p2;
        private static string c1;
        private static string c2;
        public Coincidencias(/*Geocodificacion.*/GeoReferencia[] DC, MapWindow.Interfaces.IMapWin mw, List<string>comunas)
        {
            InitializeComponent();
            this.MapWin = mw;
            this.DC = DC;
            // setear columnas
            if (DC[0].TipoRef == /*Geocodificacion.*/TipoReferencia.Altura)
            {
                listCalles.Columns.Add(HeaderConAltura[0]);
                listCalles.Columns.Add(HeaderConAltura[1]);
                listCalles.Columns.Add(HeaderConAltura[2]);
                listCalles.Columns[0].Width = (listCalles.Width * 49 / 100);
                listCalles.Columns[1].Width = (listCalles.Width * 20 / 100);
                listCalles.Columns[2].Width = (listCalles.Width * 30 / 100);
            }
            if (DC[0].TipoRef ==/*Geocodificacion.*/TipoReferencia.Esquina)
            {
                listCalles.Columns.Add(HeaderInterseccion[0]);
                listCalles.Columns.Add(HeaderInterseccion[1]);
                listCalles.Columns.Add(HeaderInterseccion[2]);
                listCalles.Columns[0].Width = (listCalles.Width * 35 / 100);
                listCalles.Columns[1].Width = (listCalles.Width * 35 / 100);
                listCalles.Columns[2].Width = (listCalles.Width * 29 / 100);

            }
            if (DC[0].TipoRef == /*Geocodificacion.*/TipoReferencia.Tramo)
            {
                listCalles.Columns.Add(HeaderTramo[0]);
                listCalles.Columns.Add(HeaderTramo[1]);
                listCalles.Columns.Add(HeaderTramo[2]);
                listCalles.Columns[0].Width = (listCalles.Width * 20 / 100);
                listCalles.Columns[1].Width = (listCalles.Width * 49 / 100);
                listCalles.Columns[2].Width = (listCalles.Width * 30 / 100);
            }

            // agregar coincidencias
            foreach (/*Geocodificacion.*/GeoReferencia gr in DC)
            {
                ListViewItem Li = listCalles.Items.Add(gr.Dato1);
                Li.SubItems.Add(gr.Dato2);
                Li.SubItems.Add(gr.Dato3);
                switch (gr.TipoRef)
                {
                    case /*Geocodificacion.*/TipoReferencia.Altura:
                    case /*Geocodificacion.*/TipoReferencia.Esquina:
                        Li.BackColor = Color.LightGreen;
                        break;
                    case /*Geocodificacion.*/TipoReferencia.Tramo:
                        Li.BackColor = Color.LightYellow;
                        break;
                }

                /*
                const string fic = @"Plugins\Referencias.txt";
                string texto3 = gr.Punto1.ToString();
                string texto4 = gr.Punto2.ToString();

                System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
                sw.WriteLine(texto1);
                sw.WriteLine(texto2);
                sw.WriteLine("-----------------------------");
                sw.WriteLine(texto3);
                sw.WriteLine(texto4);
                sw.Close();
                  
                 */
            }
            //if (DC.Length == 1)
            //    listCalles.Items[0].Selected = true;

            // mostrar primero
            if (DC.Length != 0)
            {
                Mostrar(0);
                listCalles.Items[0].Selected = true;
                listCalles.Select();
            }    
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        

        

        private string[] HeaderConAltura = { "Calle", "Número", "Comuna" };
        private string[] HeaderInterseccion = { "Calle 1", "Calle 2", "Comuna" };
        private string[] HeaderTramo ={ "Tipo Calle", "Nombre", "Comuna" };

        private /*Geocodificacion.*/GeoReferencia[] DC;
        private MapWindow.Interfaces.IMapWin MapWin;
        private Direccion direccion;

        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            
            if (listCalles.SelectedIndices.Count == 0)
                MessageBox.Show("Debe seleccionar un resultado para desplegar", "Falta Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Mostrar(listCalles.SelectedIndices[0]);
            }

            // CODIGO AGREGADO POR MARCOS PONCE RODRIGUEZ (MRKSPONCE)
            /*Claves6_3xx clav = new Claves6_3xx();
            clav.Coor1 = p1;
            clav.Coor2 = p2;
            clav.Calle1 = c1;
            clav.Calle2 = c2;

            if (clav.ShowDialog() == DialogResult.OK)
            { 
                
            }*/
        }

        private void Mostrar(int index)
        {
            direccion = new Direccion();

            switch (DC[index].TipoRef)
            {
                case /*Geocodificacion.*/TipoReferencia.Altura:
                    direccion.Calle1 = DC[index].Dato1;
                    direccion.Comuna = DC[index].Dato3;
                    direccion.Ubicacion = DC[index].Punto1;
                    direccion.Altura = int.Parse(DC[index].Dato2);
                    goto siguiente;

                case /*Geocodificacion.*/TipoReferencia.Esquina:
                    direccion.Calle1 = DC[index].Dato1;
                    direccion.Calle2 = DC[index].Dato2;
                    direccion.Comuna = DC[index].Dato3;
                    direccion.Ubicacion = DC[index].Punto1;
                siguiente:
                    PlugData.ZoomToPoint(DC[index].Punto1);
                    // marcar imagen
                    // dibujar
                    if (PlugData.DrDireccion.HasValue)
                        MapWin.View.Draw.ClearDrawing(PlugData.DrDireccion.Value);
                    PlugData.DrDireccion = MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
                    MapWin.View.Draw.DrawCircle(DC[index].Punto1.X, DC[index].Punto1.Y, 10, Color.Red, true);
                    p1 = Convert.ToInt32(DC[index].Punto1.X);
                    p2 = Convert.ToInt32(DC[index].Punto1.Y);
                    c1 = DC[index].Dato1;
                    c2 = DC[index].Dato2;
                    break;
                case /*Geocodificacion.*/TipoReferencia.Tramo:
                    direccion.Calle1 = DC[index].Dato1 + " " + DC[index].Dato2;
                    direccion.Comuna = DC[index].Dato3;

                    MapWin.View.Draw.ClearDrawings();
                    PlugData.ZoomToLocation(DC[index].Punto1, DC[index].Punto2);
                    // seleccionar
                    PlugData.SelectCalle(DC[index].Punto1, DC[index].Punto2, DC[index].Dato2, DC[index].Dato1);
                    break;
                default:
                    break;
            }
            PlugData.Direccion = direccion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if (listCalles.SelectedIndices.Count == 0)
                MessageBox.Show("Debe seleccionar un resultado", "Falta Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                btnGenerar.Blink = false;
                direccion = new Direccion();
                // establecer dirección y cerrar diálogos
                switch (DC[listCalles.SelectedIndices[0]].TipoRef)
                {
                    case /*Geocodificacion.*/TipoReferencia.Tramo:
                        ok = false;
                        direccion.Calle1 = DC[listCalles.SelectedIndices[0]].Dato1 + " " + DC[listCalles.SelectedIndices[0]].Dato2;
                        direccion.Comuna = DC[listCalles.SelectedIndices[0]].Dato3;
                        break;
                    case /*Geocodificacion.*/TipoReferencia.Altura:
                        direccion.Calle1 = DC[listCalles.SelectedIndices[0]].Dato1;
                        direccion.Comuna = DC[listCalles.SelectedIndices[0]].Dato3;
                        direccion.Ubicacion = DC[listCalles.SelectedIndices[0]].Punto1;
                        direccion.Altura = int.Parse(DC[listCalles.SelectedIndices[0]].Dato2);
                        break;
                    case /*Geocodificacion.*/TipoReferencia.Esquina:
                        direccion.Calle1 = DC[listCalles.SelectedIndices[0]].Dato1;
                        direccion.Calle2 = DC[listCalles.SelectedIndices[0]].Dato2;
                        direccion.Comuna = DC[listCalles.SelectedIndices[0]].Dato3;
                        direccion.Ubicacion = DC[listCalles.SelectedIndices[0]].Punto1;                       
                        break;
                    
                    default:
                        break;
                }
                // generar expediente
                PlugData.Direccion = direccion;
                if (ok)
                {
                    Expediente expediente = new Expediente();
                    DialogResult dr = expediente.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un punto para poder generar un expediente (ingresar una coincidencia, o generarlo manualmente)", "Sistema ZEUS");
                }
            }
        }

        private void listCalles_Click(object sender, EventArgs e)
        {
            btnMostrar_Click(this, new EventArgs());
        }

        private void listCalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGenerar.Blink = true;
        }

        private void btn_Asignar_Click(object sender, EventArgs e)
        {
            Claves6_3xx clav = new Claves6_3xx();
            clav.Coor1 = p1;
            clav.Coor2 = p2;
            clav.Calle1 = c1;
            clav.Calle2 = c2;

            if (clav.ShowDialog() == DialogResult.OK)
            {
                clav.Close();
            }
        }
    }
}