﻿using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using TournamentApp.Model;
namespace TournamentApp.Repository
{
    public class CrudRepository<T> : RepositoryBase where T : EntityBase
    {
        public CrudRepository(AggregateName aggregate, string fireBaseDataBaseUrl) : base(aggregate, fireBaseDataBaseUrl)
        {
        }

        public async Task<IQueryable<T>> AddAsync(T entity)
        {
            await _firebaseClient
                .Child(_aggregate)
                .PostAsync(entity);

            var key = await GetLastEntity();
            return await GetAsync(key);
        }

        

        public async Task<IQueryable<T>> DeleteAsync(string key)
        {
            IQueryable<T> deletedItem = await GetAsync(key);
            await _firebaseClient
                .Child(_aggregate)
                .Child(key)
                .DeleteAsync();
            return deletedItem;
        }

        public async Task<IQueryable<T>> GetAll()
        {
            var firebaseEntities = await ReadOnlyTCollection();
            return firebaseEntities.Select(x => x.Object).AsQueryable();
        }
        
        public async Task<IQueryable<T>> GetAsync(string key)
        {
            var entity = await _firebaseClient
                    .Child(_aggregate)
                    .Child(key)
                    .OnceSingleAsync<T>();
            if (entity == null) { return null; }
            entity.Key = key;
            return entity.ToQueryable();
        }

        public async Task<IQueryable<T>> UpdateAsync(string key, T entity)
        {
            await _firebaseClient
                .Child(_aggregate)
                .Child(key)
                .PutAsync(entity);

            return await GetAsync(key);
        }

        public async Task<IQueryable<T>> EditProperty(string key, string property, string value)
        {
            await _firebaseClient
                .Child(_aggregate)
                .Child(key)
                .PatchAsync("{ \"" + property +  "\" : \""  + value + "\"}");

            return await GetAsync(key);
        }

        #region HelperFunctions
        private async Task<string> GetLastEntity()
        {
            var firebaseEntities = await ReadOnlyTCollection();
            var key = firebaseEntities.Last().Key;
            return key;
        }
        
        private async Task<IReadOnlyCollection<FirebaseObject<T>>> ReadOnlyTCollection()
        {
            var firebaseEntities = await _firebaseClient
                .Child(_aggregate)
                .OnceAsync<T>();

            Parallel.ForEach(firebaseEntities, x => { x.Object.Key = x.Key; });
            return firebaseEntities;
        }
        

        #endregion
        
       

       
    }
}
