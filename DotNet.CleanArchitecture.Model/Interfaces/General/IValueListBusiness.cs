using DotNet.CleanArchitecture.Model.Entity.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CleanArchitecture.Model.Interfaces.General
{
    public interface IValueListBusiness
    {
        Task CreateAsync(string id, ValueList entity);
        Task<ValueList> ReadAsync(string id);
        Task<List<ValueList>> ReadAllAsync();
        Task<List<ValueList>> ReadAllAsync(string categoryCode);
        Task UpdateAsync(string id, ValueList entity);
        Task DeleteAsync(string id);
    }
}