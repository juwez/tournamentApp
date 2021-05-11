using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public class TournamentRepository : CrudRepository<Tournament>, 
        ITournamentRepository
    { 
        public TournamentRepository(string fireBaseDataBaseUrl) 
            : base(AggregateName.Tournament, fireBaseDataBaseUrl)
        {
        }
    }
}
