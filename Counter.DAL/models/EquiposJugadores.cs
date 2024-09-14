using System.ComponentModel.DataAnnotations;

namespace Counter.DAL.models
{
    public class Equipos : BaseModel
    {
        [Key]
        public long Equipo_ID { get; set; }
        [Required]
        public string? Nombre { get; set; }
      
        [Required]
        public int TorneosGanados { get; set; }
        

        public ICollection<Jugadores>? Jugadores { get; set; }
    }

    public class Jugadores : BaseModel
    {
        [Key]
        public long Jugador_ID { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public long Equipo_ID { get; set; }
        public Equipos? Equipo { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public int Kills { get; set; }
        [Required]
        public int Deaths { get; set; }
        [Required]
        public int RondasGanadas { get; set; }
        [Required]
        public decimal PrecisionTiro { get; set; }
        [Required]
        public string? MapaFavorito { get; set; }
        public ICollection<Armas>? Armas { get; set; }
        [Required]
        public long Pais_ID { get; set; }
        public Pais? Pais { get; set; } 

    }

    public class Pais : BaseModel
    {
        [Key]
        public long Pais_ID { get; set; }
        [Required]
        public string? Nombre { get; set; }
        
        public ICollection<Jugadores>? Jugadores { get; set; }


    }

    public class Armas : BaseModel
    {


        [Key]
        public long Armas_ID { get; set; }
        [Required]
        public string? Nombre { get;set; }
        [Required]
        public long Jugador_ID { get; set; }
        public Jugadores? Jugadores { get; set; }
        public float? Desgaste { get; set; }
        [Required]
        public string? Color { get; set; }

       
    }


}
