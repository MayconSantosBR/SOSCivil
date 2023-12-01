﻿using SosCivil.Mvc.Service;

namespace SosCivil.Mvc.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAuthService, AuthService>();
        }
    }
}