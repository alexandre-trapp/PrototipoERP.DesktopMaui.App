using PrototipoERP.DesktopMaui.Pages;
using Application = Microsoft.Maui.Controls.Application;

namespace PrototipoERP.DesktopMaui
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new LoginPage();
		}
	}
}
