using Microsoft.EntityFrameworkCore;
using ZooApi_Mediator.Domain.Interfaces;
using ZooApi_Mediator.Infrastructure.Data;

namespace ZooApi_Mediator.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();

            var useInMemoryDb = Convert.ToBoolean(Environment.GetEnvironmentVariable("USE_IN_MEMORY_DB"));

            if (!useInMemoryDb)
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });
            }

            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(Program).Assembly);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });

            return services;
        }
    }
}
