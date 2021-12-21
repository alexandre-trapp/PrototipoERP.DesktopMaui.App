using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
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
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
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
            _tokenAuthentication = AuthenticationLoginService.GetTokenAuthorization(this);

            try
            {
                if (string.IsNullOrWhiteSpace(_tokenAuthentication))
                    ExibirAvisoDeLoginInvalido(string.Empty);
            }
            catch (Exception e)
            {
                ExibirAvisoDeLoginInvalido(e.Message);
            }
        }
    }
}
