using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMVC.WebApplication
{
    public static class DependencyInjectionWebApplication
    {
        public static IServiceCollection AddWebApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<ErrorHandlingMiddleware>();
            return services;
        }
    }
}
