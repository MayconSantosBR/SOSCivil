using FluentResults;
using Newtonsoft.Json;
using SosCivil.Api.Models.Dtos.Requesters.S2id;
using SosCivil.Api.Requesters.Interfaces;

namespace SosCivil.Api.Requesters
{
    public class S2idRequester : IS2idRequester
    {
        private readonly HttpClient _httpClient;

        public S2idRequester(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<S2idCobradeResponseDto>?> GetCobradeAsync()
        {
            using var response = await _httpClient.GetAsync("rest/cobrades");

            return JsonConvert.DeserializeObject<List<S2idCobradeResponseDto>>(await response.Content.ReadAsStringAsync());
        }   
    }
}
