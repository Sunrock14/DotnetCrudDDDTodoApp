namespace TodoApp.Infrastructure.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    ITaskRepository Tasks { get; }
    ICategoryRepository Categories { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
