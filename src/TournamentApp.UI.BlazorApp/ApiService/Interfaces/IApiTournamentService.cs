using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;
using TournamentApp.UI.BlazorApp.ViewModels.TournamentRound;

namespace TournamentApp.UI.BlazorApp.ApiService.Interfaces
{
    public interface IApiTournamentService
    {
        Task<GetTournamentViewModel> GetTournament(string key);
        Task<List<GetAllTournamentViewModel>> GetTournaments();
        Task DeleteTournament(string key);
        Task<BaseTournamentViewModel> UpdateTournament(string key);
        Task<bool> CreateTournament(CreateTournamentViewModel model);
    }
}
