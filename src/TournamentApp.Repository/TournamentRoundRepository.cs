using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public class TournamentRoundRepository : CrudRepository<Round>, ITournamentRoundRepository
    {
        
        public TournamentRoundRepository(string fireBaseDataBaseUrl) : base(AggregateName.Round, fireBaseDataBaseUrl)
        {
            
        }

        public async Task<IQueryable<Round>> GetAllRoundsForATournamentAsync(string tournamentKey)
        {
            var rounds = new List<Round>();
            var entities = await GetAllRoundsEntities();

            foreach (var round in entities)
            {
                if (!string.Equals(round.Object.TournamentKey, tournamentKey)) continue;
                
                round.Object.Key = round.Key;
                rounds.Add(round.Object);
            }
            return rounds.AsQueryable();
        }

        public async Task<IQueryable<Round>> GetAllRoundsIncludingSubRoundsAsync(string tournamentKey,
            string startingRoundKey, List<Round> rounds = null)
        {
            rounds ??= new List<Round>();

            var rootRound = (await GetAsync(startingRoundKey)).First();
            rounds.Add(rootRound);

            var entities =
                (await GetAllRoundsForATournamentAsync(tournamentKey))
                .Where(round => round.ParentNodePreviousRoundKey == startingRoundKey)
                .ToList();

            entities.ForEach(round => 
            {
                round.Key = round.Key;
                GetAllRoundsIncludingSubRoundsAsync(tournamentKey, round.Key, rounds).Wait();
            });

            return rounds.AsQueryable();
        }

        public async Task RemoveAllRoundsIncludingSubRounds(string tournamentKey, string startingRoundKey)
        {
            var roundsToDelete = (await GetAllRoundsIncludingSubRoundsAsync(tournamentKey, startingRoundKey)).ToList();
            foreach (var round in roundsToDelete)
            {
                await DeleteAsync(round.Key);   
            }
        }

        private async Task<IReadOnlyCollection<FirebaseObject<Round>>> GetAllRoundsEntities()
        {
            var entities = await _firebaseClient
                .Child(_aggregate)
                .OnceAsync<Round>();
            return entities;
        }
    }
}