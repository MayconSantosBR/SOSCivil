using AutoMapper;
using FluentResults;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Data.Entities.Mongo;
using SosCivil.Api.Models.Dtos.Controllers;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class OccurrenceService : SosCivilServiceBase<Occurrence>, IOccurrenceService
    {
        private readonly IMongoService _mongoService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly string _collectionName;

        public OccurrenceService(IRepository<Occurrence> repository, IMapper mapper, IConfiguration configuration, IMongoService mongoService) : base(repository, mapper)
        {
            _mapper = mapper;
            _mongoService = mongoService;
            _configuration = configuration;
            _collectionName = _configuration.GetValue<string>("Mongo:Collections:Occurrences");
        }

        public override async Task<Result<Occurrence>> MapAndCreateAsync<M>(M dto)
        {
            var entity = _mapper.Map<OccurrenceDto, Occurrence>(dto as OccurrenceDto);
            var result = await CreateAsync(entity);
            entity = result.Value;


            if ((dto as OccurrenceDto).Documents != null || (dto as OccurrenceDto).Documents.Count > 0)
            {
                var mongoEntity = _mapper.Map<Occurrence, OccurrenceRegister>(entity);
                await _mongoService.CreateAsync(_collectionName, mongoEntity);
            }

            return result;
        }
    }
}
