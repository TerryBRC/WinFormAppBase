using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WindowsFormsApp.Services;
using WindowsFormsApp.Utils;

namespace WindowsFormsApp.Views
{
    public partial class FormReporte : Form
    {
        VentaService vs = new VentaService();
        ExcelExport grid = new ExcelExport();
        public FormReporte()
        {
            InitializeComponent();
            dtpFinal.Value = DateTime.Today.Date;
            dtpInicial.Value = DateTime.Today.Date;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargarVentasFecha_Click(object sender, EventArgs e)
        {
            if (dtpInicial.Value == null)
            {
                MessageBox.Show("Fecha Inicial Inválida","Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpInicial.Focus();
                return;
            }
            if (dtpFinal.Value == null)
            {
                MessageBox.Show("Fecha Final Inválida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpInicial.Focus();
                return;
            }
            if (dtpFinal.Value < dtpInicial.Value)
            {
                MessageBox.Show("Fecha Final no puede ser mayor a Fecha Inicial","Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                dtpInicial.Focus();
                return;
            }
            
            CargarVentasPorFechas(dtpInicial.Value, dtpFinal.Value);
            
        }

        private void CargarVentasPorFechas(DateTime fi,DateTime ff)
        {
            
            dataGridView1.DataSource = vs.VentasEntreFechas(fi,ff);
            dataGridView1.Columns["IdVenta"].Visible = false;
            dataGridView1.Columns["IdUsuario"].Visible = false;
            dataGridView1.Columns["NoFactura"].HeaderText = "No. Factura";
            dataGridView1.Columns["NoSAP"].HeaderText = "Cliente";
            dataGridView1.Columns["MontoTotal"].HeaderText = "Total";
            dataGridView1.Columns["FechaRegistro"].HeaderText = "Registro";
        }private void CargarBuscadorDetalleMaestro(string t)
        {

            DataTable ventas = vs.BuscadorMaestroDetalle(t);
            dataGridView1.DataSource = ventas;
            dataGridView1.Columns["IdVenta"].Visible = false;
            dataGridView1.Columns["IdUsuario"].Visible = false;
            dataGridView1.Columns["IdVenta"].Visible = false;
            dataGridView1.Columns["IdDetalleVenta"].Visible = false;
            dataGridView1.Columns["IdProducto"].Visible = false;
            dataGridView1.Columns["No_Factura"].HeaderText = "No. Factura";
            dataGridView1.Columns["No_SAP"].HeaderText = "Cliente";
            dataGridView1.Columns["MontoTotal"].HeaderText = "Total";
            dataGridView1.Columns["FechaRegistro"].HeaderText = "Registro";
            dataGridView1.Columns["PrecioVenta"].HeaderText = "Precio";
        }

        private void btnVentasCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscadorVentasCliente.Text))
            {
                MessageBox.Show("Escrita un término", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscadorVentasCliente.Focus();
                return;
            }
            CargarBuscadorDetalleMaestro(txtBuscadorVentasCliente.Text);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            grid.ExportarDataGridViewAExcel("Mestro Detalle de Ventas por Cliente", DateTime.Today.ToShortDateString(), dataGridView1);
        }
    }
}
