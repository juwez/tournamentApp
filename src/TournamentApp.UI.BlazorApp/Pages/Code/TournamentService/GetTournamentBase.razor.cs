using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;
using TournamentApp.UI.BlazorApp.ViewModels.TournamentRound;

namespace TournamentApp.UI.BlazorApp.Pages.Code.TournamentService
{
    public class GetTournamentBase : ComponentBase
    {
        [Parameter]
        public string Key { get; set; }

        [Inject]
        protected IApiTournamentService TService { get; set; }
        
        [Inject]
        protected IApiTournamentRoundService TournamentRoundService { get; set; }
        

        public GetTournamentViewModel TournamentViewModel { get; set; }

        public List<GetMainRoundsViewModel> Rounds { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TournamentViewModel = await TService.GetTournament(Key);
            Rounds = await GetMainRounds();
        }
        
        private async Task<List<GetMainRoundsViewModel>> GetMainRounds()
        {
            var allRounds = await TournamentRoundService.GetAllRoundsForATournamentAsync(Key);
            var result = allRounds.Where(al => al.parentNodePreviousRoundKey == null);
            return new List<GetMainRoundsViewModel>(result);
        }
    }
}
