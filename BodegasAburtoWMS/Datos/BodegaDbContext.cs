using System;
using System.Collections.Generic;
using System.Text;

namespace BodegasAburtoWMS.Datos
{
    using BodegasAburtoWMS.Model;
    using Microsoft.EntityFrameworkCore;

    public class BodegaDbContext : DbContext
    {
        public BodegaDbContext(DbContextOptions<BodegaDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<AuditoriaUsuario> AuditoriaUsuarios => Set<AuditoriaUsuario>();
        public DbSet<Envio> Envios => Set<Envio>();
        public DbSet<Agencia> Agencias => Set<Agencia>();
        public DbSet<TipoEnvio> TiposEnvio => Set<TipoEnvio>();
        public DbSet<EstadoEnvio> EstadosEnvio => Set<EstadoEnvio>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<PresupuestoParametro> PresupuestoParametros { get; set; }
        public DbSet<PresupuestoTrimestral> PresupuestoTrimestrales { get; set; }
        public DbSet<EstadoFinancieroProforma> EstadosFinancierosProforma { get; set; }
        public DbSet<CuentaBalance> CuentaBalances => Set<CuentaBalance>();

        // Nuevo modelo: catálogo estable + ejercicios + saldos por ejercicio.
        // CuentaBalances se mantiene intacta como tabla legacy.
        public DbSet<CatalogoCuentaFinanciera> CatalogoCuentasFinancieras => Set<CatalogoCuentaFinanciera>();
        public DbSet<EjercicioFinanciero> EjerciciosFinancieros => Set<EjercicioFinanciero>();
        public DbSet<SaldoCuentaFinanciera> SaldosCuentasFinancieras => Set<SaldoCuentaFinanciera>();
        public DbSet<CambioEstadoEjercicioFinanciero> HistorialEstadosEjercicios
            => Set<CambioEstadoEjercicioFinanciero>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Roles
            modelBuilder.Entity<Rol>(e =>
            {
                e.ToTable("Roles");
                e.HasKey(x => x.IdRol);
                e.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
            });

            // Configuración de Usuarios (mapeando 'Usuario' en SQL a 'UsuarioNombre' en C#)
            modelBuilder.Entity<Usuario>(e =>
            {
                e.ToTable("Usuarios");
                e.HasKey(x => x.IdUsuario);
                e.Property(x => x.UsuarioNombre).HasColumnName("Usuario").HasMaxLength(50).IsRequired();
                e.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
                e.Property(x => x.Apellido).HasMaxLength(100).IsRequired();
                e.Property(x => x.Correo).HasMaxLength(150);
                e.Property(x => x.PasswordHash).HasColumnType("varbinary(64)").IsRequired();
                e.Property(x => x.PasswordSalt).HasColumnType("varbinary(32)").IsRequired();
                e.Property(x => x.Activo).IsRequired();
                e.Property(x => x.UltimoAcceso);

                e.HasOne(x => x.Rol)
                 .WithMany()
                 .HasForeignKey(x => x.IdRol)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Auditoría de Usuarios
            modelBuilder.Entity<AuditoriaUsuario>(e =>
            {
                e.ToTable("AuditoriaUsuarios");
                e.HasKey(x => x.IdAuditoria); // Asumiendo IdAuditoria como PK
                e.Property(x => x.Accion).HasMaxLength(50).IsRequired();
                e.Property(x => x.UsuarioSistema).HasMaxLength(100).IsRequired();
                e.Property(x => x.Detalle).HasMaxLength(500);

                e.HasOne(x => x.Usuario)
                 .WithMany()
                 .HasForeignKey(x => x.IdUsuario)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // Catálogos auxiliares (Combobox)
            modelBuilder.Entity<Agencia>(e =>
            {
                e.ToTable("Agencias");
                e.HasKey(x => x.IdAgencia);
                e.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
                e.Property(x => x.Contacto).HasMaxLength(100);
                e.Property(x => x.Telefono).HasMaxLength(20);
                e.Property(x => x.Ciudad).HasMaxLength(100);
                e.Property(x => x.Estado).IsRequired();
                e.Property(x => x.FechaRegistro).IsRequired();
            });

            modelBuilder.Entity<TipoEnvio>(e =>
            {
                e.ToTable("TiposEnvio");
                e.HasKey(x => x.IdTipoEnvio);
                e.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<EstadoEnvio>(e =>
            {
                e.ToTable("EstadosEnvio");
                e.HasKey(x => x.IdEstado);
                e.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Cliente>(e =>
            {
                e.ToTable("Clientes");
                e.HasKey(x => x.IdCliente);
                e.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
                e.Property(x => x.Apellido).HasMaxLength(100).IsRequired();
                e.Property(x => x.Telefono).HasMaxLength(20);
                e.Property(x => x.Correo).HasMaxLength(150);
                e.Property(x => x.Direccion).HasMaxLength(250);
                e.Property(x => x.NumeroCedula).HasMaxLength(50);
                e.Property(x => x.FechaRegistro).IsRequired();
            });

            // Configuración de Envíos
            modelBuilder.Entity<Envio>(e =>
            {
                e.ToTable("Envios");
                e.HasKey(x => x.IdEnvio);
                e.Property(x => x.NumeroGuia).HasMaxLength(50).IsRequired();
                e.HasIndex(x => x.NumeroGuia).IsUnique();
                e.Property(x => x.Origen).HasMaxLength(150);
                e.Property(x => x.Destino).HasMaxLength(150);
                e.Property(x => x.CostoEnvio).HasPrecision(18, 2);
                e.Property(x => x.Observaciones).HasMaxLength(500);

                e.HasOne(x => x.Agencia).WithMany().HasForeignKey(x => x.IdAgencia).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(x => x.ClienteRemitente).WithMany().HasForeignKey(x => x.IdClienteRemitente).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(x => x.ClienteDestinatario).WithMany().HasForeignKey(x => x.IdClienteDestinatario).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(x => x.TipoEnvio).WithMany().HasForeignKey(x => x.IdTipoEnvio).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(x => x.Estado).WithMany().HasForeignKey(x => x.IdEstado).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CatalogoCuentaFinanciera>(e =>
            {
                e.ToTable("CatalogoCuentasFinancieras");
                e.HasKey(x => x.IdCuentaFinanciera);
                e.Property(x => x.Codigo).HasMaxLength(30).IsRequired();
                e.HasIndex(x => x.Codigo).IsUnique();
                e.Property(x => x.Nombre).HasMaxLength(120).IsRequired();
                e.Property(x => x.Grupo).HasConversion<string>().HasMaxLength(40).IsRequired();
                e.Property(x => x.Naturaleza).HasConversion<string>().HasMaxLength(10).IsRequired();
                e.Property(x => x.Nota).HasMaxLength(500);
            });

            modelBuilder.Entity<EjercicioFinanciero>(e =>
            {
                e.ToTable("EjerciciosFinancieros");
                e.HasKey(x => x.IdEjercicioFinanciero);
                e.HasIndex(x => new { x.Anio, x.Escenario }).IsUnique();
                e.Property(x => x.Escenario).HasMaxLength(20).IsRequired();
                e.Property(x => x.Estado).HasMaxLength(20).IsRequired();
                e.Property(x => x.Moneda).HasMaxLength(3).IsRequired();
                e.Property(x => x.FuenteDatos).HasMaxLength(500);
            });

            modelBuilder.Entity<CambioEstadoEjercicioFinanciero>(e =>
            {
                e.ToTable("HistorialEstadosEjercicios");
                e.HasKey(x => x.IdCambioEstado);
                e.Property(x => x.EstadoAnterior).HasMaxLength(20).IsRequired();
                e.Property(x => x.EstadoNuevo).HasMaxLength(20).IsRequired();
                e.Property(x => x.Motivo).HasMaxLength(500).IsRequired();
                e.Property(x => x.FechaUtc).IsRequired();
                e.HasIndex(x => new { x.IdEjercicioFinanciero, x.FechaUtc });
                e.HasOne(x => x.Ejercicio).WithMany(x => x.HistorialEstados)
                    .HasForeignKey(x => x.IdEjercicioFinanciero)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SaldoCuentaFinanciera>(e =>
            {
                e.ToTable("SaldosCuentasFinancieras");
                e.HasKey(x => x.IdSaldoFinanciero);
                e.HasIndex(x => new { x.IdEjercicioFinanciero, x.IdCuentaFinanciera }).IsUnique();
                e.Property(x => x.Importe).HasPrecision(18, 6).IsRequired();
                e.Property(x => x.Version).IsRowVersion();
                e.HasOne(x => x.Cuenta).WithMany(x => x.Saldos)
                    .HasForeignKey(x => x.IdCuentaFinanciera).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(x => x.Ejercicio).WithMany(x => x.Saldos)
                    .HasForeignKey(x => x.IdEjercicioFinanciero).OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Cuentas de Balance General (con soporte multi-año)
            modelBuilder.Entity<CuentaBalance>(e =>
            {
                e.ToTable("CuentaBalances");
                e.HasKey(x => x.IdCuenta);
                e.Property(x => x.NombreCuenta).HasMaxLength(100).IsRequired();
                e.Property(x => x.Tipo).HasMaxLength(50).IsRequired();
                e.Property(x => x.Saldo).HasPrecision(18, 2);
                e.Property(x => x.Anio).IsRequired();
                e.Property(x => x.FechaActualizacion).IsRequired();
            });
        }
    }
}