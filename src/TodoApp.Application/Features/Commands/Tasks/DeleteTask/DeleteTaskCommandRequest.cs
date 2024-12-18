using MediatR;

namespace TodoApp.Application.Features.Commands.Tasks.DeleteTask;

public class DeleteTaskCommandRequest : IRequest<DeleteUserCommandResponse>
{
    public Guid Id { get; set; }
}
