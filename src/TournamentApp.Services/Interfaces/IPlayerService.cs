using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.Match;
using TournamentApp.Services.Dtos.PlayerDto;

namespace TournamentApp.Services.Interfaces
{
    public interface IPlayerService : ICrudService<PlayerDtoBase>
    {
        public Task<List<List<string>>> SetPlayerMatchesCombination(List<string> players);
    }
}