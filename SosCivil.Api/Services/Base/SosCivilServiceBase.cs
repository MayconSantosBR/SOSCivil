using AutoMapper;
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
                return Result.Ok(await _repository.CreateAsync(entity));
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
                return Result.Ok(await _repository.GetAllAsync());
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual async Task<Result<T>> MapAndUpdateAsync<M>(long id, M dto)
        {
            try
            {
                var entity = _mapper.Map<T>(dto);
                entity.Id = id;
                return await UpdateAsync(entity);
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
                return Result.Ok(await _repository.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public virtual async Task<Result<T>> RemoveAsync(long id)
        {
            try
            {
                await _repository.RemoveAsync(id);
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
