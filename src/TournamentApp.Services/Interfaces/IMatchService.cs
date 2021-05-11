using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentApp.Services.Dtos.Match;
using TournamentApp.Services.Dtos.PlayerDto;

namespace TournamentApp.Services.Interfaces
{
    public interface IMatchService: ICrudService<MatchDtoBase>
    {
        public Task<MatchDtoBase> EditScore(string key, int scorePlayer1, int scorePlayer2);
        public Task<MatchDtoBase> FinishMatch(string key, int scorePlayer1, int scorePlayer2);

        //public Task<List<MatchDtoBase>> MakeMatches(List<List<PlayerDtoBase>> playerCombos);
    }
}