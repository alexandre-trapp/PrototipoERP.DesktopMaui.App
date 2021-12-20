using Microsoft.Maui.Controls;
using PrototipoERP.DesktopMaui.ViewModels;

namespace PrototipoERP.DesktopMaui.Pages
{
	public partial class LoginPage : ContentPage
	{

		public LoginPage()
		{
            var login = new LoginViewModel();
			this.BindingContext = login;

			login.ExibirAvisoDeLoginInvalido += () => DisplayAlert("Erro", "Login Inválido, tente novamente", "OK");

			InitializeComponent();
		}

  //      private async void OnLoginClicked(object sender, EventArgs e)
		//{

		//	await Navigation.PushAsync(page: new LembretesPage(string.Empty));
		//}
	}
}
