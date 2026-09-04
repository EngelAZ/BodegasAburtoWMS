using BodegasAburtoWMS.Helpers;
using BodegasAburtoWMS.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BodegasAburtoWMS.Repository
{
    public class BodegasAburtoWMSRepository : IBodegasAburtoWMSRepository
    {
        private readonly string connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=BodegasAburtoWMS;Trusted_Connection=True;TrustServerCertificate=True;";

        public Usuario ObtenerUsuarioPorNombre(string usuario)
        {
            Usuario usuarioEncontrado = null;

            string query = @"
                SELECT 
                    u.IdUsuario,
                    u.Usuario,
                    u.Nombre,
                    u.Apellido,
                    u.Correo,
                    u.IdRol,
                    r.Nombre AS Rol,
                    u.PasswordHash,
                    u.PasswordSalt,
                    u.Activo
                FROM Usuarios u
                INNER JOIN Roles r 
                    ON u.IdRol = r.IdRol
                WHERE u.Usuario = @Usuario
                  AND u.Activo = 1;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario", usuario);

                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuarioEncontrado = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                                UsuarioNombre = reader["Usuario"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Correo = reader["Correo"] == DBNull.Value
                                    ? null
                                    : reader["Correo"].ToString(),
                                IdRol = Convert.ToInt32(reader["IdRol"]),
                                Rol = reader["Rol"].ToString(),
                                PasswordHash = (byte[])reader["PasswordHash"],
                                PasswordSalt = (byte[])reader["PasswordSalt"],
                                Activo = Convert.ToBoolean(reader["Activo"])
                            };
                        }
                    }
                }
            }

            return usuarioEncontrado;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            string query = @"
                SELECT 
                    u.IdUsuario,
                    u.Usuario,
                    u.Nombre,
                    u.Apellido,
                    u.Correo,
                    u.IdRol,
                    r.Nombre AS Rol,
                    u.PasswordHash,
                    u.PasswordSalt,
                    u.Activo
                FROM Usuarios u
                INNER JOIN Roles r 
                    ON u.IdRol = r.IdRol
                ORDER BY u.IdUsuario;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                                UsuarioNombre = reader["Usuario"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Correo = reader["Correo"] == DBNull.Value
                                    ? null
                                    : reader["Correo"].ToString(),
                                IdRol = Convert.ToInt32(reader["IdRol"]),
                                Rol = reader["Rol"].ToString(),
                                PasswordHash = (byte[])reader["PasswordHash"],
                                PasswordSalt = (byte[])reader["PasswordSalt"],
                                Activo = Convert.ToBoolean(reader["Activo"])
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            string query = @"
        INSERT INTO Usuarios
        (
            Usuario,
            Nombre,
            Apellido,
            Correo,
            IdRol,
            PasswordHash,
            PasswordSalt,
            Activo
        )
        VALUES
        (
            @Usuario,
            @Nombre,
            @Apellido,
            @Correo,
            @IdRol,
            @PasswordHash,
            @PasswordSalt,
            @Activo
        );";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@Usuario", System.Data.SqlDbType.NVarChar, 50)
                        .Value = usuario.UsuarioNombre;

                    comando.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 100)
                        .Value = usuario.Nombre;

                    comando.Parameters.Add("@Apellido", System.Data.SqlDbType.NVarChar, 100)
                        .Value = usuario.Apellido;

                    comando.Parameters.Add("@Correo", System.Data.SqlDbType.NVarChar, 150)
                        .Value = (object)usuario.Correo ?? DBNull.Value;

                    comando.Parameters.Add("@IdRol", System.Data.SqlDbType.Int)
                        .Value = usuario.IdRol;

                    comando.Parameters.Add("@PasswordHash", System.Data.SqlDbType.VarBinary, 64)
                        .Value = usuario.PasswordHash;

                    comando.Parameters.Add("@PasswordSalt", System.Data.SqlDbType.VarBinary, 32)
                        .Value = usuario.PasswordSalt;

                    comando.Parameters.Add("@Activo", System.Data.SqlDbType.Bit)
                        .Value = usuario.Activo;

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            string query = @"
                UPDATE Usuarios
                SET
                    Usuario = @Usuario,
                    Nombre = @Nombre,
                    Apellido = @Apellido,
                    Correo = @Correo,
                    IdRol = @IdRol,
                    Activo = @Activo
                WHERE IdUsuario = @IdUsuario;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    comando.Parameters.AddWithValue("@Usuario", usuario.UsuarioNombre);
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    comando.Parameters.AddWithValue(
                        "@Correo",
                        (object)usuario.Correo ?? DBNull.Value
                    );
                    comando.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                    comando.Parameters.AddWithValue("@Activo", usuario.Activo);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DesactivarUsuario(int idUsuario)
        {
            string query = @"
                UPDATE Usuarios
                SET Activo = 0
                WHERE IdUsuario = @IdUsuario;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}