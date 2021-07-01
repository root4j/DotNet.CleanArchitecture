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
    public class StateBusiness : RepositoryAsync<string, State>, IStateBusiness
    {
        private readonly AppDbContext _Context;

        public StateBusiness(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        protected override IQueryable<State> GetQuery()
        {
            return _Context.States.Include(x => x.Country);
        }

        public async Task<List<State>> ReadAllAsync(string countryCode)
        {
            try
            {
                return await GetQuery().Where(x => x.CountryCode.Equals(countryCode)).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
