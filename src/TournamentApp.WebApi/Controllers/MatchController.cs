using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Model;
using TournamentApp.Services.Code;
using TournamentApp.Services.Dtos.Match;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.WebApi.Controllers
{
    [Route("api/matches")]
    public class MatchController : BaseApiController
    {
        private readonly IMatchService _service;
        public MatchController(IMatchService service)
        {
            if (service != null) _service = service;
        }
        
        #region Create 

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MatchDtoBase  entity)
        {
            var updatedEntity = await _service.AddAsync(entity);
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
        public async Task<IActionResult> UpdateAsync(string key,MatchDtoBase dto)
        {
            var updatedDto = await _service.UpdateAsync(key, dto);
            return updatedDto == null ? null : Ok(updatedDto); //Todo change this null
        }

        [HttpPatch]
        [Route("{key}")]
        public async Task<IActionResult> UpdatePointsAsync(string key, [FromBody] UpdateMatchPointsDto matchPointsDto)
        {
           await _service.EditScore(key, matchPointsDto.ScorePlayer1, matchPointsDto.ScorePlayer2);
           return Ok(await _service.GetAsync(key));
        }
        
        [HttpPatch]
        [Route("{key}/finishMatch")]
        public async Task<IActionResult> FinishMatch(string key, [FromBody] FinishMatchDto finishMatchDto)
        {
            await _service.FinishMatch(key, finishMatchDto.ScorePlayer1, finishMatchDto.ScorePlayer2);
            return Ok(await _service.GetAsync(key));
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