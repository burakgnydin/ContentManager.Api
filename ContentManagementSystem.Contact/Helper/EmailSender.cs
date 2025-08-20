using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;


namespace ContentManagementSystem.Contact.Helper
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string userEmail, string subject, string body, bool isHtml = false)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(userEmail));
            message.To.Add(MailboxAddress.Parse("btestt79@gmail.com"));   
            message.ReplyTo.Add(MailboxAddress.Parse(userEmail));         

            message.Subject = subject;
            message.Body = isHtml
                ? new TextPart(MimeKit.Text.TextFormat.Html) { Text = body }
                : new TextPart(MimeKit.Text.TextFormat.Plain) { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("btestt79@gmail.com", "ejlj xqcm mvkh zdlp");
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}
