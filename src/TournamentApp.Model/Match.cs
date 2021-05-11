using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TournamentApp.Model
{
    public class Match : EntityBase
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

        public bool Player1Won()
        {
            return ScorePlayer1 > ScorePlayer2;
        }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}