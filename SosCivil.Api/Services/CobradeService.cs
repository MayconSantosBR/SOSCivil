using AutoMapper;
using FluentResults;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Requesters.Interfaces;

namespace SosCivil.Api.Services
{
    public class CobradeService : ICobradeService
    {
        private readonly IS2idRequester _s2idRequester;
        private readonly IRepository<Cobrade> _cobradeRepository;
        private readonly IMapper _mapper;

        public CobradeService(IS2idRequester s2idRequester, IRepository<Cobrade> cobradeRepository, IMapper mapper)
        {
            _s2idRequester = s2idRequester;
            _cobradeRepository = cobradeRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<Cobrade>>> AllAsync()
        {
            try
            {
                return Result.Ok(await _cobradeRepository.GetAll());
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result> CreateOrUpdateCobradeAsync()
        {
            try
            {
                var entities = _mapper.Map<List<Cobrade>>(await _s2idRequester.GetCobradeAsync());

                foreach (var entity in entities)
                {
                    if (await _cobradeRepository.Get(c => c.CobradeCode == entity.CobradeCode) != null)
                        await _cobradeRepository.Update(entity);
                    else
                        await _cobradeRepository.Create(entity);
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
