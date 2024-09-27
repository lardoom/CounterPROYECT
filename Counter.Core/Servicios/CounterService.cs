using Counter.Core.Interfaces;
using Counter.Core.Modelos;
using Counter.Core.Modelos.Armas;
using Counter.Core.Modelos.Equipos;
using Counter.Core.Modelos.Jugadores;
using Counter.Core.Modelos.Pais;
using Counter.DAL;
using Counter.DAL.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Counter.Core.Servicios
{
    public class CounterService : ICounterService
    {
        private readonly IConfiguration _configuration;
        private readonly CounterContext _context;

        public CounterService(IConfiguration config, CounterContext context)
        {
            _configuration = config;
            _context = context;
        }

        #region EQUIPO
        public async Task<BaseResult> IngresarEquipo(EquiposInput entrada)
        {
            await Task.CompletedTask;

            var registro = new DAL.models.Equipos
            {
                Nombre = entrada.Nombre,

                TorneosGanados = entrada.TorneosGanados


            };

            _context.Equipos.Add(registro);

            await _context.SaveChangesAsync();

            return new BaseResult
            {
                Success = true,
                Message = "Equipo registrado en la BD con éxito."
            };
        } 
        
        public async Task<EquiposResult> ConsultarEquipo(string nombreDeEquipo)
        {
            await Task.CompletedTask;

            var consulta = await _context.Equipos.Where(n => n.Nombre == nombreDeEquipo).FirstOrDefaultAsync();

            if (consulta == null)
            {
                return new EquiposResult
                {
                    Success = false,
                    Message = $"No se encontró ningún equipo con el nombre {nombreDeEquipo}."
                };
            }

            return new EquiposResult
            {
                Success = true,
                Nombre = consulta.Nombre,
                TorneosGanados = consulta.TorneosGanados,

            };

        }

        #endregion

        #region JUGADOR
        public async Task<BaseResult> IngresarJugador(JugadoresInput EntradaJugador)
        {
            await Task.CompletedTask;

            //Verificar que el equipo exista en la BD. 
            var consulta = await _context.Equipos.Where(n => n.Nombre == EntradaJugador.Equipo).FirstOrDefaultAsync();

            if (consulta == null)
            {
                return new BaseResult
                {
                    Success = false,
                    Message = $"No se encontró ningún equipo con el nombre {EntradaJugador.Equipo}."
                };
            }
            var ConsultaPais = await _context.Pais.Where(o => o.Nombre == EntradaJugador.Pais).FirstOrDefaultAsync();

            if (ConsultaPais == null)
            {
                _context.Pais.Add(new Pais
                {
                    Nombre = EntradaJugador.Pais,
                });
                await _context.SaveChangesAsync();

                ConsultaPais = await _context.Pais.Where(o => o.Nombre == EntradaJugador.Pais).FirstOrDefaultAsync();
            }

            var registro = new DAL.models.Jugadores
            {
                Nombre = EntradaJugador.Nombre,
                Edad = EntradaJugador.Edad,
                Deaths = EntradaJugador.Deaths,
                Kills = EntradaJugador.Kills,
                PrecisionTiro = EntradaJugador.PrecisionTiro,
                MapaFavorito = EntradaJugador.MapaFavorito,
                RondasGanadas = EntradaJugador.RondasGanadas,

                //Relación
                Equipo = consulta,
                Equipo_ID = consulta.Equipo_ID,

                Pais = ConsultaPais,
                Pais_ID = ConsultaPais.Pais_ID,
            };

            _context.Jugadores.Add(registro);
            await _context.SaveChangesAsync();

            return new BaseResult
            {
                Success = true,
                Message = "Jugador registrado en la BD con éxito."
            };
        }

        #endregion

        #region ARMA
        public async Task<BaseResult> IngresarArma(ArmasInput EntradaArma)
        {
            await Task.CompletedTask;

            var consultaJugador = await _context.Jugadores.Where(o => o.Nombre == EntradaArma.NombreJugador).FirstOrDefaultAsync();

            if (consultaJugador == null)
            {
                return new BaseResult
                {
                    Success = false,
                    Message = $"No se encontró ningún equipo con el nombre {EntradaArma.NombreJugador}."
                };


            }
            var registro = new DAL.models.Armas
            {
                Nombre = EntradaArma.Nombre,
                Color = EntradaArma.Color,

                Jugadores = consultaJugador,
                Jugador_ID = consultaJugador.Jugador_ID,

            };

            _context.Armas.Add(registro);
            await _context.SaveChangesAsync();

            return new BaseResult
            {
                Success = true,
                Message = "Arma registrado en la BD con éxito."
            };
        }

        public async Task<BaseResult> IngresarArmasBulk(List<ArmasInput> bulk)
        {
            await Task.CompletedTask;

            foreach (var arma in bulk)
            {
                var consultaJugador = await _context.Jugadores.Where(o => o.Nombre == arma.NombreJugador).FirstOrDefaultAsync();

                if (consultaJugador == null)
                {
                    return new BaseResult
                    {
                        Success = false,
                        Message = $"No se encontró ningún equipo con el nombre {arma.NombreJugador}."
                    };


                }
                var registro = new DAL.models.Armas
                {
                    Nombre = arma.Nombre,
                    Color = arma.Color,

                    Jugadores = consultaJugador,
                    Jugador_ID = consultaJugador.Jugador_ID,

                };

                _context.Armas.Add(registro);
            }
            await _context.SaveChangesAsync();

            return new BaseResult
            {
                Success = true,
                Message = "Arma registrado en la BD con éxito."
            };
        }


        #endregion

        #region PAIS

        public async Task<BaseResult> IngresarPais(PaisInput EntradaPais)
        {
            await Task.CompletedTask;

            var registro = new DAL.models.Pais
            {
                Nombre = EntradaPais.Nombre,

            };

            _context.Pais.Add(registro);
            await _context.SaveChangesAsync();


            return new BaseResult
            {

                Success = true,
                Message = "Pais registrado en la BD con éxito."
            };

        }

        #endregion

        public async Task<JugadoresRondasGanadasResult> MayorRondasGanadas(int rondasGanadas)
        {
            await Task.CompletedTask;

            var consulta = await _context.Jugadores
                .Include(e => e.Equipo)
                .Where(j => j.RondasGanadas > rondasGanadas)
                .ToListAsync();
            
            JugadoresRondasGanadasResult result = new JugadoresRondasGanadasResult();
            result.jugadores = new List<JugadorRondasGanadas>();

            if (consulta.Count > 0)
            {
                foreach (var jugador in consulta)
                {
                    var jug = new JugadorRondasGanadas
                    {
                        Nombre = jugador.Nombre,    
                        NombreEquipo = jugador.Equipo.Nombre,
                        Edad = jugador.Edad,
                        RondasGanadas = jugador.RondasGanadas,
                    };
                    result.jugadores.Add(jug);
                }
            }

            result.Success = true;
            return result;
        }

        public async Task<PromedioRondasGanadasPorEquipoResult> PromedioRondasGanadasPorEquipo()
        {
            await Task.CompletedTask;

            var result = new PromedioRondasGanadasPorEquipoResult();
            var equipos = await _context.Equipos.Include(j => j.Jugadores).ToListAsync();

            foreach (var equipo in equipos)
            {
                decimal prom = 0;
                foreach( var jugador in equipo.Jugadores)
                {
                    prom += jugador.RondasGanadas;
                }

                result.items.Add(new Modelos.Equipos.PromedioRondasGanadasPorEquipo
                {
                    NombreEquipo = equipo.Nombre,
                    PromedioRondasGanadas = prom / equipo.Jugadores.Count()
                });
            }

            result.Success = true;
            return result;
        }

        public async Task<JugadorMayorKillsResult> JugadorConMasKills()
        {
            await Task.CompletedTask;

            var consulta = await _context.Jugadores.OrderByDescending(j => j.Kills).Include(e => e.Equipo).FirstAsync();

            var jugador = new JugadorMayorKills
            {
                Nombre = consulta.Nombre,
                Kills = consulta.Kills,
                Edad = consulta.Edad,
                NombreEquipo = consulta.Equipo.Nombre
            };


            return new JugadorMayorKillsResult
            {
                Success = true,
                jugador = jugador,
            };
        }

        public async Task<MapaFavYPrecTiroJugadoresResult> MapaFavYPrecTiro(string nombreMapa, decimal precisionTiro)
        {
            await Task.CompletedTask;

            var result = new MapaFavYPrecTiroJugadoresResult();

            var consulta = await _context.Jugadores
                .Where( j => j.MapaFavorito == nombreMapa && 
                        j.PrecisionTiro > precisionTiro)
                .ToListAsync();

            foreach (var jugador in consulta)
            {
                result.jugadores.Add(new MapaFavYPrecTiroJugador
                {
                    Nombre = jugador.Nombre,
                    Mapa = jugador.MapaFavorito,
                    PrecisionTiro = jugador.PrecisionTiro,
                });
            }

            result.Success = true;
            return result;
        }
    }
}
