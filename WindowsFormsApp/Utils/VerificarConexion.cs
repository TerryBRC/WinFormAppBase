using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp.Utils
{
    public class VerificarConexion
    {
        private readonly string connectionString;

        public VerificarConexion()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        public bool EsConexionValida()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    return true; // Conexión exitosa
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión MySQL: " + ex.Message + connectionString);
                return false; // Error de conexión
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
                return false; // Error general
            }
        }
    }
}