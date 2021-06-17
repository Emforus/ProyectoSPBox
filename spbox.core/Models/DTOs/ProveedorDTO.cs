using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models.DTOs
{
    public class ProveedorDTO
    {
        public int IDProveedor { get; set; }
        public string nomProveedor { get; set; }
        public string dirProveedor { get; set; }
        public string cuidadProveedor { get; set; }
        public string paisProveedor { get; set; }
        public int codPostalProveedor { get; set; }
    }
}
