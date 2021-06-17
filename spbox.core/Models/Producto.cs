using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models
{
    public class Producto
    {
        public int IDProducto { get; set; }
        public string nomProducto { get; set; }
        public int precioProducto { get; set; }
        public string descProducto { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public List<ProductoPedido> ProductosPorPedido { get; set; }
    }
}
