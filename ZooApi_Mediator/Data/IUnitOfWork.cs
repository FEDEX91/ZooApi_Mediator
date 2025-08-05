using ZooApi_Mediator.Entities;

namespace ZooApi_Mediator.Data
{
    public interface IUnitOfWork
    {
        IRepository<Bird> Birds { get; }
        Task<int> SaveChangesAsync();
    }
}
