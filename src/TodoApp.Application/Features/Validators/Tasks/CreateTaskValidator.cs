using FluentValidation;
using TodoApp.Application.Features.Commands.Tasks;

namespace TodoApp.Application.Features.Validators.Tasks;

public class CreateTaskValidator : AbstractValidator<CreateTaskCommandRequest>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.Body)
            .NotEmpty()
            .MinimumLength(6);
    }

}
