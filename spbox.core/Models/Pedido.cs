using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models
{
    public partial class Pedido
    {
        public int IDPedido { get; set; }
        public DateTime fechaPedido { get; set; }
        public int FKDetalle { get; set; }
        public DetallePedido DetallePedido { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public List<ProductoPedido> ProductosPorPedido { get; set; }
    }
}
