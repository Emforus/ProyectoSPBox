using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spbox.core.Models.DTOs
{
    public class CompradorDTO
    {
        public int IDComprador {get; set;}
        public string nomComprador { get; set; }
        public string dirComprador { get; set; }
        public string cuidadComprador { get; set; }
        public string paisComprador { get; set; }
        public int codPostalComprador { get; set; }
    }
}
