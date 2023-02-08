//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System.ComponentModel;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

/*
RequestBody rb = new RequestBody();
rb.Direction = "left";
rb.Num = "two";
*/

LoginRequestBody rb = new();
rb.Id = "id";
rb.Password = "pass";

// Web API を呼ぶための HttpClient を作る
var client = new HttpClient();

string apiAddress;
//apiAddress = "https://testhost:7029/?apiKey=hogehoge";
apiAddress = "https://localhost:7027/api/login";

//---------------------------------------------------------------

var body_rb = JsonConvert.SerializeObject(rb);
var content = new StringContent(body_rb, Encoding.UTF8, "application/json");
var response = await client.PostAsync(apiAddress, content);

//---------------------------------------------------------------

//or

//---------------------------------------------------------------

// POST メソッドで JSON の Body のリクエストを投げる
//var response = await client.PostAsJsonAsync(
//    //"http://localhost:5130/?apiKey=hogehoge", rb);
//    "https://localhost:7029/?apiKey=hogehoge", rb);


//var response = await client.PostAsJsonAsync("https://localhost:7027/api/login", rb);

//---------------------------------------------------------------

// レスポンスのステータスコードが成功していたら Answer の値を出力
//if (response.IsSuccessStatusCode)
//{
//    var responseBody = await response.Content.ReadFromJsonAsync<Response>();
//    Console.WriteLine($"body : {body_rb}");
//    Console.WriteLine($"response : {responseBody?.Answer}");
//}

// リクエストとレスポンス
class RequestBody
{
    public string? Direction { get; set; }
    public string? Num { get; set; }
}

class Response
{
    public string? Answer { get; set; }
}


class LoginRequestBody
{
    public string? Id { get; set; }
    public string? Password { get; set; }
}