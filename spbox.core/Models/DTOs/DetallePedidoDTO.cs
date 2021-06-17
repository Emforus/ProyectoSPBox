using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models.DTOs
{
    public class DetallePedidoDTO
    {
        public int IDDetalle { get; set; }
        public string notasDetalle { get; set; }
        public CompradorDTO Comprador { get; set; }
        public ProveedorDTO Proveedor { get; set; }
    }
}
