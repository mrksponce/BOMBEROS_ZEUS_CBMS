using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;

namespace PruebaEquipos
{
    public partial class PruebaEquiposConfigForm : Form
    {
        public PruebaEquiposConfigForm()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // grabar y cerrar
            Settings.Default.UsarCarros = checkTipoCarro.Checked;

            if (checkTipoCarro.Checked)
            {
                Settings.Default.CarrosSeleccionados = ObtenerTiposSeleccionados();
            }

            Settings.Default.Save();
            Close();
        }

        private void FormPruebaAdmin_Load(object sender, EventArgs e)
        {
            // icono
            Icon = Icon.FromHandle(Resources.prueba_equipos_32.GetHicon());

            // establecer valores por defecto
            checkTipoCarro.Checked = Settings.Default.UsarCarros;

            if (Settings.Default.CarrosSeleccionados == null)
            {
                Settings.Default.CarrosSeleccionados = new ArrayList();
            }

            // cargar tipos de carro
            DataSet ds = new z_tipo_carro().Getz_tipo_carro();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                clTipoCarro.Items.Add(new TipoCarro((string) dr["tipo_carro_letra"], (int) dr["id_tipo_carro"]),
                                      isChecked((int) dr["id_tipo_carro"]));
            }
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

        private static bool isChecked(int id)
        {
            foreach (int item in Settings.Default.CarrosSeleccionados)
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