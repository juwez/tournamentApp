using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Players;

namespace TournamentApp.UI.BlazorApp.Pages.Code.PlayersService
{
    public class IndexPlayersBase : ComponentBase
    {
        [Inject] public  IApiPlayerService Service { get; set; }

        public List<BasePlayerViewModel> PlayerList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PlayerList = await Service.GetAllPlayers();
        }
    }
}