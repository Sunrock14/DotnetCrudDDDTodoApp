using MediatR;

namespace TodoApp.Application.Features.Commands.Users.UserDelete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommandRequest, UserDeleteCommandResponse>
    {
        public async Task<UserDeleteCommandResponse> Handle(UserDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                IsSuccess = true,
            };
        }
    }
}
