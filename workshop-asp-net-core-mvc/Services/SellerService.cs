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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.Include(obj => obj.Department).ToListAsync();

        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                throw new IntegrityException(ex.Message);
            }
        }

        public async Task InsertAsync(Seller obj)
        {            
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj) 
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
