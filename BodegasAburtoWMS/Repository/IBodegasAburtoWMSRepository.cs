using BodegasAburtoWMS.Model;
using System.Collections.Generic;

namespace BodegasAburtoWMS.Repository
{
    public interface IBodegasAburtoWMSRepository
    {
        Usuario ObtenerUsuarioPorNombre(string usuario);

        List<Usuario> ObtenerUsuarios();

        bool RegistrarUsuario(Usuario usuario);

        bool ActualizarUsuario(Usuario usuario);

        bool DesactivarUsuario(int idUsuario);

        void RegistrarUltimoAcceso(int idUsuario);

        void RegistrarAuditoria(
            int idUsuario,
            string accion,
            string usuarioSistema,
            string detalle
        );
        bool RegistrarEnvio(Envio envio);

    }
}