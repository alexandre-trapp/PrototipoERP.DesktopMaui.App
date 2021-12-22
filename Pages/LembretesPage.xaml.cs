using System;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PrototipoERP.DesktopMaui.Models;
using PrototipoERP.DesktopMaui.Services;
using Microsoft.Maui.Controls.Xaml;

namespace PrototipoERP.DesktopMaui.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LembretesPage : ContentPage
    {
        private readonly long _usuarioId;
        private readonly ConsultaLembretesServices _consultaLembretesService;

        public LembretesPage(string authenticationToken, long usuarioId)
        {
            InitializeComponent();

            _usuarioId = usuarioId;
            _consultaLembretesService = new ConsultaLembretesServices(authenticationToken);

            LembretesPorUsuario();

            myListView.ItemsSource = AppState.Lembretes;
        }

        private void LembretesPorUsuario()
        {
            AppState.Lembretes = new ObservableCollection<LembreteModel>();

            var response = _consultaLembretesService.GetLembretesPorUsuario(_usuarioId);

            if (response == null)
            {
                DisplayAlert("Erro", "Falha na integração pra buscar os lembretes.", "OK");
                return;
            }

            if (!response.IsSuccessful)
            {
                DisplayAlert("Erro", $"Falha na integração: Status = {response.StatusCode.ToString()} - " +
                              $"{response.StatusDescription} - message: {response.ErrorMessage}", "OK");

                return;
            }

            var lembretes = JsonConvert.DeserializeObject<List<LembreteModel>>(response.Content);

            if (lembretes != null && lembretes.Any())
            {
                lembretes.ForEach(x =>
                    AppState.Lembretes.Add(new LembreteModel()
                    {
                        Texto = x.Texto,
                        UsuarioId = x.UsuarioId,
                        Usuario = $"Criado pelo usuário: {App._usuarioLogado}",
                        CriadoEm = $"Criado em: {x.DataHora:dd/MM/yyyy HH:mm:ss}"
                    }));
            }
        }

        public async void OnTodosUsuariosClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TodosLembretesPage(App._tokenAutenticacao), animated: true);
        }
    }
}
