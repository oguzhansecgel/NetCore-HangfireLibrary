
using SendGrid.Helpers.Mail;
using SendGrid;

namespace Hangfire.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userID, string message)
        {
            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("oguzhan.secgel.19@gmail.com", "Example User");
            var subject = "www.oguzhansecgel.com.tr AÇILDI!!!";
            var to = new EmailAddress("oguzhansecgel19@icloud.com", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
