using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models
{
    public class Proveedor
    {
        public int IDProveedor { get; set; }
        public string nomProveedor { get; set; }
        public string dirProveedor { get; set; }
        public string cuidadProveedor { get; set; }
        public string paisProveedor { get; set; }
        public int codPostalProveedor { get; set; }
        public List<DetallePedido> Detalles { get; set; }
    }
}
