using Hospital_Management.Model;
using Hospital_Management.Services.IServices;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace Hospital_Management.Services
{
    public class EmailServices : IEmailServices
    {

        private readonly EmailSetting _emailsetting;
        public EmailServices( IOptions <EmailSetting> emailsetting)
        {
            _emailsetting = emailsetting.Value;
        }



        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailsetting.FromEmail));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = body };
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_emailsetting.SmptHost,_emailsetting.SmptPort, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_emailsetting.Username, _emailsetting.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
