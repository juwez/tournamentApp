using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.RoundsDto;

namespace TournamentApp.Services.Interfaces
{
    public interface ITournamentRoundService : ICrudService<RoundDtoBase>
    {
        Task<List<RoundDtoBase>> GetAllRoundsForATournamentAsync(string tournamentKey);
        Task<List<RoundDtoBase>> GetAllRoundsIncludingSubRoundsAsync(string tournamentkey, string startingRoundKey);
        Task RemoveAllRoundsIncludingSubRounds(string tournamentKey, string startingRoundKey);
    }
}