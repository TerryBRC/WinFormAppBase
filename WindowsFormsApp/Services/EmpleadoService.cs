using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using WindowsFormsApp.Models;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp.Services
{
    public class EmpleadoService
    {
        private readonly string connectionString;

        public EmpleadoService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // 🔹 Método para Insertar un Empleado
        public int InsertarEmpleado(Empleado empleado)
        {
            int idEmpleado = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("InsertEmpleado", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_NombreCompleto", empleado.NombreCompleto);
                        cmd.Parameters.AddWithValue("@p_FechaIngreso", empleado.FechaIngreso);
                        cmd.Parameters.AddWithValue("@p_IdUsuario", empleado.IdUsuario);

                        // Parámetro de salida para obtener el ID generado
                        MySqlParameter outputIdParam = new MySqlParameter("@p_IdEmpleado", MySqlDbType.Int32);
                        outputIdParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputIdParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Obtener el ID generado
                        idEmpleado = Convert.ToInt32(outputIdParam.Value);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar empleado: " + ex.Message);
                }
            }
            return idEmpleado;
        }


        // 🔹 Método para Obtener Todos los Empleados
        public DataTable ObtenerEmpleados()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("GetEmpleados", connection);
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        // 🔹 Método para Obtener un Empleado por su ID
        public Empleado ObtenerEmpleadoPorId(int idEmpleado)
        {
            Empleado empleado = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetEmpleadoById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_IdEmpleado", idEmpleado);
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empleado = new Empleado
                            {
                                IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]),
                                NombreCompleto = reader["Nombre_Completo"].ToString(),
                                FechaIngreso = reader["Fecha_Ingreso"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha_Ingreso"]) : (DateTime?)null,
                                IdUsuario = reader["IdUsuario"] != DBNull.Value ? Convert.ToInt32(reader["IdUsuario"]) : (int?)null
                            };
                        }
                    }
                }
            }
            return empleado;
        }

        // 🔹 Método para Actualizar un Empleado
        public bool ActualizarEmpleado(Empleado empleado)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("UpdateEmpleado", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_IdEmpleado", empleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("@p_NombreCompleto", empleado.NombreCompleto);
                    cmd.Parameters.AddWithValue("@p_FechaIngreso", empleado.FechaIngreso);
                    cmd.Parameters.AddWithValue("@p_IdUsuario", empleado.IdUsuario);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // 🔹 Método para Eliminar un Empleado
        public bool EliminarEmpleado(int idEmpleado)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("DeleteEmpleado", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        public bool ActualizarEmpleadoIdUsuario(int idEmpleado, int idUsuario)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE empleado SET IdUsuario = @p_IdUsuario WHERE IdEmpleado = @p_IdEmpleado", conn))
                    {
                        cmd.Parameters.AddWithValue("@p_IdUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@p_IdEmpleado", idEmpleado);

                        conn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar IdUsuario en Empleado: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
