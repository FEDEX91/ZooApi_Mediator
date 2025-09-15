using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZooApi_Mediator.Domain.Entities;
using ZooApi_Mediator.Infrastructure.Data;

namespace ZooApi_Mediator.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            Environment.SetEnvironmentVariable("USE_IN_MEMORY_DB", "true");

            builder.ConfigureTestServices(services =>
            {
                // Add in-memory database
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("ZooMDb");
                });

                // Build the service provider
                var sp = services.BuildServiceProvider();

                // Create DB and seed data
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.EnsureCreated();

                // Seed test data
                db.Birds.AddRange(
                    new Bird { Id = 1, Name = "Sparrow" },
                    new Bird { Id = 2, Name = "Eagle" }
                );
                db.SaveChanges();
            });
        }
    }
}
