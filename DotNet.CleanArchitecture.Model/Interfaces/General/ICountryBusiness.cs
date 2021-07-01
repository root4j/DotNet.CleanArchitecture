using DotNet.CleanArchitecture.Model.Entity.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CleanArchitecture.Model.Interfaces.General
{
    public interface ICountryBusiness
    {
        Task CreateAsync(string id, Country entity);
        Task<Country> ReadAsync(string id);
        Task<List<Country>> ReadAllAsync();
        Task UpdateAsync(string id, Country entity);
        Task DeleteAsync(string id);
    }
}