using Microsoft.EntityFrameworkCore;
using ZooApi_Mediator.Domain.Entities;

namespace ZooApi_Mediator.Infrastructure.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Bird> Birds { get; set; }

        public DbSet<Fish> Fishes { get; set; }
    }
}
