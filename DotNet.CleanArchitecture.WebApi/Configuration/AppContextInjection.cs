using DotNet.CleanArchitecture.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DotNet.CleanArchitecture.WebApi.Configuration
{
    public static class AppContextInjection
    {
        public static IServiceCollection AddDbContextInjection(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("AppDbContext")));
                return services;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}