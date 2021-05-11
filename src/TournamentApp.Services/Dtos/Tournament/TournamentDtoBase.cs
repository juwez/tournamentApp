using System;
using System.Text.Json;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.Services.Dtos.Tournament
{
    public class TournamentDtoBase : DtoBase
    {
        public string TournamentName { get; set; }
        public DateTime Date { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}