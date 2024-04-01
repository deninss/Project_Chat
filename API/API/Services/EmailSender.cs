using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using WebChat.Domain;
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
            
        }
        //yjvchjxggapdjtjj
        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
             
        }
    }
}
