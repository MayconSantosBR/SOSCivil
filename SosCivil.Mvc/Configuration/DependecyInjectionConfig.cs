using SosCivil.Mvc.Extensions;
using SosCivil.Mvc.Models.AutoMapper;
using SosCivil.Mvc.Service;
using SosCivil.Mvc.Service.Interfaces;

namespace SosCivil.Mvc.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mapper));
            services.AddHttpClient<IAuthService, AuthService>();
            services.AddHttpClient<IItemService, ItemService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISolicitacaoService, SolicitacaoService>();
            services.AddScoped<IDocumentoService, DocumentoService>();
        }
    }
}
