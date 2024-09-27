using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Modelos.Equipos
{
    public class PromedioRondasGanadasPorEquipo
    {
        public string? NombreEquipo { get; set; }
        public decimal PromedioRondasGanadas { get; set; } = 0;
    }

    public class PromedioRondasGanadasPorEquipoResult : BaseResult
    {
        public List<PromedioRondasGanadasPorEquipo> items { get; set; } = new List<PromedioRondasGanadasPorEquipo>();
    }
}
