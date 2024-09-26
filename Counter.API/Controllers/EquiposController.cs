using Counter.Core.Interfaces;
using Counter.Core.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Counter.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EquiposController : BaseController
    {
        public EquiposController(IConfiguration configuration, IHttpContextAccessor contextAccessor, ICounterService counterService) : base(configuration, contextAccessor, counterService) {


        }

        [HttpGet]
        [Route("Team")]

        public string Team(string team)
        {
            return $"hola mundo" + team;
        }
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
        [HttpGet]
        [Route("consultarjugadorespaisesArmas")]

        public async Task<JugadoresPyA> ConsultarJugadorPyA(string NombreJugador)
        {
            try
            {
                return await _counterService.ConsultarJugadorPyA(NombreJugador);

            }
            catch
            {

                return new JugadoresPyA
                {
                    Success = false,
                    Message = "No salio bien la operacion."
                };
            }



        }
        [HttpGet]
        [Route("consultakiller")]

        public async Task<Killer> Jugadorkiller ()
        {

            try
            {
                return await _counterService.Jugadorkiller();

            }
            catch
            {

                return new Killer
                {
                    Success = false,
                    Message = "No salio bien la operacion."
                };
            }


        }




    }
}
