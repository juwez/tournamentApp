using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Players;

namespace TournamentApp.UI.BlazorApp.Pages.Code.PlayersService
{
    public class DeletePlayerBase : ComponentBase
    {
        [Parameter] public string Key { get; set; }
        [Inject] public IApiPlayerService Service { get; set; }
        
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        public BasePlayerViewModel BasePlayerViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BasePlayerViewModel = await Service.GetPlayer(Key);
        }

        protected async void DeletePlayer(string key)
        {
            await Service.DeletePlayer(key);
            NavigationManager.NavigateTo("/players");
        }
        
        
    }
}