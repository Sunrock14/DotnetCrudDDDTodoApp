using FluentValidation;
using TodoApp.Application.Features.Commands.Tasks.UpdateTask;

namespace TodoApp.Application.Features.Validators.Tasks;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommandRequest>
{
    public UpdateTaskValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
