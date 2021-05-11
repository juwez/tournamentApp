using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;
using TournamentApp.UI.BlazorApp.ViewModels.TournamentRound;

namespace TournamentApp.UI.BlazorApp.Pages.Code.RoundService
{
    public class GetAllSubRoundsBase : ComponentBase
    {
        [Parameter]
        public string Roundkey { get; set; }
        
        [Parameter] public string TournamentKey { get; set; }

        [Inject]
        public IApiTournamentRoundService TournamentRoundService { get; set; }
        [Inject] public IApiTournamentService ApiTournamentService { get; set; }

        public BaseTournamentRoundViewModel MainRound { get; set; }

        public GetTournamentViewModel TournamentViewModel { get; set; }

        public List<GetMainRoundsViewModel> Subrounds { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var result =  (await TournamentRoundService.GetAllRoundsIncludingSubRoundsAsync(TournamentKey, Roundkey));
            MainRound = result.First();
            Subrounds = result.Skip(1).ToList();
            TournamentViewModel = await ApiTournamentService.GetTournament(TournamentKey);
        }
    }
}