using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

using NLog;

namespace ScoreSender.Entity
{
    /// <summary>
    /// Выполняет отправку e-mail сообщений
    /// </summary>
    public class MailSender
    {
        public MailSender()
        {
            ReadSettings();
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="email">адрес получателя</param>
        /// <param name="att">вложение, путь к файлу, который нужно отправить </param>
        public void SendMail(string mailTo, string att)
        {
            logger.Trace("MailSender running");

            MailAddress from = new MailAddress(mailFrom);
            MailAddress to = new MailAddress(mailTo);
            MailMessage mm = new MailMessage(from, to);
            mm.Subject = messageSubject;
            mm.Body = String.Format(messageBody, 3);
            mm.IsBodyHtml = true;
            mm.Attachments.Add(new Attachment(att));
            SmtpClient smtp = new SmtpClient(smtpServer, int.Parse(smtpPort));
            smtp.Credentials = new NetworkCredential(mailUser, mailPassword);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mm);

            logger.Trace("MailSender leaving");
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.MailFrom = this.mailFrom;
            Properties.Settings.Default.MailUser = this.mailUser;
            Properties.Settings.Default.SmtpPort = this.smtpPort;
            Properties.Settings.Default.SmtpServer = this.smtpServer;
            Properties.Settings.Default.MessageBody = this.messageBody;
            Properties.Settings.Default.MessageSubject = this.messageSubject;

            Properties.Settings.Default.Save();
        }

        private void ReadSettings()
        {
            string pass = Properties.Settings.Default.MailPassword;
            mailFrom   = Properties.Settings.Default.MailFrom;
            mailUser   = Properties.Settings.Default.MailUser;
            smtpPort   = Properties.Settings.Default.SmtpPort;
            smtpServer = Properties.Settings.Default.SmtpServer;
            messageSubject = Properties.Settings.Default.MessageSubject;
            messageBody = Properties.Settings.Default.MessageBody;

            if (String.IsNullOrEmpty(pass))
            {
                mailPassword = StringCryptor.DecryptString(pass, Common.CryptKey);
            }
        }

        private string mailFrom;
        private string smtpServer;
        private string smtpPort;
        private string mailUser;
        private string mailPassword;
        private string messageSubject;
        private string messageBody;

        private static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
