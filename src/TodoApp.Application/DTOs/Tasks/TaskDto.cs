using TodoApp.Domain.ComplexTypes;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.DTOs.Tasks;

public class TodoTaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskStatus Status { get; set; }
    public Priority Priority { get; set; }
    public Category Category { get; set; }
    public Guid UserId { get; set; }
}
