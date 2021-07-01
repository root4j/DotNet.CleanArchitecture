using DotNet.CleanArchitecture.Model.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace DotNet.CleanArchitecture.WebApi.Configuration
{
    public static class AppRouteInjection
    {
        public static IApplicationBuilder UseMvcInjection(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: Constants.AREA_GENERAL,
                    areaName: Constants.AREA_GENERAL,
                    template: Constants.AREA_GENERAL + "/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=App}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}