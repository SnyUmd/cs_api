using AttendanceExcel.Classes;
using MauiCtrl;
namespace AttendanceExcel;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		clsCommon.AttendanceExcelInit();
		MainPage = new AppShell();
	}
}
