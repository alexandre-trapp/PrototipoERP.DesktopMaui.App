using Microsoft.Maui.Controls;
using PrototipoERP.DesktopMaui.ViewModels;

namespace PrototipoERP.DesktopMaui.Pages
{
	public partial class LembretesPage : ContentPage
	{
        public LembretesPage(string authenticationToken, long usuarioId)
		{
			InitializeComponent();

            var lembretesViewModel = new LembretesViewModel(authenticationToken, usuarioId);
            this.BindingContext = lembretesViewModel;
        }

        //public void OnMeuUsuarioClicked(object sender, EventArgs args)
        //{
        //    LembretesPorUsuario();
        //}

        //private void LembretesPorUsuario()
        //{
        //    AppState.Lembretes = new ObservableCollection<LembreteModel>();

        //    var response = _consultaLembretesService.GetLembretesPorUsuario(_usuarioId);

        //    if (response == null)
        //    {
        //        DisplayAlert("Erro", "Falha na integração pra buscar os lembretes.", "OK");
        //        return;
        //    }

        //    if (!response.IsSuccessful)
        //    {
        //        DisplayAlert("Erro", $"Falha na integração: Status = {response.StatusCode.ToString()} - " +
        //                      $"{response.StatusDescription} - message: {response.ErrorMessage}", "OK");

        //        return;
        //    }

        //    var lembretes = JsonConvert.DeserializeObject<List<LembreteModel>>(response.Content);
        //    if (lembretes != null && lembretes.Any())
        //    {
        //        lembretes.ForEach(x =>
        //            AppState.Lembretes.Add(new LembreteModel()
        //            {
        //                UsuarioId = x.UsuarioId,
        //                DataHora = x.DataHora,
        //                Texto = x.Texto
        //            }));
        //    }
        //}
    }
}
