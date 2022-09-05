using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Itmaskinen_api.Services
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {
        }

        public void SendAccountCreatedEmail(string recipient)
        {
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("ce98cdefcf9e7e", "1269a0fe487337"),
                EnableSsl = true
            };

            var htmlBody = "<body>Account created Successfully.</body>";

            client.Send("noreply@testexamination.com", recipient, "Test - Account Created", htmlBody);
        }
    }
}
