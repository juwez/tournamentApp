﻿using System;
 using System.Collections.Generic;
 using Microsoft.AspNetCore.Mvc;
using TournamentApp.Services.Interfaces;
using System.Threading.Tasks;
 using TournamentApp.Services.Dtos.Match;
 using TournamentApp.Services.Dtos.PlayerDto;
 using TournamentApp.Services.Dtos.RoundsDto;
 using TournamentApp.Services.Dtos.Tournament;

namespace TournamentApp.WebApi.Controllers
{
    [Route("api/tournaments")]
    public class TournamentController : BaseApiController
    {
        private readonly ITournamentService _tournamentService;
        private readonly IRoundService _roundService;
        private readonly IMatchService _matchService;
        private readonly IPlayerService _playerService;
        private readonly IRoundMatchService _roundMatchService;
        public TournamentController(ITournamentService tournamentService, IRoundService roundService, IPlayerService service, IMatchService matchService, IRoundMatchService roundMatchService)
        {
            if (service != null) _roundMatchService = roundMatchService;
            if (service != null) _matchService = matchService;
            if (service != null) _playerService = service;
            if (roundService != null) _roundService = roundService;
            if (tournamentService != null) _tournamentService = tournamentService;
        }

        #region Create

        [HttpPost, Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTournamentDto dto)
        {
            //start here joey 
            if (dto.TournamentDate.ToLongDateString().EndsWith("0001")) { dto.TournamentDate = DateTime.Now; } //Checking if the date is the default value, if so updating it.
            // 1 Maak een trounament aan
            var createdTournament = await MakeTournamentFromDto(dto);
            // 2 Maak van elke combinatie van spelers eesn match
            List<List<string>> playerMatchesCombination = await _playerService.SetPlayerMatchesCombination(dto.Players);
            // 3 Maak een ronde
            var addedRound = await MakeRound();
            // 3.1 Stop alle matchen in de ronde
            //hier gaat het fout
            await _roundMatchService.MakeMatches(playerMatchesCombination, addedRound);
            // 3.2 hang tournamentKey aan de ronde
            await _roundService.EditPropertyAsync(addedRound.Key, "TournamentKey", createdTournament.Key);
            return Created(new Uri(Url.Link("GetTournament", new { key = createdTournament.Key})), createdTournament);
        }
        
        #endregion

        #region Read

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            return Ok(await _tournamentService.GetAllAsync());
        }

        [HttpGet("{key}", Name = "GetTournament")]
        public async Task<IActionResult> GetAsync(string key)
        {
            var entity = await _tournamentService.GetAsync(key);
            if (entity == null)
            {
                return NotFound(key);
            }

            return Ok(entity);
        }

        #endregion

        #region Update

        [HttpPut]
        [Route("{key}")]
        public async Task<IActionResult> UpdateAsync(string key, [FromBody] TournamentDtoBase dto)
        {
            var updatedDto = await _tournamentService.UpdateAsync(key, dto);
            return updatedDto == null ? null : Ok(updatedDto); //Todo change this null
        }

        #endregion

        #region Delete

        [HttpDelete]
        [Route("{key}")]
        public async Task<IActionResult> DeleteAsync(string key)
        {
            await _tournamentService.DeleteAsync(key);
            return NoContent();
        }
        #endregion

        #region HelperFunctions

        private async Task<TournamentDtoBase> MakeTournamentFromDto(CreateTournamentDto dto)
        {
            return await _tournamentService.AddAsync(new TournamentDtoBase
            {
                Date = DateTime.Now,
                TournamentName = dto.TournamentName
            });
        }

        private async Task<RoundDtoBase> MakeRound()
        {
            return await _roundService.AddAsync(new RoundDtoBase
            {
                RoundName = "R1"
            });
        }

        #endregion
        

        
    }
}

