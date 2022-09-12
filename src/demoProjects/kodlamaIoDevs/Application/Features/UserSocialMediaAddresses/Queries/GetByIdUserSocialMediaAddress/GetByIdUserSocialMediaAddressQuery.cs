using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserSocialMediaAddresses.Queries.GetByIdUserSocialMediaAddress
{
    public class GetByIdUserSocialMediaAddressQuery : IRequest<GetByIdUserSocialMediaAddressDto>
    {
        public int Id { get; set; }
        public class GetByIdUserSocialMediaAddressQueryHandler : IRequestHandler<GetByIdUserSocialMediaAddressQuery, GetByIdUserSocialMediaAddressDto>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

            public GetByIdUserSocialMediaAddressQueryHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
                _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
            }

            public async Task<GetByIdUserSocialMediaAddressDto> Handle(GetByIdUserSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                UserSocialMediaAddress? userSocialMediaAddress = await _userSocialMediaAddressRepository.GetAsync(p => p.Id == request.Id, include: p => p.Include(p => p.User));

                _userSocialMediaAddressBusinessRules.UserSocialMediaAddressShouldExistWhenRequested(userSocialMediaAddress);

                GetByIdUserSocialMediaAddressDto getByIdUserSocialMediaAddressDto = _mapper.Map<GetByIdUserSocialMediaAddressDto>(userSocialMediaAddress);
                return getByIdUserSocialMediaAddressDto;
            }
        }
    }
}
