using HangfireApp.Web.BackgroundJobs;
using HangfireApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
    }
}