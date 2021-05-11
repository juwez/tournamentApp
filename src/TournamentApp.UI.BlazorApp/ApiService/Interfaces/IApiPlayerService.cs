using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentApp.UI.BlazorApp.ViewModels.Players;

namespace TournamentApp.UI.BlazorApp.ApiService.Interfaces
{
    public interface IApiPlayerService
    {
        Task<List<BasePlayerViewModel>> GetAllPlayers();
        Task<bool> AddPlayer(BasePlayerViewModel viewModel);

        Task<bool> DeletePlayer(string key);

        Task<BasePlayerViewModel> GetPlayer(string key);
    }
}