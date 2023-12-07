using SosCivil.Mvc.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using SosCivil.Mvc.Service.Interfaces;

namespace SosCivil.Mvc.Service
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _httpClient;

        public PersonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> CreatePerson(PersonModel person, string token, string email)
        {
            var personContent = new StringContent(JsonSerializer.Serialize(person), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://localhost:7021/api/persons?token={token}&email={email}", personContent);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
