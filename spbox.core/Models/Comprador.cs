using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models
{
    public class Comprador
    {
        public int IDComprador {get; set;}
        public string nomComprador { get; set; }
        public string dirComprador { get; set; }
        public string cuidadComprador { get; set; }
        public string paisComprador { get; set; }
        public int codPostalComprador { get; set; }
        public List<DetallePedido> Detalles { get; set; }
    }
}
