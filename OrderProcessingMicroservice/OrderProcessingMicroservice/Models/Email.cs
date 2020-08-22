using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessingMicroservice.Models
{
    public class Email
    {
        public EmailAddress From { get; set; }

        public List<EmailAddress> Tos { get; set; }

        public string Subject { get; set; }
        public string HtmlContent { get; set; }
        public bool DisplayRecipients { get; set; }
    }
}
