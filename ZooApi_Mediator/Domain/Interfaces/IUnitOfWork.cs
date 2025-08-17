using ZooApi_Mediator.Domain.Entities;

namespace ZooApi_Mediator.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Bird> Birds { get; }
        IRepository<Fish> Fishes { get; }
        Task<int> SaveChangesAsync();
    }
}
