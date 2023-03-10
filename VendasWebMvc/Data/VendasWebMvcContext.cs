using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Models;

namespace VendasWebMvc.Data
{
    public class VendasWebMvcContext : DbContext
    {
        public VendasWebMvcContext (DbContextOptions<VendasWebMvcContext> options)
            : base(options)
        {
        }

        //Faz com que o models sejam reconhecidos pelo EntityFramework
        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
