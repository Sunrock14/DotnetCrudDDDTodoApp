using TodoApp.Infrastructure.Repositories.Categories;
using TodoApp.Infrastructure.Repositories.Tasks;
using TodoApp.Infrastructure.Repositories.Users;

namespace TodoApp.Infrastructure.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    ITaskRepository Tasks { get; }
    ICategoryRepository Categories { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
