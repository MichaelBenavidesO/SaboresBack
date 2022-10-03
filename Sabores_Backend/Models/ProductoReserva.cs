using System;
using System.Collections.Generic;

namespace Sabores_Backend.Models
{
    public partial class ProductoReserva
    {
        public int IdProductoReserva { get; set; }
        public int? IdProducto { get; set; }
        public int? IdReserva { get; set; }
        public int? Cantidad { get; set; }
        public string? Nota { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
        public virtual Reserva? IdReservaNavigation { get; set; }
    }
}
