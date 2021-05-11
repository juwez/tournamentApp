using System.Threading.Tasks;
using TournamentApp.UI.BlazorApp.ViewModels.Match;
using TournamentApp.UI.BlazorApp.ViewModels.RoundMatchViewModel;

namespace TournamentApp.UI.BlazorApp.ApiService.Interfaces
{
    public interface IApiMatchService
    {
        Task<BaseRoundMatchesViewModel> GetMatchById(string matchKey);
        Task<BaseMatchViewModel> SendScoreToApi(string matchKey, BaseMatchViewModel model);
        Task<FinishMatchViewModel> FinishMatch(string matchkey, FinishMatchViewModel model);
    }
}