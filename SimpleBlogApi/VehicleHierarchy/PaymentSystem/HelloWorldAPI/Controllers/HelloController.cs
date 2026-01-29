using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        // GET: api/hello
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World from GET!");
        }

        // POST: api/hello
        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            return Ok($"Hello {name} from POST!");
        }
    }
}
