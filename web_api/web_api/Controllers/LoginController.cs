using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace web_api.Controllers
{
    //[RoutePrefix("api/profile")]
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public JsonNode? LoginPost([FromBody] JsonNode value)
        {
            int cnt = 0;
            while(true)
            {
                try
                {
                    Console.WriteLine(value[cnt]);
                    cnt++;
                }
                catch
                {
                    break;
                }
            }
            return value;
        }
    }
}
