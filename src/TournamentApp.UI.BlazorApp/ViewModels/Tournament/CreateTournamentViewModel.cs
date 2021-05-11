using System.Collections.Generic;
using TournamentApp.UI.BlazorApp.ViewModels.Players;

namespace TournamentApp.UI.BlazorApp.ViewModels.Tournament
{
    public class CreateTournamentViewModel : BaseTournamentViewModel
    {
        public List<BasePlayerViewModel> Players { set; get; }
    }
}