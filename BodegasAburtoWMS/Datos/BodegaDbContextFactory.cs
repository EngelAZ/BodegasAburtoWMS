using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BodegasAburtoWMS.Datos
{
    /// <summary>Solo para EF Core CLI / Package Manager Console.</summary>
    public sealed class BodegaDbContextFactory : IDesignTimeDbContextFactory<BodegaDbContext>
    {
        public BodegaDbContext CreateDbContext(string[] args)
        {
            var configuration = BodegaDbConfiguration.Load(
                BodegaDbConfiguration.ResolveBasePath());
            var connectionString = BodegaDbConfiguration.GetConnectionString(configuration);
            var options = new DbContextOptionsBuilder<BodegaDbContext>()
                .UseSqlServer(connectionString)
                .Options;
            return new BodegaDbContext(options);
        }
    }
}
