using Microsoft.AspNetCore.Mvc;

namespace workshop_asp_net_core_mvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
    }
}
