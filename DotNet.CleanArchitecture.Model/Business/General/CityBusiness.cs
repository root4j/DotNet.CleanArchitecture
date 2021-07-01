using DotNet.CleanArchitecture.Model.Common;
using DotNet.CleanArchitecture.Model.Entity.General;
using DotNet.CleanArchitecture.Model.Interfaces.General;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.CleanArchitecture.Model.Business.General
{
    public class CityBusiness : RepositoryAsync<string, City>, ICityBusiness
    {
        private readonly AppDbContext _Context;

        public CityBusiness(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        protected override IQueryable<City> GetQuery()
        {
            return _Context.Cities.Include(x => x.State).ThenInclude(x => x.Country);
        }

        public async Task<List<City>> ReadAllAsync(string stateCode)
        {
            try
            {
                return await GetQuery().Where(x => x.StateCode.Equals(stateCode)).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}