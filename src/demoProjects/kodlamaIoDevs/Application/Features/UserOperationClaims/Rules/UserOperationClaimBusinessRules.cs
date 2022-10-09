using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IUserRepository _userRepository;

        public UserOperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository)
        {
            _operationClaimRepository = operationClaimRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
        }

        public async Task UserOperationClaimIdShouldBeExist(int id)
        {
            IPaginate<UserOperationClaim> result = await _userOperationClaimRepository.GetListAsync(p => p.Id == id);
            if (!result.Items.Any()) throw new BusinessException("User Operation Claim not found.");
        }

        public async Task UserIdShouldBeExist(int userId)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(p => p.Id == userId);
            if (!result.Items.Any()) throw new BusinessException("User not found.");
        }

        public async Task OperationClaimIdShouldBeExist(int operationClaimId)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(p => p.Id == operationClaimId);
            if (!result.Items.Any()) throw new BusinessException("Operation Claim not found.");
        }

        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("Requested User Operation Claim does not exist.");
        }
    }
}
