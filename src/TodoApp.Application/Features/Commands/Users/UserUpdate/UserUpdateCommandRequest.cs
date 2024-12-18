using MediatR;
using TodoApp.Domain.ComplexTypes;

namespace TodoApp.Application.Features.Commands.Users.UserUpdate;

public class UserUpdateCommandRequest : IRequest<UserUpdateCommandResponse>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public Priority Priority { get; set; }
}
