using Microsoft.Extensions.Configuration;
using SosCivil.Mvc.Models;
using SosCivil.Mvc.Models.Auth;
using System.Text;
using System.Text.Json;

namespace SosCivil.Mvc.Service
{
    public class SolicitacaoService : Service, ISolicitacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public SolicitacaoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Solicitacao>> GetAllSolicitacoes()
        {
            var response = await _httpClient.GetAsync(_configuration.GetConnectionString("Api") + "occurrences");
            var content = await response.Content.ReadAsStringAsync();
            var solicitacoes = JsonSerializer.Deserialize<List<Solicitacao>>(content);
            return solicitacoes;
        }
    }
}
