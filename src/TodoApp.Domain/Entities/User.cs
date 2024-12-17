﻿namespace TodoApp.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public virtual ICollection<TodoTask> CreatedTasks { get; private set; }
    public virtual ICollection<TodoTask> AssignedTasks { get; private set; }
}
