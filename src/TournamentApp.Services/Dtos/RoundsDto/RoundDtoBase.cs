using System.Collections.Generic;
using Newtonsoft.Json;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.Match;

namespace TournamentApp.Services.Dtos.RoundsDto
{
    public class RoundDtoBase : DtoBase
    {
        [JsonIgnore]
        public RoundDtoBase ParentNodePreviousRound { get; set; } // ref
        public string ParentNodePreviousRoundKey { get; set; }

        [JsonIgnore]
        public RoundDtoBase WinnerNode { get; set; }// ref
        public string WinnerNodeKey { get; set; }

        [JsonIgnore]
        public RoundDtoBase LoserNode { get; set; } // ref
        public string LoserNodeKey { get; set; }

        public RoundDtoBase NodeSubRound { get; set; } // Embedded
        public string RoundName { get; set; }
        
        [JsonIgnore]
        public Model.Tournament Tournament { get; set; } // ref
        public string TournamentKey { get; set; }

        [JsonIgnore]
        public List<Model.Match> Matches { get; set; } // Ref
        public List<string> MatchKeys { get; set; }
    }
}