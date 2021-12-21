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
		public LembretesPage(string authenticationToken, long usuarioId)
		{
			InitializeComponent();

			myListView.ItemsSource = AppState.Lembretes;

            var consultaLembretesService = new ConsultaLembretesServices(authenticationToken);
            var response = consultaLembretesService.GetLembretesPorUsuario(usuarioId);

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

        public void OnMeuUsuarioClicked(object sender, EventArgs args)
        {
            //AppState.Lembretes.Add(new TodoModel() { Id = 2, Title = "Ir a academia", CreatedAt = DateTime.Now, Done = false });
        }

        public void OnTodosUsuariosClicked(object sender, EventArgs args)
        {
            //AppState.Lembretes.Add(new TodoModel() { Id = 2, Title = "Ir a academia", CreatedAt = DateTime.Now, Done = false });
        }
    }
}
