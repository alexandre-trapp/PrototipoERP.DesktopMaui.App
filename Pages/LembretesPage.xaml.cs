using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using PrototipoERP.DesktopMaui.Models;
using PrototipoERP.DesktopMaui.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrototipoERP.DesktopMaui.Pages
{
	public partial class LembretesPage : ContentPage
	{
        private readonly long _usuarioId;
        private readonly ConsultaLembretesServices _consultaLembretesService;

        public LembretesPage(string authenticationToken, long usuarioId)
		{
			InitializeComponent();

			myListView.ItemsSource = AppState.Lembretes;

            _usuarioId = usuarioId;
            _consultaLembretesService = new ConsultaLembretesServices(authenticationToken);
            
        }

        public void OnMeuUsuarioClicked(object sender, EventArgs args)
        {
            LembretesPorUsuario();
        }

        private void LembretesPorUsuario()
        {
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
                        UsuarioId = x.UsuarioId,
                        DataHora = x.DataHora,
                        Texto = x.Texto
                    }));
            }
        }


        private void TodosOsLembretes()
        {
            AppState.Lembretes.Clear();

            var response = _consultaLembretesService.GetTodosOsLembretes();

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
                        UsuarioId = x.UsuarioId,
                        DataHora = x.DataHora,
                        Texto = x.Texto
                    }));
            }
        }

        public void OnTodosUsuariosClicked(object sender, EventArgs args)
        {
            TodosOsLembretes();
        }
    }
}
