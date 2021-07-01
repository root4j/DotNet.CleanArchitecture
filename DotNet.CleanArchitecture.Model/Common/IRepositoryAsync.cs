using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CleanArchitecture.Model.Common
{
    public interface IRepositoryAsync<K, T>
    {
        Task CreateAsync(K id, T entity);
        Task<T> ReadAsync(K id);
        Task<List<T>> ReadAllAsync();
        Task UpdateAsync(K id, T entity);
        Task DeleteAsync(K id);
    }
}