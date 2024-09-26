using Counter.Core.Interfaces;
using Counter.Core.Modelos;
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


        // Ingresa los Equipos a la Base de Datos 
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
        //Consulta los Equipos de la Base de Datos 
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
                return new BaseResult
                {
                    Success = false,
                    Message = $"No se encontró ningún equipo con el nombre {EntradaJugador.Pais}."
                };
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
                Message = "Equipo registrado en la BD con éxito."
            };
        }



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





        public async Task<JugadoresPyA> ConsultarJugadorPyA (string NombreJugador)
        {
            await Task.CompletedTask;

            JugadoresPyA jugadoresPyARes = new JugadoresPyA();
            
            var consultaPyA = await _context.Jugadores.Include(o => o.Pais).Include(i => i.Armas).Where(u => u.Nombre == NombreJugador).FirstOrDefaultAsync();

            if (consultaPyA == null)
            {
                return new JugadoresPyA
                {
                    Success = false,
                    Message = $"El nombre del Jugador {NombreJugador} no ha sido encontrado"
                };

            }

            jugadoresPyARes.Nombre = consultaPyA.Nombre;
            jugadoresPyARes.Edad = consultaPyA.Edad;
            jugadoresPyARes.Pais.Nombre = consultaPyA.Pais.Nombre;

            foreach (var Arma in consultaPyA.Armas)

            {

                jugadoresPyARes.Armas.Add(new ArmasData {
                
                Nombre = Arma.Nombre,
                Color = Arma.Color,
                
                
                }
                );
            
            }
            return jugadoresPyARes;
        }

        //Otro servicio 
        public async Task<Killer> Jugadorkiller()
        {
            await Task.CompletedTask;

          

            
            var consultakills = await _context.Jugadores.Where(e => e.RondasGanadas >5).ToListAsync();


           

        

            return new Killer
            {
                Success = true,
                Nombre = consultakills
                RondasGanadas = consultakills.RondasGanadas,

            };

        }

    }
}
//public async Task<EquiposResult> ConsultarEquipo(string nombreDeEquipo)
//{
//    await Task.CompletedTask;

//    var consulta = await _context.Equipos.Where(n => n.Nombre == nombreDeEquipo).FirstOrDefaultAsync();

//    if (consulta == null)
//    {
//        return new EquiposResult
//        {
//            Success = false,
//            Message = $"No se encontró ningún equipo con el nombre {nombreDeEquipo}."
//        };
//    }

//    return new EquiposResult
//    {
//        Success = true,
//        Nombre = consulta.Nombre,
//        TorneosGanados = consulta.TorneosGanados,

//    };

//}