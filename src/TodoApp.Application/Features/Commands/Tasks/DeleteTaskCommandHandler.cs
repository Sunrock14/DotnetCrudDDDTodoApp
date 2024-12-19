namespace TodoApp.Application.Features.Commands.Tasks;


public class DeleteUserCommandResponse
{
    public string Message { get; set; }
}

public class DeleteTaskCommandRequest : IRequest<DeleteUserCommandResponse>
{
    public Guid Id { get; set; }
}

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
