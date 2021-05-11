using System.Collections.Generic;
using System.Threading.Tasks;
using TournamentApp.Services.Dtos;

namespace TournamentApp.Services.Interfaces
{
    public interface ICrudService<T> where T : DtoBase
    {
        Task<T> GetAsync(string key);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(string key);
        Task<T> UpdateAsync(string key, T entity);
        Task<List<T>> GetAllAsync();
        Task<T> EditPropertyAsync(string key, string property, string value);
    }
}