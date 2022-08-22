using HangfireApp.Web.Dienste;

namespace HangfireApp.Web.BackgroundJobs
{
    public class FireAndForgetJobs
    {
        public static void EmailSendenZuBenutzerJob(string benutzerId,string nachricht)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailAbsender>(x => x.Absender(benutzerId, nachricht));
        }
        //Weitere Jobs kann man hier hinzufügen
    }
}
