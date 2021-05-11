using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;

namespace TournamentApp.UI.BlazorApp.Pages.Code.TournamentService
{
    public class DeleteTournamentBase : ComponentBase
    {
        [Parameter] public string Key { get; set; }
        
        [Inject] private IApiTournamentService TService { get; set; }
        
        [Inject] public NavigationManager NavigationManager { get; set; }
        protected GetTournamentViewModel TournamentViewModel { get; set; }


        protected override async Task OnInitializedAsync()
        {
            TournamentViewModel = await TService.GetTournament(Key);
        }

        protected async void DeleteTournament(string key)
        {
            await TService.DeleteTournament(key);
            NavigationManager.NavigateTo("/tournaments");

        }

    }
}
