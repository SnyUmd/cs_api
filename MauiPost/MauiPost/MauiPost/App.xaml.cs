using MauiPost.Classes;

namespace MauiPost;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		ClsCommon.Init();
		MainPage = new AppShell();
	}
}
