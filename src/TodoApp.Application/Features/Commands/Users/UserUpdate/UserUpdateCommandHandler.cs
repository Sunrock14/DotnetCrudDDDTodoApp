using MediatR;

namespace TodoApp.Application.Features.Commands.Users.UserUpdate;

public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommandRequest, UserUpdateCommandResponse>
{
    public async Task<UserUpdateCommandResponse> Handle(UserUpdateCommandRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Message = ""
        };
    }
}
