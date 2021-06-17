using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models
{
    public class DetallePedido
    {
        public int IDDetalle { get; set; }
        public string notasDetalle { get; set; }
        public Comprador Comprador { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
