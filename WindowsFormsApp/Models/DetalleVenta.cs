﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.Models
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? Cantidad { get; set; }
        public decimal? SubTotal { get; set; }
        public string NombreProducto { get; set; } // Nueva propiedad
    }
}
