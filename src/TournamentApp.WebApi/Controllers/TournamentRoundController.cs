using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.RoundsDto;
using TournamentApp.Services.Dtos.Tournament;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.WebApi.Controllers
{
    [Route("api/tournaments/{tournamentKey}/")]
    public class TournamentRoundController : BaseApiController
    {
        private readonly ITournamentRoundService _service;
        public TournamentRoundController(ITournamentRoundService tournamentRoundService)
        {
            _service = tournamentRoundService;
        }
        
        [HttpGet]
        [Route("rounds")]
        public async Task<IActionResult> GetAllRoundsForATournamentAsync(string tournamentKey)
        {
            var entity = await _service.GetAllRoundsForATournamentAsync(tournamentKey);
            if (entity == null) { return NotFound(tournamentKey); }
            return Ok(entity);
        }

        [HttpGet]
        [Route("rounds/{parentNodeKey}")]
        public async Task<IActionResult> GetAllRoundsIncludingSubRoundsAsync(string tournamentKey, string parentNodeKey)
        {
            var rounds = await _service.GetAllRoundsIncludingSubRoundsAsync(tournamentKey, parentNodeKey);
            if (rounds == null) { return NotFound(); }
            return Ok(rounds);
        }
        
        [HttpDelete]
        [Route("rounds/{parentNodeKey}")]
        public async Task<IActionResult> RemoveAllRoundsIncludingSubRounds(string tournamentKey, string parentNodeKey)
        {
            await _service.RemoveAllRoundsIncludingSubRounds(tournamentKey, parentNodeKey);
            return NoContent();
        }

    }
}