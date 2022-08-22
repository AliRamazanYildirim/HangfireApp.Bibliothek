using Hangfire;
using System.Diagnostics;

namespace HangfireApp.Web.BackgroundJobs
{
    public class RecurringJobs
    {
        public static void BerichterStattungsProzess()
        {
            Hangfire.RecurringJob.AddOrUpdate("bericht1", () => EmailBericht(), Cron.Minutely);
        }
        public static void EmailBericht()
        {
            Debug.WriteLine("Der Bericht wurde per Email gesendet");
        }
    }
}
