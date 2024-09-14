using Counter.DAL.models;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;

namespace Counter.DAL
{
    public class CounterContext : DbContext
    {
        public CounterContext(DbContextOptions<CounterContext> options) : base (options) { }

        public DbSet<Equipos> Equipos { get; set; }
        public DbSet<Jugadores> Jugadores { get; set; }

        public DbSet<Pais> Pais { get; set; }   

        public DbSet<Armas> Armas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Equipos
            modelBuilder.Entity<Equipos>()
                .HasKey(k => k.Equipo_ID);
            modelBuilder.Entity<Equipos>()
                .HasIndex(i => i.Nombre);

            //Jugadores
            modelBuilder.Entity<Jugadores>()
                .HasKey(k => k.Jugador_ID);
            modelBuilder.Entity<Jugadores>()
                .HasIndex(i => i.Nombre);
            modelBuilder.Entity<Jugadores>()
                .HasOne(e => e.Equipo)
                .WithMany(j => j.Jugadores)
                .HasForeignKey(fk => fk.Equipo_ID);
            modelBuilder.Entity<Jugadores>()
                .HasOne(e => e.Pais)
                .WithMany(j => j.Jugadores)
                .HasForeignKey(fk => fk.Pais_ID);
            


            //Armas
            modelBuilder.Entity<Armas>()
                .HasKey(k => k.Armas_ID);
            modelBuilder.Entity<Armas>()
                .HasIndex(i => i.Nombre);
            modelBuilder.Entity<Armas>()
                .HasOne(e => e.Jugadores)
                .WithMany(a => a.Armas)
                .HasForeignKey(fk => fk.Jugador_ID);

            //Paises
            modelBuilder.Entity<Pais>()
              .HasKey(k => k.Pais_ID);
            modelBuilder.Entity<Pais>()
                .HasIndex(i => i.Nombre);
           




        }


    }
}
