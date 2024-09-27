using Counter.Core.Interfaces;
using Counter.Core.Modelos;
using Counter.Core.Modelos.Armas;
using Counter.Core.Modelos.Equipos;
using Counter.Core.Modelos.Jugadores;
using Counter.Core.Modelos.Pais;
using Microsoft.AspNetCore.Mvc;

namespace Counter.API.Controllers
{
    /// <summary>
    /// Nombre del controlador.
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]
    public class CounterController : BaseController
    {
        public CounterController(
            IConfiguration configuration, 
            IHttpContextAccessor contextAccessor, 
            ICounterService counterService) : 
            base(configuration, contextAccessor, counterService) {}

        #region EQUIPOS

        /// <summary>
        /// Permite ingresar datos de un equipo.
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("IngresarEquipo")]
        public async Task<BaseResult> IngresarEquipo(EquiposInput entrada)
        {
            try
            {
                return await _counterService.IngresarEquipo(entrada);
            }
            catch
            {
                return new BaseResult
                {
                    Success = false,
                    Message = "No salió bien la operación."
                };
            }
        }

        /// <summary>
        /// Permite consultar los datos de un equipo.
        /// </summary>
        /// <param name="nombreDeEquipo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ConsultarEquipo")]
        public async Task<EquiposResult> ConsultarEquipo(string nombreDeEquipo)
        {
            try
            {
                return await _counterService.ConsultarEquipo(nombreDeEquipo);
            }
            catch
            {
                return new EquiposResult
                {
                    Success = false,
                    Message = "No salió bien la operación."
                };
            }
        }

        #endregion

        #region JUGADORES

        /// <summary>
        /// Permite ingresar datos de un jugador.
        /// </summary>
        /// <param name="EntradaJugador"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("IngresarJugador")]
        public async Task<BaseResult> IngresarJugador(JugadoresInput EntradaJugador)
        {
            try
            {
                return await _counterService.IngresarJugador(EntradaJugador);
            }
            catch
            {
                return new BaseResult
                {
                    Success = false,
                    Message = "No salió bien la operación."
                };
            }
        }

        #endregion

        #region ARMAS

        /// <summary>
        /// Permite ingresar datos de un arma
        /// </summary>
        /// <param name="EntradaArma"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("IngresarArma")]
        public async Task<BaseResult> IngresarArma(ArmasInput EntradaArma)
        {

            try
            {
                return await _counterService.IngresarArma(EntradaArma);
            }
            catch
            {
                return new BaseResult
                {
                    Success = false,
                    Message = "No salió bien la operación."
                };
            }
        }

        /// <summary>
        /// Permite ingresar una o varias armas.
        /// </summary>
        /// <param name="bulk"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("IngresarArmasBulk")]
        public async Task<BaseResult> IngresarArmasBulk(List<ArmasInput> bulk)
        {

            try
            {
                return await _counterService.IngresarArmasBulk(bulk);
            }
            catch
            {
                return new BaseResult
                {
                    Success = false,
                    Message = "No salió bien la operación."
                };
            }
        }

        #endregion

        #region PAIS

        /// <summary>
        /// Permite ingresar los datos de un país.
        /// </summary>
        /// <param name="EntradaPais"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("IngresarPais")]
        public async Task<BaseResult> ingresarPais(PaisInput EntradaPais)
        {
            try
            {
                return await _counterService.IngresarPais(EntradaPais);

            }
            catch
            {

                return new BaseResult
                {
                    Success = false,
                    Message = "No salio bien la operacion."
                };
            }
        }

        #endregion
    }
}
