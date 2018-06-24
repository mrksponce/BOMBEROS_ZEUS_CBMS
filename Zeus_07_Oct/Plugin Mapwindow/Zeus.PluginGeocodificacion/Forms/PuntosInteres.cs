using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class PuntosInteres : Form
    {
        public PuntosInteres()
        {
            InitializeComponent();

            // cargar y agregar
            Datos = new PostgresDataAccess.DataAccess();
            Pi = Datos.ObtenerPuntosInteres();
            int i = 0;
            foreach (PostgresDataAccess.PuntoInteres p in Pi)
            {
                RadioButton r = new RadioButton();
                r.Name = r.Text = p.RadioText;
                r.Location = new Point(6, 19 + r.Size.Height * i++);
                r.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
                groupTipo.Controls.Add(r);
                groupZoom.Location = new Point(groupZoom.Location.X, groupZoom.Location.Y + r.Size.Height+1);
                btnMostrar.Location = new Point(btnMostrar.Location.X, btnMostrar.Location.Y + r.Size.Height+1);
                this.Height += 10;
            }

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= Pi.GetUpperBound(0); i++)
            {
                if (((RadioButton)sender).Name == Pi[i].RadioText && ((RadioButton)sender).Checked == true)
                {
                    Etiqueta1.Text = Pi[i].Label1;
                    Etiqueta2.Text = Pi[i].Label2;
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(Pi[i].Combo1.Split(','));
                    comboBox2.Items.Clear();
                    selected = i;
                    goto ok;
                }
            }
        ok:
            return;
        }


        PostgresDataAccess.DataAccess Datos;
        PostgresDataAccess.PuntoInteres[] Pi;
        PostgresDataAccess.PInteres[] Pis;
        int selected = -1;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            Pis = Datos.ObtenerPInteres(comboBox1.SelectedIndex + 1, Pi[selected].Tabla);
            if (Pis!=null)
            {
                foreach (PostgresDataAccess.PInteres pi in Pis)
                {
                    comboBox2.Items.Add(pi.Nombre);
                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                PlugData.ZoomToPoint(Pis[comboBox2.SelectedIndex].Ubicacion);
                PlugData.MapWin.View.Draw.ClearDrawing(PlugData.DrPuntoInteres);
                PlugData.DrPuntoInteres = PlugData.MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
                PlugData.MapWin.View.Draw.DrawCircle(Pis[comboBox2.SelectedIndex].Ubicacion.X, Pis[comboBox2.SelectedIndex].Ubicacion.Y, 10, Color.Green, true);

                Forms.Expediente2 exp2 = new Expediente2(Pis[comboBox2.SelectedIndex].Ubicacion.ToString());
                exp2.ShowDialog();
            }
        }
    }
}