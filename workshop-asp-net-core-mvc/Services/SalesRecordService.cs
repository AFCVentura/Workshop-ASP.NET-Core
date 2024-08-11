using Microsoft.EntityFrameworkCore;
using workshop_asp_net_core_mvc.Data;
using workshop_asp_net_core_mvc.Models;

namespace workshop_asp_net_core_mvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;
        
        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            //LINQ replicating SQL
            var result = from obj in _context.SalesRecord select obj; // Returns a IQueryable object
            // var result2 = _context.SalesRecord.ToList(); Returns a list, not so good
            if (minDate.HasValue)
            {
                // IQueryable permits to use more methods the query before the query is called in the db
                result = result.Where(x => x.Date >= minDate.Value); 
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync(); // The query will only be called here if we create an IQueryable object before
        }
    }
}
