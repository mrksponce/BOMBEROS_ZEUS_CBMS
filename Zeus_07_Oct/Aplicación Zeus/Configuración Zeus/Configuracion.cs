using System;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Zeus.Data;

namespace Zeus.ConfigTool
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
            // datos actuales
            Config.Load();
            textIP.Text = Config.Host;
            comboBD.Text = Config.Database;
            //textREDTIC.Text = DatosSGC.RedTicURL;
        }

        public bool Validar()
        {
            StringBuilder sb = new StringBuilder("Por favor verifique los siguientes parámetros:\n");
            bool ok = true;

            if (textIP.Text == "")
            {
                sb.Append("* IP de servidor no válida.");
                ok = false;
            }

            if (ok == false)
            {
                MessageBox.Show(sb.ToString(), "Faltan parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return ok;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            SetValues(textIP.Text, comboBD.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private static void SetValues(string server, string database)
        {
            Config.Host = server;
            Config.Database = database;
            RegistryKey host1 = Registry.CurrentUser.OpenSubKey("Software\\GEOBit\\ZEUS", true) ??
                                Registry.CurrentUser.CreateSubKey("Software\\GEOBit\\ZEUS");

            // If the return value is null, the key doesn't exist
            if (host1 != null)
            {
                host1.SetValue("Host", server);
                host1.SetValue("Database", database);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                string preHost = Config.Host, preBD = Config.Database;

                SetValues(textIP.Text, comboBD.Text);
                try
                {
                    DBNotifyListeners.CheckBD();
                    MessageBox.Show("La prueba de conexión fue correcta", "Conexión exitosa");
                }
                catch (Exception ex)
                {
                    SetValues(preHost, preBD);
                    MessageBox.Show(ex.Message, "Ha ocurrido un error");
                }
            }
        }
    }
}