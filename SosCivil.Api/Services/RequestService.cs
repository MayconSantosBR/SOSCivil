﻿using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class RequestService : SosCivilServiceBase<Request>, IRequestService
    {
        private readonly IMapper _mapper;
        protected RequestService(IRepository<Request> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
    }
}
