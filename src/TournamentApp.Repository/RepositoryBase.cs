using Firebase.Database;
using System;
using System.Configuration;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public abstract class RepositoryBase
    {
        protected readonly FirebaseClient _firebaseClient;
        protected readonly string _aggregate;

        public RepositoryBase(AggregateName aggregate, string fireBaseDataBaseUrl)
        {
            _aggregate = aggregate.ToString();
            _firebaseClient = new FirebaseClient(fireBaseDataBaseUrl);
        }
    }
}
