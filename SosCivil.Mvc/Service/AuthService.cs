using SosCivil.Mvc.Models.Auth;
using System.Text;
using System.Text.Json;

namespace SosCivil.Mvc.Service
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLoginViewModel userLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(userLogin),Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7210/api/auth/login", loginContent);
            var resContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(resContent, options);
        }

        public async Task<UsuarioRespostaLogin> Registrar(UsuarioRegistroViewModel userRegistro)
        {
            var registroContent = new StringContent(JsonSerializer.Serialize(userRegistro), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7210/api/auth/register", registroContent);
            var resContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(resContent, options);
        }
    }
}
