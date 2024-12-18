using MediatR;

namespace TodoApp.Application.Features.Commands.Tasks.UpdateTask;

public class UpdateTaskCommandRequest : IRequest<UpdateTaskCommandResponse>
{
    public Guid Id { get; set; }
}
