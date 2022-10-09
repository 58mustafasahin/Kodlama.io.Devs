using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using Application.Features.UserSocialMediaAddresses.Models;
using Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress;

namespace Application.Features.UserSocialMediaAddresses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserSocialMediaAddress, CreatedUserSocialMediaAddressDto>().ReverseMap();
            CreateMap<UserSocialMediaAddress, CreateUserSocialMediaAddressCommand>().ReverseMap();

            CreateMap<UserSocialMediaAddress, DeletedUserSocialMediaAddressDto>().ReverseMap();
            CreateMap<UserSocialMediaAddress, DeleteUserSocialMediaAddressCommand>().ReverseMap();

            CreateMap<UserSocialMediaAddress, UpdatedUserSocialMediaAddressDto>().ReverseMap();
            CreateMap<UserSocialMediaAddress, UpdateUserSocialMediaAddressCommand>().ReverseMap();

            CreateMap<IPaginate<UserSocialMediaAddress>, UserSocialMediaAddressListModel>().ReverseMap();

            CreateMap<UserSocialMediaAddress, GetListUserSocialMediaAddressDto>()
                .ForMember(p => p.UserName, p => p.MapFrom(p => p.User.FirstName))
                .ForMember(p => p.UserSurname, p => p.MapFrom(p => p.User.LastName)).ReverseMap();
            CreateMap<UserSocialMediaAddress, GetByIdUserSocialMediaAddressDto>()
                .ForMember(p => p.UserName, p => p.MapFrom(p => p.User.FirstName))
                .ForMember(p => p.UserSurname, p => p.MapFrom(p => p.User.LastName)).ReverseMap();
        }
    }
}
