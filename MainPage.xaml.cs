using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace PrototipoERP.DesktopMaui
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
		}


        private async void OnLoginClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(page: new LembretesPage());
		}
	}
}
