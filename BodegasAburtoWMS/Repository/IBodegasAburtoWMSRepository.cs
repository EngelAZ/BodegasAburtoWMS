using System.Collections.Generic;
using System.Threading.Tasks;
using BodegasAburtoWMS.Model;

namespace BodegasAburtoWMS.Repository
{
    public interface IBodegasAburtoWMSRepository
    {
        // Usuarios y Autenticación
        Task<List<Usuario>> ObtenerUsuariosAsync();
        Task<Usuario?> ObtenerUsuarioPorNombreAsync(string usuario);
        Task<bool> RegistrarUsuarioAsync(Usuario usuario);
        Task<bool> ActualizarUsuarioAsync(Usuario usuario);
        Task<bool> DesactivarUsuarioAsync(int idUsuario);
        Task RegistrarUltimoAccesoAsync(int idUsuario);
        Task RegistrarAuditoriaAsync(int idUsuario, string accion, string usuarioSistema, string detalle);

        // ComboBoxes y Catálogos
        Task<List<ComboboxItem>> ObtenerAgenciasComboAsync();
        Task<List<ComboboxItem>> ObtenerTiposEnvioComboAsync();
        Task<List<ComboboxItem>> ObtenerEstadosEnvioComboAsync();
        Task<List<ComboboxItem>> ObtenerClientesComboAsync();
        Task<List<ComboboxItem>> ObtenerRolesComboAsync();

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
    }
}