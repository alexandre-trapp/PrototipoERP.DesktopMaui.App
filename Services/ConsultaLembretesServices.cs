using RestSharp;

namespace PrototipoERP.DesktopMaui.Services
{
    public class ConsultaLembretesServices
    {
        public readonly string _authenticationToken;

        public ConsultaLembretesServices(string authenticationToken) =>
            _authenticationToken = authenticationToken;

        public IRestResponse GetLembretesPorUsuario(long usuarioId)
        {
            var client = new RestClient($"http://artesanatosampa.com.br/api/usuario/{usuarioId}/lembretes");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authenticationToken}");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            return response;
        }

        public IRestResponse GetTodosOsLembretes()
        {
            var client = new RestClient($"http://artesanatosampa.com.br/api/lembretes");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", $"Bearer {_authenticationToken}");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}
