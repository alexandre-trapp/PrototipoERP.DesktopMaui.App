﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using PrototipoERP.DesktopMaui.DTOs;
using PrototipoERP.DesktopMaui.Services;

namespace PrototipoERP.DesktopMaui.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action<string> ExibirAvisoDeLoginInvalido;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Usuario"));
            }
        }
        
        private string senha;
        public string _tokenAuthentication;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Senha"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }

        public LoginViewModel() =>
            SubmitCommand = new Command(OnSubmit);

        public void OnSubmit()
        {
            _tokenAuthentication = string.Empty;
            var response = AuthenticationLoginService.GetTokenAuthorization(this);

            try
            {
                if (response == null)
                {
                    ExibirAvisoDeLoginInvalido("Falha na integração pra autenticar o usuário.");
                    return;
                }

                if (!response.IsSuccessful)
                {
                    ExibirAvisoDeLoginInvalido($"Falha na integração: Status = {response.StatusCode.ToString()} - " +
                                               $"{response.StatusDescription} - message: {response.ErrorMessage}");
                    return;
                }

                var authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(response.Content);

                if (string.IsNullOrWhiteSpace(authenticationResponse.Token))
                {
                    ExibirAvisoDeLoginInvalido("Falha na autenticação, token de acesso vazio ou inválido.");
                    return;
                }

                _tokenAuthentication = authenticationResponse.Token;
            }
            catch (Exception e)
            {
                ExibirAvisoDeLoginInvalido(e.Message);
            }
        }
    }
}
