using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kaos.Combinatorics;
using TournamentApp.Model;
using TournamentApp.Repository;
using TournamentApp.Services.Code;
using TournamentApp.Services.Dtos.Match;
using TournamentApp.Services.Dtos.RoundsDto;
using TournamentApp.Services.Dtos.Tournament;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.UI.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = Task.Run(() => MainAsync(args));
            l.Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var url = "https://tournamentapp-a5523.firebaseio.com/";
            //Repositories
            ITournamentRepository tournamentRepository = new TournamentRepository(url);
            ITournamentRoundRepository tournamenRoundRepository = new TournamentRoundRepository(url);
            IRoundRepository roundRepository = new RoundRepository(url);
            IMatchRepository matchRepository = new MatchRepository(url);
            IPlayerRepository playerRepository = new PlayerRepository(url);

            //Services
            var matchConfig = new MapperConfiguration(cfg => cfg.CreateMap<Match, MatchDtoBase>()).CreateMapper();
            var matchService = new MatchService(matchRepository, matchConfig, roundRepository);
            
            var roundConfig = new MapperConfiguration(cfg => cfg.CreateMap<Round, RoundDtoBase>()).CreateMapper();
            var roundService = new RoundService(roundRepository, roundConfig);
            
            var tournamentRoundConfig = new MapperConfiguration(cfg => cfg.CreateMap<Round, RoundDtoBase>()).CreateMapper();
            var tournamentRoundService = new TournamentRoundService(tournamenRoundRepository, tournamentRoundConfig,
                matchRepository, roundRepository);
            
            var tournamentConfig = new MapperConfiguration(cfg => cfg.CreateMap<Tournament, TournamentDtoBase>()).CreateMapper();
            var tournamentService =  new TournamentService(tournamentRepository, tournamentConfig);

            /*await playerRepository.AddAsync(new Player()
            {
                Name = "Joey"
            });*/
            /*Console.WriteLine();#1#
            //var t = await trepo.GetAsync("-MAupoZh9YVbCgKOnkHK");
            //Console.WriteLine(t);

            //Console.WriteLine("AFTER");


            //a = (await trepo.GetAll()).ToList();

            //foreach (var q in a)
            //{
            //    Console.WriteLine(q);
            //    Console.WriteLine();
            //}*/
            
           
            
            /*
            var players = new List<Player>{ new Player
            {
                Key = "-MFX8QR5gTrIunl5gvbz",
                Name = "Thijs"
            }, new Player
            {
                Key   = "-MFX8ULHvKC8uL1QDfWX",
                Name = "Nico"
            },new Player
            {
              Key  = "-MFX8XsGCcPV81W5WldS",
              Name = "Jasper"
            }};
            
            
            
            var combination1 = new Combination(1, 2);
            foreach (var rowsForAllPick in combination1.GetRowsForAllPicks())
            {
                Console.WriteLine(rowsForAllPick);
            }*/
            
            /*Console.WriteLine(combination1.Picks);
            Console.WriteLine(combination1.Choices);

            Console.WriteLine(combination1[0]);*/
            /*await matchRepository.AddAsync(new Match
            {
                Player1Key = players.First().Key,
                Player2Key = players.Skip(1).First().Key,
                ScorePlayer1 = 0,
                ScorePlayer2 = 0,
                IsMatchPlayed = false,
            });*/
            
            
            /*players.AddRange(players);*/
            
            
            //var permutations = new Permutations<Player>(players);
            /*Console.WriteLine("Permutation");
            Console.WriteLine();

            foreach(IList<Player> p in permutations) {
                //Console.WriteLine($"{{{p[0]} {p[1]} {p[2]}}}");
            }*/
            
            
            
            //var integers = new List<int> {1, 2, 3, 4, 5, 6};

            
            /*foreach (var v in c)
            {
              
                
                foreach (var player in v)
                {
                    if (counter % 2 == 0)
                    {
                        Console.WriteLine("-------");
                    }
                    
                    Console.WriteLine(player.Name);
                    counter++;
                }
            }*/
            /*Console.WriteLine("Combinations");
            Console.WriteLine();
            Console.WriteLine(c.Count);*/

           /*combinations.ForEach(x =>
            {
                foreach (var player in x)
                {
                    if (counter % 2 == 0)
                    {
                        Console.WriteLine("-------");
                    }
                    
                    Console.WriteLine(player.Name);
                    counter++;

                }
            });*/

            /*Console.WriteLine(combinations.Count);*/
            

            /*await playerRepository.AddAsync(new Player
            {
                Name = "Pol"
            });
            */

            
            //var goodRes = res.SelectMany(x => x).ToList();
            /*for (int i = 0; i < 10 ; i++)
            {
                Console.WriteLine(res);
            }*/


            /*foreach (var enumerable in goodRes)
            {
                Console.WriteLine(enumerable.Name);
            }*/


            await roundRepository.AddAsync(new Round()
            {
                TournamentKey = "-MGnKuMU58-huxwphAql",
                RoundName = "R2",
                ParentNodePreviousRoundKey = "-MGnKucm8bKWjjXfEB5c"
            });
            





        }

        
        
    }
}
