using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TournamentApp.Model;
using TournamentApp.Repository;
using TournamentApp.Services.Dtos.Match;
using TournamentApp.Services.Dtos.PlayerDto;
using TournamentApp.Services.Dtos.RoundsDto;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.Services.Code
{
    public class RoundMatchService : IRoundMatchService
    {
        private readonly IRoundRepository _roundRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public RoundMatchService(IRoundRepository roundRepository, IMatchRepository matchRepository, IMapper mapper)
        {
            _roundRepository = roundRepository;
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<List<MatchDtoBase>> GetMatches(string roundKey)
        {
            var matchKeys = (await _roundRepository.GetMatchKeys(roundKey)).ToList().Select(x => x).ToList();
            var matches = new List<MatchDtoBase>();
            foreach (var key in matchKeys)
            {
                var matchAsEntity  = (await _matchRepository.GetAsync(key)).First();
                var matchAsDto = _mapper.Map<Match, MatchDtoBase>(matchAsEntity);
                matches.Add(matchAsDto);
            }

            return matches;
            
        }
        
        public async Task MakeMatches(List<List<string>> playerCombos, RoundDtoBase roundDtoBase)
        {
            
            Console.WriteLine("make these matches");
            List<Match> matches = new List<Match>();
            foreach (var combo in playerCombos)
            {
                var match = await _matchRepository.AddAsync(new Match
                {
                    Player1 = new Player()
                    {
                        Name = combo[0]
                    },
                    Player2 = new Player()
                    {
                    Name = combo[1]
                    },
                    ScorePlayer1 = 0,
                    ScorePlayer2 = 0,
                    IsMatchPlayed = false
                });
                
                matches.Add(match.First());
            }
            await SetMatchKeys(roundDtoBase.Key, roundDtoBase, matches.Count);
            

        }

        public Dictionary<string, int> CountPlayerWinAtEndOfMatch(IEnumerable<FinishRoundDto> finishRoundDtos)
        {
            var playerWins = new Dictionary<string, int>();
            foreach (var finishRoundDto in finishRoundDtos)
            {
                if (finishRoundDto.ScorePlayer1 > finishRoundDto.ScorePlayer2)
                {
                    finishRoundDto.Player1Won = true;
                    UpdateMatchScores(playerWins, finishRoundDto.Player1.Key);
                }
                else
                {
                    UpdateMatchScores(playerWins, finishRoundDto.Player2.Key);
                }
            }

            return playerWins;
        }

        public List<List<Player>> GetWinnerAndLoserMatches(Dictionary<string, int> pLayerWinsDic)
        {
            int count = pLayerWinsDic.Count;
            //Math.Round()
            return null;
        }

        private void UpdateMatchScores(Dictionary<string, int> playerWinsDic, string playerWonKey)
        {
            int val;
            if (playerWinsDic.TryGetValue(playerWonKey, out val))
            {
                // yay, value exists!
                playerWinsDic[playerWonKey] = val + 1;
            }
            else
            {
                // darn, lets add the value
                playerWinsDic.Add(playerWonKey, 1);
            }
        }
        
        private async Task SetMatchKeys(string roundKey, RoundDtoBase addedRound, int matchesCount)
        {
            List<string> matchKeys = new List<string>();
            var matches = (await _matchRepository.GetAll()).ToList().TakeLast(matchesCount);
            foreach (var match in matches)
            {
                matchKeys.Add(match.Key);
            }

            addedRound.MatchKeys = matchKeys;
            var mappedRoundDto = _mapper.Map<Round>(addedRound);
            await _roundRepository.UpdateAsync(roundKey, mappedRoundDto);
        }

    }
}