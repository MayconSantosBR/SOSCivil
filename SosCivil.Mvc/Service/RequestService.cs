using AutoMapper;
using Newtonsoft.Json;
using SosCivil.Mvc.Models;
using SosCivil.Mvc.Service.Interfaces;
using SosCivil.Mvc.Models.Services;
using System.Text;

namespace SosCivil.Mvc.Service
{
    public class RequestService : IRequestService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public RequestService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _mapper = mapper;

            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("SosCivil:ConnectionStrings:Api"));
        }

        public async Task<List<Entrega>> PegarEntregasAssincrono()
        {
            using var response = await _httpClient.GetAsync("requests");

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<List<Entrega>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Entrega> PegarEntregaPorIdAssincrono(long id)
        {
            using var response = await _httpClient.GetAsync($"requests/{id}");

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Entrega>(await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> CriarEntregaAssincrono(Entrega entrega)
        {
            try
            {
                var entregaDto = _mapper.Map<EntregaDto>(entrega);

                using var response = await _httpClient.PostAsync("requests", new StringContent(JsonConvert.SerializeObject(entregaDto), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditarEntregaAssincrono(Entrega entrega)
        {
            try
            {
                var entregaDto = _mapper.Map<EntregaDto>(entrega);

                using var response = await _httpClient.PutAsync($"requests/{entrega.Id}", new StringContent(JsonConvert.SerializeObject(entregaDto), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ExcluirEntregaAssincrono(long id)
        {
            try
            {
                using var response = await _httpClient.DeleteAsync($"requests/{id}");

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
