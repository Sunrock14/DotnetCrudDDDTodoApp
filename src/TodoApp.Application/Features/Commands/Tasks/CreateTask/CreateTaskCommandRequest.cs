using MediatR;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Features.Commands.Tasks.CreateTask;

public class CreateTaskCommandRequest : IRequest<CreateTaskCommandResponse>
{
    public string Name { get; set; }
    public string Body { get; set; }
    public string Title { get; set; }
    public string UserId { get; set; }
    public User AssignId { get; set; }
}
