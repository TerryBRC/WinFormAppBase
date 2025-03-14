using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string UsuarioN { get; set; } // Renombrado para evitar conflicto
        public string Pwd { get; set; }
        public int? IdUbicacion { get; set; }
        public string Rol { get; set; }
    }
}
