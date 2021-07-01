using DotNet.CleanArchitecture.Model.Entity.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CleanArchitecture.Model.Interfaces.General
{
    public interface ICityBusiness
    {
        Task CreateAsync(string id, City entity);
        Task<City> ReadAsync(string id);
        Task<List<City>> ReadAllAsync();
        Task<List<City>> ReadAllAsync(string stateCode);
        Task UpdateAsync(string id, City entity);
        Task DeleteAsync(string id);
    }
}