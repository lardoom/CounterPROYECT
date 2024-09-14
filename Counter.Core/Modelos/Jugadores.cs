using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Core.Modelos
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

        //public ArmasInput? Armas { get; set; }

        
    }

    public class JugadoresPyA : BaseResult
        {
              public string? Nombre { get; set; }
              public int Edad { get; set; }
              public List<ArmasData>? Armas { get; set; } = new List<ArmasData>();
              public PaisData? Pais { get; set; } = new PaisData();
        }
    }
