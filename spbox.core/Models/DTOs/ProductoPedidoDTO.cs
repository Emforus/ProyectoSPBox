using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models.DTOs
{
    public class ProductoPedidoDTO
    {
        public int IDPedido { get; set; }
        public int IDProducto { get; set; }
        public int cantidadProducto { get; set; }
        public int totalProducto { get; set; }
        public ProductoDTO Producto { get; set; }
    }
}
