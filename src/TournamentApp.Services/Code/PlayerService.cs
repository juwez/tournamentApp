﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TournamentApp.Model;
using TournamentApp.Repository;
 using TournamentApp.Services.Dtos.Match;
 using TournamentApp.Services.Dtos.PlayerDto;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.Services.Code
{
    public class PlayerService : CrudService<PlayerDtoBase, Player>, IPlayerService
    {
        public PlayerService(IPlayerRepository repository, IMapper mapper) : base(repository, mapper)
        {
            
        }
        

        public async Task<List<List<string>>> SetPlayerMatchesCombination(List<string> players)
        {
            List<List<string>> playerCombination = new List<List<string>>();
            
            for (var i = 0; i < players.Count; i++)
            { 
                //var currentPlayer = players[i].Player1;
                for (var j = 0; j < players.Count; j++)
                {
                    if (players[j] != players[i])
                    {
                        playerCombination.Add( new List<string>
                        {
                            players[i], players[j]
                        });
                        
                    }
                    
                }
            }
            await RemoveDuplicateValues(playerCombination);
            
            return playerCombination;
        }

        private async Task RemoveDuplicateValues(ICollection<List<string>> playerCombination)
        {
            foreach (var listofplayers in playerCombination.ToList())
            {
                string player1Key = listofplayers.First();
                string player2Key= listofplayers.Skip(1).First();
                
                foreach (var combos in playerCombination.ToList())
                {
                    if (combos.First() == player2Key && combos.Skip(1).First() == player1Key)
                    {
                        playerCombination.Remove(listofplayers);
                    }
                }
            }
        }
    }
}