using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservationManager.Infrastructure.Context;
using ReservationManager.Application.Contracts;
using ReservationManager.Infrastructure.Repositories;

namespace ReservationManager.Infrastructure
{
    public static class InfastructureServiceRegistration
    {
        public static IServiceCollection AddInfastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReservationsContext>(options =>
                     options.UseNpgsql(configuration.GetConnectionString("ReservationDB")));
            services.AddScoped<IReservationsContext>(provider=> provider.GetService<ReservationsContext>());
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IReservationRepository, ReservationRepository>();

            return services;
        }
    }
}
