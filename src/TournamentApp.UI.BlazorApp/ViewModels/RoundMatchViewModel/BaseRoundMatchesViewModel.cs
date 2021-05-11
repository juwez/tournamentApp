using Newtonsoft.Json;
using TournamentApp.Model;
using TournamentApp.UI.BlazorApp.ViewModels.Players;

namespace TournamentApp.UI.BlazorApp.ViewModels.RoundMatchViewModel
{
    public class BaseRoundMatchesViewModel : BaseViewModel
    {
        [JsonIgnore]
        public BasePlayerViewModel Player1 { get; set; }
        
        public string Player1Key { get; set; }
        public int ScorePlayer1 { get; set; }

        [JsonIgnore]
        public BasePlayerViewModel Player2 { get; set; }

        public string Player2Key { get; set; }
        public int ScorePlayer2 { get; set; }
        
        public bool IsMatchPlayed { get; set; }
    }
}