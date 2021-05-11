using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;

namespace TournamentApp.UI.BlazorApp.Pages.Code
{
    public class FetchDataBase : ComponentBase
    {
        [Inject]
        protected IApiTournamentService TService { get; set; }

        public BaseTournamentViewModel ViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ViewModel = await TService.GetTournament("-MAutTJ3KfqprXEb-mh8");
        }
    }
}
