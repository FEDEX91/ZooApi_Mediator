using ZooApi_Mediator.Domain.Entities;
using ZooApi_Mediator.Domain.Interfaces;
using ZooApi_Mediator.Infrastructure.Data.Repositories;

namespace ZooApi_Mediator.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IRepository<Bird> Birds { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Birds = new Repository<Bird>(_context);
        }
      

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
