using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress
{
    public class UpdateUserSocialMediaAddressCommand : IRequest<UpdatedUserSocialMediaAddressDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }

        public class UpdateUserSocialMediaAddressCommandHandler : IRequestHandler<UpdateUserSocialMediaAddressCommand, UpdatedUserSocialMediaAddressDto>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

            public UpdateUserSocialMediaAddressCommandHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
                _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
            }

            public async Task<UpdatedUserSocialMediaAddressDto> Handle(UpdateUserSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                await _userSocialMediaAddressBusinessRules.UserSocialMediaAddressIdShouldBeExist(request.Id);
                await _userSocialMediaAddressBusinessRules.UserSocialMediaAddressNameCanNotBeDuplicated(request.Name, request.UserId);

                UserSocialMediaAddress mappedUserSocialMediaAddress = _mapper.Map<UserSocialMediaAddress>(request);
                UserSocialMediaAddress updatedUserSocialMediaAddress = await _userSocialMediaAddressRepository.UpdateAsync(mappedUserSocialMediaAddress);
                UpdatedUserSocialMediaAddressDto updatedUserSocialMediaAddressDto = _mapper.Map<UpdatedUserSocialMediaAddressDto>(updatedUserSocialMediaAddress);

                return updatedUserSocialMediaAddressDto;
            }
        }
    }
}
