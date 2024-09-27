using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Modelos.Jugadores
{
    public class MapaFavYPrecTiroJugador
    {
        public string? Nombre { get; set; }
        public string? Mapa { get; set; }
        public decimal PrecisionTiro { get; set; }
    }

    public class MapaFavYPrecTiroJugadoresResult : BaseResult
    {
        public List<MapaFavYPrecTiroJugador> jugadores { get; set; } = new List<MapaFavYPrecTiroJugador> ();
    }
}
