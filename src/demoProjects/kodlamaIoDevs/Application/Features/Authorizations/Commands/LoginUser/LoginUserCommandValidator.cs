using Core.Security.Dtos;
using FluentValidation;

namespace Application.Features.Authorizations.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().Length(1, 100).EmailAddress();
            RuleFor(p => p.Password).NotEmpty().Length(1, 100);
        }
    }
}
