using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp.Utils
{
    public class OperacioneBD
    {
        private readonly string connectionString;

        public OperacioneBD()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
        public void RespaldarBaseDeDatos()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string databaseName = connection.Database;
                    string fileName = $"respaldo_{databaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.sql";

                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = fileName,
                        Filter = "Archivos SQL (*.sql)|*.sql|Todos los archivos (*.*)|*.*",
                        Title = "Guardar respaldo de base de datos"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string mysqldumpPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe";
                        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(connectionString);
                        string username = builder.UserID;
                        string password = builder.Password;
                        string server = builder.Server;

                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = mysqldumpPath,
                            Arguments = $"-h {server} -u {username} -p\"{password}\" --routines --events --triggers {databaseName}",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        process.StartInfo = startInfo;
                        process.Start();

                        // Lee la salida estándar y escribe en el archivo
                        using (var fileStream = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        using (var streamWriter = new System.IO.StreamWriter(fileStream))
                        {
                            streamWriter.Write(process.StandardOutput.ReadToEnd());
                        }

                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        if (process.ExitCode != 0)
                        {
                            MessageBox.Show($"Error al ejecutar mysqldump: {error}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Respaldo de base de datos completado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al respaldar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void RestaurarBaseDeDatos(string filePath)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(connectionString);
                    string username = builder.UserID;
                    string password = builder.Password;
                    string server = builder.Server;

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "mysql",
                        Arguments = $"-h {server} -u {username} -p\"{password}\" < \"{filePath}\"",
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    process.StartInfo = startInfo;
                    process.Start();

                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        MessageBox.Show($"Error al restaurar la base de datos: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Restauración de base de datos completada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al restaurar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
