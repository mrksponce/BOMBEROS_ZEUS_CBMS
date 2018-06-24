using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class BitacoraExpedientesTabControl : BaseControl
    {
        private int id;
        private TipoElemento tipo;
        private z_carros carros;

        public BitacoraExpedientesTabControl()
        {
            InitializeComponent();
            GetCarros();
            ddl2.Visible = false;
        }

        protected void GetCarros()
        {
            carros = new z_carros();
            ddlCarrosBitacoraExp.DisplayMember = "nombre";
            ddlCarrosBitacoraExp.ValueMember = "id_carro";
            ddlCarrosBitacoraExp.DataSource = carros.GetCarros().Tables[0];

            ddl2.DisplayMember = "nombre";
            ddl2.ValueMember = "id_carro";
            ddl2.DataSource = carros.GetCarros().Tables[0];
        }

        public void OnSeleccionHandler(object sender, DataEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    id = e.Id;
                    tipo = e.TipoElemento;
                    CargarBitacora();
                }
                else
                {
                    foreach (DataGridViewRow o in dgBitacoraLlamados.Rows)
                    {
                        dgBitacoraLlamados.Rows.Remove(o);
                    }
                }
            }
            catch (Exception exe)
            { 
            
            }
        }

        private void MainTabs_Load(object sender, EventArgs e)
        {
            // expedientes
            if (!DesignMode)
            {
                DBNotifyListeners.RegisterListener(OnExpedienteInsertUpdateHandler);
                DBNotifyListeners.RegisterListener(OnBitacoraChanged);

                CargarExpedientes();
                CargarBitacora();
            }
        }

        public void CargarBitacora()
        {
            // cargar bitacora solo si somos visibles
            if (!Visible)
                return;
            DataSet ds1;
            var bl = new bitacora_llamados();
            var bg = new bitacora_gestion();
            DataSet ds2 = bg.Getbitacora_gestion_limit();
            dgBitacoraGestion.DataSource = ds2.Tables[0];
            // cargar para este expediente o carro
            switch (tipo)
            {
                case TipoElemento.Expediente:
                    ds1 = bl.Getbitacora_llamados_expediente_limit(id);
                    dgBitacoraLlamados.DataSource = ds1.Tables[0];
                    break;
                case TipoElemento.Carro:
                    ds1 = bl.Getbitacora_llamados_carro_limit(id);
                    dgBitacoraLlamados.DataSource = ds1.Tables[0];
                    break;
                default:
                    break;
            }
        }

        public void GetDatos2()
        {
            // cargar bitacora solo si somos visibles
            if (!Visible)
                return;
            DataSet ds1;
            var bl = new bitacora_llamados();
            var bg = new bitacora_gestion();
            DataSet ds2 = bg.Getbitacora_gestion_limit();
            dgBitacoraGestion.DataSource = ds2.Tables[0];
            // cargar para este expediente o carro
            switch (tipo)
            {
                case TipoElemento.Expediente:
                    ds1 = bl.Getbitacora_llamados_expediente_limit(id);
                    dgBitacoraLlamados.DataSource = ds1.Tables[0];
                    break;
                case TipoElemento.Carro:
                    ds1 = bl.Getbitacora_llamados_carro_limit(id);
                    dgBitacoraLlamados.DataSource = ds1.Tables[0];
                    break;
                default:
                    break;
            }
        }

        private void OnBitacoraChanged(object sender, ListenerEventArgs e)
        {
            if (e.Event == "bitacora")
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker) CargarBitacora);
                }
            }
        }

        public void CargarDatos()
        {
            CargarBitacora();
        }

        private void dgExpedientes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!dgExpedientes.Columns.Contains("login")) return;
            var csn = new DataGridViewCellStyle();
            var csb = new DataGridViewCellStyle
                          {
                              Font = new Font(dgExpedientes.Font, FontStyle.Bold),
                              BackColor = Color.Beige
                          };
            for (int i = e.RowIndex; i < e.RowCount + e.RowIndex; i++)
            {
                dgExpedientes.Rows[i].DefaultCellStyle = dgExpedientes["login", i].Value == DBNull.Value ? csb : csn;
            }
        }

        private void CargarExpedientes()
        {
            if (dgExpedientes.InvokeRequired)
            {
                dgExpedientes.Invoke((MethodInvoker) CargarExpedientes);
            }
            else
            {
                ZeusWin.Ocupado(true);
                ZeusWin.BarraEstado("Cargando Expedientes...");
                var exp = new e_expedientes();

                try
                {
                    dgExpedientes.DataSource = exp.Gete_expedientes().Tables[0];
                }
                catch (Exception e)
                {
                    Log.ShowAndLog(e);
                }
                ZeusWin.Ocupado(false);
                ZeusWin.BarraEstado("");
            }
        }

        private void OnExpedienteInsertUpdateHandler(object sender, ListenerEventArgs e)
        {
            if (e.Event == "insertexpediente" || e.Event == "updateexpediente")
            {
                CargarExpedientes();
            }
        }

        private void ddlCarrosBitacoraExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds1;
            var bl = new bitacora_llamados();
            var bg = new bitacora_gestion();
            DataSet ds2 = bg.Getbitacora_gestion_limit();
            dgBitacoraGestion.DataSource = ds2.Tables[0];
            ds1 = bl.Getbitacora_llamados_carro_limit(Convert.ToInt32(ddlCarrosBitacoraExp.SelectedValue));
            dgBitacoraLlamados.DataSource = ds1.Tables[0];
        }

        private void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {   
            DataSet ds1;
            var bl = new bitacora_llamados();
            var bg = new bitacora_gestion();
            DataSet ds2 = bg.Getbitacora_gestion_limit_specific(ddl2.Text);
            dgBitacoraGestion.DataSource = ds2.Tables[0];
        }

        private void chkBgestion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBgestion.Checked == false)
            {
                DataSet ds1;
                var bl = new bitacora_llamados();
                var bg = new bitacora_gestion();
                DataSet ds2 = bg.Getbitacora_gestion_limit();
                dgBitacoraGestion.DataSource = ds2.Tables[0];
                chkBgestion.Checked = false;
                ddl2.Visible = false;
            }
            else
            {
                chkBgestion.Checked = true;
                ddl2.Visible = true;
            }
        }        
    }
}