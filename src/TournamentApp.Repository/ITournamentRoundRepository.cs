using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public interface ITournamentRoundRepository : ICrudRepository<Round>
    {
        Task<IQueryable<Round>> GetAllRoundsForATournamentAsync(string tournamentKey);
        Task<IQueryable<Round>> GetAllRoundsIncludingSubRoundsAsync(string tournamentKey, string startingRoundKey, List<Round> rounds = null);

        Task RemoveAllRoundsIncludingSubRounds(string tournamentKey, string startingRoundKey);
    }
}