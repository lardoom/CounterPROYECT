using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Modelos.Jugadores
{
    public class JugadoresRondasGanadasResult : BaseResult
    {
        public List<JugadorRondasGanadas>? jugadores { get; set; } = new List<JugadorRondasGanadas>();
    }

    public class JugadorRondasGanadas
    {
        public string? Nombre { get; set; }
        public string? NombreEquipo { get; set; }
        public int Edad { get; set; }
        public int RondasGanadas { get; set; }
    }
}
