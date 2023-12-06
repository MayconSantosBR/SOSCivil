using AutoMapper;
using FluentResults;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Requesters.Interfaces;
using SosCivil.Api.Services.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class CobradeService : SosCivilServiceBase<Cobrade>, ICobradeService
    {
        private readonly IS2idRequester _s2idRequester;
        private readonly IMapper _mapper;

        public CobradeService(IS2idRequester s2idRequester, IMapper mapper, IRepository<Cobrade> repository) : base(repository, mapper)
        {
            _s2idRequester = s2idRequester;
            _mapper = mapper;
        }

        public override async Task<Result> CreateOrUpdateAsync()
        {
            try
            {
                var entities = _mapper.Map<List<Cobrade>>(await _s2idRequester.GetCobradeAsync());

                foreach (var entity in entities)
                {
                    if (await _repository.Get(c => c.CobradeCode == entity.CobradeCode) != null)
                        await _repository.Update(entity);
                    else
                        await _repository.CreateAsync(entity);
                }

                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail($"Error: {e.Message}\nInnerMessage: {e.InnerException?.Message}");
            }
        }
    }
}
