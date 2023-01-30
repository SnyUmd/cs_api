//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System.Net.Http.Json;
using Newtonsoft.Json;

RequestBody rb = new RequestBody();
rb.Direction = "left";
rb.num = "two";
var body = JsonConvert.SerializeObject(rb);

// Web API を呼ぶための HttpClient を作る
var client = new HttpClient();
// POST メソッドで JSON の Body のリクエストを投げる
var response = await client.PostAsJsonAsync(
    "https://localhost:7029/?apiKey=hogehoge", rb);
    //new RequestBody { Direction = "left", num = "eight"});
// レスポンスのステータスコードが成功していたら Answer の値を出力
if (response.IsSuccessStatusCode)
{
    var responseBody = await response.Content.ReadFromJsonAsync<Response>();
    Console.WriteLine(responseBody?.Answer);
}

// リクエストとレスポンス
class RequestBody
{
    public string? Direction { get; set; }
    public string? num { get; set; }
}

class Response
{
    public string? Answer { get; set; }
}