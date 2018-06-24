using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class Claves : Form
    {
        public Claves()
        {
            InitializeComponent();
            Datos = new PostgresDataAccess.DataAccess();

            aClaves = Datos.ObtenerTipoLlamado();
            foreach (KeyValuePair<string, int> k in aClaves)
            {
                listClaves.Items.Add(k.Key);
            }
            listSubclaves.ValueMember = "Key";
        }

        bool updating = false;
        private PostgresDataAccess.DataAccess Datos;
        private KeyValuePair<string, int>[] aClaves;
        private List<KeyValuePair<string, int>> SubClaves;

        private int _codigo_llamado;

        public int Codigo_llamado
        {
            get { return _codigo_llamado; }
            set { _codigo_llamado = value; }
        }

        private string _clave;

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        private void listClaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubClaves = Datos.ObtenerSubTipoLlamados(aClaves[listClaves.SelectedIndex].Value);
            listSubclaves.Items.Clear();
            groupBox2.Text = "Subclaves de " + listClaves.SelectedItem.ToString().Split(' ')[0];
            foreach (KeyValuePair<string, int> k in SubClaves)
            {
                listSubclaves.Items.Add(k);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (SubClaves != null && SubClaves.Count == 0 && listClaves.SelectedIndex != -1)
            {
                // batallón?
                this.Codigo_llamado = aClaves[listClaves.SelectedIndex].Value;
                this.Clave = (string)listClaves.SelectedItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            if (listSubclaves.SelectedIndex != -1)
            {
                this.Codigo_llamado = ((KeyValuePair<string, int>)listSubclaves.SelectedItem).Value;//SubClaves[comboSubclaves.SelectedIndex].Value;
                this.Clave = ((KeyValuePair<string, int>)listSubclaves.SelectedItem).Key;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una subclave antes de proceder.", "Seleccionar Claves", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textClaves_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            List<KeyValuePair<string, int>> l = SubClaves.FindAll(delegate(KeyValuePair<string, int> s) { return s.Key.ToLower().Contains(textClave.Text.ToLower()); });
            listSubclaves.Items.Clear();
            foreach (KeyValuePair<string, int> k in l)
            {
                listSubclaves.Items.Add(k);
            }
            // agregar la ultima
            listSubclaves.Items.Add(SubClaves[SubClaves.Count - 1]);
        }

        private void listSubclaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSubclaves.SelectedItem != null)
            {
                updating = true;
                textClave.Text = ((KeyValuePair<string, int>)listSubclaves.SelectedItem).Key;
                updating = false;
            }
        }
    }
}