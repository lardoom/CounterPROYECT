using Counter.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Counter.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    
    public class BaseController : ControllerBase
    {

        protected readonly ICounterService _counterService;
        public BaseController(
            IConfiguration configuration,
            IHttpContextAccessor contextAccessor,
            ICounterService counterService)
        {
            _counterService = counterService;



        }
    }
}
