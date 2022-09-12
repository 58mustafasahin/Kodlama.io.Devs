using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress
{
    public class CreateUserSocialMediaAddressCommand : IRequest<CreatedUserSocialMediaAddressDto>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }

        public class CreateUserSocialMediaAddressCommandHandler : IRequestHandler<CreateUserSocialMediaAddressCommand, CreatedUserSocialMediaAddressDto>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

            public CreateUserSocialMediaAddressCommandHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
                _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
            }

            public async Task<CreatedUserSocialMediaAddressDto> Handle(CreateUserSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                await _userSocialMediaAddressBusinessRules.UserSocialMediaAddressNameCanNotBeDuplicated(request.Name, request.UserId);

                UserSocialMediaAddress mappedUserSocialMediaAddress = _mapper.Map<UserSocialMediaAddress>(request);
                UserSocialMediaAddress createdUserSocialMediaAddress = await _userSocialMediaAddressRepository.AddAsync(mappedUserSocialMediaAddress);
                CreatedUserSocialMediaAddressDto createdUserSocialMediaAddressDto = _mapper.Map<CreatedUserSocialMediaAddressDto>(createdUserSocialMediaAddress);

                return createdUserSocialMediaAddressDto;
            }
        }
    }
}
