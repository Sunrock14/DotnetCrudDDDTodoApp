﻿

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

    private TodoTask()
    {
    }

    public TodoTask(string title, string description, DateTime dueDate, Priority priority,
        Guid categoryId, Guid createdById)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        CategoryId = categoryId;
        CreatedById = createdById;
        Status = Status.Todo;
        CreatedDate = DateTime.UtcNow;
    }

    public void AssignTo(Guid userId)
    {
        AssignedToId = userId;
        ModifiedDate = DateTime.UtcNow;
        ModifiedByName = userId.ToString();
    }

    public void UpdateStatus(Status newStatus)
    {
        Status = newStatus;
        ModifiedDate = DateTime.UtcNow;
    }
}
