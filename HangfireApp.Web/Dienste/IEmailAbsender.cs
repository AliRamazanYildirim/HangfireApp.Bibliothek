namespace HangfireApp.Web.Dienste
{
    public interface IEmailAbsender
    {
        Task Absender(string benutzerId, string nachricht);
    }
}
