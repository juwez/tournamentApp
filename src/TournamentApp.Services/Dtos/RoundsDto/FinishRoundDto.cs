using System.Collections.Generic;
using Newtonsoft.Json;
using TournamentApp.Services.Dtos.PlayerDto;

namespace TournamentApp.Services.Dtos.RoundsDto
{
    public class FinishRoundDto : DtoBase
    {
        [JsonIgnore]
        public PlayerDtoBase Player1 { get; set; }
        public string Player1Key { get; set; }
        public int ScorePlayer1 { get; set; }

        [JsonIgnore]
        public PlayerDtoBase Player2 { get; set; }
        public string Player2Key { get; set; }
        public int ScorePlayer2 { get; set; }

        public bool Player1Won { get; set; }
    }
    
}