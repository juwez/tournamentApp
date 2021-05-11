using System.ComponentModel.DataAnnotations;

namespace TournamentApp.UI.BlazorApp.ViewModels.Match
{
    public class BaseMatchViewModel : BaseViewModel
    {
        public int ScorePlayer1 { get; set; }
        public int ScorePlayer2 { get; set; }
    }
}