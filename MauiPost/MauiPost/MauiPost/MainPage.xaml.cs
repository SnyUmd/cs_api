using System.ComponentModel;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MauiPost;

public class ClsPickerItems
{
    //***********************************************
    public enum EnmItems
    {
        jsonNode = 0,
        str
    }

    //public static EnmItems enmItems = new();

    public static List<string> aryTypeItems 
        = new List<string>() { "JsonNode", "String"};
}

public partial class MainPage : ContentPage
{
	int count = 0;
	string strBody;
    HttpClient client;
    string address = "https://localhost:7027/api/login";
    JsBody bodys = new();

    //***********************************************
    public MainPage()
    {
		InitializeComponent();
        client = new HttpClient();

        //BindingContext = new ClsPickerItems();

        Console.WriteLine(ClsPickerItems.aryTypeItems[(int)ClsPickerItems.EnmItems.jsonNode]);
        Console.WriteLine(ClsPickerItems.aryTypeItems[(int)ClsPickerItems.EnmItems.str]);
        PickerType.ItemsSource = ClsPickerItems.aryTypeItems;
        PickerType.SelectedIndex= 0;
   }

    //***********************************************
    private async void OnCounterClicked(object sender, EventArgs e)
    {
        if (EditorBody.Text == "")
            return;
        //JsonNode jnBody = JsonNode.Parse(strBody);
        //JObject joBody = JObject.Parse(strBody);
        //JObject joBody = (JObject)JsonConvert.DeserializeObject(strBody);
        JsonNode jnBody = JsonNode.Parse(EditorBody.Text);
        var response = await client.PostAsJsonAsync(address, jnBody);
    }

    //***********************************************
    private void myPicker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //***********************************************
    private void ClickedEdit(object sender, EventArgs e)
    {

    }


    //private void myPicker_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    myLabel.Text = myPicker.SelectedIndex.ToString();
    //}
}

    //***********************************************
class JsBody
{
    public string? Id { get; set; }
    public string? Pass { get; set; }
}

