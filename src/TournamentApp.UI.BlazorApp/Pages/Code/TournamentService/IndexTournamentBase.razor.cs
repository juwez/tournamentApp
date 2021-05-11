using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;

namespace TournamentApp.UI.BlazorApp.Pages.Code.TournamentService
{
    public class IndexTournamentBase : ComponentBase
    {
        [Inject] private IApiTournamentService TService { get; set; }

        protected List<GetAllTournamentViewModel> Tournaments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Tournaments = await TService.GetTournaments();
        }

        protected async void DeleteTournament(string key)
        {
            await TService.DeleteTournament(key);
        }

    }
}
