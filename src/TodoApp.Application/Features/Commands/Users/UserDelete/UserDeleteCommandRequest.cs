using MediatR;

namespace TodoApp.Application.Features.Commands.Users.UserDelete;

public class UserDeleteCommandRequest : IRequest<UserDeleteCommandResponse>
{
    public Guid Id { get; set; }
}
