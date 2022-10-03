using System;
using System.Collections.Generic;

namespace Sabores_Backend.Models
{
    public partial class ProductoVentum
    {
        public ProductoVentum()
        {
            Venta = new HashSet<Ventum>();
        }

        public int IdProductoVenta { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
