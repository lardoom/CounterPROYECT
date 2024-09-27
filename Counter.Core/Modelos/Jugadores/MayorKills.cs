using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Modelos.Jugadores
{
    public class JugadorMayorKills 
    {
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public int Kills { get; set; }
        public string? NombreEquipo { get; set; }
    }

    public class JugadorMayorKillsResult : BaseResult
    {
        public JugadorMayorKills? jugador { get; set; }
    }
}
