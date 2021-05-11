using Newtonsoft.Json;
using TournamentApp.Model;
using TournamentApp.UI.BlazorApp.ViewModels.Players;

namespace TournamentApp.UI.BlazorApp.ViewModels.Match
{
    public class UpdateScoreViewModel : BaseMatchViewModel
    {
        public string Player1Key { get; set; }
        public string Player2Key { get; set; }

        /*public bool IsMatchPlayed { get; set; }*/
    }
}