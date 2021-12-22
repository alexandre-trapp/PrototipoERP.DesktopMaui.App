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
            var client = new RestClient($"http://artesanatosampa.com.br/api/usuarios/id");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authenticationToken}");

            request.AddParameter("nome", usuario.Nome);
            request.AddParameter("senha", usuario.Senha);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<UsuarioDto>(response.Content);
        }
    }
}
