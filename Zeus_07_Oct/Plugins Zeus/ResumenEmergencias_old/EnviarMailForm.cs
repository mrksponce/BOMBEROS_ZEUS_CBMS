using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace ResumenEmergencias
{
    public partial class EnviarMailForm : Form
    {
        private string attachment;

        public EnviarMailForm()
        {
            InitializeComponent();
        }

        public string Attachment
        {
            get { return attachment; }
            set { attachment = value; }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnviarMailForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new z_companias().Getz_companias();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var li = new ListViewItem(Convert.ToString(dr["id_compania"]));
                    li.SubItems.Add(Convert.ToString(dr["email"]));
                    li.Checked = dr["email"] != DBNull.Value;
                    listCompanias.Items.Add(li);
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Settings.Default.SmtpData == null)
            {
                MessageBox.Show("No se ha configurado Envío de Correos Electrónicos", "Mensaje de Zeus",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnEnviar.Enabled = btnCerrar.Enabled = false;
            Cursor = Cursors.WaitCursor;
            // crear lista de direcciones
            var To = new List<string>();
            foreach (ListViewItem li in listCompanias.Items)
            {
                if (li.Checked)
                {
                    To.Add(li.SubItems[1].Text);
                }
            }
            // attachments
            var att = new List<string> {attachment};
            if (To.Count == 0)
            {
                MessageBox.Show("Debe seleccionar algún destino para el mensaje", "No ha seleccionado destino",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // enviar mensaje
                SmtpData sd = Settings.Default.SmtpData;
                //SmtpData sd = new SmtpData();
                //sd.FromAddress = Settings.Default.SmtpData.FromAddress;//"telecomunicaciones@cbms.cl";
                //sd.Host = Settings.Default.SmtpData.Host;//"mail.cbmss.cl";
                //sd.Password = "centralx";
                //sd.Port = 25;
                //sd.User = "telecomunicaciones@cbms.cl";
                var ms = new MailSender(sd);
                ms.AddCompletedHandler(sc_SendCompleted);
                try
                {
                    ms.Send("Resumen Emergencias", To, att);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void sc_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            btnCerrar.Enabled = true;
            Cursor = Cursors.Default;
            if (e.Error == null)
            {
                MessageBox.Show("Correo Enviado exitosamente", "Mensaje de ZEUS", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                Log.ShowAndLog(e.Error);
            }
        }
    }
}