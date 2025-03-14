using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int? IdUsuario { get; set; }
        public string NoFactura { get; set; }
        public string NoSap { get; set; }
        public decimal? MontoTotal { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>(); // Initialize the list

    }
}
