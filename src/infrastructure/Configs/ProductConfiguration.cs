using Delicious.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delicious.infrastructure
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.HasKey(k=>k.Id);
           builder.Property(p=>p.ProductName).HasMaxLength(50).IsRequired();
           builder.Property(p=>p.UrlShortName).HasMaxLength(70).IsRequired();
           builder.Property(p=>p.Price).IsRequired();
           
           builder.Property(p=>p.Describe).IsRequired(false);
           builder.Property(p=>p.Images).HasMaxLength(100).IsRequired(false);

           builder.HasOne(p=>p.Category)
                    .WithMany(c=>c.Products)
                    .HasForeignKey(fk=>fk.CategoryId);
        }
    }
}