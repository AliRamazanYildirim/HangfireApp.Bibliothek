using System.Diagnostics;

namespace HangfireApp.Web.BackgroundJobs
{
    public class ContinuationsJobs
    {
        public static void SchreibenWasserZeichenStatus(string id,string dateiName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{dateiName}:Der Dateipfad wurde dem Bild hinzugefügt."));
        }
    }
}
