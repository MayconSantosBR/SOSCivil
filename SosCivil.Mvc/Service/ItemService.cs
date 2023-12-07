using AutoMapper;
using Newtonsoft.Json;
using SosCivil.Mvc.Models;
using SosCivil.Mvc.Models.Services;
using SosCivil.Mvc.Service.Interfaces;
using System.Text;

namespace SosCivil.Mvc.Service
{
    public class ItemService : IItemService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ItemService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _mapper = mapper;

            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("SosCivil:ConnectionStrings:Api"));
        }

        public async Task<List<Suprimento>> PegarSuprimentosAssincrono()
        {
            using var response = await _httpClient.GetAsync("items");

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<List<Suprimento>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Suprimento> PegarSuprimentoPorIdAssincrono(long id)
        {
            using var response = await _httpClient.GetAsync($"items/{id}");

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Suprimento>(await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> CriarSuprimentoAssincrono(Suprimento suprimento)
        {
            try
            {
                var suprimentoDto = _mapper.Map<SuprimentoDto>(suprimento);

                using var response = await _httpClient.PostAsync("items", new StringContent(JsonConvert.SerializeObject(suprimentoDto), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditarSuprimentoAssincrono(Suprimento suprimento)
        {
            try
            {
                var suprimentoDto = _mapper.Map<SuprimentoDto>(suprimento);

                using var response = await _httpClient.PutAsync($"items/{suprimento.Id}", new StringContent(JsonConvert.SerializeObject(suprimentoDto), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ExcluirSuprimentoAssincrono(long id)
        {
            try
            {
                using var response = await _httpClient.DeleteAsync($"items/{id}");

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
