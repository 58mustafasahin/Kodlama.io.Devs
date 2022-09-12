using FluentValidation;

namespace Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress
{
    public class CreateUserSocialMediaAddressCommandValidator : AbstractValidator<CreateUserSocialMediaAddressCommand>
    {
        public CreateUserSocialMediaAddressCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().Length(1, 50);
            RuleFor(p => p.Url).NotEmpty().Length(1, 500);
        }
    }
}
