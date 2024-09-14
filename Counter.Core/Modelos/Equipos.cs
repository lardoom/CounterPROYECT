using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Modelos
{
    public class EquiposInput
    {
        public string? Nombre { get; set; }
       
        public int TorneosGanados { get; set; }

        
    }

    public class EquiposResult : BaseResult
    {
        public string? Nombre { get; set; }
      
        public int TorneosGanados { get; set; }
    }
}
