using Newtonsoft.Json;

namespace PrototipoERP.DesktopMaui.DTOs
{
    public class UsuarioAuthenticationRequest
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }
    }
}
