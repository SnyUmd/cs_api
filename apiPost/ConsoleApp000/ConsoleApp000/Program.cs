//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

RequestBody rb = new RequestBody();
rb.Direction = "left";
rb.Num = "two";
// Web API を呼ぶための HttpClient を作る
var client = new HttpClient();

//---------------------------------------------------------------
var body_rb = JsonConvert.SerializeObject(rb);
var content = new StringContent(body_rb, Encoding.UTF8, "application/json");
var response = await client.PostAsync("https://testhost:7029/?apiKey=hogehoge", content);
//---------------------------------------------------------------

//or

//---------------------------------------------------------------
/*
// POST メソッドで JSON の Body のリクエストを投げる
var response = await client.PostAsJsonAsync(
    //"http://localhost:5130/?apiKey=hogehoge", rb);
    "https://localhost:7029/?apiKey=hogehoge", rb);
*/
//---------------------------------------------------------------


// レスポンスのステータスコードが成功していたら Answer の値を出力
if (response.IsSuccessStatusCode)
{
    var responseBody = await response.Content.ReadFromJsonAsync<Response>();
    Console.WriteLine($"body : {body_rb}");
    Console.WriteLine($"response : {responseBody?.Answer}");
}

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