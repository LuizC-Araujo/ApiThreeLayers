using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context
{
    public class DevIODbContext : DbContext
    {
        public DevIODbContext(DbContextOptions<DevIODbContext> options) : base(options) 
        {
            // some configs
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
