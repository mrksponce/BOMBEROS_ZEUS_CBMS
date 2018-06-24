using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace PruebaEquipos
{
    public partial class PruebaEquiposForm : Form
    {
        public PruebaEquiposForm()
        {
            InitializeComponent();
        }

        private void FormPrueba_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.prueba_equipos_32.GetHicon());

            // hora y saludo
            labelHora.Text = string.Format(Settings.Default.Titulo, DateTime.Now.ToShortTimeString());

            //carros!
            int largo = new z_tipo_carro().getCantidad();
            DataSet carros = new z_carros().Getz_carrosTodosDisponiblesEnLlamado();

            DataTable dt = carros.Tables[0].Clone();

            // filtrar carros
            if (Settings.Default.UsarCarros)
            {
                foreach (DataRow dr in carros.Tables[0].Rows)
                {
                    if (Settings.Default.CarrosSeleccionados.Contains(dr["id_tipo_carro"]))
                    {
                        dt.ImportRow(dr);
                    }
                }
            }
            else
            {
                dt = carros.Tables[0];
            }

            DataSet tipo_carros = new z_tipo_carro().Getz_tipo_carro();
            int i = 0;
            tableLayoutPanel1.ColumnCount = largo;

            foreach (DataRow tipo in tipo_carros.Tables[0].Rows)
            {
                DataRow[] c = dt.Select("id_tipo_carro=" + tipo["id_tipo_carro"], "id_compania");
                int j = 0;
                foreach (DataRow carro in c)
                {
                    var cb = new CheckBox
                                 {
                                     Text = ((string) carro["nombre"]),
                                     Tag = ((int) carro["id_carro"]),
                                     AutoSize = true
                                 };
                    tableLayoutPanel1.Controls.Add(cb, i, j++);
                }
                //tableLayoutPanel1.ColumnStyles[i] = new ColumnStyle(SizeType.AutoSize);
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //grabar
            try
            {
                foreach (CheckBox c in tableLayoutPanel1.Controls)
                {
                    //# Registrar Sólo las Radios Disconformes
                    if (c.Checked == false)
                    {
                        var pe = new z_prueba_equipo(DateTime.Now, (int)c.Tag, c.Checked);
                        pe.addz_prueba_equipo(pe);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                MessageBox.Show("No se pudo completar la operación debido a un error de Base de Datos.",
                                "Sistema ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Close();
        }
    }
}