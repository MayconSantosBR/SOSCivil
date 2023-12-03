using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class OccurrenceService : SosCivilServiceBase<Occurrence>, IOccurrenceService
    {
        private readonly IMapper _mapper;

        public OccurrenceService(IRepository<Occurrence> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }
    }
}
