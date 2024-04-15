using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebChat.Domain;
using MimeKit;
using MailKit.Security;
using MimeKit.Text;
using System.Net;
using MailKit.Net.Smtp;
using MimeKit;
namespace WebChat.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                           ILogger<EmailSender> logger)
        {
            Options = optionsAccessor.Value;
            _logger = logger;
        }

        public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

        public async Task SendEmailAsync(string toEmail, string subject, string messages)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("dino.wuckert84@ethereal.email"));
            //email.To.Add(MailboxAddress.Parse(toEmail));
            //email.Subject = subject;
            //email.Body = new TextPart(TextFormat.Text) {Text = message};
            //using var smtp = new SmtpClient();
            //smtp.Connect("smtp.ethereal.email",587,SecureSocketOptions.StartTls);
            //smtp.Authenticate("dino.wuckert84@ethereal.email", "t42kMnWP6t4Uh8XDUx");
            //smtp.Send(email);
            //smtp.Disconnect(true);
            //  await Execute(Options.SendGridKey, subject, message, toEmail);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(name: "John Doe", address: "Milloche@yandex.ru"));
            message.To.Add(new MailboxAddress(name: "Bruce Williams", address: "nodemon12323@gmail.com"));
            message.Subject = "Test subject";

            message.Body = new TextPart("plain")
            {
                Text = "Test body"
            };

            using (var client = new SmtpClient())
            {
                client.Connect(host: "smtp.yandex.ru", port: 465, useSsl: true);
                client.Authenticate(userName: "15bcb078c6ea8863d4acccad98c35737", password: "yjvchjxggapdjtjj");
                client.Send(message);
                client.Disconnect(quit: true);
            }
        }
        //yjvchjxggapdjtjj
        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("nodemon12323@gmail.com", "Thegamegood1234530"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }
    }
}
