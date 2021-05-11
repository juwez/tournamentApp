using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentApp.UI.BlazorApp.ViewModels.RoundMatchViewModel;
using TournamentApp.UI.BlazorApp.ViewModels.Rounds;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;
using TournamentApp.UI.BlazorApp.ViewModels.TournamentRound;

namespace TournamentApp.UI.BlazorApp.ApiService.Interfaces
{
    public interface IApiRoundService
    {
        Task<BaseRoundViewModel> GetRound(string key);
        Task<List<BaseRoundMatchesViewModel>> GetMatchesForARound(string key);
        Task<bool> FinishRound(string key, List<BaseRoundMatchesViewModel> matchesViewModels);
    }
}