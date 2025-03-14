using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.Models
{
    public class Producto
    {
            public int IdProducto { get; set; }
            public string ProductoN { get; set; }
            public decimal? Precio { get; set; }
            public int? Stock { get; set; }

        public string NombrePrecio
        {
            get { return $"{ProductoN} - ${Precio:N2}"; }
        }

    }
}
