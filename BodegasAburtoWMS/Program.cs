using System;
using System.Windows.Forms;
using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Repository;
using BodegasAburtoWMS.Service;
using BodegasAburtoWMS.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BodegasAburtoWMS
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            try
            {
                var configuration = BodegaDbConfiguration.Load(
                    BodegaDbConfiguration.ResolveBasePath());
                string connectionString = BodegaDbConfiguration.GetConnectionString(configuration);

                var services = new ServiceCollection();

                // Factory de runtime (singleton). Cada repositorio/servicio
                // solicita y libera su propio DbContext por operación.
                services.AddDbContextFactory<BodegaDbContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddScoped<IBodegasAburtoWMSRepository, BodegasAburtoWMSRepository>();
                services.AddScoped<PresupuestoService>();
                services.AddScoped<PresupuestoOperativoService>();
                services.AddScoped<EstadoProformaService>();
                services.AddScoped<FinanzasEstadosService>();

                services.AddTransient<Login>();
                services.AddTransient<Register>();
                // Principal necesita un Usuario autenticado; se crea en Login,
                // NO mediante el contenedor sin argumentos de usuario.
                services.AddTransient<Agencias>();
                services.AddTransient<Clientes>();
                services.AddTransient<DatosEnvios>();
                services.AddTransient<RegistroDiario>();
                services.AddTransient<FormSupuestosBudget>();
                services.AddTransient<FormPresupuestoOperacion>();
                services.AddTransient<FormEstadosProforma>();
                services.AddTransient<FormModuloPresupuesto>();

                using var serviceProvider = services.BuildServiceProvider(
                    new ServiceProviderOptions
                    {
                        ValidateScopes = true,
                        ValidateOnBuild = true
                    });

                // Nunca alterar bases existentes automáticamente por defecto.
                // Habilitar explícitamente con Database:ApplyMigrationsOnStartup=true,
                // después de revisar migraciones y respaldar la base.
                if (bool.TryParse(configuration["Database:ApplyMigrationsOnStartup"], out bool migrate)
                    && migrate)
                {
                    var factory = serviceProvider.GetRequiredService<IDbContextFactory<BodegaDbContext>>();
                    using var context = factory.CreateDbContext();
                    context.Database.Migrate();
                }

                using var uiScope = serviceProvider.CreateScope();
                using var loginForm = uiScope.ServiceProvider.GetRequiredService<Login>();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al iniciar ABURTO WMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
