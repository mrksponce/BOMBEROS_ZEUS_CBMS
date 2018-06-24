using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;

namespace Zeus.UIElements
{
    public partial class Claves : Form
    {
        //bool updating=false;
        //private PostgresDataAccess.DataAccess Datos;
        //private KeyValuePair<string, int>[] aClaves;
        //private List<KeyValuePair<string, int>> SubClaves;
        private DataTable listsubclaves_datasource;

        public Claves()
        {
            InitializeComponent();
        }

        public int CodigoLlamado { get; set; }

        public int CodigoPrincipal { get; set; }

        public string Clave { get; set; }

        private void listClaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listClaves.SelectedIndex != -1)
            {
                listSubclaves.DataSource =
                    listsubclaves_datasource =
                    new z_llamados().Getz_llamados_codigo((int) listClaves.SelectedValue).Tables[0];
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (SubClaves!=null && SubClaves.Count==0 && listClaves.SelectedIndex!=-1)
            //{
            //    // batall�n?
            //    this.Codigo_llamado = aClaves[listClaves.SelectedIndex].Value;
            //    this.Clave = (string)listClaves.SelectedItem;
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //    return;
            //}
            //if (listSubclaves.SelectedIndex != -1)
            //{
            //    this.Codigo_llamado = ((KeyValuePair<string,int>)listSubclaves.SelectedItem).Value;//SubClaves[comboSubclaves.SelectedIndex].Value;
            //    this.Clave = ((KeyValuePair<string,int>)listSubclaves.SelectedItem).Key;
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Debe seleccionar una subclave antes de proceder.", "Seleccionar Claves", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            if (listSubclaves.SelectedIndex != -1)
            {
                CodigoLlamado = (int) listSubclaves.SelectedValue;
                CodigoPrincipal = (int) listClaves.SelectedValue;
                Clave = listSubclaves.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void textClaves_TextChanged(object sender, EventArgs e)
        {
            //if (updating) return;
            //List<KeyValuePair<string, int>> l = SubClaves.FindAll(delegate(KeyValuePair<string, int> s) { return s.Key.ToLower().Contains(textClave.Text.ToLower()); });
            //listSubclaves.Items.Clear();
            //foreach (KeyValuePair<string, int> k in l)
            //{
            //    listSubclaves.Items.Add(k);
            //}
            //// agregar la ultima
            //listSubclaves.Items.Add(SubClaves[SubClaves.Count - 1]);
            if (listsubclaves_datasource != null)
            {
                // buscar
                listSubclaves.DataSource =
                    ArrayToDataTable(listsubclaves_datasource.Select("desc like '%" + textClave.Text + "%'"));
            }
        }

        private void listSubclaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listSubclaves.SelectedItem!=null)
            //{
            //    updating = true;
            //    textClave.Text = ((KeyValuePair<string, int>)listSubclaves.SelectedItem).Key;
            //    updating = false;
            //}
        }

        private void Claves_Load(object sender, EventArgs e)
        {
            // cargar claves
            listClaves.DataSource = new z_llamados().Getz_llamados_principal().Tables[0];

            if (CodigoPrincipal != 0)
            {
                listClaves.SelectedValue = CodigoPrincipal;
            }
            if (CodigoLlamado != 0)
            {
                listSubclaves.SelectedValue = CodigoLlamado;
            }
        }

        protected DataTable ArrayToDataTable(DataRow[] drs)
        {
            DataTable t = (listsubclaves_datasource).Clone();
            foreach (DataRow dr in drs)
            {
                t.ImportRow(dr);
            }
            return t;
        }
    }
}