using Application.Features.UserSocialMediaAddresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddressByDynamic
{
    public class GetListUserSocialMediaAddressByDynamicQuery : IRequest<UserSocialMediaAddressListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetListUserSocialMediaAddressByDynamicQueryHandler : IRequestHandler<GetListUserSocialMediaAddressByDynamicQuery, UserSocialMediaAddressListModel>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;

            public GetListUserSocialMediaAddressByDynamicQueryHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
            }

            public async Task<UserSocialMediaAddressListModel> Handle(GetListUserSocialMediaAddressByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserSocialMediaAddress> userSocialMediaAddresses = await _userSocialMediaAddressRepository.GetListByDynamicAsync(request.Dynamic, include: p => p.Include(p => p.User), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                UserSocialMediaAddressListModel mappedUserSocialMediaAddressListModel = _mapper.Map<UserSocialMediaAddressListModel>(userSocialMediaAddresses);

                return mappedUserSocialMediaAddressListModel;
            }
        }
    }
}

