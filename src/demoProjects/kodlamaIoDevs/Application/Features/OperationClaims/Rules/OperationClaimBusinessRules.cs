using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimNameCanNotBeDuplicated(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Operation Claim name exists.");
        }

        public async Task OperationClaimIdShouldBeExist(int id)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(p => p.Id == id);
            if (!result.Items.Any()) throw new BusinessException("Operation Claim not found.");
        }

        public void OperationClaimShouldExistWhenRequested(OperationClaim operationClaim)
        {
            if (operationClaim == null) throw new BusinessException("Requested Operation Claim does not exist.");
        }
    }
}
