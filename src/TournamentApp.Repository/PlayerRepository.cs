using System.Threading.Tasks;
using Firebase.Database.Query;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public class PlayerRepository : CrudRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(string fireBaseDataBaseUrl) : base(AggregateName.Player, fireBaseDataBaseUrl)
        {
            
        }
    }
}