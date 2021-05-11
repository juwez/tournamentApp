using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.Model;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Match;
using TournamentApp.UI.BlazorApp.ViewModels.Players;
using TournamentApp.UI.BlazorApp.ViewModels.RoundMatchViewModel;

namespace TournamentApp.UI.BlazorApp.Pages.Code.MatchService
{
    public class GetMatchBase : ComponentBase
    {
        #region Params

        [Parameter] public string TournamentKey { get; set; }
        [Parameter] public string RoundKey { get; set; }
        [Parameter] public string MatchKey { get; set; }

        #endregion

        #region Di
        [Inject] public IApiMatchService MatchService { get; set; }
        
        [Inject] public IApiPlayerService PlayerService { get; set; }
        
        [Inject] public NavigationManager NavigationManager { get; set; }
        

        #endregion

        #region ViewModels

        public BaseRoundMatchesViewModel PlayerMatchViewModel { get; set; }

        public BaseMatchViewModel MatchViewModel { get; set; }

        #endregion

        #region StateHandlers

        public bool ClickedSendScoreButton { get; set; } = false;

        public string TextInPopup { get; set; }

        #endregion


        protected override async Task OnInitializedAsync()
        {
           
            PlayerMatchViewModel = await MatchService.GetMatchById(MatchKey);
            InitMatchViewModel();
            await SetPlayers();

        }


        #region FunctionsExposedToView

        protected void UpdateScore(string player, string upOrDownScore)
        {
            
            switch (upOrDownScore.ToLower())
            {
                case "up" when player.ToLower() == "player1":
                    MatchViewModel.ScorePlayer1 += 1;
                    break;
                case "up":
                    MatchViewModel.ScorePlayer2 += 1;
                    break;
                case "down" when player.ToLower() == "player1":
                    MatchViewModel.ScorePlayer1 -= 1;
                    break;
                case "down":
                    MatchViewModel.ScorePlayer2 -= 1;
                    break;
            }

            if (MatchViewModel.ScorePlayer1 >= 0 && MatchViewModel.ScorePlayer2 >= 0) return;
            MatchViewModel.ScorePlayer1 = 0;
            MatchViewModel.ScorePlayer2 = 0;
        }

        protected async Task SendScoreToApi()
        {
            await MatchService.SendScoreToApi(MatchKey, new BaseMatchViewModel
            {
                Key = MatchKey,
                ScorePlayer1 = MatchViewModel.ScorePlayer1,
                ScorePlayer2 = MatchViewModel.ScorePlayer2
            });
            
            TextInPopup = "De score is geupdated!";
            ClickedSendScoreButton = true;
            StateHasChanged();
            await Task.Delay(5000);
            ClickedSendScoreButton = false;
            StateHasChanged();
        }

        protected async Task FinishMatch()
        {
            TextInPopup = $"Bedankt voor het spelen van deze match! De score is {MatchViewModel.ScorePlayer1} - {MatchViewModel.ScorePlayer2} ";
            ClickedSendScoreButton = true;
            await MatchService.FinishMatch(MatchKey, new FinishMatchViewModel()
            {
                Key = MatchKey,
                ScorePlayer1 = MatchViewModel.ScorePlayer1,
                ScorePlayer2 = MatchViewModel.ScorePlayer2,
                IsMatchPlayed = true
            });
            NavigationManager.NavigateTo($"/tournaments/{TournamentKey}/rounds/{RoundKey}");
            
        }
        

        #endregion

        #region HelperFucntions

        private void InitMatchViewModel()
        {
            MatchViewModel = new BaseMatchViewModel
            {
                ScorePlayer1 = PlayerMatchViewModel.ScorePlayer1,
                ScorePlayer2 = PlayerMatchViewModel.ScorePlayer2
            };
        }
        private async Task SetPlayers()
        {
            var player1 = await PlayerService.GetPlayer(PlayerMatchViewModel.Player1Key);
            var player2 = await  PlayerService.GetPlayer(PlayerMatchViewModel.Player2Key);
            
            PlayerMatchViewModel.Player1 = new BasePlayerViewModel
            {
                Key = player1.Key,
                Name = player1.Name
            };
            PlayerMatchViewModel.Player2 = new BasePlayerViewModel
            {
                Key = player2.Key,
                Name = player2.Name
            };
        }

        #endregion



        

        
    }
}