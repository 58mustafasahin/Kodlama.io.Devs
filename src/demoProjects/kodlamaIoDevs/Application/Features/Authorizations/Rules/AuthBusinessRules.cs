using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Authorizations.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string requestEmail)
        {
            var user = await _userRepository.GetAsync(x => x.Email == requestEmail);
            if (user is not null)
                throw new BusinessException("User Email Already Exists");
        }

        public void CheckIfUserExists(User user)
        {
            if (user is null)
                throw new BusinessException("User Not Found");
        }

        public void CheckIfPasswordIsCorrect(string requestPassword, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(requestPassword, userPasswordHash, userPasswordSalt))
                throw new BusinessException("Password Is Not Correct");
        }
    }
}