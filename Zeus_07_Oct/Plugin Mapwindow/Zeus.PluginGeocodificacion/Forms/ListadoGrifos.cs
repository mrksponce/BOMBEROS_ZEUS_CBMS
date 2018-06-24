using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class ListadoGrifos : Form
    {
        public ListadoGrifos()
        {
            InitializeComponent();
            Datos = new PostgresDataAccess.DataAccess();
        }

        private void checkPunto_CheckedChanged(object sender, EventArgs e)
        {
            listGrifos.Items.Clear();
            if (checkPunto.Checked == true)
            {
                if (PlugData.Direccion == null || PlugData.Direccion.Ubicacion.HasValue == false)
                {
                    MessageBox.Show("No hay disponible una dirección en este momento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkPunto.Checked=false;
                }
                else
                {
                    // deshabilitar
                    comboDireccion.Enabled = false;
                    comboTipoLlamado.Enabled = false;
                    textGeoz.Text = PlugData.Direccion.Geoz;
                }
            }
            else
            {
                // habilitar
                comboTipoLlamado.Enabled = true;
                comboDireccion.Enabled = true;
                textGeoz.Text = "";
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                int radio = int.Parse(textRadio.Text);
                // obtener grifos
                if (checkPunto.Checked == true)
                {
                    // desde geocodificacion
                    ubicacion = PlugData.Direccion.Ubicacion.Value;
                    textGeoz.Text = PlugData.Direccion.Geoz;
                }
                else
                {
                    // desde expediente
                    e_expedientes exp = new e_expedientes().getObjecte_expedientes((int)comboDireccion.SelectedValue);
                    ubicacion = new PointD(exp.puntoX, exp.puntoY);
                    textGeoz.Text = exp.geoz;
                }
                grifos = Datos.ObtenerGrifos(ubicacion, radio);
                //todo: comentado para evitar zoom a mapa
                //PlugData.ZoomToPointPaint(ubicacion, radio);
                // rellenar y dibujar
                if (grifos != null)
                {
                    _llenando = true;
                    listGrifos.Items.Clear();
                    foreach (PostgresDataAccess.Grifo g in grifos)
                    {
                        ListViewItem Li = listGrifos.Items.Add("");
                        Li.Checked = g.Utilizado;
                        Li.SubItems.Add(g.Direccion);
                        Li.SubItems.Add(g.Distancia.ToString("N"));
                        Li.SubItems.Add(g.Esquina);
                    }
                    listGrifos.Columns[2].Width = 1;
                    DibujarGrifos(ubicacion);
                    _llenando = false;
                }
            }

        }

        private bool Validar()
        {
            StringBuilder sb = new StringBuilder("Han ocurrido los siguientes errores:\n");
            int d = 0;
            bool error = false;
            if (checkPunto.Checked == false)
            {
                if (comboDireccion.SelectedIndex == -1)
                {
                    sb.Append("\n* No ha seleccionado un 0-5.");
                    error = true;
                }
            }
            if (int.TryParse(textRadio.Text, out d) == false)
            {
                sb.Append("\n* El radio no es válido.");
                error = true;
            }
            if (error)
                MessageBox.Show(sb.ToString(), "Error");
            return !error;
        }

        private void DibujarGrifos(PointD ubicacion)
        {
            // modificado para dibujar centro y desplegar grifos sin hacer zoom
            // centrar en llamado
            MapWinGIS.Extents ex=new MapWinGIS.Extents();
            ex.SetBounds(ubicacion.X - (PlugData.MapWin.View.Extents.xMax - PlugData.MapWin.View.Extents.xMin) / 2, ubicacion.Y - (PlugData.MapWin.View.Extents.yMax - PlugData.MapWin.View.Extents.yMin) / 2, 0, ubicacion.X + (PlugData.MapWin.View.Extents.xMax - PlugData.MapWin.View.Extents.xMin) / 2, ubicacion.Y + (PlugData.MapWin.View.Extents.yMax - PlugData.MapWin.View.Extents.yMin) / 2, 0);
            PlugData.MapWin.View.Extents = ex;

            // dibujar
            PlugData.MapWin.View.Draw.DrawCircle(ubicacion.X, ubicacion.Y, 10, Color.Red, true);
            
            PlugData.MapWin.View.Draw.ClearDrawing(PlugData.DrGrifos.Value);
            PlugData.DrGrifos = PlugData.MapWin.View.Draw.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
            foreach (PostgresDataAccess.Grifo g in grifos)
            {
                if (g.Utilizado)
                    PlugData.MapWin.View.Draw.DrawCircle(g.Ubicacion.X, g.Ubicacion.Y, 10, Color.DarkOrange, true);
                else
                    PlugData.MapWin.View.Draw.DrawCircle(g.Ubicacion.X, g.Ubicacion.Y, 10, Color.Yellow, true);
            }
        }

        private PostgresDataAccess.Grifo[] grifos = null;
        private bool _llenando = false;
        private bool _verTodo = true;
        private PostgresDataAccess.DataAccess Datos;
        private PointD ubicacion;

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (_verTodo)
            {
                // ocultar
                this.Size = new Size(370, this.Size.Height);
                _verTodo = false;
                btnHide.Text = "Más >>";
            }
            else
            {
                this.Size = new Size(542, 319);
                _verTodo = true;
                btnHide.Text = "Menos <<";
            }
        }

        private void listGrifos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_llenando) return;

            if (checkPunto.Checked == true)
            {
                if (e.NewValue ==  CheckState.Checked)
                {
                    MessageBox.Show("Debe seleccionar un 0-5 antes de poder seleccionar grifos", "Error");
                    e.NewValue =  CheckState.Unchecked;
                    return;
                }
            }
            if (e.NewValue == CheckState.Checked)
            {
                // marcar grifo
                if (Datos.MarcarGrifo(grifos[e.Index].Gid, (int)comboDireccion.SelectedValue) == true)
                    grifos[e.Index].Utilizado = true;
                else
                {
                    e.NewValue = CheckState.Unchecked;
                }
            }
            else
            {
                if (Datos.DesmarcarGrifo(grifos[e.Index].Gid) == true)
                {
                    grifos[e.Index].Utilizado = false;
                }
                else
                {
                    e.NewValue = CheckState.Checked;
                }
            }
            DibujarGrifos(ubicacion);
        }

        private void comboTipoLlamado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoLlamado.SelectedIndex != -1)
            {
                // llenar combo de 0-5
                DataSet ds = new e_expedientes().Gete_expedientes_codigoprincipal((int)comboTipoLlamado.SelectedValue);
                comboDireccion.DisplayMember = "esquina";
                comboDireccion.ValueMember = "id_expediente";
                comboDireccion.DataSource = ds.Tables[0];
            }
        }

        private void ListadoGrifos_Load(object sender, EventArgs e)
        {
            // tipos de llamado
            DataSet ds = new z_llamados().Getz_llamados_principal();
            comboTipoLlamado.DisplayMember = "desc";
            comboTipoLlamado.ValueMember = "codigo_llamado";
            comboTipoLlamado.DataSource = ds.Tables[0];
            // expediente seleccionado
            /*
            try
            {
                RemoteZeus rz = StartRPCClient();
                int id = rz.get_IdExpediente();
                if (id != 0)
                {
                    e_expedientes exp = new e_expedientes().getObjecte_expedientes(id);
                    comboTipoLlamado.SelectedValue = exp.codigo_principal;
                    comboDireccion.SelectedValue = id;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
             */
        }

        private RemoteZeus StartRPCClient()
        {
            try
            {
                //ChannelServices.RegisterChannel(new HttpClientChannel("client_remotezeus_grifos", new SoapClientFormatterSinkProvider()), false);
                RemoteZeus rz = (RemoteZeus)Activator.GetObject(typeof(RemoteZeus), "http://localhost:9254/RemoteZeus");
                return rz;
            }
            catch
            {
                return new RemoteZeus();
            }

        }

        private void ListadoGrifos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ChannelServices.UnregisterChannel(ChannelServices.GetChannel("client_remotezeus_grifos"));
        }
    }
}