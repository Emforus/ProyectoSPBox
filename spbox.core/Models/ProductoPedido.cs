using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models
{
    public class ProductoPedido
    {
        public int cantidadProducto { get; set; }
        public int IDProducto { get; set; }
        public Producto Producto { get; set; }
        public int IDPedido { get; set; }
        public Pedido Pedido { get; set; }
    }
}
