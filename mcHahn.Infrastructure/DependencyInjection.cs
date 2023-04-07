using mcHahn.Application.Common.Interfaces.Authentication;
using mcHahn.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using mcHahn.Application.Common.Interfaces.Persistance;
using mcHahn.Infrastructure.Persistance;

namespace mcHahn.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            return services;
        }
    }
}
