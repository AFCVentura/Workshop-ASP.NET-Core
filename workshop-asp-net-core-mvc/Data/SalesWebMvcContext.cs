using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using workshop_asp_net_core_mvc.Models;

namespace workshop_asp_net_core_mvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
    }
}
