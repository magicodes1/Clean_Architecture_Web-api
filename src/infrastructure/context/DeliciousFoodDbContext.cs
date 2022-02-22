using System.Reflection;
using Delicious.core;
using Microsoft.EntityFrameworkCore;

namespace Delicious.infrastructure
{
    public class DeliciousFoodDbContext : DbContext
    {
        public DeliciousFoodDbContext(DbContextOptions<DeliciousFoodDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}