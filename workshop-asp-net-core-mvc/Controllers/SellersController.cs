using Microsoft.AspNetCore.Mvc;
using workshop_asp_net_core_mvc.Models;
using workshop_asp_net_core_mvc.Models.ViewModels;
using workshop_asp_net_core_mvc.Services;
using workshop_asp_net_core_mvc.Services.Exceptions;

namespace workshop_asp_net_core_mvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        // GET: Sellers
        public IActionResult Index()
        {
            return View(_sellerService.FindAll());
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        // POST: Sellers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            //return RedirectToAction("Index"); or
            return RedirectToAction(nameof(Index));
        }

        // GET: Sellers/Delete/x
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Sellers/Delete/x
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Sellers/Details/x
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Sellers/Edit/x
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel
            {
                Seller = obj,
                Departments = departments
            };
            return View(viewModel);
        }

        //POST: Sellers/Edit/x
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
