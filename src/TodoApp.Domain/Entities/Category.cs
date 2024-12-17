namespace TodoApp.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public virtual ICollection<TodoTask> Tasks { get; private set; }
}
