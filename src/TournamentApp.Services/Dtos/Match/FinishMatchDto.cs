namespace TournamentApp.Services.Dtos.Match
{
    public class FinishMatchDto : DtoBase
    {
        public int ScorePlayer1 { get; set; }
        
        public int ScorePlayer2 { get; set; }

        public bool IsMatchPlayed { get; set; }
        
    }
}