using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using BodegasAburtoWMS;

namespace BodegasAburtoWMS.Datos
{
    public class BodegaDbContextFactory : IDesignTimeDbContextFactory<BodegaDbContext>
    {
        public BodegaDbContext CreateDbContext(string[] args)
        {
            // Lee el appsettings.json del proyecto principal
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets(typeof(Program).Assembly)
                .Build();

            var builder = new DbContextOptionsBuilder<BodegaDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new BodegaDbContext(builder.Options);
        }
    }
}