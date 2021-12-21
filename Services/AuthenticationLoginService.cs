using System;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json;
using PrototipoERP.DesktopMaui.DTOs;
using PrototipoERP.DesktopMaui.ViewModels;

namespace PrototipoERP.DesktopMaui.Services
{
    public static class AuthenticationLoginService
    {
        public static IRestResponse GetTokenAuthorization(LoginViewModel dadosLogin)
        {
            const string baseUrl = "https://artesanatosampa.com.br/api/auth";
            var client = new RestClient(baseUrl);
            
            var request = new RestRequest(Method.POST); 
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(
                            new UsuarioAuthenticationRequest
                            {
                                Nome = dadosLogin.Usuario,
                                Senha = dadosLogin.Senha
                            });

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}
