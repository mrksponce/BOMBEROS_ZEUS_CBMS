using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;

namespace BoletinInformativo
{
    public partial class BoletinInformativoConfigForm : Form
    {
        public BoletinInformativoConfigForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // grabar y cerrar
            if (Validar())
            {
                Settings1.Default.UsarCarros = checkTipoCarro.Checked;
                Settings1.Default.UsarDias = checkTiempoFuera.Checked;
                if (checkTiempoFuera.Checked)
                {
                    Settings1.Default.NumDias = Convert.ToInt32(textDias.Text);
                }
                if (checkTipoCarro.Checked)
                {
                    Settings1.Default.CarrosSeleccionados = ObtenerTiposSeleccionados();
                }

                Settings1.Default.Save();
                Close();
            }
        }

        private bool Validar()
        {
            int d;
            if (checkTiempoFuera.Checked && !int.TryParse(textDias.Text, out d))
            {
                MessageBox.Show("Cantidad de días inválida.", "Faltan parámetros", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private ArrayList ObtenerTiposSeleccionados()
        {
            var al = new ArrayList();
            for (int i = 0; i < clTipoCarro.Items.Count; i++)
            {
                if (clTipoCarro.GetItemChecked(i))
                {
                    al.Add(((TipoCarro) clTipoCarro.Items[i]).Id);
                }
            }
            return al;
        }

        private void checkTipoCarro_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = checkTipoCarro.Checked;
            clTipoCarro.Enabled = checkTipoCarro.Checked;
        }

        private void checkTiempoFuera_CheckedChanged(object sender, EventArgs e)
        {
            label2.Enabled = checkTiempoFuera.Checked;
            label3.Enabled = checkTiempoFuera.Checked;
            textDias.Enabled = checkTiempoFuera.Checked;
        }

        private void BoletinInformativoConfigForm_Load(object sender, EventArgs e)
        {
            // icono
            Icon = Icon.FromHandle(Resources.boletin_informativo_32.GetHicon());

            // establecer valores por defecto
            checkTiempoFuera.Checked = Settings1.Default.UsarDias;
            checkTipoCarro.Checked = Settings1.Default.UsarCarros;
            textDias.Text = Settings1.Default.NumDias.ToString();

            if (Settings1.Default.CarrosSeleccionados == null)
            {
                Settings1.Default.CarrosSeleccionados = new ArrayList();
            }

            // cargar tipos de carro
            DataSet ds = new z_tipo_carro().Getz_tipo_carro();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                clTipoCarro.Items.Add(new TipoCarro((string) dr["tipo_carro_letra"], (int) dr["id_tipo_carro"]),
                                      isChecked((int) dr["id_tipo_carro"]));
            }
        }

        private static bool isChecked(int id)
        {
            foreach (int item in Settings1.Default.CarrosSeleccionados)
            {
                if (id == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}