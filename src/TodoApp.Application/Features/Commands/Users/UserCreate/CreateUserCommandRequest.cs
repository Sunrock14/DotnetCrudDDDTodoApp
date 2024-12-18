using MediatR;
using TodoApp.Application.DTOs.Users;

namespace TodoApp.Application.Features.Commands.Users.UserCreate
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
