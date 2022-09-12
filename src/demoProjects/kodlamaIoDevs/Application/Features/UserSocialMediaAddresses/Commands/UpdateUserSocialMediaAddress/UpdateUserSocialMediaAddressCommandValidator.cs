using FluentValidation;

namespace Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress
{
    public class UpdateUserSocialMediaAddressCommandValidator : AbstractValidator<UpdateUserSocialMediaAddressCommand>
    {
        public UpdateUserSocialMediaAddressCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Name).NotEmpty().Length(1, 50);
            RuleFor(p => p.Url).NotEmpty().Length(1, 500);
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}
