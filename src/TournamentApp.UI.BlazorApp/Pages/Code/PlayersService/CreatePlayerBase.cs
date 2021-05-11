using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Players;

namespace TournamentApp.UI.BlazorApp.Pages.Code.PlayersService
{
    public class CreatePlayerBase : ComponentBase
    {
        [Inject] public IApiPlayerService Service { get; set; }
        
        [Inject] public NavigationManager MyNavigationManager {get; set;}
        
        public string StatusMessage { get; set; }

        public BasePlayerViewModel PlayerViewModel { get; set; } = new BasePlayerViewModel();

        protected async void InsertPerson()
        {
            var result = await Service.AddPlayer(PlayerViewModel);
            if (result)
            {
                MyNavigationManager.NavigateTo("/");
            }
            
            

        }


    }
}