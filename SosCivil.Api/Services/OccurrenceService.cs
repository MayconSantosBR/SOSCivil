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
            entity = await _repository.CreateAsync(entity);


            if ((dto as OccurrenceDto).Documents != null && (dto as OccurrenceDto).Documents.Count > 0)
            {
                var mongoEntity = new OccurrenceRegister
                {
                    OccurrenceId = entity.Id,
                    Documents = (dto as OccurrenceDto).Documents
                };

                await _mongoService.CreateAsync(_collectionName, mongoEntity);
            }

            return Result.Ok(entity);
        }

        public async override Task<Result<Occurrence>> MapAndUpdateAsync<M>(long id, M dto)
        {
            await base.MapAndUpdateAsync(id, dto);

            if ((dto as OccurrenceDto).Documents != null || (dto as OccurrenceDto).Documents.Count > 0)
            {
                var mongoEntity = await _mongoService.GetOneAsync<OccurrenceRegister>(_collectionName, c => c.OccurrenceId == id);
                mongoEntity.Documents = (dto as OccurrenceDto).Documents;
                await _mongoService.ReplaceAsync<OccurrenceRegister>(_collectionName, c => c.OccurrenceId == id, mongoEntity);
            }

            return Result.Ok();
        }

        public async override Task<Result<Occurrence>> RemoveAsync(long id)
        {
            await base.RemoveAsync(id);
            await _mongoService.DeleteAsync<OccurrenceRegister>(_collectionName, c => c.OccurrenceId == id);
            return Result.Ok();
        }

        public async Task<Result<List<OccurrenceDocuments>?>> GetDocumentByIdAsync(long id)
        {
            var mongoEntity = await _mongoService.GetOneAsync<OccurrenceRegister>(_collectionName, c => c.OccurrenceId == id);

            if (mongoEntity == null)
                return Result.Fail<List<OccurrenceDocuments>?>("No documents for this occurrence");

            return Result.Ok(mongoEntity.Documents);
        }
    }
}
