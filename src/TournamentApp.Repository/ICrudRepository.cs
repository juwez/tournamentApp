﻿using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
using TournamentApp.Model;

namespace TournamentApp.Repository
{
    public interface ICrudRepository<T> where T: EntityBase
    {
        Task<IQueryable<T>> GetAsync(string key);
        Task<IQueryable<T>> AddAsync(T entity);
        Task<IQueryable<T>> DeleteAsync(string key);
        Task<IQueryable<T>> UpdateAsync(string key, T entity);
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> EditProperty(string key, string property, string value);
    }
}
