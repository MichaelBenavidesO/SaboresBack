using System;
using System.Collections.Generic;

namespace Sabores_Backend.Models
{
    public partial class Preguntum
    {
        public int IdPregunta { get; set; }
        public int? IdUsuario { get; set; }
        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }

    }
}
