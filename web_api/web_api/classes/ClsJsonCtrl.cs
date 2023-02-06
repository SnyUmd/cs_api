using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace web_api.classes
{
    //*********************************************************
    public class ClsJsonCtrl
    {
        //json成形
        public static string? FormatJson(string json)
        {
            dynamic? parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }


}
