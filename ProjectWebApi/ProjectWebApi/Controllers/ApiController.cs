using Data.Providers;
using Microsoft.AspNetCore.Mvc;
using ProjectWebApi.View;

namespace ProjectWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        // GET api/Api
        [HttpGet("{id1}/{id2}")]
        public ActionResult<string> Get(string id1, string id2)
        {
            var parameters = Startup.parameters;
            Request request = new Request(id1, id2);

            var textFileDataProvider = new TextFileDataProvider(request.Numbers, parameters);
            var msSqlDataProvider = new MsSqlDataProvider(request.Numbers, parameters);

            return $"Wynik dodawania {request.Numbers.Ids[0]} i {request.Numbers.Ids[1]} rowna sie {request.Numbers.result}";
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
