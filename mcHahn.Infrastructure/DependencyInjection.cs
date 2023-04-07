using mcHahn.Application.Common.Interfaces.Authentication;
using mcHahn.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace mcHahn.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
