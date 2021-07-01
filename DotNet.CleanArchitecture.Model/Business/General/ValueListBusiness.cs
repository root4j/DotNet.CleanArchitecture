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
    public class ValueListBusiness : RepositoryAsync<string, ValueList>, IValueListBusiness
    {
        private readonly AppDbContext _Context;

        public ValueListBusiness(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        protected override IQueryable<ValueList> GetQuery()
        {
            return _Context.ValueLists;
        }

        public async Task<List<ValueList>> ReadAllAsync(string categoryCode)
        {
            try
            {
                return await GetQuery().Where(x => x.ValueListCategory.Equals(categoryCode)).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}