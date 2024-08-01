using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using workshop_asp_net_core_mvc.Models;

namespace workshop_asp_net_core_mvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department
            {
                Id = 1,
                Name = "Eletronics"
            });
            list.Add(new Department
            {
                Id = 2,
                Name = "Fashion"
            });

            return View(list);
        }
    }
}
