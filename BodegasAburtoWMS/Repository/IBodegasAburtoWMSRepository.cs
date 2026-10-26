using System.Collections.Generic;
using System.Threading.Tasks;
using BodegasAburtoWMS.Model;

namespace BodegasAburtoWMS.Repository
{
    public interface IBodegasAburtoWMSRepository
    {
        Task<Usuario?> ObtenerUsuarioPorNombreAsync(string usuario);
        Task<List<Usuario>> ObtenerUsuariosAsync();
        Task<bool> RegistrarUsuarioAsync(Usuario usuario);
        Task<bool> ActualizarUsuarioAsync(Usuario usuario);
        Task<bool> DesactivarUsuarioAsync(int idUsuario);
        Task RegistrarUltimoAccesoAsync(int idUsuario);
        Task RegistrarAuditoriaAsync(int idUsuario, string accion, string usuarioSistema, string detalle);

        Task<List<ComboboxItem>> ObtenerAgenciasComboAsync();
        Task<List<ComboboxItem>> ObtenerTiposEnvioComboAsync();
        Task<List<ComboboxItem>> ObtenerEstadosEnvioComboAsync();
        Task<List<ComboboxItem>> ObtenerClientesComboAsync();
        Task<List<ComboboxItem>> ObtenerRolesComboAsync();

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
    }
}