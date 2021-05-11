using System.Threading.Tasks;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public interface IPlayerRepository : ICrudRepository<Player>
    {
    }
}