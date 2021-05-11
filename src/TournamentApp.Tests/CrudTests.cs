using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApp.Model;
using TournamentApp.Repository;
using TournamentApp.Services.Dtos.Tournament;
using Xunit;

namespace TournamentApp.Tests
{
    public class CrudTests
    {
        [Fact]
        public async void TestGet()
        {
            var trepo = new TournamentRepository("https://tournamentapp-a5523.firebaseio.com/");
            string tournamentKey = (await trepo.GetAll()).ToList().First().Key;
            var tournamentFromApi = await trepo.GetAsync(tournamentKey);
            var tournamentFromApiKey = tournamentFromApi.First().Key;
            Assert.Equal(tournamentKey, tournamentFromApiKey);
            
            string invalidKey = "ThisisainvalidKey";
            Assert.Null(await trepo.GetAsync(invalidKey));
        }
        
        [Fact]
        public async void TestGetAll()
        {
            var trepo = new TournamentRepository("https://tournamentapp-a5523.firebaseio.com/");
            var tournaments = (await trepo.GetAll()).ToList();
            if (tournaments.Count == 0) { Assert.Empty(tournaments); }
            else Assert.NotEmpty(tournaments);
            Assert.IsType<List<Tournament>>(tournaments);
        }
        
        [Fact]
        public async void TestAdd()
        {
            var trepo = new TournamentRepository("https://tournamentapp-a5523.firebaseio.com/");
            var currentCountTournaments = (await trepo.GetAll()).ToList().Count;
            await MakeTournament(trepo);
            var tournaments = (await trepo.GetAll()).ToList();
            Assert.Equal(currentCountTournaments +1, tournaments.Count);
        }
        
        [Fact]
        public async void TestDelete()
        {
            var trepo = new TournamentRepository("https://tournamentapp-a5523.firebaseio.com/");
            var currentTournaments = (await trepo.GetAll()).ToList();
            
            await trepo.DeleteAsync(currentTournaments.First().Key);
            
            var tournamentsCount = (await trepo.GetAll()).ToList().Count;
            Assert.Equal(currentTournaments.Count -1, tournamentsCount);
        }
        
        [Fact]
        public async void TestEdit()
        {
            var trepo = new TournamentRepository("https://tournamentapp-a5523.firebaseio.com/");
            var currentTournaments = (await trepo.GetAll()).ToList();
            if (currentTournaments.Count == 0)
            {
                await MakeTournament(trepo);
                TestEdit();
            }
            var lastTournament = (await trepo.GetAll()).ToList().Last();

            await trepo.EditProperty(lastTournament.Key, "TournamentName", "TournamentName");
            
            var updatedTournament = await trepo.GetAsync(currentTournaments.Last().Key);
            Assert.Equal("TournamentName", updatedTournament.Last().TournamentName);
            
        }
        
        [Fact]
        public async void TestUpdate()
        {
            var trepo = new TournamentRepository("https://tournamentapp-a5523.firebaseio.com/");
            var currentTournaments = (await trepo.GetAll()).ToList();
            await trepo.UpdateAsync(currentTournaments.First().Key, new Tournament
            {
                TournamentName = "DitIsEenUpdate",
                Rounds = null,
                Date = DateTime.Now
            });
            var afterUpdateTournaments = (await trepo.GetAll()).ToList();
            Assert.Equal(currentTournaments.Count, afterUpdateTournaments.Count);
            Assert.Equal("DitIsEenUpdate", afterUpdateTournaments.First().TournamentName);
            Assert.Null(afterUpdateTournaments.First().Rounds);
        }

        private async Task<Tournament> MakeTournament(TournamentRepository trepo)
        {
            var tournament =  await trepo.AddAsync(new Tournament
            {
                Date = DateTime.Now,
                TournamentName = "boe"
            });

            return tournament.First();
        }
        
        
    }
}