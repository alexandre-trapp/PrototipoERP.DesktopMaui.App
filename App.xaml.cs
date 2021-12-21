using Microsoft.Maui.Controls;
using PrototipoERP.DesktopMaui.Pages;
using Application = Microsoft.Maui.Controls.Application;

namespace PrototipoERP.DesktopMaui
{
	public partial class App : Application
	{
		public static string _tokenAutenticacao { get; set; }

		public App()
		{
			InitializeComponent();

			if (string.IsNullOrWhiteSpace(_tokenAutenticacao))
			{
				MainPage = new NavigationPage(new LoginPage());
			}
			else
			{
				MainPage = new NavigationPage(new LembretesPage(_tokenAutenticacao));
			}

			MainPage = new LoginPage();
		}
	}
}
