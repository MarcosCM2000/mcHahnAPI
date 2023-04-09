using mcHahn.Application.Services.Authentication;
using mcHahn.Application.Services.Shipments;
using Microsoft.Extensions.DependencyInjection;

namespace mcHahn.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            return services;
        }
    }
}
