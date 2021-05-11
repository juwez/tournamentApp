using System;
using System.Collections.Generic;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.Match;
using TournamentApp.Services.Dtos.PlayerDto;

namespace TournamentApp.Services.Dtos.Tournament
{
    public class CreateTournamentDto
    {
        public List<string> Players { get; set; }
        public string TournamentName { get; set; }

        public DateTime TournamentDate { get; set; }
    }
}