using ZooApi_Mediator.Entities;

namespace ZooApi_Mediator.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Bird> Birds { get; }
        Task<int> SaveChangesAsync();
    }
}
