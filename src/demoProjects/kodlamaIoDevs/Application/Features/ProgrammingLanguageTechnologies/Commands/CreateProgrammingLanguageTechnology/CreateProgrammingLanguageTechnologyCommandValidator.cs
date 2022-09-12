using FluentValidation;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<CreateProgrammingLanguageTechnologyCommand>
    {
        public CreateProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().Length(1, 50);
        }
    }
}
