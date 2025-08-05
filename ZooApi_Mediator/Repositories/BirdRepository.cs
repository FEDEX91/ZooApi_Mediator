using Microsoft.EntityFrameworkCore;
using ZooApi_Mediator.Data;
using ZooApi_Mediator.Entities;
using ZooApi_Mediator.Interfaces;

namespace ZooApi_Mediator.Repositories
{
    public class BirdRepository : IBirdRepository
    {
        private readonly DataContext _context;

        public BirdRepository(DataContext context)
        {
            _context = context;
        }

        public Task AddAsync(Bird entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Bird>> GetAllAsync()
        {
            return await _context.Birds.ToListAsync();
        }

        public Task<Bird> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
