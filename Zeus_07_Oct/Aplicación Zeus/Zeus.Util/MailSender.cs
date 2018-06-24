using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Zeus.Util
{
    public class MailSender
    {
        private readonly SmtpClient client;

        public MailSender(SmtpData data)
        {
            client = new SmtpClient(data.Host, data.Port)
                         {
                             Credentials = new NetworkCredential(data.User, data.Password)
                         };
        }

        public void Send(string subject, List<string> to, List<string> attachments)
        {
            // preparar destinos
            string strTo = "";
            foreach (string s in to)
            {
                strTo += s + ",";
            }
            var mailMsg = new MailMessage("telecomunicaciones@cbms.cl", strTo.Trim(','), subject, "");
            // attachments
            foreach (string att in attachments)
            {
                mailMsg.Attachments.Add(new Attachment(att));
            }

            client.SendAsync(mailMsg, null);
        }

        public void AddCompletedHandler(SendCompletedEventHandler sc)
        {
            client.SendCompleted += sc;
        }
    }
}