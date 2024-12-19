
namespace TodoApp.Application.Features.Commands.Tasks;

public class UpdateTaskCommandResponse
{
    public string Message { get; set; }
}

public class UpdateTaskCommandRequest : IRequest<UpdateTaskCommandResponse>
{
    public Guid Id { get; set; }
}
public class UpdateTaskCommandHandler: IRequestHandler<UpdateTaskCommandRequest, UpdateTaskCommandResponse>
{
    public async Task<UpdateTaskCommandResponse> Handle(UpdateTaskCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
