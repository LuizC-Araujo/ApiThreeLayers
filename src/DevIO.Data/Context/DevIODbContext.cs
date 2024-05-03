using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context
{
    public class DevIODbContext : DbContext
    {
        public DevIODbContext(DbContextOptions<DevIODbContext> options) : base(options) 
        {
            // evita problema de concorrência
            // não faz sentido ter o tracking ativado quando traz o objeto do banco e mapeia pra outra model/viewModel/DTO
            // só vale a pena ter ligado quando mapeia e executa ela mesma
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
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

        public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default)
        {
            // pega as entidades de CreatedAt
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added) entry.Property("CreatedAt").CurrentValue = DateTime.Now;

                // com IsModified = false, o EF não inclui essa propriedade na query que vai fazer o update
                if (entry.State == EntityState.Modified) entry.Property("CreatedAt").IsModified = false;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
