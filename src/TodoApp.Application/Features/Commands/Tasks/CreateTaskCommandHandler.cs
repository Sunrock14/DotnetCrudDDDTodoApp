namespace TodoApp.Application.Features.Commands.Tasks;

public class CreateTaskCommandResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class CreateTaskCommandRequest : IRequest<CreateTaskCommandResponse>
{
    public string Name { get; set; }
    public string Body { get; set; }
    public string Title { get; set; }
    public string UserId { get; set; }
    public User AssignId { get; set; }
}

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommandRequest, CreateTaskCommandResponse>
{
    public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommandRequest request, CancellationToken cancellationToken)
    {
        //Do Somethink
        return new()
        {
            IsSuccess = true,
            Message = ""
        };
    }
}
