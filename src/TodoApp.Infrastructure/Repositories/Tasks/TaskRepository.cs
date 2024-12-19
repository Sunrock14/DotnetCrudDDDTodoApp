
namespace TodoApp.Infrastructure.Repositories.Tasks;

public class TaskRepository : BaseRepository<TodoTask>, ITaskRepository
{
    public TaskRepository(DbContext context) : base(context)
    {
    }
}
