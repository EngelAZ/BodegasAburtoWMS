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
    /*internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 0. Construir la configuración para leer Secretos de Usuario y/o appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets(typeof(Program).Assembly)// <--- Esto lee los secretos de usuario de tu PC
                .Build();

            // 1. Crear el contenedor de servicios para la Inyección de Dependencias
            var services = new ServiceCollection();

            // 2. Registrar el DbContext como Transient para aislar las instancias y evitar conflictos de hilos, usando la cadena de conexión leída de los secretos
            services.AddDbContext<BodegaDbContext>(options =>
            {
                // Asegúrate de que aquí esté tu cadena de conexión o usa la configuración del DbContext
                // Aquí leemos la cadena usando la configuración que acabamos de construir
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);

            // 3. Registrar el Repositorio como Transient
            services.AddTransient<IBodegasAburtoWMSRepository, BodegasAburtoWMSRepository>();
            services.AddScoped<PresupuestoService>();
            services.AddScoped<PresupuestoOperativoService>();
            services.AddScoped<EstadoProformaService>();

            // 4. Registrar todos los formularios de la aplicación
            services.AddTransient<Login>();
            services.AddTransient<Register>();
            services.AddTransient<Principal>();
            services.AddTransient<Agencias>();
            services.AddTransient<Clientes>();
            services.AddTransient<DatosEnvios>();
            services.AddTransient<RegistroDiario>();
            services.AddTransient<FormSupuestosBudget>();
            services.AddTransient<FormPresupuestoOperacion>();
            services.AddTransient<FormEstadosProforma>();
            services.AddTransient<FormModuloPresupuesto>();

            // 5. Construir el proveedor de servicios
            using var serviceProvider = services.BuildServiceProvider();

            // Aplicar migraciones pendientes automáticamente al arrancar
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<BodegaDbContext>();
                    dbContext.Database.Migrate(); // Aplica cualquier migración nueva que haya bajado de Git
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar las migraciones a la base de datos: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 6. Iniciar la aplicación ejecutando primero el formulario de Login
            var loginForm = serviceProvider.GetRequiredService<Login>();
            Application.Run(loginForm);
        }
    }*/

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
