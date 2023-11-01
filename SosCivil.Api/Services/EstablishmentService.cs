using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class EstablishmentService : SosCivilServiceBase<Establishment>, IEstablishmentService
    {
        private readonly IMapper _mapper;
        public EstablishmentService(IMapper mapper, IRepository<Establishment> repository) : base(repository)
        {
            _mapper = mapper;
        }
    }
}
