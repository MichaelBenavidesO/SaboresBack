using System;
using System.Collections.Generic;

namespace Sabores_Backend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string DocumentoIdentidad { get; set; } = null!;
        public string? CorreoElectronico { get; set; }
        public string Contrasena { get; set; } = null!;
        public string OlvidarContrasena { get; set; } = null!;
        public string? Imagen { get; set; }
        public string Rol { get; set; } = null!;


     
    }
}
