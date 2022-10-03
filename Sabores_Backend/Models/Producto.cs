using System;
using System.Collections.Generic;

namespace Sabores_Backend.Models
{
    public partial class Producto
    {
        public Producto()
        {
           
        }

        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public double? Precio { get; set; }
        public bool? Estado { get; set; }

       
    }
}
