using _2_Pastelaria.Application.Infra;
using _2_Pastelaria.Application.Model;
using System.Net.Http;

namespace _2_Pastelaria.Application
{
    public class UsuarioApplication : BaseApplication
    {
        public UsuarioApplication() : base("https://localhost:44311/api/Usuario/")
        {
        }
        public HttpResponseMessage Get() => _httpClient.GetAsync("Get").Result;

        public HttpResponseMessage Post(UsuarioModel usuario) => _httpClient.PostAsJsonAsync("Post", usuario).Result;

    }

}
