using Microsoft.EntityFrameworkCore;
using ZooApi_Mediator.Domain.Interfaces;
using ZooApi_Mediator.Infrastructure.Data;

namespace ZooApi_Mediator.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

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
