using Calculator;
using Microsoft.AspNetCore.Mvc;
using ProjectWebApi.View;

namespace ProjectWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private Numbers _numbers;

        // GET api/Api
        [HttpGet("{id1}/{id2}")]
        public ActionResult<string> Get(string id1, string id2)
        {
            Request request = new Request(id1, id2, Startup.parameters);
            _numbers = request.CalculateResult();

            return $"Wynik dodawania {_numbers.number1} i {_numbers.number2} rowna sie {_numbers.result}";
        }

        // POST api/Api
        [HttpPost()]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Api/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Api/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
