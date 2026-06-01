using FizzBuzz.Entity;
using FizzBuzz.IServices;
using FizzBuzz.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _service;

        public FizzBuzzController(IFizzBuzzService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody]List<string> values)
        {
            if (values == null || !values.Any())
                return BadRequest("Input list cannot be empty.");

            var results = _service.Process(values);
            return Ok(results);
        }
    }
}
