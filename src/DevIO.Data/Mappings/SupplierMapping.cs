using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s  => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(s => s.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //Relação de 1 pra 1 =: Supplier tem um Address

            builder.HasOne(s => s.Address)
                .WithOne(a => a.Supplier);

            //Relação 1 para N => Suppplier tem muitos products
            builder
                .HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(s => s.SupplierId);

            builder.ToTable("Suppliers");
        }
    }
}
