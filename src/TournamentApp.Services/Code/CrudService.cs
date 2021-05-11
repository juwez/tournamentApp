using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TournamentApp.Model;
using TournamentApp.Repository;
using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.Code
{
    public abstract class CrudService<ST, RT> where ST : DtoBase where RT : EntityBase
    {
        protected readonly ICrudRepository<RT> _repository;
        protected readonly IMapper _mapper;

        public CrudService(ICrudRepository<RT> repository, IMapper mapper)
        {
            _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ST>> GetAllAsync()
        {
            var entities = (await _repository.GetAll());
            var l = entities.ToList();
            var l2 = new List<ST>();
            return entities.ProjectTo<ST>(_mapper.ConfigurationProvider).ToList();
           
        }
        
        public async Task<ST> GetAsync(string key)
        {
            var entity = await _repository.GetAsync(key);
            return entity?.ProjectTo<ST>(_mapper.ConfigurationProvider).First();
        }

        public async Task<ST> AddAsync(ST entity)
        {
            var dtoAsEntity = entity.ToQueryable().ProjectTo<RT>(_mapper.ConfigurationProvider);
            var test = await _repository.AddAsync(dtoAsEntity.First());
            return await GetAsync(test.First().Key);
        }

        public async Task DeleteAsync(string key)
        {
            var entityToDelete = await GetAsync(key);
            if (entityToDelete == null)
            {
                return;
            }
            await _repository.DeleteAsync(key);
        }

        public async Task<ST> UpdateAsync(string key, ST entity)
        {
            var entityToUpdate= entity.ToQueryable().ProjectTo<RT>(_mapper.ConfigurationProvider).First();
            await _repository.UpdateAsync(key,entityToUpdate);
            return await GetAsync(key);
        }

        public async Task<ST> EditPropertyAsync(string key, string property, string value)
        {
            var entity = await GetAsync(key);
            if (entity == null) { return null; }
            await _repository.EditProperty(key, property, value);
            return await GetAsync(key);
        }
        
    }
}