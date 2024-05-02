using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Number)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(a => a.Complement)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Address");
        }
    }
}
