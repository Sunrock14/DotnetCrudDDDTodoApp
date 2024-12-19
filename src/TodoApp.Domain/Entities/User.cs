
namespace TodoApp.Domain.Entities;

public class User : BaseEntity, IEntity
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public virtual ICollection<TodoTask> CreatedTasks { get; private set; } = new List<TodoTask>();
    public virtual ICollection<TodoTask> AssignedTasks { get; private set; } = new List<TodoTask>();
}
