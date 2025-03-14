using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using WindowsFormsApp.Models;

namespace WindowsFormsApp.Services
{
    public class UbicacionService
    {
        private readonly string connectionString;
        public UbicacionService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
        // 🔹 1. Insertar ubicación usando procedimiento almacenado
        public bool GuardarUbicacion(Ubicacion ubicacion)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("InsertUbicacion", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_UbicacionN", ubicacion.UbicacionN);
                        exito = command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar ubicación: " + ex.Message);
                }
            }
            return exito;
        }

        // 🔹 2. Obtener todas las ubicaciones
        public List<Ubicacion> ObtenerUbicaciones()
        {
            List<Ubicacion> lista = new List<Ubicacion>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("GetUbicaciones", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Ubicacion
                                {
                                    IdUbicacion = reader.GetInt32("IdUbicacion"),
                                    UbicacionN = reader.GetString("Ubicacion")
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener ubicaciones: " + ex.Message);
                }
            }
            return lista;
        }

        // 🔹 3. Actualizar ubicación
        public bool ActualizarUbicacion(Ubicacion ubicacion)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("UpdateUbicacion", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_IdUbicacion", ubicacion.IdUbicacion);
                        command.Parameters.AddWithValue("@p_UbicacionN", ubicacion.UbicacionN);
                        exito = command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar ubicación: " + ex.Message);
                }
            }
            return exito;
        }

        // 🔹 4. Eliminar ubicación
        public bool EliminarUbicacion(int id)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("DeleteUbicacion", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_IdUbicacion", id);
                        exito = command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar ubicación: " + ex.Message);
                }
            }
            return exito;
        }
    }
}
