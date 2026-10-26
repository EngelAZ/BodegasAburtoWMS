using BodegasAburtoWMS.Datos;
using BodegasAburtoWMS.Model;
using BodegasAburtoWMS.Repository;
using BodegasAburtoWMS.View;
using Microsoft.Extensions.DependencyInjection;

namespace BodegasAburtoWMS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Crear el contenedor de servicios para la Inyección de Dependencias
            var services = new ServiceCollection();

            // 2. Registrar el DbContext como Transient para aislar las instancias y evitar conflictos de hilos
            services.AddDbContext<BodegaDbContext>(options =>
            {
                // Asegúrate de que aquí esté tu cadena de conexión o usa la configuración del DbContext
            }, ServiceLifetime.Transient);

            // 3. Registrar el Repositorio como Transient
            services.AddTransient<IBodegasAburtoWMSRepository, BodegasAburtoWMSRepository>();

            // 4. Registrar todos los formularios de la aplicación
            services.AddTransient<Login>();
            services.AddTransient<Register>();
            services.AddTransient<Principal>();
            services.AddTransient<Agencias>();
            services.AddTransient<Clientes>();
            services.AddTransient<DatosEnvios>();
            services.AddTransient<RegistroDiario>();

            // 5. Construir el proveedor de servicios
            using var serviceProvider = services.BuildServiceProvider();

            // 6. Iniciar la aplicación ejecutando primero el formulario de Login
            var loginForm = serviceProvider.GetRequiredService<Login>();
            Application.Run(loginForm);
        }
    }

}
