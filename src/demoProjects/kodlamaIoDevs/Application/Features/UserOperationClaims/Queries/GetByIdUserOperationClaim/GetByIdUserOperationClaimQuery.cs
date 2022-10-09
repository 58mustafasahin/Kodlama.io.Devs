using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim
{
    public class GetByIdUserOperationClaimQuery : IRequest<GetByIdUserOperationClaimDto>
    {
        public int Id { get; set; }

        public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, GetByIdUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<GetByIdUserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(p => p.Id == request.Id, include: p => p.Include(p => p.User).Include(p => p.OperationClaim));

                _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenRequested(userOperationClaim);

                GetByIdUserOperationClaimDto getByIdUserOperationClaimDto = _mapper.Map<GetByIdUserOperationClaimDto>(userOperationClaim);
                return getByIdUserOperationClaimDto;
            }
        }
    }
}
