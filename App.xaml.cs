using Microsoft.Maui.Controls;
using Application = Microsoft.Maui.Controls.Application;

namespace PrototipoERP.DesktopMaui
{
	public partial class App : Application
	{
		public static string _tokenAutenticacao { get; set; }
		public static string _usuarioLogado { get; set; }

		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
		}
	}
}
