using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.Code;
using TournamentApp.Services.Dtos.PlayerDto;
using TournamentApp.Services.Dtos.RoundsDto;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.WebApi.Controllers
{
    [Route("api/rounds")]
    public class RoundController : BaseApiController
    {
        private readonly IRoundService _service;
        private readonly IRoundMatchService _roundMatchService;
        public RoundController(IRoundService roundService, IRoundMatchService roundMatchService)
        {
            if (roundMatchService != null)_roundMatchService = roundMatchService;
            if (roundService != null) _service = roundService;
        }
        
        
        
        #region Post 

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RoundDtoBase  entity)
        {
            var updatedEntity = await _service.AddAsync(entity);
            return Created(new Uri(Url.Link("GetRound", new { key = entity.Key})), updatedEntity);
        }

        [HttpPost]
        [Route("{key}/finish")]
        public async Task<IActionResult> EndRound([FromBody] List<FinishRoundDto> finishRoundDto)
        {
            Console.WriteLine("test");
            //Checking the count on how many players won
            var playerWinAtEndOfMatchDic = _roundMatchService.CountPlayerWinAtEndOfMatch(finishRoundDto);
            //Deciding who is a winner and a loser
            return Ok();
        }
    
        #endregion

        #region Get
        
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
        
        [HttpGet("{key}", Name = "GetRound")]
        public async Task<IActionResult> GetAsync(string key)
        {
            var entity = await _service.GetAsync(key);
            if (entity == null) { return NotFound(key); }
            return Ok(entity);
        }
        
        [HttpGet("{key}/matches")]
        public async Task<IActionResult> GetMatchesForARound(string key)
        {
            var res = await _roundMatchService.GetMatches(key);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        #endregion

        #region Put

        [HttpPut]
        [Route("{key}")]
        public async Task<IActionResult> UpdateAsync(string key,RoundDtoBase dto)
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