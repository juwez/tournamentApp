using LiteDB;
using Newtonsoft.Json;
using TournamentApp.Model;

namespace TournamentApp.Services.Dtos.Match
{
    public class MatchDtoBase : DtoBase
    {
        [JsonIgnore]
        public Player Player1 { get; set; }
        
        public string Player1Key { get; set; }
        public int ScorePlayer1 { get; set; }

        [JsonIgnore]
        public Player Player2 { get; set; }

        public string Player2Key { get; set; }
        public int ScorePlayer2 { get; set; }
        
        public bool IsMatchPlayed { get; set; }
    }
}