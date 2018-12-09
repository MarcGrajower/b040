using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Core.Common
{
    public static class Email
    {
        public static string email_Host;
        public static string email_User;
        public static string email_Password;
        public static int email_Port;
        public static bool email_EnableSsl;
        public static string email_fromAddress;
        static Email()
        {
            email_Host = "smtp.gMAIL.com";
            email_User = "b040Mail2@gmail.com";
            email_Password = "Mail2B040";
            email_Port = 587;
            email_EnableSsl = true;
            email_fromAddress = "b040Mail2@gmail.com";
        }
        public static void send(
            string subject,
            string messageBody,
            string toAddress,
            string ccAddress)
        {
            MailMessage message = new MailMessage();
            var client = new SmtpClient();
            message.From = new MailAddress(email_fromAddress);
            if (toAddress.Trim().Length >0 )
            {
                foreach (string addr in toAddress.Split(";"[0]))
                {
                    message.To.Add(new MailAddress(addr));
                }
            }
            if (ccAddress.Trim().Length > 0)
            {
                foreach (string addr in ccAddress.Split(";"[0]))
                {
                    message.CC.Add(new MailAddress(addr));
                }
            }
            message.Subject = subject;
            message.IsBodyHtml = false;
            message.Body = messageBody;
            client.Host = email_Host;
            client.Credentials = new NetworkCredential(email_User, email_Password);
            client.Port = email_Port;
            client.EnableSsl = email_EnableSsl;
            client.Send(message);
        }
    }
}





