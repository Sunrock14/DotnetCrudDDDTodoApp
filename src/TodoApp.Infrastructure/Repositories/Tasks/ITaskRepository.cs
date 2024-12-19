using Star.Core.BaseRepository;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Repositories.Tasks;

public interface ITaskRepository : IBaseRepository<TodoTask>
{
}
