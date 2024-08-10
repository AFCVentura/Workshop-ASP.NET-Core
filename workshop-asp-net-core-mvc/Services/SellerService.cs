using Microsoft.EntityFrameworkCore;
using workshop_asp_net_core_mvc.Data;
using workshop_asp_net_core_mvc.Models;
using workshop_asp_net_core_mvc.Services.Exceptions;

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
            return _context.Seller.Include(obj => obj.Department).ToList();

        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Insert(Seller obj)
        {            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj) 
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
