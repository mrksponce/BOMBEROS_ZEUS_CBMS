using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class Info71 : Form
    {
        private int id_expediente;

        public Info71()
        {
            InitializeComponent();
        }

        public int Id_expediente
        {
            get { return id_expediente; }
            set { id_expediente = value; }
        }

        private void Info71_Load(object sender, EventArgs e)
        {
            // obtener información
            var bl = new bitacora_llamados();
            DataSet ds = bl.Getbitacora_llamados_expediente(id_expediente);
            // hora desp
            DataRow[] dr = ds.Tables[0].Select("tipo='" + BitacoraLlamado.Despacho + "'", "fecha asc");
            textHoraDespacho.Text = dr.Length > 0 ? ((DateTime) dr[0]["fecha"]).TimeOfDay.ToString() : "No Disponible";

            // hora incendio
            dr = ds.Tables[0].Select("tipo='" + BitacoraLlamado.Incendio + "'", "fecha asc");
            textAlarmaIncendio.Text = dr.Length > 0 ? ((DateTime) dr[0]["fecha"]).TimeOfDay.ToString() : "No Disponible";

            // hora sit. controlada
            dr = ds.Tables[0].Select("tipo='" + BitacoraLlamado.Carro + "' and evento='6-7'", "fecha asc");
            textSitControlada.Text = dr.Length > 0 ? ((DateTime) dr[0]["fecha"]).TimeOfDay.ToString() : "No Disponible";


            // carros!
            ds = new e_carros_usados().Gete_carros_exp(id_expediente);
            var carro = new z_carros();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (string.Compare((string) row["seis"], "6-3") >= 0)
                {
                    //listLugar.Items.Add(carro.getObjectz_carros((int)row["id_carro"]).nombre);
                    textLugar.Text += ", " + carro.getObjectz_carros((int) row["id_carro"]).nombre;
                }
                else
                {
                    //listTransito.Items.Add(carro.getObjectz_carros((int)row["id_carro"]).nombre);
                    textTransito.Text += ", " + carro.getObjectz_carros((int) row["id_carro"]).nombre;
                }
            }
            textLugar.Text = textLugar.Text.Trim(',', ' ');
            textTransito.Text = textTransito.Text.Trim(',', ' ');

            ds = carro.Getz_carrosTodosDisponibles();
            dr = ds.Tables[0].Select("", "id_tipo_carro");
            foreach (DataRow row in dr)
            {
                textDisponible.Text += ", " + (string) row["nombre"];
            }
            textDisponible.Text = textDisponible.Text.Trim(',', ' ');
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}