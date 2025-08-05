using Microsoft.EntityFrameworkCore;
using ZooApi_Mediator.Entities;

namespace ZooApi_Mediator.Data
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
