using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Models;
using WindowsFormsApp.Utils;

namespace WindowsFormsApp.Views
{
    public partial class FormDashboard : Form
    {
        Usuario User { get; set; }
        private readonly OperacioneBD operacionesBD = new OperacioneBD();
        public FormDashboard(Usuario usuario)
        {
            InitializeComponent();
            this.User = usuario;
            Permisos();
        }

        private void AbrirFormulario(Form nuevoFormulario)
        {
            // Si ya hay formularios abiertos, mostrar advertencia
            if (this.MdiChildren.Length > 0)
            {
                //DialogResult resultado = 
                MessageBox.Show(
                "Ya hay un formulario abierto. Debe cerrarlo antes de abrir otro.",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                //if (resultado == DialogResult.No)
                //{
                return; // Si el usuario no quiere cerrar, no abre el nuevo formulario
                //}

                // Cerrar todos los formularios hijos si el usuario acepta
                //foreach (Form frm in this.MdiChildren)
                //{
                //    frm.Close();
                //}
            }

            // Abrir el nuevo formulario
            nuevoFormulario.MdiParent = this;
            nuevoFormulario.WindowState = FormWindowState.Maximized;
            nuevoFormulario.Show();
        }
        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormUsuario());
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormProducto());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormFacturacion(User.IdUsuario));
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "DASHBOARD - " + User.NombreCompleto.ToString() + " - " + User.Rol.ToString();
        }

        private void ventaEntreFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReporte());
        }
        private void Permisos()
        {
            if (User.Rol != "Administrador")
            {
                usuariosToolStripMenuItem.Visible = false;
                productosToolStripMenuItem.Visible = false;
            }
        }

        private void respaldoBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operacionesBD.RespaldarBaseDeDatos();
        }

        private void restaurarBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos SQL (*.sql)|*.sql|Todos los archivos (*.*)|*.*",
                Title = "Seleccionar archivo de respaldo para restaurar"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                operacionesBD.RestaurarBaseDeDatos(openFileDialog.FileName);
            }
        }
    }
}
