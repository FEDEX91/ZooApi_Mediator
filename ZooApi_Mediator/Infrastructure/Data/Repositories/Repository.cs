using Microsoft.EntityFrameworkCore;
using ZooApi_Mediator.Domain.Interfaces;
using ZooApi_Mediator.Infrastructure.Data;

namespace ZooApi_Mediator.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item is null) throw new Exception($"{id} not found");
            return item; 
        }
    }
}
