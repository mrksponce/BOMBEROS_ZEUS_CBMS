using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.UIElements;
using Zeus.Util;

namespace DespachoHerramientasEquipos
{
    public partial class DespachoHerramientasEquiposForm : Form
    {
        private IZeusWin zeusWin;

        public DespachoHerramientasEquiposForm()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        private void DespachoHerramientasEquiposForm_Load(object sender, EventArgs e)
        {
            //icono
            Icon = Icon.FromHandle(Resources.icon.GetHicon());
            // cargar treeview
            DataSet ds = new dh_categorias().GetDataSet();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var tn = new TreeNode {Text = ((string) dr["categoria"])};

                DataSet ds1 = new dh_subcategorias().GetDataSet((int) dr["id_categoria"]);
                tn.ImageKey = "icon-toolbox";
                tn.SelectedImageKey = "icon-toolbox";
                foreach (DataRow dr2 in ds1.Tables[0].Rows)
                {
                    var tn2 = new SubcategoriaTreeNode((string) dr2["subcategoria"])
                                  {
                                      Tag = dr2["id_subcategoria"],
                                      ImageKey = "icon-tools",
                                      SelectedImageKey = "icon-tools"
                                  };
                    tn.Nodes.Add(tn2);
                }
                treeCategorias.Nodes.Add(tn);
            }
            // cargar expedientes
            DataSet exp = new e_expedientes().Gete_expedientes();
            comboExpedientes.DisplayMember = "clave_dir";
            comboExpedientes.ValueMember = "id_expediente";
            comboExpedientes.DataSource = exp.Tables[0];
            comboExpedientes.SelectedValue = zeusWin.IdExpediente;
        }

        private void treeCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is SubcategoriaTreeNode)
            {
                // cargar herramientas
                DataSet ds = new dh_herramientas().GetDataSet((int) e.Node.Tag);
                listHerramientas.DataSource = ds.Tables[0];
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listHerramientas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // mostrar carros y cantidades
            if (listHerramientas.SelectedValue != null)
            {
                DataSet ds = new dh_herramientas_carros().GetCarrosCantidad((int) listHerramientas.SelectedValue);
                listCarrosCantidad.DataSource = ds.Tables[0];

                btnPrepararDespacho.Enabled = (!string.IsNullOrEmpty(textCantidad.Text) &&
                                               listHerramientas.SelectedValue != null);
            }
        }

        private void btnPrepararDespacho_Click(object sender, EventArgs e)
        {
            // obtener prioridades para este despacho
            DataSet prioridades =
                new dh_prioridad().GetDataSet((int) ((DataRowView) comboExpedientes.SelectedItem)["id_area"]);

            // ordenar carros disponibles segun prioridades
            var carros_final = new Dictionary<z_carros, int>();
            // lista con los carros disponibles
            var carros_disp = new Dictionary<z_carros, int>();
            foreach (DataRow carro in listCarrosCantidad.DataSource.Rows)
            {
                carros_disp.Add(new z_carros().getObjectz_carros((int) carro["id_carro"]), (int) carro["cantidad"]);
            }

            foreach (DataRow prio in prioridades.Tables[0].Rows)
            {
                var todel = new List<z_carros>();
                foreach (KeyValuePair<z_carros, int> carro in carros_disp)
                {
                    if ((int) prio["despacho_herramienta"] == carro.Key.id_compania)
                    {
                        // añadir a orden y eliminar de la lista actual
                        carros_final.Add(carro.Key, carro.Value);
                        todel.Add(carro.Key);
                    }
                }
                // eliminar carros añadidos
                foreach (z_carros c in todel)
                {
                    carros_disp.Remove(c);
                }
            }

            // seleccionar carros necesarios
            int cantidad = int.Parse(textCantidad.Text);
            var despacho = new List<int>();
            foreach (KeyValuePair<z_carros, int> carro in carros_final)
            {
                // marcar como despachado y agregar
                Carro.Despachar(carro.Key);
                despacho.Add(carro.Key.id_carro);
                cantidad -= carro.Value;
                if (cantidad <= 0)
                {
                    break;
                }
            }

            if (cantidad <= 0 ||
                (cantidad > 0 &&
                 MessageBox.Show(
                     string.Format(
                         "No existe cantidad suficiente para satisfacer la solicitud. Han quedado {0} elementos pendientes. ¿Desea realizar el despacho de todas maneras?",
                         cantidad), "Elementos insuficientes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                 DialogResult.Yes))
            {
                // preparar despacho
                var cd = new ConfirmarDespacho
                             {
                                 IdCarros = despacho,
                                 IdExpediente = ((int) comboExpedientes.SelectedValue),
                                 IdArea = ((int) ((DataRowView) comboExpedientes.SelectedItem)["id_area"])
                             };
                cd.ShowDialog();
            }
        }

        private void textCantidad_TextChanged(object sender, EventArgs e)
        {
            btnPrepararDespacho.Enabled = (!string.IsNullOrEmpty(textCantidad.Text) &&
                                           listHerramientas.SelectedValue != null);
        }
    }
}