namespace TodoApp.Domain.Entities;

public class TodoTask : BaseEntity, IEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public Status Status { get; private set; }
    public Priority Priority { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    public Guid CreatedById { get; private set; }
    public User CreatedBy { get; private set; }

    public Guid? AssignedToId { get; private set; }
    public User AssignedTo { get; private set; }
}
