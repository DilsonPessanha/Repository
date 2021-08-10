using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Infrastructure.Model;

namespace Products.Infrastructure.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<ProductObject>
    {
        public void Configure(EntityTypeBuilder<ProductObject> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.Name).HasColumnName("Name");

            builder.Property(e => e.Price).HasColumnName("Price");
        }
    }
}
