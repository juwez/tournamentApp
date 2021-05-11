using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.Match;
using TournamentApp.Services.Dtos.RoundsDto;

namespace TournamentApp.Services.Interfaces
{
    public interface IRoundMatchService
    {
        Task<List<MatchDtoBase>> GetMatches(string roundKey);
        public Task MakeMatches(List<List<string>> playerCombos, RoundDtoBase roundDtoBase);
        Dictionary<string, int> CountPlayerWinAtEndOfMatch(IEnumerable<FinishRoundDto> finishRoundDtos);

        List<List<Player>> GetWinnerAndLoserMatches(Dictionary<string, int> pLayerWinsDic);
    }
}