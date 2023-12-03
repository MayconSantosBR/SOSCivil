﻿using AutoMapper;
using FluentResults;
using SosCivil.Api.Data.Entities.Base;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base.Interfaces;

namespace SosCivil.Api.Services.Base
{
    public class SosCivilServiceBase<T> : ISosCivilServiceBase<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;

        protected SosCivilServiceBase(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<Result<T>> MapAndCreateAsync<M>(M dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                return await CreateAsync(entity);
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual async Task<Result<T>> CreateAsync(T entity)
        {
            try
            {
                await _repository.Create(entity);
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual async Task<Result<List<T>>> GetAllAsync()
        {
            try
            {
                return Result.Ok(await _repository.GetAll());
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual async Task<Result> UpdateAsync(T entity)
        {
            try
            {
                await _repository.Update(entity);
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual async Task<Result<T>> GetByIdAsync(long id)
        {
            try
            {
                return Result.Ok(await _repository.GetById(id));
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual async Task<Result> RemoveAsync(long id)
        {
            try
            {
                await _repository.Remove(id);
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual async Task<Result> CreateOrUpdateAsync() => throw new NotImplementedException();
    }
}
