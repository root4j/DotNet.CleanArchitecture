using DotNet.CleanArchitecture.Model.Entity.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CleanArchitecture.Model.Interfaces.General
{
    public interface IStateBusiness
    {
        Task CreateAsync(string id, State entity);
        Task<State> ReadAsync(string id);
        Task<List<State>> ReadAllAsync();
        Task<List<State>> ReadAllAsync(string countryCode);
        Task UpdateAsync(string id, State entity);
        Task DeleteAsync(string id);
    }
}