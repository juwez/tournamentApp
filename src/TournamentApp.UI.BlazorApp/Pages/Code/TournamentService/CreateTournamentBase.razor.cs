using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Players;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;

namespace TournamentApp.UI.BlazorApp.Pages.Code.TournamentService
{
    public class CreateTournamentBase: ComponentBase
    {
        [Inject] private IApiTournamentService  ApiTournamentService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IApiPlayerService PlayerService { get; set; }
        

        public List<BasePlayerViewModel> currentPlayers { get; set; } = new List<BasePlayerViewModel>();

        public string Chosenperson { get; set; }
        
        
        public  CreateTournamentViewModel TournamentViewModel { get; set; } = new CreateTournamentViewModel();
        public List<BasePlayerViewModel> Players { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Players = await PlayerService.GetAllPlayers();
            Console.WriteLine(Players);
        }

        protected async void CreateTournament()
        {
            TournamentViewModel.Players = currentPlayers;
            var result = await ApiTournamentService.CreateTournament(TournamentViewModel);
            if (result)
            {
                NavigationManager.NavigateTo("/");
            }

        }

        protected async void OnPersonSelected(ChangeEventArgs e)
        {
            if (e.Value.ToString()=="empty")
            {
                return;
            }
            Console.WriteLine(e);
            var key = e.Value.ToString();
            var selectedPlayer = await PlayerService.GetPlayer(key);
            currentPlayers.Add(selectedPlayer);
            var remainingPlayers = Players.Where(x => x.Key != key).ToList();
            Players = remainingPlayers;
            StateHasChanged();
        }

        protected void DeletePlayerFromCurrentPlayers(string key)
        {
            var player = currentPlayers.First(x => x.Key == key);
            currentPlayers.Remove(player);
            Players.Add(player);
            StateHasChanged();
        }


    }
}