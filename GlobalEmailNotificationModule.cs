using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Fuentes_PrelimsP2
{
    internal static class GlobalEmailNotificationModule
    {
        private static readonly string sender_Email = "official.agri.projectpananom@gmail.com";
        private static readonly string sender_Email_password = "sngnkzppkmdihsac";

        internal static async Task send_Notification(string recipient_Email, string subject, string body)
        {
            try
            {
                var SMTP_Client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, 
                    Credentials = new NetworkCredential(sender_Email, sender_Email_password),
                    EnableSsl = true,
                };

                var email_Message = new MailMessage()
                {
                    From = new MailAddress(sender_Email, "Project Pananom Official"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                email_Message.To.Add(recipient_Email);

                await Task.Run(() => SMTP_Client.Send(email_Message));
            }

            catch (Exception ex)
            {
                MessageBox.Show("An Error occured: " + ex.Message);
            }
        }
    }
}
