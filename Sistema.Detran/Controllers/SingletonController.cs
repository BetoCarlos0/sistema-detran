using Microsoft.AspNetCore.Mvc;
using Sistema.Detran.Infra.Singleton;

namespace Sistema.Detran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingletonController : Controller
    {
        private readonly SingletonContainer _singletonContainer;

        public SingletonController(SingletonContainer singletonContainer)
        {
            _singletonContainer = singletonContainer;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_singletonContainer);
        }
    }
}
