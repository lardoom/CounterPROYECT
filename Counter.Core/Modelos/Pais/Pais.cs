using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Modelos.Pais
{
    public class PaisInput : PaisData
    {


    }
    public class PaisResult : BaseResult
    {
        public string? Nombre { get; set; }


    }

    public class PaisData
    {

        public string? Nombre { get; set; }

    }
}
