using System.Linq;
using System.Threading.Tasks;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public class MatchRepository : CrudRepository<Match>, IMatchRepository
    {
        public MatchRepository(string fireBaseDataBaseUrl) : base(AggregateName.Match, fireBaseDataBaseUrl)
        {
        }
        
    }
}
