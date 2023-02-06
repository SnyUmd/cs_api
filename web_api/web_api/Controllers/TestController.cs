using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using web_api.classes;

namespace web_api.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        Respons Resp = new();
        
        [HttpGet]
        //[HttpGet("{id}")]
        //public String Get(int id, [FromQuery] string foo, [FromQuery] string bar)
        public string? Get(int? id, [FromQuery] string? foo, [FromQuery] string? bar)
        {
            Resp.id = id;
            Resp.foo = foo;
            Resp.bar = bar;
            //Console.WriteLine(Resp);
            JsonNode? jnRespons = JsonConvert.SerializeObject(Resp);
            Console.WriteLine(classes.ClsJsonCtrl.FormatJson(jnRespons.ToString()));
            return classes.ClsJsonCtrl.FormatJson(jnRespons.ToString());

            //if (id == 1) return "one";
            //else if (id == 2) return "two";
            //else return "error";
        }
    }

    class  Respons
    {
        public int? id { get; set; }
        public string? foo { get; set; }
        public string? bar { get; set; }
    }
}
