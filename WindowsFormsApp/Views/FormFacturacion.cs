using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp.Models;
using WindowsFormsApp.Services;

namespace WindowsFormsApp.Views
{
    public partial class FormFacturacion : Form
    {
        ProductoService ub = new ProductoService();
        int iduser;
        public FormFacturacion(int idusuario)
        {
            InitializeComponent();
            this.iduser = idusuario;
        }
        private void CargarComboProductos()
        {
            cmbProductos.DataSource = ub.ObtenerProductos();
            cmbProductos.DisplayMember = "NombrePrecio";
            cmbProductos.ValueMember = "IdProducto";
            cmbProductos.SelectedIndex = -1;
        }
        private void CancelarFactura()
        {
            txtCliente.Clear();
            txtNoFactura.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            cmbProductos.SelectedIndex = -1;
            dateTimePicker1.ResetText();
            dataGridView1.DataSource = null;
            txtMontoTotal.Clear();
            txtNoFactura.Focus();
        }
        private void LimpiarAlAgregarProducto()
        {
            cmbProductos.SelectedIndex = -1;
            txtCantidad.Clear();
            txtPrecio.Clear();
            cmbProductos.Focus();
        }

        private void btnAddDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar las entradas
                if (cmbProductos.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un producto.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbProductos.Focus();
                    return;
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad no válida.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCantidad.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
                {
                    MessageBox.Show("Precio no válido.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecio.Focus();
                    return;
                }

                // 2. Obtener el producto seleccionado
                Producto productoSeleccionado = (Producto)cmbProductos.SelectedItem;

                // 3. Verificar el stock disponible
                if (productoSeleccionado.Stock < cantidad)
                {
                    MessageBox.Show($"Stock insuficiente. Stock disponible: {productoSeleccionado.Stock}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return;
                }

                // 4. Calcular el subtotal
                decimal subtotal = cantidad * precio;

                // 5. Buscar el producto en la lista de detalles
                List<DetalleVenta> detallesVenta = dataGridView1.DataSource as List<DetalleVenta>;
                if (detallesVenta == null)
                {
                    detallesVenta = new List<DetalleVenta>();
                }

                DetalleVenta detalleExistente = detallesVenta.Find(d => d.IdProducto == productoSeleccionado.IdProducto);

                if (detalleExistente != null)
                {
                    // 6. Si el producto ya existe, actualizar la cantidad y el subtotal
                    detalleExistente.Cantidad += cantidad;
                    detalleExistente.SubTotal = detalleExistente.Cantidad * precio;
                    detalleExistente.NombreProducto = productoSeleccionado.ProductoN; // Asigna el nombre
                }
                else
                {
                    // 7. Si el producto no existe, crear un nuevo objeto DetalleVenta
                    DetalleVenta nuevoDetalle = new DetalleVenta
                    {
                        IdProducto = productoSeleccionado.IdProducto,
                        NombreProducto = productoSeleccionado.ProductoN, // Asigna el nombre
                        PrecioVenta = precio,
                        Cantidad = cantidad,
                        SubTotal = subtotal
                    };

                    detallesVenta.Add(nuevoDetalle);
                }

                // 8. Actualizar la fuente de datos de la cuadrícula
                dataGridView1.AutoGenerateColumns = false; // Desactiva la generación automática de columnas
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = detallesVenta;

                // 9. Limpiar los campos
                LimpiarAlAgregarProducto();

                // 10. Actualizar el total de la venta
                ActualizarTotalVenta(detallesVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar detalle: {ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarTotalVenta(List<DetalleVenta> detalles)
        {
            decimal total = 0;
            if (detalles != null)
            {
                foreach (DetalleVenta detalle in detalles)
                {
                    total += detalle.SubTotal ?? 0; // Usar ?? 0 para manejar valores nulos
                }
            }
            txtMontoTotal.Text = total.ToString("N2"); // Formatear el total como moneda
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFacturacion_Load(object sender, EventArgs e)
        {
            CargarComboProductos();
            LimpiarAlAgregarProducto();
            CancelarFactura();
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProductos.SelectedItem != null)
                {
                    Producto productoSeleccionado = (Producto)cmbProductos.SelectedItem;
                    txtPrecio.Text = productoSeleccionado.Precio.ToString(); // Formatea el precio como moneda
                    lblStock.Text = productoSeleccionado.Stock.ToString();
                }
                else
                {
                    lblStock.ResetText();
                    txtPrecio.Clear(); // Limpia el campo si no hay producto seleccionado
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el precio: {ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Verificar si hay una fila seleccionada
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // 2. Obtener el índice de la fila seleccionada
                    int rowIndex = dataGridView1.SelectedRows[0].Index;

                    // 3. Obtener la lista de detalles actual
                    List<DetalleVenta> detallesVenta = dataGridView1.DataSource as List<DetalleVenta>;

                    // 4. Verificar si la lista no es nula
                    if (detallesVenta != null && rowIndex >= 0 && rowIndex < detallesVenta.Count)
                    {
                        // 5. Eliminar el detalle de la lista
                        detallesVenta.RemoveAt(rowIndex);

                        // 6. Actualizar la fuente de datos de la cuadrícula
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = detallesVenta;

                        // 7. Actualizar el total de la venta
                        ActualizarTotalVenta(detallesVenta);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el detalle a eliminar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un detalle para eliminar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar detalle: {ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                CancelarFactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar la factura: {ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar la información de la factura
                if (string.IsNullOrEmpty(txtNoFactura.Text))
                {
                    MessageBox.Show("Ingrese el número de factura.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNoFactura.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtCliente.Text))
                {
                    MessageBox.Show("Ingrese el nombre del cliente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCliente.Focus();
                    return;
                }

                if (dataGridView1.DataSource == null || ((List<DetalleVenta>)dataGridView1.DataSource).Count == 0)
                {
                    MessageBox.Show("Agregue al menos un producto a la venta.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbProductos.Focus();
                    return;
                }
                VentaService ventaService = new VentaService(); // Crea una instancia de tu servicio
                // Verificar si el número de factura ya existe
                if (ventaService.ExisteNumeroFactura(txtNoFactura.Text))
                {
                    MessageBox.Show("El número de factura ya existe.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNoFactura.Focus();
                    return;
                }
                // 2. Crear objetos Venta y DetalleVenta
                Venta venta = new Venta
                {
                    NoFactura = txtNoFactura.Text,
                    NoSap=txtCliente.Text,
                    IdUsuario = iduser, // Reemplaza con el ID del usuario actual
                    MontoTotal = decimal.Parse(txtMontoTotal.Text),
                    FechaRegistro = dateTimePicker1.Value
                };

                List<DetalleVenta> detallesVenta = (List<DetalleVenta>)dataGridView1.DataSource;

                // 3. Guardar la venta en la base de datos
                
                if (ventaService.GuardarVenta(venta, detallesVenta))
                {
                    MessageBox.Show("Venta guardada correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CancelarFactura(); // Limpia el formulario
                }
                else
                {
                    MessageBox.Show("Error al guardar la venta.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la venta: {ex.Message}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
