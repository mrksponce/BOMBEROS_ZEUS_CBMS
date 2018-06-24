using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;

namespace CarroEspecialidades
{
    public partial class CarroEspecialidad : Form
    {
        private IZeusWin zeusWin;

        public CarroEspecialidad()
        {
            InitializeComponent();
            comboClaves.DisplayMember = "desc";
            comboClaves.ValueMember = "codigo_llamado";

            comboExpediente.DisplayMember = "esquina";
            comboExpediente.ValueMember = "id_expediente";
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        private void CarroEspecialidad_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.asignacion_carro_especialidad_32.GetHicon());
            var llam = new z_llamados();
            DataSet ds = llam.Getz_llamados_principal();
            comboClaves.DataSource = ds.Tables[0];

            // expediente seleccionado
            if (ZeusWin.IdExpediente != 0)
            {
                e_expedientes exp = new e_expedientes().getObjecte_expedientes(zeusWin.IdExpediente);
                comboClaves.SelectedValue = exp.codigo_principal;
                comboExpediente.SelectedValue = exp.id_expediente;
            }
        }

        private void comboClaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cargar expedientes para dicha clave
            if (comboClaves.SelectedIndex != -1)
            {
                var exp = new e_expedientes();
                DataSet ds = exp.Gete_expedientes_codigoprincipal((int) comboClaves.SelectedValue);
                comboExpediente.DataSource = ds.Tables[0];
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sector = new s_sector();
            if (!checkBox1.Checked)
            {
                if (comboExpediente.SelectedIndex != -1)
                {
                    sector =
                        sector.getObjects_sector_area((int) ((DataRowView) comboExpediente.SelectedItem).Row["id_area"]);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un expediente", "Error de Selección", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
            }
            switch (comboEspecialidad.SelectedIndex)
            {
                case 0:
                    var haz = new s_hazmat();
                    fillCarros(haz.Gets_hazmat_sector(sector.id_sector));
                    break;
                case 1:
                    var mec = new s_mecanica();
                    fillCarros(mec.Gets_mecanica_sector(sector.id_sector));
                    break;
                case 2:
                    var bom = new s_bomba();
                    fillCarros(bom.Gets_bomba_sector(sector.id_sector));
                    break;
                case 3:
                    var res = new s_rescate();
                    fillCarros(res.Gets_rescate_sector(sector.id_sector));
                    break;
                case 4:
                    var pa = new s_puesto_aire();
                    fillCarros(pa.Gets_puesto_aire_sector(sector.id_sector));
                    break;
                case 5:
                    var ru = new s_rescate_urbano();
                    fillCarros(ru.Gets_rescate_urbano_sector(sector.id_sector));
                    break;
                case 6:
                    var cis = new s_cisternas_z();
                    fillCarros(cis.Gets_cisternas_z_sector(sector.id_sector));
                    break;
                case 7:
                    var alj = new s_aljibe();
                    fillCarros(alj.Gets_aljibe_sector(sector.id_sector));
                    break;

                default:
                    break;
            }
        }

        private void fillCarros(DataSet ds)
        {
            listCarros.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var li = new ListViewItem(dr["prioridad"].ToString());
                li.SubItems.Add((string) dr["nombre"]);
                li.SubItems.Add((string) dr["telefono"]);
                listCarros.Items.Add(li);
            }
            listCarros.Columns[1].Width = 190;
            lblDetalle.Text = "";
        }

        private void listCarros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCarros.SelectedIndices.Count != 0 && listCarros.SelectedIndices[0] != -1)
            {
                lblDetalle.Text = listCarros.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (ZeusWin.LastGeo.IsEmpty())
                {
                    MessageBox.Show("No hay un punto geocodificado disponible");
                    checkBox1.Checked = false;
                }
                else
                {
                    comboClaves.Enabled = false;
                    comboExpediente.Enabled = false;
                }
            }
            else
            {
                comboExpediente.Enabled = true;
                comboClaves.Enabled = true;
            }
        }
    }
}