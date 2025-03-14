using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using WindowsFormsApp.Models;

namespace WindowsFormsApp.Services
{
    public class VentaService
    {
        private readonly string connectionString;

        public VentaService()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        public bool GuardarVenta(Venta venta, List<DetalleVenta> detallesVenta)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. Guardar la venta
                    int idVenta = GuardarVentaCabecera(connection, transaction, venta);

                    // 2. Guardar los detalles de la venta
                    foreach (DetalleVenta detalle in detallesVenta)
                    {
                        detalle.IdVenta = idVenta;
                        GuardarDetalleVenta(connection, transaction, detalle);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error al guardar la venta: {ex.Message}");
                    return false;
                }
            }
        }

        private int GuardarVentaCabecera(MySqlConnection connection, MySqlTransaction transaction, Venta venta)
        {
            string query = "INSERT INTO Venta (IdUsuario, No_Factura, No_SAP, MontoTotal, FechaRegistro) " +
                           "VALUES (@IdUsuario, @NoFactura, @NoSap, @MontoTotal, @FechaRegistro); SELECT LAST_INSERT_ID();"; // LAST_INSERT_ID() para obtener el ultimo id insertado

            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                command.Parameters.AddWithValue("@NoFactura", venta.NoFactura);
                command.Parameters.AddWithValue("@NoSap", venta.NoSap);
                command.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);
                command.Parameters.AddWithValue("@FechaRegistro", venta.FechaRegistro);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void GuardarDetalleVenta(MySqlConnection connection, MySqlTransaction transaction, DetalleVenta detalle)
        {
            string query = "INSERT INTO Detalle_Venta (IdVenta, IdProducto, PrecioVenta, Cantidad, SubTotal) " +
                           "VALUES (@IdVenta, @IdProducto, @PrecioVenta, @Cantidad, @SubTotal)";

            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdVenta", detalle.IdVenta);
                command.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                command.Parameters.AddWithValue("@PrecioVenta", detalle.PrecioVenta);
                command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                command.Parameters.AddWithValue("@SubTotal", detalle.SubTotal);

                command.ExecuteNonQuery();
            }
        }

        public bool ExisteNumeroFactura(string numeroFactura)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Venta WHERE No_Factura = @NumeroFactura";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroFactura", numeroFactura);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }


        public List<Venta> VentasEntreFechas(DateTime fechaIn,DateTime fechaFin)
        {
            List<Venta> lista = new List<Venta>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("ObtenerVentasPorRangoFechas", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_FechaInicio",fechaIn);
                        command.Parameters.AddWithValue("@p_FechaFin", fechaFin);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Venta
                                {
                                    IdVenta = reader.GetInt32("IdVenta"),
                                    IdUsuario = reader.GetInt32("IdUsuario"),
                                    NoFactura = reader.GetString("No_Factura"),
                                    NoSap = reader.GetString("No_SAP"),
                                    MontoTotal = reader.GetDecimal("MontoTotal"),
                                    FechaRegistro = reader.GetDateTime("FechaRegistro").Date,
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener ventas: " + ex.Message);
                }
            }
            return lista;
        }
        public DataTable BuscadorMaestroDetalle(string texto)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("BuscarVentaDetallePorNoSAP", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_NO_SAP", texto);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener ventas: " + ex.Message);
                }
            }
            return dt;
        }
    }
}
