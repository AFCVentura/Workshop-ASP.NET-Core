using System.Security.Cryptography;
using workshop_asp_net_core_mvc.Data;
using workshop_asp_net_core_mvc.Models;

namespace workshop_asp_net_core_mvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
