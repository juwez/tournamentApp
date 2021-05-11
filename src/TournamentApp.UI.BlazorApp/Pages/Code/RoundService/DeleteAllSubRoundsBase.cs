using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Rounds;
using TournamentApp.UI.BlazorApp.ViewModels.TournamentRound;

namespace TournamentApp.UI.BlazorApp.Pages.Code.RoundService
{
    public class DeleteAllSubRoundsBase : ComponentBase
    {
        [Inject] public IApiTournamentRoundService Service{ get; set; }
        
        [Inject] public IApiRoundService RoundService { get; set; }
        
        [Inject] public NavigationManager MyNavigationManager { get; set; }
        
        [Parameter] public string Roundkey { get; set; }
        
        [Parameter] public string TournamentKey { get; set; }

        public BaseRoundViewModel Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Model = await RoundService.GetRound(Roundkey);
        }
        
        protected async void DeleteSubRounds(string touramentkey, string roundkey)
        {
            var res = await Service.RemoveAllRoundsIncludingSubRounds(touramentkey, roundkey);
            if (res)
            {
                MyNavigationManager.NavigateTo("/");
            }
        }
    }
}