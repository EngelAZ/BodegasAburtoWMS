using System.Collections.Generic;
using System.Threading.Tasks;
using BodegasAburtoWMS.Model;

namespace BodegasAburtoWMS.Repository
{
    public interface IBodegasAburtoWMSRepository
    {
<<<<<<< HEAD
        // Usuarios y Autenticación
        Task<List<Usuario>> ObtenerUsuariosAsync();
        Task<Usuario?> ObtenerUsuarioPorNombreAsync(string usuario);
=======
        Task<Usuario?> ObtenerUsuarioPorNombreAsync(string usuario);
        Task<List<Usuario>> ObtenerUsuariosAsync();
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
        Task<bool> RegistrarUsuarioAsync(Usuario usuario);
        Task<bool> ActualizarUsuarioAsync(Usuario usuario);
        Task<bool> DesactivarUsuarioAsync(int idUsuario);
        Task RegistrarUltimoAccesoAsync(int idUsuario);
        Task RegistrarAuditoriaAsync(int idUsuario, string accion, string usuarioSistema, string detalle);

<<<<<<< HEAD
        // ComboBoxes y Catálogos
=======
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
        Task<List<ComboboxItem>> ObtenerAgenciasComboAsync();
        Task<List<ComboboxItem>> ObtenerTiposEnvioComboAsync();
        Task<List<ComboboxItem>> ObtenerEstadosEnvioComboAsync();
        Task<List<ComboboxItem>> ObtenerClientesComboAsync();
        Task<List<ComboboxItem>> ObtenerRolesComboAsync();

<<<<<<< HEAD
        // Agencias
        Task<List<Agencia>> ObtenerAgenciasAsync();
        Task<List<Agencia>> BuscarAgenciasAsync(string filtro);
        Task<bool> GuardarAgenciaAsync(Agencia agencia);

        // Clientes
        Task<List<Cliente>> ObtenerClientesAsync();
        Task<List<Cliente>> BuscarClientesAsync(string filtro);
        Task<bool> GuardarClienteAsync(Cliente cliente);

        // Envíos y Entregas / Salidas (Nuevos métodos agregados)
        Task<bool> RegistrarEnvioAsync(Envio envio);
        Task<List<Envio>> ObtenerEnviosAsync();
        Task<List<Envio>> BuscarEnviosAsync(string filtro);
        Task<List<Envio>> ObtenerEnviosPendientesAsync();
        Task<bool> RegistrarEntregaEnvioAsync(int idEnvio, int idUsuarioAuditoria);
        Task<List<Envio>> ObtenerEnviosHistorialAsync();
        Task<bool> RevertirEntregaEnvioAsync(int idEnvio, int idUsuarioAuditoria);
=======
        // para Agencias
        Task<List<Agencia>> ObtenerAgenciasAsync();
        Task<List<Agencia>> BuscarAgenciasAsync(string filtro);
        Task<bool> GuardarAgenciaAsync(Agencia agencia);

        // para Clientes
        Task<List<Cliente>> ObtenerClientesAsync();
        Task<List<Cliente>> BuscarClientesAsync(string filtro);
        Task<bool> GuardarClienteAsync(Cliente cliente);

        //para Envio
        Task<bool> RegistrarEnvioAsync(Envio envio);

        //para Registro Diario
        Task<List<Envio>> ObtenerEnviosAsync();
        Task<List<Envio>> BuscarEnviosAsync(string filtro);
>>>>>>> 8ab2d7ad2998ff951d10edd89790beb4ec479ed8
    }
}