using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public interface IRoundRepository : ICrudRepository<Round>
    {
        Task<List<string>> GetMatchKeys(string roundKey);
    }
}
