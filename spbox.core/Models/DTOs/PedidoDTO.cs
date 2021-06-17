using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models.DTOs
{
    public class PedidoDTO
    {
        public int IDPedido { get; set; }
        public DateTime fechaPedido { get; set; }
        public int totalPedido { get; set; }
        public DetallePedidoDTO DetallePedido { get; set; }
        public List<ProductoPedidoDTO> ProductosPorPedido { get; set; }
    }
}
