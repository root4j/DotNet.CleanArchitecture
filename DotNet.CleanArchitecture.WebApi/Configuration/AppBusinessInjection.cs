using Microsoft.Extensions.DependencyInjection;

namespace DotNet.CleanArchitecture.WebApi.Configuration
{
    public static class AppBusinessInjection
    {
        public static IServiceCollection AddBusinessInjection(this IServiceCollection services)
        {
            #region General Injection
            services.AddScoped<Model.Interfaces.General.ICityBusiness, Model.Business.General.CityBusiness>();
            services.AddScoped<Model.Interfaces.General.ICountryBusiness, Model.Business.General.CountryBusiness>();
            services.AddScoped<Model.Interfaces.General.IStateBusiness, Model.Business.General.StateBusiness>();
            services.AddScoped<Model.Interfaces.General.IValueListBusiness, Model.Business.General.ValueListBusiness>();
            #endregion

            return services;
        }
    }
}