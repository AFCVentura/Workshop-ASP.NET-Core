using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
            // ToListAsync is a EntityFrameworkCore method
        }
    }
}
