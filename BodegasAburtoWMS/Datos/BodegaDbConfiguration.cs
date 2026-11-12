using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BodegasAburtoWMS.Datos
{
    /// <summary>
    /// Fuente única de configuración para ejecución y herramientas de EF Core.
    /// Prioridad: appsettings.json, User Secrets, variables de entorno.
    /// </summary>
    public static class BodegaDbConfiguration
    {
        public static IConfigurationRoot Load(string basePath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddUserSecrets<BodegaDbContext>(optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static string GetConnectionString(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Falta ConnectionStrings:DefaultConnection. " +
                    "Configúrala en User Secrets, appsettings.json o " +
                    "la variable de entorno ConnectionStrings__DefaultConnection.");
            }
            return connectionString;
        }

        public static string ResolveBasePath()
        {
            string current = Directory.GetCurrentDirectory();
            string[] paths =
            {
                AppContext.BaseDirectory,
                current,
                Path.Combine(current, "BodegasAburtoWMS")
            };
            foreach (var path in paths)
            {
                if (File.Exists(Path.Combine(path, "appsettings.json")))
                    return path;
            }
            // User Secrets puede suministrar la conexión aunque no exista JSON.
            return AppContext.BaseDirectory;
        }
    }
}
