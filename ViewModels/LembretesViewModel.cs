using System;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PrototipoERP.DesktopMaui.Models;
using PrototipoERP.DesktopMaui.Services;

namespace PrototipoERP.DesktopMaui.ViewModels
{
    public class LembretesViewModel : BindableObject
    {
        public ObservableCollection<LembreteModel> _lembretes;
        private readonly long _usuarioId;
        private readonly ConsultaLembretesServices _consultaLembretesService;

        public ObservableCollection<LembreteModel> Lembretes
        {
            get { return _lembretes; }
            set 
            { 
                _lembretes = value;
                OnPropertyChanged();
            }

        }
        
        public ICommand TodosLembretesCommand { get; set; }

        public LembretesViewModel(string authenticationToken, long usuarioId)
        {
            _usuarioId = usuarioId;
            _consultaLembretesService = new ConsultaLembretesServices(authenticationToken);

            TodosLembretesCommand = new Command(TodosOsLembretes);
            Lembretes = new ObservableCollection<LembreteModel>();
        }

        public void TodosOsLembretes()
        {
            Lembretes.Clear();

            var response = _consultaLembretesService.GetTodosOsLembretes();

            if (response == null)
            {
                Application.Current.MainPage.DisplayAlert("Erro", "Falha na integração pra buscar os lembretes.", "OK");
                return;
            }

            if (!response.IsSuccessful)
            {
                Application.Current.MainPage.DisplayAlert("Erro", $"Falha na integração: Status = {response.StatusCode.ToString()} - " +
                              $"{response.StatusDescription} - message: {response.ErrorMessage}", "OK");

                return;
            }

            var lembretes = JsonConvert.DeserializeObject<List<LembreteModel>>(response.Content);
            if (lembretes != null && lembretes.Any())
            {
                lembretes.ForEach(x =>
                    Lembretes.Add(new LembreteModel()
                    {
                        UsuarioId = x.UsuarioId,
                        DataHora = x.DataHora,
                        Texto = x.Texto
                    }));
            }
        }
    }
}
