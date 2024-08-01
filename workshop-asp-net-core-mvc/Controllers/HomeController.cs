using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using workshop_asp_net_core_mvc.Models;
using workshop_asp_net_core_mvc.Models.ViewModels;

namespace workshop_asp_net_core_mvc.Controllers
{
    public class HomeController : Controller
    {
        // attribute
        private readonly ILogger<HomeController> _logger;

        // constructor
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // methods
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
    }
}
