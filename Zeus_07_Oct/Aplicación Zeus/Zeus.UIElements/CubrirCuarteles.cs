using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class CubrirCuarteles : Form
    {
        public CubrirCuarteles()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin { get; set; }

        private void CubrirCuarteles_Load(object sender, EventArgs e)
        {
            // cargar datos
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void CargarDatos()
        {
            var carro = new z_carros();
            var comp = new z_companias();

            listCarros.DisplayMember = "nombre";
            listCarros.ValueMember = "id_carro";
            //listCarros.DataSource = carro.Getz_carrosDisponibles().Tables[0];
            //# Solo para Clave 0-11
            listCarros.DataSource = carro.Getz_carrosDisponibles011().Tables[0];

            comboCompania.DisplayMember = "id_compania";
            comboCompania.ValueMember = "id_compania";
            comboCompania.DataSource = comp.Getz_companias011().Tables[0];

            dataGridActuales.DataSource = carro.GetCarrosCubriendo().Tables[0];

            comboCompania_m.DisplayMember = "id_compania";
            comboCompania_m.ValueMember = "id_compania";
            comboCompania_m.DataSource = comp.Getz_companias011().Tables[0];
        }

        private void btnCubrir_Click(object sender, EventArgs e)
        {
            if (listCarros.SelectedIndex != -1 && comboCompania.SelectedIndex != -1)
            {
                try
                {
                    Carro.CubrirCuartel((int) listCarros.SelectedValue, (int) comboCompania.SelectedValue);
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar carro y compañía para realizar esta operación", "Mensaje de Zeus");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridActuales.SelectedRows.Count != 0 && comboCompania_m.SelectedIndex != -1)
            {
                try
                {
                    Carro.CubrirCuartel((int) dataGridActuales.SelectedRows[0].Cells["id_carro"].Value,
                                        (int) comboCompania_m.SelectedValue);
                    BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                "0-11: Carro " + dataGridActuales.SelectedRows[0].Cells["nombre"].Value +
                                                "cubre cuartel " + (int) comboCompania.SelectedValue + " compañía");
                    CargarDatos();
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar carro y compañía para realizar esta operación", "Mensaje de Zeus");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridActuales.SelectedRows.Count != 0)
            {
                if (
                    MessageBox.Show("¿Desea eliminar esta asignación?", "Confirmación", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Carro.EliminarCubrirCuartel((int) dataGridActuales.SelectedRows[0].Cells["id_carro"].Value);
                        BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                    "0-11: Carro " +
                                                    dataGridActuales.SelectedRows[0].Cells["nombre"].Value +
                                                    " vuelve a su cuartel.");
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar carro para realizar esta operación", "Mensaje de Zeus");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}