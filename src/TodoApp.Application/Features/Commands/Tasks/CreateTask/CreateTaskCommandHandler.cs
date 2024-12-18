using MediatR;

namespace TodoApp.Application.Features.Commands.Tasks.CreateTask;

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
