using AutoMapper;
using Microsoft.Extensions.Configuration;
using SosCivil.Api.Data.Enums;
using SosCivil.Mvc.Models;
using SosCivil.Mvc.Models.Auth;
using SosCivil.Mvc.Service.Base;
using System.Text;
using System.Text.Json;

namespace SosCivil.Mvc.Service
{
    public class SolicitacaoService : ServiceBase, ISolicitacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public SolicitacaoService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _mapper = mapper;

            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("SosCivil:ConnectionStrings:Api"));
        }



        public async Task<List<Solicitacao>> GetAllSolicitacoes()
        {
            try
            {
                var response = await _httpClient.GetAsync("requests");
                var content = await response.Content.ReadAsStringAsync();
                var solicitacoes = JsonSerializer.Deserialize<List<Solicitacao>>(content);
                return solicitacoes;
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }
        public async Task<Solicitacao> Create(Solicitacao solicitacao)
        {
            try
            {
                var estabelecimento = await CriarEstabelecimento(solicitacao);
                var requestItem = await CriarRequestItem(solicitacao);
                var ocurrence = await CriarOcurrence(solicitacao, estabelecimento.Id, estabelecimento.PersonId, requestItem.Id);
                var solicitacaoDto = new SolicitacaoDto
                {
                    OccurrenceId = ocurrence.Id,
                    Status = StatusEnum.Created,
                    RequestDate = DateTime.UtcNow,
                    DeliveryDate = DateTime.UtcNow
                };
                var content = new StringContent(JsonSerializer.Serialize(solicitacaoDto),  Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("requests", content);
                var responseString = await response.Content.ReadAsStringAsync();
                var solicitacaoCriada = JsonSerializer.Deserialize<Solicitacao>(responseString);

                return solicitacaoCriada;
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        private async Task<OcurrenceModel> CriarOcurrence(Solicitacao solicitaca, long estabelecimentoId, long personId, long requestItemId)
        {
            try
            {
                var ocurrence = new OcurrenceModel
                {
                    EstablishmentId = estabelecimentoId,
                    PersonId = personId,
                    Status = (int)solicitaca.Status,
                    UserId = personId,
                    requestItemId = requestItemId
                };

                var content = new StringContent(JsonSerializer.Serialize(ocurrence), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("occurrences", content);
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<OcurrenceModel>(responseString);
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        private async Task<RequestItemModel> CriarRequestItem(Solicitacao solicitacao)
        {
            try
            {
                var requestItem = new RequestItemModel
                {
                    ItemId = solicitacao.Suprimento.Id,
                    Quantity = solicitacao.Suprimento.Quantidade
                };

                var content = new StringContent(JsonSerializer.Serialize(requestItem), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("request-items", content);
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<RequestItemModel>(responseString);

            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }
        private async Task<Estabelecimento> CriarEstabelecimento(Solicitacao solicitacao)
        {
            try
            {
                var estabelecimento = new Estabelecimento
                {
                    Neighborhood = solicitacao.Bairro,
                    Street = solicitacao.Rua,
                    ZipCode = solicitacao.Cep,
                    PersonId = 1
                };

                var content = new StringContent(JsonSerializer.Serialize(estabelecimento), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("establishments", content);
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Estabelecimento>(responseString);

            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

    }
}
