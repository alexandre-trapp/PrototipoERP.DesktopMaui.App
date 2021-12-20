using Microsoft.Maui.Controls;
using PrototipoERP.DesktopMaui.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PrototipoERP.DesktopMaui.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action ExibirAvisoDeLoginInvalido;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        
        private string senha;
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
            var tokenAuthorizationLogin = AuthotizationLoginService.GetTokenAuthorization(this);

            if (string.IsNullOrWhiteSpace(tokenAuthorizationLogin))
                ExibirAvisoDeLoginInvalido();
        }
    }
}
