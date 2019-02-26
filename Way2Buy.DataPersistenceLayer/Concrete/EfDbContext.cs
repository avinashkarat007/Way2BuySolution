using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Way2Buy.BusinessObjects.Entities;

namespace Way2Buy.DataPersistenceLayer.Concrete
{
    public class EfDbContext : DbContext
    {
        public EfDbContext():base("conn")
        {
            
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
