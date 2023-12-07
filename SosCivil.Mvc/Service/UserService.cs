using System.Net.Http;
using System.Text.Json;
using System.Text;
using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MeuPerfilViewModel> GetUserPerson(string email)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7021/api/users/email/{email}");
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<MeuPerfilViewModel>(content);
            return user;
        }
    }
}
