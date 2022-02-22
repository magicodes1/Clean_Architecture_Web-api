using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Delicious.infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DeliciousFoodDbContext>
    {
        public DeliciousFoodDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile(@Directory.GetCurrentDirectory() + "/../webapi/appsettings.json")
                                        .Build();
            var builder = new DbContextOptionsBuilder<DeliciousFoodDbContext>();
            var connectionString = configuration.GetConnectionString("defaultConnection");
            builder.UseSqlServer(connectionString);
            return new DeliciousFoodDbContext(builder.Options);
        }
    }
}