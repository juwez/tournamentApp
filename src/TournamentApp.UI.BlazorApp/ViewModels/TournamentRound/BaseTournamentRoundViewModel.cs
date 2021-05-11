using System;

namespace TournamentApp.UI.BlazorApp.ViewModels.TournamentRound
{
    public class BaseTournamentRoundViewModel : BaseViewModel
    {
        public string RoundKey { get; set; }
        public string RoundName { get; set; }
        public string TournamentKey { get; set; }

        public string TournamentName { get; set; }
        
    }
}