using FluentValidation;

namespace Application.Features.Authorizations.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().Length(1, 50);
            RuleFor(p => p.LastName).NotEmpty().Length(1, 50);
            RuleFor(p => p.Email).NotEmpty().Length(1, 100).EmailAddress();
            RuleFor(p => p.Password).NotEmpty().Length(1, 100);
        }
    }
}
