using System.Collections.Generic;
using System.Text.Json;
using TournamentApp.Model;

namespace TournamentApp.Services.Dtos.Tournament
{
    public class GetTournamentDto : TournamentDtoBase
    {
        public List<Round> Rounds { get; set; } // ref
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}