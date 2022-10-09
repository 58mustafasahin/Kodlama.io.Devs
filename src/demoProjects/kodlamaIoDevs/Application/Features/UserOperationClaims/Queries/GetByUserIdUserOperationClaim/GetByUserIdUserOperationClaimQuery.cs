using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim
{
    public class GetByUserIdUserOperationClaimQuery : IRequest<UserOperationClaimListModel>
    {
        public int UserId { get; set; }

        public class GetByUserIdUserOperationClaimQueryHandler : IRequestHandler<GetByUserIdUserOperationClaimQuery, UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public GetByUserIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<UserOperationClaimListModel> Handle(GetByUserIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(p => p.UserId == request.UserId, include: p => p.Include(p => p.User).Include(p => p.OperationClaim));

                UserOperationClaimListModel userOperationClaimListModel = _mapper.Map<UserOperationClaimListModel>(userOperationClaims);
                return userOperationClaimListModel;
            }
        }
    }
}
