using DotNet.CleanArchitecture.Model.Common;
using DotNet.CleanArchitecture.Model.Entity.General;
using DotNet.CleanArchitecture.Model.Interfaces.General;
using System.Linq;

namespace DotNet.CleanArchitecture.Model.Business.General
{
    public class CountryBusiness : RepositoryAsync<string, Country>, ICountryBusiness
    {
        private readonly AppDbContext _Context;

        public CountryBusiness(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        protected override IQueryable<Country> GetQuery()
        {
            return _Context.Countries;
        }
    }
}