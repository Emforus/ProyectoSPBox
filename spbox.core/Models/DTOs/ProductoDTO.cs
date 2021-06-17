using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models.DTOs
{
    public class ProductoDTO
    {
        public int IDProducto { get; set; }
        public string nomProducto { get; set; }
        public int precioProducto { get; set; }
        public string descProducto { get; set; }
    }
}
