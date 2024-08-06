using Microsoft.AspNetCore.Mvc;
using workshop_asp_net_core_mvc.Services;

namespace workshop_asp_net_core_mvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        // GET: Sellers
        public IActionResult Index()
        {
            return View(_sellerService.FindAll());
        } 
    }
}
