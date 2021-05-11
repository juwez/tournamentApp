using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database.Query;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public class RoundRepository : CrudRepository<Round>, IRoundRepository
    {
        public RoundRepository(string fireBaseDataBaseUrl) : base(AggregateName.Round, fireBaseDataBaseUrl)
        {
            
        }

        public async Task<List<string>> GetMatchKeys(string roundKey)
        {
            var round = await GetAsync(roundKey);
            List<string> matchKeys = round.First().MatchKeys;
            if (matchKeys == null) { return null; }
            List<string> list = new List<string>();
            foreach (var key in matchKeys) list.Add(key);
            return list;

        }
        
    }
}
