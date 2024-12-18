using MediatR;

namespace TodoApp.Application.Features.Commands.Tasks.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommandRequest, DeleteUserCommandResponse>
{
    public async Task<DeleteUserCommandResponse> Handle(DeleteTaskCommandRequest request, CancellationToken cancellationToken)
    {
        //Delete User Service 
        return new()
        {
            Message = ""
        };
    }
}
