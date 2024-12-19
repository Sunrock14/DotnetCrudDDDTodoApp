
namespace TodoApp.Application.Features.Commands.Tasks;

public class AssignTaskCommandResponse
{
    public string Message { get; set; }
}

public class AssingTaskCommandRequest : IRequest<AssignTaskCommandResponse>
{
    public Guid TaskId { get; set; }
    public Guid AssignUserId { get; set; }
}


public class AssignTaskCommandHandler : IRequestHandler<AssingTaskCommandRequest, AssignTaskCommandResponse>
{
    public async Task<AssignTaskCommandResponse> Handle(AssingTaskCommandRequest request, CancellationToken cancellationToken)
    {
        //Do Somethink
        return new()
        {
            Message = ""
        };
    }
}

