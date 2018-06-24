using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class ExpedientesTreeView : BaseControl
    {
        private int _id_operadora;

        public ExpedientesTreeView()
        {
            InitializeComponent();
            treeExpedientes.TreeViewNodeSorter = new ZNodeSorter();
//#if CBQN
//            // hack: cambiar imagenes (se deben cargar después desde carpeta)
//            imageTiposDeLlamado.Images[89] = Properties.Resources.BAT1_R;
//            imageTiposDeLlamado.Images[90] = Properties.Resources.BAT1_R_S;
//            imageTiposDeLlamado.Images[91] = Properties.Resources.BAT1_V;
//            imageTiposDeLlamado.Images[92] = Properties.Resources.BAT1_V_S;
//            imageTiposDeLlamado.Images[93] = Properties.Resources.BAT2_R;
//            imageTiposDeLlamado.Images[94] = Properties.Resources.BAT2_R_S;
//            imageTiposDeLlamado.Images[95] = Properties.Resources.BAT2_V;
//            imageTiposDeLlamado.Images[96] = Properties.Resources.BAT2_V_S;

//#endif
        }

        public void CargarExpedientes(int id_operadora)
        {
            // levantar hilo para cargar expedientes

            //new Thread(new ThreadStart(delegate() { _CargarExpedientes(id_operadora); })).Start();
            _id_operadora = id_operadora;

            string selected = "";
            if (treeExpedientes.SelectedNode != null)
            {
                selected = treeExpedientes.SelectedNode.Text;
            }
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(new object[] {id_operadora, selected});
            }
        }

        private void OnDataChanged(object sender, ListenerEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("onDataChanged");

            if (e.Event == "updateexpediente" || e.Event == "despacho")
            {
                if (InvokeRequired)
                {
                    Invoke(new TCargarExpedientes(CargarExpedientes), new object[] {_id_operadora});
                }
                else
                {
                    CargarExpedientes(_id_operadora);
                }
            }
            if (e.Event == "z_guardia")
            {
                if (InvokeRequired)
                {
                    Invoke(new TCargarComandanteGuardia(CargarComandantesGuardia));
                }
                else
                {
                    CargarComandantesGuardia();
                }
            }
        }

        private void OnActualizar(object sender, EventArgs e)
        {
            CargarExpedientes(_id_operadora);
        }

        public event EventHandler<DataEventArgs> OnSeleccion;

        private void treeExpedientes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tn = e.Node as LlamadoTreeNode;
            if (tn == null)
            {
                if (OnSeleccion != null)
                    OnSeleccion(this, null);
            }
            else
            {
                if (OnSeleccion != null)
                    OnSeleccion(this, new DataEventArgs(tn.NodeId, tn.NodeType));
            }
        }

        public void OnAsignacionHandler(object sender, DataEventArgs e)
        {
            // cargar el nodo
            var exp = new e_expedientes();
            var llam = new z_llamados();
            try
            {
                exp = exp.getObjecte_expedientes(e.Id);
                llam = llam.getObjectz_llamados(exp.codigo_llamado);
                var tn = new LlamadoTreeNode(exp.seis2 + " / " + exp.cero5)
                             {
                                 ImageKey = llam.clave,
                                 SelectedImageKey = llam.clave,
                                 NodeId = exp.id_expediente,
                                 NodeType = TipoElemento.Expediente
                             };
                // carros pedidos

                // agregar al árbol
                treeExpedientes.Nodes.Add(tn);
                treeExpedientes.SelectedNode = tn;
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                MessageBox.Show("No se pudo completar la operación debido a un error de Base de Datos.",
                                "Mensaje de ZEUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //CargarExpedientes(_id_operadora);
        }

        private void MainTree_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                DBNotifyListeners.RegisterListener(OnDataChanged);
                ZeusWin.AddActualizarHandler(OnActualizar);
                CargarComandantesGuardia();
            }
        }

        private void CargarComandantesGuardia()
        {
            // cargar comandantes de guardia
            try
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.ColumnCount = 1;
                DataSet ds = new z_guardia().Getz_guardia();
                int i = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if ((bool) dr["mostrar"] != true)
                    {
                        continue;
                    }
                    var l = new Label {AutoSize = true, Text = ((string) dr["oficial"])};
                    var ll = new LinkLabel {Text = ((string) dr["tipo_oficial"]), Tag = dr["responsabilidades"]};
                    ll.Click += delegate { MessageBox.Show((string) ll.Tag, "Responsabilidades para este Oficial"); };
                    ll.AutoSize = true;
                    tableLayoutPanel1.ColumnCount++;
                    tableLayoutPanel1.Controls.Add(ll, 0, i);
                    tableLayoutPanel1.Controls.Add(l, 1, i);
                    i++;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CargarExpedientes(_id_operadora);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var id_operadora = (int) ((object[]) e.Argument)[0];
            var exps = new e_expedientes();
            //treeExpedientes.Nodes.Clear();
            var nodes = new List<TreeNode>();
            try
            {
                // expedientes normales
                DataSet ds = exps.Gete_expedientes_operadora_all(id_operadora);
                // agregar al árbol
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var tn = new LlamadoTreeNode(dr["seis2"] + " / " + dr["cero5"])
                                 {
                                     ImageKey = dr["clave"].ToString(),
                                     SelectedImageKey = (dr["clave"] + "s")
                                 };

                    if ((bool) dr["sit_controlada"])
                    {
                        tn.ImageKey = dr["clave"] + "-ok";
                        tn.SelectedImageKey = dr["clave"] + "-oks";
                    }
                    tn.NodeId = (int) dr["id_expediente"];
                    tn.Fecha = (DateTime) dr["fecha"];
                    tn.NodeType = TipoElemento.Expediente;
                    // carros pedidos
                    var carros = new e_carros_usados();
                    DataSet dt = carros.Gete_carros_exp(tn.NodeId);
                    foreach (DataRow dw in dt.Tables[0].Rows)
                    {
                        var te = new LlamadoTreeNode(dw["nombre"].ToString())
                                     {
                                         ImageKey = ((string) dw["seis"]),
                                         SelectedImageKey = ((string) dw["seis"] + "s"),
                                         NodeId = ((int) dw["id_carro"]),
                                         NodeType = TipoElemento.Carro,
                                         NodeOrder = Convert.ToInt64(dw["id_despachado"])
                                     };

                        tn.Nodes.Add(te);
                    }
                    // agregar al árbol
                    //treeExpedientes.Nodes.Add(tn);
                    nodes.Add(tn);
                }
                // expedientes falsos (claves de servicios)
                var ec = new e_carros_usados();
                // -1: 6-13
                ds = ec.Gete_carros_exp(-1);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    var tn = new LlamadoTreeNode("TRAMITE DE COMPAÑIA")
                                 {
                                     NodeId = (-1),
                                     Fecha = DateTime.MinValue,
                                     ImageKey = "6-13",
                                     SelectedImageKey = "6-13s",
                                     NodeType = TipoElemento.Servicio
                                 };

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var te = new LlamadoTreeNode(dr["nombre"].ToString())
                                     {
                                         ImageKey = ((string) dr["seis"]),
                                         SelectedImageKey = ((string) dr["seis"] + "s"),
                                         NodeId = ((int) dr["id_carro"]),
                                         NodeType = TipoElemento.Carro,
                                         NodeOrder = Convert.ToInt64(dr["id_despachado"])
                                     };

                        tn.Nodes.Add(te);
                    }
                    //treeExpedientes.Nodes.Add(tn);
                    nodes.Add(tn);
                }

                // -2: 6-14
                ds = ec.Gete_carros_exp(-2);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    var tn = new LlamadoTreeNode("CARGA DE COMBUSTIBLE")
                                 {
                                     NodeId = (-2),
                                     Fecha = DateTime.MinValue,
                                     ImageKey = "6-14",
                                     SelectedImageKey = "6-14s",
                                     NodeType = TipoElemento.Servicio
                                 };

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var te = new LlamadoTreeNode(dr["nombre"].ToString())
                                     {
                                         ImageKey = ((string) dr["seis"]),
                                         SelectedImageKey = ((string) dr["seis"] + "s"),
                                         NodeId = ((int) dr["id_carro"]),
                                         NodeType = TipoElemento.Carro,
                                         NodeOrder = Convert.ToInt64(dr["id_despachado"])
                                     };

                        tn.Nodes.Add(te);
                    }
                    //treeExpedientes.Nodes.Add(tn);
                    nodes.Add(tn);
                }

                // -3: 6-15
                ds = ec.Gete_carros_exp(-3);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    var tn = new LlamadoTreeNode("SE DIRIGE A SERVICIO DE SALUD")
                                 {
                                     NodeId = (-3),
                                     Fecha = DateTime.MinValue,
                                     ImageKey = "6-15",
                                     SelectedImageKey = "6-15s",
                                     NodeType = TipoElemento.Servicio
                                 };

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var te = new LlamadoTreeNode(dr["nombre"].ToString())
                                     {
                                         ImageKey = ((string) dr["seis"]),
                                         SelectedImageKey = ((string) dr["seis"] + "s"),
                                         NodeId = ((int) dr["id_carro"]),
                                         NodeType = TipoElemento.Carro,
                                         NodeOrder = Convert.ToInt64(dr["id_despachado"])
                                     };

                        tn.Nodes.Add(te);
                    }
                    //treeExpedientes.Nodes.Add(tn);
                    nodes.Add(tn);
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
            e.Result = new[] {nodes.ToArray(), ((object[]) e.Argument)[1]};
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var selected = (string) ((object[]) e.Result)[1];
            var nodes = (TreeNode[]) ((object[]) e.Result)[0];
            treeExpedientes.SuspendLayout();
            treeExpedientes.Nodes.Clear();
            treeExpedientes.Nodes.AddRange(nodes);

            treeExpedientes.ExpandAll();
            nodes = treeExpedientes.Nodes.Find(selected, true);
            if (nodes.Length != 0)
            {
                treeExpedientes.SelectedNode = nodes[0];
            }
            else
            {
                if (treeExpedientes.Nodes.Count != 0)
                {
                    treeExpedientes.SelectedNode = treeExpedientes.Nodes[0];
                }
            }
            if (treeExpedientes.Nodes.Count == 0)
            {
                treeExpedientes_AfterSelect(this, new TreeViewEventArgs(null));
            }
            treeExpedientes.ResumeLayout();
            //treeExpedientes.Refresh();
        }

        #region Nested type: TCargarComandanteGuardia

        private delegate void TCargarComandanteGuardia();

        #endregion

        #region Nested type: TCargarExpedientes

        private delegate void TCargarExpedientes(int id);

        #endregion
    }
}