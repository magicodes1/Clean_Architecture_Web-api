using Delicious.core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delicious.infrastructure
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           builder.HasKey(k=>k.Id);
           builder.Property(n=>n.CategoryName).HasMaxLength(30).IsRequired();
        }
    }
}