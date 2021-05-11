using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;
using TournamentApp.UI.BlazorApp.ViewModels.TournamentRound;

namespace TournamentApp.UI.BlazorApp.ApiService.Interfaces
{
    public interface IApiTournamentRoundService
    {
        Task<List<GetMainRoundsViewModel>> GetAllRoundsForATournamentAsync(string tournamentkey);
        Task<List<GetMainRoundsViewModel>> GetAllRoundsIncludingSubRoundsAsync(string tournamentkey,
            string startingRoundKey);
        
        Task<bool> RemoveAllRoundsIncludingSubRounds(string tournamentkey,
            string startingRoundKey);
    }
}