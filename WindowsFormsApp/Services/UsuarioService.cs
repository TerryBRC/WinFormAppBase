using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using WindowsFormsApp.Models;
using WindowsFormsApp.Utils;

namespace WindowsFormsApp.Services
{
    public  class UsuarioService
    {
        private readonly string connectionString;

        public UsuarioService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // 1️⃣ Método para Insertar un Usuario
        public int InsertarUsuario(Usuario usuario)
        {
            int idUsuario = 0;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("InsertUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_Nombre_Completo", usuario.NombreCompleto);
                        command.Parameters.AddWithValue("@p_usuario", usuario.UsuarioN);
                        command.Parameters.AddWithValue("@p_pwd", usuario.Pwd); // Encripta antes de enviar
                        command.Parameters.AddWithValue("@p_IdUbicacion", usuario.IdUbicacion);
                        command.Parameters.AddWithValue("@p_Rol", usuario.Rol);

                        // Agregar parámetro de salida para obtener el ID
                        MySqlParameter outputIdParam = new MySqlParameter("@p_IdUsuario", MySqlDbType.Int32);
                        outputIdParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        // Obtener el ID generado
                        idUsuario = Convert.ToInt32(outputIdParam.Value);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar usuario: " + ex.Message);
                }
            }
            return idUsuario;
        }


        // 2️⃣ Método para Obtener Todos los Usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("GetUsuarios", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuarios.Add(new Usuario
                                {
                                    IdUsuario = reader.GetInt32("IdUsuario"),
                                    NombreCompleto = reader.GetString("Nombre_Completo"),
                                    UsuarioN = reader.GetString("usuario"),
                                    Pwd = reader.GetString("pwd"),
                                    IdUbicacion = reader.IsDBNull(reader.GetOrdinal("IdUbicacion")) ? (int?)null : reader.GetInt32("IdUbicacion"),
                                    Rol = reader.GetString("Rol")
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener usuarios: " + ex.Message);
                }
            }
            return usuarios;
        }

        // 3️⃣ Método para Obtener un Usuario por ID
        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            Usuario usuario = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("GetUsuarioById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_IdUsuario", idUsuario);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario
                                {
                                    IdUsuario = reader.GetInt32("IdUsuario"),
                                    NombreCompleto = reader.GetString("Nombre_Completo"),
                                    UsuarioN = reader.GetString("usuario"),
                                    Pwd = reader.GetString("pwd"),
                                    IdUbicacion = reader.IsDBNull(reader.GetOrdinal("IdUbicacion")) ? (int?)null : reader.GetInt32("IdUbicacion"),
                                    Rol = reader.GetString("Rol")
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener usuario: " + ex.Message);
                }
            }
            return usuario;
        }

        // 4️⃣ Método para Actualizar un Usuario
        public bool ActualizarUsuario(Usuario usuario)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("UpdateUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_IdUsuario", usuario.IdUsuario);
                        command.Parameters.AddWithValue("@p_Nombre_Completo", usuario.NombreCompleto);
                        command.Parameters.AddWithValue("@p_usuario", usuario.UsuarioN);
                        command.Parameters.AddWithValue("@p_pwd", usuario.Pwd); // Encripta antes de enviar
                        command.Parameters.AddWithValue("@p_IdUbicacion", usuario.IdUbicacion);
                        command.Parameters.AddWithValue("@p_Rol", usuario.Rol);
                        exito = command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar usuario: " + ex.Message);
                }
            }
            return exito;
        }

        // 5️⃣ Método para Eliminar un Usuario
        public bool EliminarUsuario(int idUsuario)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("DeleteUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_IdUsuario", idUsuario);
                        exito = command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar usuario: " + ex.Message);
                }
            }
            return exito;
        }
        // Método para Autenticar un Usuario
        public Usuario AutenticarUsuario(string usuarioN, string pwd)
        {
            Usuario usuarioAutenticado = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("GetUsuarioPorNombreUsuario", connection)) // Asumiendo que tienes un SP para obtener usuario por nombre
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_usuario", usuarioN);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashedPassword = reader.GetString("pwd"); // Obtiene la contraseña hasheada de la base de datos
                                if (Encriptador.VerificarContraseña(pwd, hashedPassword)) // Verifica la contraseña
                                {
                                    usuarioAutenticado = new Usuario
                                    {
                                        IdUsuario = reader.GetInt32("IdUsuario"),
                                        NombreCompleto = reader.GetString("Nombre_Completo"),
                                        UsuarioN = reader.GetString("usuario"),
                                        Pwd = hashedPassword, // Mantén la contraseña hasheada
                                        IdUbicacion = reader.IsDBNull(reader.GetOrdinal("IdUbicacion")) ? (int?)null : reader.GetInt32("IdUbicacion"),
                                        Rol = reader.GetString("Rol")
                                    };
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al autenticar usuario: " + ex.Message);
                }
            }
            return usuarioAutenticado;
        }

        // Método para hashear contraseña antes de guardar
        public string HashPassword(string password)
        {
            return Encriptador.EncriptarContraseña(password);
        }
    }
}
