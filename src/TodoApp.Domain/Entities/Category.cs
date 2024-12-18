namespace TodoApp.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public virtual ICollection<TodoTask> Tasks { get; private set; } = new List<TodoTask>();
}
