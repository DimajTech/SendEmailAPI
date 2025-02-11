using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using SendEmailAPI.Model;
namespace SendEmailAPI.Service
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public void SendEmail(Email request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:Username").Value));
            email.To.Add(MailboxAddress.Parse(request.ToUser));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Content };
            using var smtp = new SmtpClient();

            bool ignoreCertErrors = bool.Parse(_configuration["Email:IgnoreCertificateErrors"] ?? "false");
            if (ignoreCertErrors)
            {
                smtp.ServerCertificateValidationCallback = (s, cert, chain, sslPolicyErrors) => true;
            }

            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
            );
            smtp.Authenticate(_configuration.GetSection("Email:Username").Value, _configuration.GetSection("Email:Password").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
