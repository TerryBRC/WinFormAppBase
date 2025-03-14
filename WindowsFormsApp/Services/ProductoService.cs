using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using WindowsFormsApp.Models;
using MySql.Data.MySqlClient;
using System.Windows;

namespace WindowsFormsApp.Services
{
    public class ProductoService
    {
        private readonly string connectionString;

        public ProductoService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        // 🔹 Método para Insertar un Producto
        public bool InsertarProducto(Producto producto)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("InsertProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_Producto", producto.ProductoN);
                    cmd.Parameters.AddWithValue("@p_Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@p_Stock", producto.Stock);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // 🔹 Método para Obtener Todos los Productos
        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetProductos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
                            {
                                IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                ProductoN = reader["Producto"].ToString(),
                                Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : (decimal?)null,
                                Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : (int?)null
                            });
                        }
                    }
                }
            }
            return productos;
        }

        // 🔹 Método para Obtener un Producto por su ID
        public Producto ObtenerProductoPorId(int idProducto)
        {
            Producto producto = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetProductoById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_IdProducto", idProducto);
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Producto
                            {
                                IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                ProductoN = reader["Producto"].ToString(),
                                Precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : (decimal?)null,
                                Stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : (int?)null
                            };
                        }
                    }
                }
            }
            return producto;
        }

        // 🔹 Método para Actualizar un Producto
        public bool ActualizarProducto(Producto producto)
        {
            bool exito = false;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {

                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UpdateProducto", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_IdProducto", producto.IdProducto);
                        cmd.Parameters.AddWithValue("@p_Producto", producto.ProductoN);
                        cmd.Parameters.AddWithValue("@p_Precio", producto.Precio);
                        cmd.Parameters.AddWithValue("@p_Stock", producto.Stock);
                        exito = cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar ubicación: " + ex.Message);
                }
            }
            return exito;
        }

        // 🔹 Método para Eliminar un Producto
        public bool EliminarProducto(int idProducto)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("DeleteProducto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}
