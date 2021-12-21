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
        public static string GetTokenAuthorization(LoginViewModel dadosLogin)
        {
            const string baseUrl = "https://artesanatosampa.com.br/api/";
            var restClient = new RestClient(baseUrl);
            restClient.AddDefaultHeader("Content-Type", "application/json");

            var request = new RestRequest();
            request.AddBody(new UsuarioAuthenticationRequest
            {
                Nome = dadosLogin.Usuario, 
                Senha = dadosLogin.Senha 
            });

            var response = restClient.ExecuteAsPost(request, "auth");

            if (response == null)
                throw new ArgumentNullException(nameof(response));

            if (!response.IsSuccessful)
                throw new HttpRequestException($"Error on request - Status = {response.StatusCode.ToString()} - " +
                    $"{response.StatusDescription} - message: {response.ErrorMessage}");

            var authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(response.Content);
            return authenticationResponse.Token;
        }
    }
}
