using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Montreal.Domain.Models;

namespace Montreal.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);

            builder.HasOne(c => c.FatherProduct)
                .WithMany(c => c.ChildrenProducts)
                .HasForeignKey(c => c.IdFatherProduct);

            builder.HasMany(c => c.Images)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.IdProduct);
        }
    }
}
