using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress
{
    public class DeleteUserSocialMediaAddressCommand : IRequest<DeletedUserSocialMediaAddressDto>
    {
        public int Id { get; set; }

        public class DeleteUserSocialMediaAddressCommandHandler : IRequestHandler<DeleteUserSocialMediaAddressCommand, DeletedUserSocialMediaAddressDto>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaAddressBusinessRules _userSocialMediaAddressBusinessRules;

            public DeleteUserSocialMediaAddressCommandHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRules userSocialMediaAddressBusinessRules)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
                _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
            }

            public async Task<DeletedUserSocialMediaAddressDto> Handle(DeleteUserSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                await _userSocialMediaAddressBusinessRules.UserSocialMediaAddressIdShouldBeExist(request.Id);

                UserSocialMediaAddress mappedUserSocialMediaAddress = _mapper.Map<UserSocialMediaAddress>(request);
                UserSocialMediaAddress deletedUserSocialMediaAddress = await _userSocialMediaAddressRepository.DeleteAsync(mappedUserSocialMediaAddress);
                DeletedUserSocialMediaAddressDto deletedUserSocialMediaAddressDto = _mapper.Map<DeletedUserSocialMediaAddressDto>(deletedUserSocialMediaAddress);

                return deletedUserSocialMediaAddressDto;
            }
        }
    }
}
