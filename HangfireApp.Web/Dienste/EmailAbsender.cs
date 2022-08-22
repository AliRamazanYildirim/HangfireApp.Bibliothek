using SendGrid.Helpers.Mail;
using SendGrid;

namespace HangfireApp.Web.Dienste
{
    public class EmailAbsender : IEmailAbsender
    {
        private readonly IConfiguration _configuration;

        public EmailAbsender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Absender(string benutzerId, string nachricht)
        {
            //
            var apiSchlüssel = _configuration.GetSection("API")["SendGridApiSchlüssel"];
            var client = new SendGridClient(apiSchlüssel);
            var von = new EmailAddress("steinschwarz29@gmail.com", "Beispielbenutzer");
            var subjekt = "Info über www.meinewebseite.com";
            var zu = new EmailAddress("ebrargun12@gmail.com", "Beispielbenutzer");
            var reinerTextInhalt = "Und einfach überall, auch mit C#";
            var htmlInhalt = $"<strong>{nachricht}</strong>";
            var ncht = MailHelper.CreateSingleEmail(von, zu, subjekt, reinerTextInhalt, htmlInhalt);
            await client.SendEmailAsync(ncht);
        }
    }
}
