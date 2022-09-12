using Application.Features.UserSocialMediaAddresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddress
{
    public class GetListUserSocialMediaAddressQuery : IRequest<UserSocialMediaAddressListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListUserSocialMediaAddressQueryHandler : IRequestHandler<GetListUserSocialMediaAddressQuery, UserSocialMediaAddressListModel>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;

            public GetListUserSocialMediaAddressQueryHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<UserSocialMediaAddressListModel> Handle(GetListUserSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserSocialMediaAddress> userSocialMediaAddresses = await _userSocialMediaAddressRepository.GetListAsync(include: p => p.Include(p => p.User), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                UserSocialMediaAddressListModel mappedUserSocialMediaAddressListModel = _mapper.Map<UserSocialMediaAddressListModel>(userSocialMediaAddresses);

                return mappedUserSocialMediaAddressListModel;
            }
        }
    }
}
