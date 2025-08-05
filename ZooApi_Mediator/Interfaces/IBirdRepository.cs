using ZooApi_Mediator.Entities;

namespace ZooApi_Mediator.Interfaces
{
    public interface IBirdRepository
    {
        Task<IEnumerable<Bird>> GetAllAsync();
        Task<Bird> GetByIdAsync(int id);
        Task AddAsync(Bird entity);
    }
}
