using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.Model;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Players;
using TournamentApp.UI.BlazorApp.ViewModels.RoundMatchViewModel;
using TournamentApp.UI.BlazorApp.ViewModels.Rounds;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;
using TournamentApp.UI.BlazorApp.ViewModels.TournamentRound;

namespace TournamentApp.UI.BlazorApp.Pages.Code.RoundService
{
    public class RoundMatchesIndexGetRoundBase : ComponentBase
    {
        #region Parameters

        [Parameter] public string Tournamentkey { get; set; }
        [Parameter] public string RoundKey { get; set; }

        #endregion
        
        #region DI

        [Inject] private IApiRoundService RoundService { get; set; }
        [Inject] private IApiTournamentService TournamentService { get; set; }
        [Inject] private IApiTournamentRoundService TournamentRoundService { get; set; }
        
        [Inject] private IApiPlayerService PlayerService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        #endregion

        #region VmNotExposedToView

        private GetTournamentViewModel TournamentViewModel { get; set; }

        #endregion

        #region VmExposedToView

        protected BaseTournamentRoundViewModel TournamentRoundViewModel { get; set; }

        protected List<GetMainRoundsViewModel> SubRounds { get; set; }

        protected List<BaseRoundMatchesViewModel> Matches { get; set; }

        #endregion

        #region Etc

        public bool IsEveryMatchPlayed { get; set; } = false;

        #endregion
       
        protected override  async Task OnInitializedAsync()
        {
            SubRounds = await GetSubRounds();
            TournamentViewModel = await TournamentService.GetTournament(Tournamentkey);
            TournamentRoundViewModel = await MakeTournamentRoundViewModel();
            Matches = await RoundService.GetMatchesForARound(RoundKey);
            CheckIfEveryMatchIsPlayed();
        }

        #region HelpersFunctions

        private async Task<List<GetMainRoundsViewModel>> GetSubRounds()
        {
            return (await TournamentRoundService.GetAllRoundsIncludingSubRoundsAsync(Tournamentkey, RoundKey)).Skip(1).ToList();
        }

        private async Task<BaseRoundViewModel> GetRound()
        {
            return await RoundService.GetRound(RoundKey);
        }

        private async Task<BaseTournamentRoundViewModel> MakeTournamentRoundViewModel()
        {
            return TournamentRoundViewModel = new BaseTournamentRoundViewModel
            {
                RoundKey = RoundKey,
                RoundName = (await GetRound()).RoundName,
                TournamentKey = Tournamentkey,
                TournamentName = TournamentViewModel.TournamentName
            };
        }

        protected void ReloadPageWithNewData(string roundkey)
        {
            NavigationManager.NavigateTo($"tournaments/{Tournamentkey}/rounds/{roundkey}", true);
        }

        #endregion

        protected bool CheckIfEveryMatchIsPlayed()
        {
            if (Matches.Any(match => !match.IsMatchPlayed))
            {
                IsEveryMatchPlayed = false;
                return false;
            }

            IsEveryMatchPlayed = true;
            return true;
        }

        protected async void FinishRound()
        {
           var matches =  await RoundService.FinishRound(RoundKey,Matches);
           if (matches != null)
           {
               //Todo change url to the main rounds
           }
        }
        
    }
}