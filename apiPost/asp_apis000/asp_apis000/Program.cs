//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello Worlds!");

//app.Run();


using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
string[] Directions = { "up", "down", "left", "right" };
string[] nums = { "one","two", "three", "four", "five", "six", "seven", "eight","nine"};

/*
// / に対して POST が来たら呼ばれる処理を登録
 //app.MapPost("/", (
 //   // body からのパラメーター
 //   RequestBody body,
 //   // クエリパラメータから受け取る
 //   string? apiKey,
 //   // ロガー
 //   ILogger<Program> logger) =>
 //   {
 //       string ans = "";

 //       // apiKey が hogehoge じゃない場合は NG
 //       if (apiKey != "hogehoge") return Results.Unauthorized();
 //       // 一応受けた質問はログに出しておく
 //       logger.LogInformation("{direction}", body.Direction);
 //       logger.LogInformation("{num}", body.num);

 //       ans += "{";
 //       for (int i = 0; i < Directions.Length; i++)
 //       {
 //           if (body.Direction == Directions[i])
 //           {
 //               ans += $"Direction:{DirectionAnsuwer[i]},";
 //               break;
 //           }
 //           else if (i == Directions.Length - 1)
 //           {
 //               ans += "Direction:error,";
 //           }
 //       }
 //       for (int i = 0; i < nums.Length; i++)
 //       {
 //           if (body.num == nums[i])
 //           {
 //               ans += $"num:{i + 1}";
 //               break;
 //           }
 //           else if(i == nums.Length - 1)
 //           {
 //               ans += "num:error";
 //           }
 //       }
 //       ans += "}";

 //       // 結果を返す
 //       return Results.Ok(new Response { Answer = ans });
 //   });
*/

//app.Run();


/* http://localhost:5130/?apiKey=hogehoge
 * https://localhost:7029/?apiKey=hogehoge
 * {
 *      "Direction":"left",
 *      "Num":"two"
 * }
*/
clsApiPost clsAP = new(ref app);
clsAP.setPostApi(ref app, Directions, nums);
Console.WriteLine("post api run");
clsAP.RunWebApp();

class clsApiPost
{
    WebApplication webApp;
    public clsApiPost(ref WebApplication wa)
    {
        webApp = wa;
    }

    //*****************************************
    public void RunWebApp()
    {
        webApp.Run();
    }

    //*****************************************
    public void setPostApi(ref WebApplication wa, string[] directions, string[] ary_nums)
    {
        wa.MapPost("/", (
        // body からのパラメーター
        RequestBody body,
        // クエリパラメータから受け取る
        string? apiKey,
        // ロガー
        ILogger<Program> logger) =>
        {
            string ans = "";

            // apiKey が hogehoge じゃない場合は NG
            if (apiKey != "hogehoge") return Results.Unauthorized();
            // 一応受けた質問はログに出しておく
            logger.LogInformation("{direction}", body.Direction);
            logger.LogInformation("{num}", body.Num);

            ans += "{";
            for (int i = 0; i < directions.Length; i++)
            {
                if (body.Direction == directions[i])
                {
                    ans += $"\"Direction\":\"{Response.DirectionAnsuwer[i]}\",";
                    break;
                }
                else if (i == directions.Length - 1)
                {
                    ans += "\"Direction:error\":\"error\",";
                }
            }
            for (int i = 0; i < ary_nums.Length; i++)
            {
                if (body.Num == ary_nums[i])
                {
                    ans += $"\"Num\":\"{i + 1}\"";
                    break;
                }
                else if (i == ary_nums.Length - 1)
                {
                    ans += "\"Num\":\"error\"";
                }
            }
            ans += "}";

            // 結果を返す
            return Results.Ok(new Response { Answer = ans });
        });
    }

    public void setGetApi(ref WebApplication wa, string[] directions, string[] ary_nums)
    {
        wa.MapGet("/", (string? sts) =>
        {
        });

    }
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
    public static string[] DirectionAnsuwer = { "↑", "↓", "←", "→" };

}

