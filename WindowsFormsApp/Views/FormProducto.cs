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
using WindowsFormsApp.Services;
using WindowsFormsApp.Utils;

namespace WindowsFormsApp.Views
{
    public partial class FormProducto : Form
    {
        ExcelExport grid = new ExcelExport();
        ProductoService service = new ProductoService();
        public FormProducto()
        {
            InitializeComponent();
        }
        private void FormProducto_Load(object sender, EventArgs e)
        {
            BotonesCampos(true, false, false, false, false, true);
            CargarDatosGrid();
            Limpiar();
        }
        private void BotonesCampos(bool nuevo, bool guardar, bool actualizar, bool cancelar, bool campos, bool grid)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnActualizar.Enabled = actualizar;
            btnCancelar.Enabled = cancelar;
            txtProducto.Enabled = campos;
            txtPrecio.Enabled = campos;
            txtStock.Enabled = campos;
            txtProducto.Enabled = campos;
            txtPrecio.Enabled = campos;
            txtStock.Enabled = campos;
            dataGridView1.Enabled = grid;
        }
        private void Limpiar()
        {
            txtProducto.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtProducto.Focus();
        }
        private void CargarDatosGrid()
        {
            dataGridView1.DataSource = service.ObtenerProductos();
            dataGridView1.Columns["IdProducto"].Visible = false;
            dataGridView1.Columns["NombrePrecio"].Visible = false;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            BotonesCampos(false, true, false, true, true, false);
        }
        #region Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensajeError = ValidarEntradasParaGuardar();
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!InsertarProducto())
            {
                MessageBox.Show("Error al guardar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Limpiar();
            CargarDatosGrid();
            BotonesCampos(true, false, false, false, false, true);
        }
        private bool InsertarProducto()
        {
            try
            {
                decimal precio = decimal.Parse(txtPrecio.Text);
                int stock = int.Parse(txtStock.Text);

                Producto producto = new Producto();
                producto.ProductoN = txtProducto.Text;
                producto.Precio = precio;
                producto.Stock = stock;

                return service.InsertarProducto(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar, " + ex, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private string ValidarEntradasParaGuardar()
        {
            if (!int.TryParse(txtStock.Text, out _))
            {
                txtStock.Select();
                return "Stock no es un valor entero.";
            }

            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                txtPrecio.Select();
                return "Precio no válido.";
            }

            if (string.IsNullOrEmpty(txtProducto.Text))
            {
                txtProducto.Select();
                return "Producto requerido.";
            }

            return null; // Sin errores
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            BotonesCampos(true, false, false, false, false, true);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            grid.ExportarDataGridViewAExcel("LISTADO DE PRODUCTOS", DateTime.Today.ToShortDateString(), dataGridView1);
        }
        #region ActualizarProducto
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string mensajeError = ValidarEntradasParaActualizar();
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ActualizarProducto())
            {
                MessageBox.Show("Error al actualizar el producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Limpiar();
            CargarDatosGrid();
            BotonesCampos(true, false, false, false, false, true);
        }
        private string ValidarEntradasParaActualizar()
        {
            if (!int.TryParse(txtStock.Text, out _))
            {
                txtStock.Select();
                return "Stock no es un valor entero.";
            }

            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                txtPrecio.Select();
                return "Precio no válido.";
            }

            if (string.IsNullOrEmpty(txtProducto.Text))
            {
                txtProducto.Select();
                return "Producto requerido.";
            }

            if (!int.TryParse(lblIdProducto.Text, out _))
            {
                txtProducto.Select();
                return "Seleccione un producto.";
            }

            return null; // Sin errores
        }

        private bool ActualizarProducto()
        {
            try
            {

                int idproducto = int.Parse(lblIdProducto.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);
                int stock = int.Parse(txtStock.Text);

                Producto producto = service.ObtenerProductoPorId(idproducto);
                MessageBox.Show("producto: "+producto.IdProducto+producto.ProductoN);
                if (producto != null)
                {
                    producto.IdProducto = idproducto;
                    producto.ProductoN = txtProducto.Text;
                    producto.Precio = precio;
                    producto.Stock = stock;
                }
                else
                {
                    MessageBox.Show("No se encontró el producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return service.ActualizarProducto(producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar actualizar {ex.Message}.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                lblIdProducto.Text = row.Cells["IdProducto"].Value.ToString();
                txtProducto.Text = row.Cells["ProductoN"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
            }
            BotonesCampos(false, false, true, true, true, true);
        }
    }
}
