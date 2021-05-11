using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TournamentApp.Model;
using TournamentApp.Repository;
using TournamentApp.Services.Dtos.Match;
using TournamentApp.Services.Dtos.PlayerDto;
using TournamentApp.Services.Dtos.RoundsDto;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.Services.Code
{
    public class MatchService : CrudService<MatchDtoBase, Match>, IMatchService
    {
        private readonly IRoundRepository _roundRepository;
        public MatchService(IMatchRepository repository, IMapper mapper, IRoundRepository roundRepository) : base(repository, mapper)
        {
            _roundRepository = roundRepository;
        }
        
        public async Task<MatchDtoBase> EditScore(string key,int scorePlayer1, int scorePlayer2)
        {
            var entity = await GetAsync(key);
            if (entity == null) { return null; }
            SetPlayerScore(entity,scorePlayer1, scorePlayer2);
            return await ReturnUpdatedEntity(key, entity);
        }
        public async Task<MatchDtoBase> FinishMatch(string key, int scorePlayer1, int scorePlayer2)
        {
            var entity = await GetAsync(key);
            if (entity == null) { return null; }
            entity.IsMatchPlayed = true;
            SetPlayerScore(entity,scorePlayer1, scorePlayer2);
            return await ReturnUpdatedEntity(key, entity);
        }
        
        private async Task<MatchDtoBase> ReturnUpdatedEntity(string key, MatchDtoBase entity)
        {
            var mappedEntity = _mapper.Map<Match>(entity);
            await _repository.UpdateAsync(key,mappedEntity );
            return await GetAsync(key);
        }

        private void SetPlayerScore(MatchDtoBase entity,int scorePlayer1, int scorePlayer2)
        {
            entity.ScorePlayer1 = scorePlayer1;
            entity.ScorePlayer2 = scorePlayer2; 
        }
        
        
        
        
        
    }
}