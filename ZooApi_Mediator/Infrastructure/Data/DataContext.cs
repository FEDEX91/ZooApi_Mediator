using Microsoft.EntityFrameworkCore;
using ZooApi_Mediator.Domain.Entities;

namespace ZooApi_Mediator.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        public DbSet<Bird> Birds { get; set; }
    }
}
