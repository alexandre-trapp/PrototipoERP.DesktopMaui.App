using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using PrototipoERP.DesktopMaui.DTOs;
using PrototipoERP.DesktopMaui.Pages;
using PrototipoERP.DesktopMaui.Services;
using PrototipoERP.DesktopMaui.ViewModels;
using System;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
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
			var loginViewModel = (this.BindingContext as LoginViewModel);
			App._tokenAutenticacao = loginViewModel._tokenAuthentication;

			if (string.IsNullOrWhiteSpace(App._tokenAutenticacao))
				return;

			App._usuarioLogado = loginViewModel.Usuario;

			var usuarioDto = new ConsultaUsuarioService(App._tokenAutenticacao).GetUsuarioId(
				new UsuarioAuthenticationRequest
				{
					Nome = loginViewModel.Usuario,
					Senha = loginViewModel.Senha
				});

			await Navigation.PushAsync(new LembretesPage(App._tokenAutenticacao, usuarioDto.Id), animated: true);
		}
	}
}
