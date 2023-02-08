using System.ComponentModel;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MauiPost;

public partial class MainPage : ContentPage
{
	int count = 0;
	string strBody;
    HttpClient client;
    string address = "https://localhost:7027/api/login";
    JsBody bodys = new();


    public MainPage()
	{
		InitializeComponent();
        client = new HttpClient();

        PickerType.SelectedIndex= 0;

        //bodys.Id = "id";
        //bodys.Pass = "pass";

        strBody = "[{\r\n\t\"Id\":\"id1\",\r\n\t\"Password\":\"pass1\"\r\n},\r\n{\r\n\t\"Id\":\"id2\",\r\n\t\"Password\":\"pass2\"\r\n}]";
        //strBody = "{\"Items\":{\"Id\":\"id1\",\"Password\":\"pass1\"},\"Items\":{\"Id\":\"id2\",\"Password\":\"pass2\"}}";
        //strBody = "{\"Id\":\"id1\",\"Password\":\"pass1\"}";
        //strBody = "{\r\n\"package1\": {\r\n    \"type\": \"envelope\",\r\n    \"quantity\": 1,\r\n    \"length\": 6,\r\n    \"width\": 1,\r\n    \"height\": 4\r\n},\r\n\"package2\": {\r\n    \"type\": \"box\",\r\n    \"quantity\": 2,\r\n    \"length\": 9,\r\n    \"width\": 9,\r\n    \"height\": 9\r\n}\r\n}";
    }

    private async void OnCounterClicked(object sender, EventArgs e)
	{
        if (EditorBody.Text == "")
            return;
        JsonNode jnBody = JsonNode.Parse(strBody);
        //JObject joBody = JObject.Parse(strBody);
        //JObject joBody = (JObject)JsonConvert.DeserializeObject(strBody);
        jnBody = JsonNode.Parse(EditorBody.Text);
        var response = await client.PostAsJsonAsync(address, jnBody);
    }

    private void myPicker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    //private void myPicker_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    myLabel.Text = myPicker.SelectedIndex.ToString();
    //}
}

class JsBody
{
    public string? Id { get; set; }
    public string? Pass { get; set; }
}

