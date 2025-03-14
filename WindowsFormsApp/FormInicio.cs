using System;
using System.Windows.Forms;
using WindowsFormsApp.Models;
using WindowsFormsApp.Services;
using WindowsFormsApp.Utils;
using WindowsFormsApp.Views;

namespace WindowsFormsApp
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener los valores ingresados en los campos de texto
                string usuario = txtUser.Text.Trim();
                string password = txtPwd.Text.Trim();

                // 2. Validar los campos
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Ingrese usuario y contraseña.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Verificar las credenciales
                UsuarioService usuarioService = new UsuarioService(); // Asumiendo que tienes un servicio para usuarios
                Usuario usuarioAutenticado = usuarioService.AutenticarUsuario(usuario, password);

                if (usuarioAutenticado != null)
                {

                    // 4. Acceso exitoso
                   // MessageBox.Show("Acceso concedido.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Abrir el formulario principal o realizar otras acciones
                    FormDashboard formDashboard = new FormDashboard(usuarioAutenticado);
                    formDashboard.FormClosed += (s, args) =>
                    {
                        txtPwd.Clear();
                        txtUser.Clear();
                        txtUser.Focus();
                        this.Show(); // Mostrar el formulario de inicio de sesión
                    };
                    formDashboard.Show();
                    this.Hide();
                }
                else
                {
                    // 6. Acceso denegado
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
