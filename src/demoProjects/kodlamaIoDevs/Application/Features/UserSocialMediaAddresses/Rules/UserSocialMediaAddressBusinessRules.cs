using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.UserSocialMediaAddresses.Rules
{
    public class UserSocialMediaAddressBusinessRules
    {
        private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;

        public UserSocialMediaAddressBusinessRules(IUserSocialMediaAddressRepository userSocialMediaAddressRepository)
        {
            _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
        }

        public async Task UserSocialMediaAddressNameCanNotBeDuplicated(string name, int userId)
        {
            IPaginate<UserSocialMediaAddress> result = await _userSocialMediaAddressRepository.GetListAsync(p => p.Name == name && p.UserId == userId);
            if (result.Items.Any()) throw new BusinessException("User Social Media Address name exists.");
        }

        public async Task UserSocialMediaAddressIdShouldBeExist(int id)
        {
            IPaginate<UserSocialMediaAddress> result = await _userSocialMediaAddressRepository.GetListAsync(p => p.Id == id);
            if (!result.Items.Any()) throw new BusinessException("User Social Media Address not found.");
        }

        public void UserSocialMediaAddressShouldExistWhenRequested(UserSocialMediaAddress userSocialMediaAddress)
        {
            if (userSocialMediaAddress == null) throw new BusinessException("Requested User Social Media Address does not exist.");
        }
    }
}
