using workshop_asp_net_core_mvc.Data;
using workshop_asp_net_core_mvc.Models;

namespace workshop_asp_net_core_mvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();

        }
    }
}
