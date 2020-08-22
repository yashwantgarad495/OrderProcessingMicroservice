using OrderProcessingMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OrderProcessingMicroservice.Helper
{
    public class SendMailHelper
    {
        /// <summary>
        /// Send Mail to User.
        /// </summary>
        /// <param name="mailTemplate"></param>
        /// <returns></returns>
        public static Task<bool> SendMail(Email email)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(ConfigData.Configuration["SEND_GRID_FROMUSER"]),
                    Subject = email.Subject,
                    Body = email.HtmlContent,
                };
                //mailMessage.To.Add( email.Tos);

                foreach (var item in email.Tos)
                {
                    mailMessage.To.Add(item.Email);
                }

                var smtpClient = new SmtpClient
                {
                    Credentials = new NetworkCredential(ConfigData.Configuration["SEND_GRID_USERNAME"], ConfigData.Configuration["SEND_GRID_PASSWORD"]),
                    Host = "smtp.sendgrid.net",
                    Port = 587
                };
                smtpClient.SendMailAsync(mailMessage);
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}
