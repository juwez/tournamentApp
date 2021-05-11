using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TournamentApp.Model
{
    public class Round : EntityBase
    {
        [JsonIgnore]
        public Round ParentNodePreviousRound { get; set; } // ref
        public string ParentNodePreviousRoundKey { get; set; }

        [JsonIgnore]
        public Round WinnerNode { get; set; }// ref
        public string WinnerNodeKey { get; set; }

        [JsonIgnore]
        public Round LoserNode { get; set; } // ref
        public string LoserNodeKey { get; set; }

        public Round NodeSubRound { get; set; } // Embedded
        public string RoundName { get; set; }
        
        [JsonIgnore]
        public Tournament Tournament { get; set; } // ref
        public string TournamentKey { get; set; }
        

        [JsonIgnore]
        public List<Match> Matches { get; set; } // Ref
        public List<string> MatchKeys { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}