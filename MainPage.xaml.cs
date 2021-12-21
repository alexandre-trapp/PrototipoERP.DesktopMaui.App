using Microsoft.Maui.Controls;
using PrototipoERP.DesktopMaui.Pages;
using PrototipoERP.DesktopMaui.ViewModels;
using System;

namespace PrototipoERP.DesktopMaui
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			var login = new LoginViewModel();
			this.BindingContext = login;

            login.ExibirAvisoDeLoginInvalido += (string message) => DisplayAlert("Erro", !string.IsNullOrEmpty(message) ?
				$"Login Inválido, tente novamente - {message}" :
				"Login Inválido, tente novamente", "OK");

			InitializeComponent();
		}

		private async void OnLoginClicked(object sender, EventArgs e)
		{
			App._tokenAutenticacao = (this.BindingContext as LoginViewModel)._tokenAuthentication;

			if (!string.IsNullOrWhiteSpace(App._tokenAutenticacao))
			{
				await Navigation.PushAsync(new LembretesPage(App._tokenAutenticacao, 1), animated: true);
			}
		}
	}
}
