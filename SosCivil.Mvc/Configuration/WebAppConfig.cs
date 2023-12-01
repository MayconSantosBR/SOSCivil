namespace SosCivil.Mvc.Configuration
{
    public static class WebAppConfig
    {

        public static void AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        public static void UseMvcConfiguration(this WebApplication app)
        {
            app.UseForwardedHeaders();

            app.UseExceptionHandler("/error/500");
            app.UseStatusCodePagesWithRedirects("/error/{0}");


            if (app.Configuration["USE_HTTPS_REDIRECTION"] == "true")
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Catalog}/{action=Index}/{id?}");


        }

    }
}
