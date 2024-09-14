using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Modelos
{
    public class ArmasInput : ArmasData
    {

        public string? NombreJugador { get; set; }
     
    }

    public class ArmasResult : BaseResult
    { 
        public string? Nombre { get; set; }
        public string? Color { get; set; }

        public JugadoresInput? NombreJugador { get; set; }

    }
    public class ArmasData

    {
        public string? Nombre { get; set; }
        public string? Color { get; set; }

    }



}
