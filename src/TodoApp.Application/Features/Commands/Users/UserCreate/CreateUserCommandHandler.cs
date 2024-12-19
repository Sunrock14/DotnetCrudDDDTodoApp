namespace TodoApp.Application.Features.Commands.Users.UserCreate;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        //DO somethink

        return new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Username = request.Username,
        };
    }
}
