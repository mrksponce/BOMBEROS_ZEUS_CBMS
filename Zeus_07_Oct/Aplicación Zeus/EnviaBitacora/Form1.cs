using System;
using System.ComponentModel;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using Zeus.Data;

namespace EnviaBitacora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            mail();
        }

        private void mail()
        {
            // enviar bitácora
            Zeus.Data.Config.Load();
            DataSet bg = new bitacora_gestion().Getbitacora_gestion();
            DataSet bl = new bitacora_llamados().Getbitacora_llamados();
            bl.WriteXml(System.IO.Path.GetTempPath() + "\\bitacora_llamados.xml");
            bg.WriteXml(System.IO.Path.GetTempPath() + "\\bitacora_gestion.xml");
            this.Cursor = Cursors.WaitCursor;

            MailMessage mailMsg = new MailMessage("telecomunicaciones@cbms.cl", "carlitos.orrego@gmail.com", "Bitácoras Zeus", "");
            mailMsg.Attachments.Add(new Attachment(System.IO.Path.GetTempPath() + "\\bitacora_llamados.xml"));
            mailMsg.Attachments.Add(new Attachment(System.IO.Path.GetTempPath() + "\\bitacora_gestion.xml"));
            SmtpClient sc = new SmtpClient("mail.cbms.cl", 25);
            sc.Credentials = new System.Net.NetworkCredential("telecomunicaciones@cbms.cl", "central");
            sc.SendCompleted+=new SendCompletedEventHandler(sc_SendCompleted);
            try
            {
                sc.SendAsync(mailMsg,null);
            }
            catch (Exception ex)
            {
                label1.Text = "Error al enviar bitácoras: " + ex.Message;
                button1.Enabled = true;
            }
        }

        void sc_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            label1.Text = "Bitácoras enviadas exitosamente";
            button1.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}