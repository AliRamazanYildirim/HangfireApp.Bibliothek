using HangfireApp.Web.BackgroundJobs;
using HangfireApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace HangfireApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Anmelden()
        {
            //Der Registrierungsprozess der Mitglieder findet im Rahmen dieser Methode statt.
            FireAndForgetJobs.EmailSendenZuBenutzerJob("123","Willkommen auf unserer Website");
            return View();
        }

        public IActionResult BildSpeichern()
        {
            BackgroundJobs.RecurringJobs.BerichterStattungsProzess();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BildSpeichern(IFormFile bild)
        {
            string neueDateiName = String.Empty;
            if(bild!=null && bild.Length>0)
            {
                neueDateiName = Guid.NewGuid().ToString() + Path.GetExtension(bild.FileName);
                var weg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/bilder", neueDateiName);
                using(var strom=new FileStream(weg,FileMode.Create))
                {
                    await bild.CopyToAsync(strom);
                }
                string jobId=BackgroundJobs.DelayedJobs.WasserZeichenJobHinzufügen(neueDateiName, "www.meinewebseite.com");
                BackgroundJobs.ContinuationsJobs.SchreibenWasserZeichenStatus(jobId,neueDateiName);
            }
            return View();
        }
    }
}