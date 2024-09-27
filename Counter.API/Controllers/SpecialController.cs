using Counter.Core.Interfaces;
using Counter.Core.Modelos.Equipos;
using Counter.Core.Modelos.Jugadores;
using Microsoft.AspNetCore.Mvc;

namespace Counter.API.Controllers
{
    /// <summary>
    /// Nombre del controlador.
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]
    public class SpecialController : BaseController
    {
        public SpecialController(
            IConfiguration configuration,
            IHttpContextAccessor contextAccessor,
            ICounterService counterService) : 
            base(configuration, contextAccessor, counterService) { }

        /// <summary>
        /// Permite consultar los jugadores con un número mayor a N partidas ganadas.
        /// </summary>
        /// <param name="rondasGanadas"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MayorRondasGanadas")]
        public async Task<JugadoresRondasGanadasResult> MayorRondasGanadas(int rondasGanadas)
        {
            try
            {
                return await _counterService.MayorRondasGanadas(rondasGanadas);
            }
            catch
            {
                return new JugadoresRondasGanadasResult
                {
                    Success = false,
                    Message = "No salio bien la operacion."
                };
            }
        }

        /// <summary>
        /// Permite saber el promedio de rondas ganadas por cada equipo registrado.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PromedioRondasGanadasPorEquipo")]
        public async Task<PromedioRondasGanadasPorEquipoResult> PromedioRondasGanadasPorEquipo()
        {
            try
            {
                return await _counterService.PromedioRondasGanadasPorEquipo();
            }
            catch
            {
                return new PromedioRondasGanadasPorEquipoResult
                {
                    Success = false,
                    Message = "No salio bien la operacion."
                };
            }
        }

        /// <summary>
        /// Permite saber cuál es el jugador con mayor número de kills.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("JugadorConMasKills")]
        public async Task<JugadorMayorKillsResult> JugadorConMasKills()
        {
            try
            {
                return await _counterService.JugadorConMasKills();
            }
            catch
            {
                return new JugadorMayorKillsResult
                {
                    Success = false,
                    Message = "No salio bien la operacion."
                };
            }
        }

        /// <summary>
        /// Permite saber los jugadores cuyo mapa favorito sea M y precisión de tiro se mayor a N
        /// </summary>
        /// <param name="nombreMapa">M</param>
        /// <param name="precisionTiro">N</param>
        /// <returns></returns>
        [HttpGet]
        [Route("MapaFavYPrecTiro")]
        public async Task<MapaFavYPrecTiroJugadoresResult> MapaFavYPrecTiro(string nombreMapa = "", decimal precisionTiro = 0)
        {
            try
            {
                return await _counterService.MapaFavYPrecTiro(nombreMapa, precisionTiro);
            }
            catch
            {
                return new MapaFavYPrecTiroJugadoresResult
                {
                    Success = false,
                    Message = "No salio bien la operacion."
                };
            }
        }
    }
}
