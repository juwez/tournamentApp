using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.Dtos;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.WebApi.Controllers
{
    public class BaseCrudController<T> : BaseApiController where T : DtoBase 
    {
        private readonly ICrudService<T> _crudService;

        protected BaseCrudController(ICrudService<T> crudService)
        {
            _crudService = crudService ?? throw new ArgumentNullException(nameof(crudService));
        }

        #region Create 

        [HttpPost]
        public async Task<IActionResult> CreateAsync(T entity)
        {
            var updatedEntity = await _crudService.AddAsync(entity);
            return Ok(updatedEntity);
        }    
    
        #endregion

        #region Read
        
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            return Ok(await _crudService.GetAllAsync());
        }
        
        [HttpGet("{key}")]
        public async Task<IActionResult> GetAsync(string key)
        {
            var entity = await _crudService.GetAsync(key);
            if (entity == null) { return NotFound(key); }
            return Ok(entity);
        }
        #endregion

        #region Update

        [HttpPut]
        [Route("{key}")]
        public async Task<IActionResult> UpdateAsync(string key,T dto)
        {
            var updatedDto = await _crudService.UpdateAsync(key, dto);
            return updatedDto == null ? null : Ok(updatedDto); //Todo change this null
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("{key}")]
        public async Task<IActionResult> DeleteAsync(string key)
        {
            await _crudService.DeleteAsync(key);
            return NoContent();
        }

        #endregion
       
    }
}