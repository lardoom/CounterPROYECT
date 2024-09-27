using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Counter.Core.Modelos.Armas;
using Counter.Core.Modelos.Pais;

namespace Counter.Core.Modelos.Jugadores
{
    public class JugadoresInput
    {
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int RondasGanadas { get; set; }
        public decimal PrecisionTiro { get; set; }
        public string? MapaFavorito { get; set; }

        //Campo que hace la referencia con la tabla de equipos
        public string? Equipo { get; set; }

        public string? Pais { get; set; }

        //public string? Armas { get; set; }

    }

    public class JugadoresResult : BaseResult
    {
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int RondasGanadas { get; set; }
        public decimal PrecisionTiro { get; set; }
        public string? MapaFavorito { get; set; }

        public List<ArmasData>? Armas { get; set; }
        public PaisInput? Pais { get; set; }
    }
}

