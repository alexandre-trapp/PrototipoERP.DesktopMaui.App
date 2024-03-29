﻿using System;
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
    public partial class TodosLembretesPage : ContentPage
    {
        private readonly long _usuarioId;
        private readonly ConsultaLembretesServices _consultaLembretesService;

        public TodosLembretesPage(string authenticationToken)
        {
            InitializeComponent();

            _consultaLembretesService = new ConsultaLembretesServices(authenticationToken);

            TodosOsLembretes();

            myListView.ItemsSource = AppState.Lembretes;
        }

        private void TodosOsLembretes()
        {
            AppState.Lembretes = new ObservableCollection<LembreteModel>();

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
                        Texto = x.Texto,
                        UsuarioId = x.UsuarioId,
                        Usuario = $"Criado pelo usuário: {x.Usuario}",
                        CriadoEm = $"Criado em: {x.DataHora:dd/MM/yyyy HH:mm:ss}"
                    }));
            }
        }
    }
}
