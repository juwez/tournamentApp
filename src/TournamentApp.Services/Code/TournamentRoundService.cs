using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TournamentApp.Model;
using TournamentApp.Repository;
using TournamentApp.Services.Dtos.RoundsDto;
using TournamentApp.Services.Interfaces;


namespace TournamentApp.Services.Code
{
    public class TournamentRoundService: CrudService<RoundDtoBase, Round>, ITournamentRoundService
    {
        private readonly ITournamentRoundRepository _tournamentRoundRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IRoundRepository _roundRepository;
        public TournamentRoundService(ITournamentRoundRepository repository, IMapper mapper, IMatchRepository matchRepository, IRoundRepository roundRepository) : base(repository, mapper)
        {
            _tournamentRoundRepository = repository;
            _matchRepository = matchRepository;
            _roundRepository = roundRepository;
        }

        public async Task<List<RoundDtoBase>> GetAllRoundsForATournamentAsync(string tournamentKey)
        {
            var entities = (await _tournamentRoundRepository.GetAllRoundsForATournamentAsync(tournamentKey));
            return entities.ProjectTo<RoundDtoBase>(_mapper.ConfigurationProvider).ToList();

        }

        public async Task<List<RoundDtoBase>> GetAllRoundsIncludingSubRoundsAsync(string tournamentKey, string parentNodeKey)
        {
            var rounds = await _tournamentRoundRepository.GetAllRoundsIncludingSubRoundsAsync(tournamentKey, parentNodeKey);
            return rounds.ProjectTo<RoundDtoBase>(_mapper.ConfigurationProvider).ToList();
        }

        public async Task RemoveAllRoundsIncludingSubRounds(string tournamentKey,
            string startingRoundKey)
        {
            await _tournamentRoundRepository.RemoveAllRoundsIncludingSubRounds(tournamentKey, startingRoundKey);
        }
        

       

        


    }
}