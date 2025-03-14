using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;
using WindowsFormsApp.Utils;

namespace WindowsFormsApp.Views
{
    public partial class FormConfiguracion : Form
    {
        public FormConfiguracion()
        {
            InitializeComponent();
        }
        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(txtServer.Text.Trim()) ||
                string.IsNullOrEmpty(txtBD.Text.Trim()) ||
                string.IsNullOrEmpty(txtUser.Text.Trim()) ||
                string.IsNullOrEmpty(txtPwd.Text.Trim())
                )
            {
                MessageBox.Show("Campos requeridos", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string servidor = txtServer.Text.Trim();
            string usuario = txtUser.Text.Trim();
            string password = txtPwd.Text.Trim();
            string baseDatos = txtBD.Text.Trim();

            string connectionString = $"Server={servidor};Database={baseDatos};Uid={usuario};Pwd={password};";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Conexión exitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServer.Text.Trim())) { return; }
            if (string.IsNullOrEmpty(txtBD.Text.Trim())) { return; }
            if (string.IsNullOrEmpty(txtUser.Text.Trim())) { return; }
            if (string.IsNullOrEmpty(txtPwd.Text.Trim())) { return; }

            string servidor = txtServer.Text.Trim();
            string usuario = txtUser.Text.Trim();
            string password = txtPwd.Text.Trim();
            string baseDatos = txtBD.Text.Trim();

            string nuevaCadena = $"Server={servidor};Database={baseDatos};Uid={usuario};Pwd={password};";

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                XmlNode node = xmlDoc.SelectSingleNode("//connectionStrings/add[@name='conn']");

                if (node != null)
                {
                    XmlAttribute attr = node.Attributes["connectionString"];
                    if (attr != null)
                    {
                        attr.Value = nuevaCadena;
                    }
                }

                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Configuración guardada correctamente. La aplicación se reiniciará.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            // Extraer los valores de la cadena de conexión
            var parametros = connString.Split(';');

            txtServer.Text = parametros.FirstOrDefault(p => p.StartsWith("Server="))?.Split('=')[1];
            txtBD.Text = parametros.FirstOrDefault(p => p.StartsWith("Database="))?.Split('=')[1];
            txtUser.Text = parametros.FirstOrDefault(p => p.StartsWith("Uid="))?.Split('=')[1];
            txtPwd.Text = parametros.FirstOrDefault(p => p.StartsWith("Pwd="))?.Split('=')[1];
        }
    }
}
