using Microsoft.AspNetCore.Mvc.DataAnnotations;
using SosCivil.Api.Data.Contexts;

namespace DevIO.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MainContext>();

            return services;
        }
    }
}