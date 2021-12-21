using RestSharp;
using Newtonsoft.Json;
using PrototipoERP.DesktopMaui.DTOs;

namespace PrototipoERP.DesktopMaui.Services
{
    public class ConsultaUsuarioService
    {
        public readonly string _authenticationToken;

        public ConsultaUsuarioService(string authenticationToken) =>
            _authenticationToken = authenticationToken;

        public UsuarioDto GetUsuarioId(UsuarioAuthenticationRequest usuario)
        {
            var client = new RestClient($"https://artesanatosampa.com.br/api/usuario");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(
                            new UsuarioAuthenticationRequest
                            {
                                Nome = usuario.Nome,
                                Senha = usuario.Senha
                            });

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<UsuarioDto>(response.Content);
        }
    }
}
