using System;
using System.Collections.Generic;

namespace Sabores_Backend.Models
{
    public partial class Ventum
    {
        public int IdProductoVenta { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int IdVenta { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
        public virtual ProductoVentum IdProductoVentaNavigation { get; set; } = null!;
    }
}
