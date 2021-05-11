using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.Dtos.PlayerDto;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.WebApi.Controllers
{
    [Route("api/players")]
    public class PlayerController : BaseApiController
    {
        private readonly IPlayerService _service;
        public PlayerController(IPlayerService playerService)
        {
            if (playerService != null) _service = playerService;
        }

        #region Create 

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PlayerDtoBase  entity)
        {
            var updatedEntity = await _service.AddAsync(entity);
            if (updatedEntity == null) { return Conflict(); }
            return Ok(updatedEntity);
        }    
    
        #endregion

        #region Read
        
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
        
        [HttpGet("{key}")]
        public async Task<IActionResult> GetAsync(string key)
        {
            var entity = await _service.GetAsync(key);
            if (entity == null) { return NotFound(key); }
            return Ok(entity);
        }
        #endregion

        #region Update

        [HttpPut]
        [Route("{key}")]
        public async Task<IActionResult> UpdateAsync(string key, [FromBody] PlayerDtoBase dto)
        {
            var updatedDto = await _service.UpdateAsync(key, dto);
            return updatedDto == null ? null : Ok(updatedDto); //Todo change this null
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("{key}")]
        public async Task<IActionResult> DeleteAsync(string key)
        {
            await _service.DeleteAsync(key);
            return NoContent();
        }

        #endregion

        
        
       
    }
}