using FluentValidation;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<UpdateProgrammingLanguageTechnologyCommand>
    {
        public UpdateProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Name).NotEmpty().Length(1, 50);
            RuleFor(p => p.ProgrammingLanguageId).NotEmpty();
        }
    }
}
