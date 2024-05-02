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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // caso esqueça de mapear as strings aqui ele criará um varchar(100) ao invés de max
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevIODbContext).Assembly);

            // varre todos os relacionamento e seta o comportamento para clientSetNull
            // impede que delete em cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
