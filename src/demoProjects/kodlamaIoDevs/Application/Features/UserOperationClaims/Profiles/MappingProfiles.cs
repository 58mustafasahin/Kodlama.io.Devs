using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>()
                .ForMember(p => p.UserFirstName, p => p.MapFrom(p => p.User.FirstName))
                .ForMember(p => p.UserLastName, p => p.MapFrom(p => p.User.LastName))
                .ForMember(p => p.OperationClaimName, p => p.MapFrom(p => p.OperationClaim.Name)).ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>()
                .ForMember(p => p.UserFirstName, p => p.MapFrom(p => p.User.FirstName))
                .ForMember(p => p.UserLastName, p => p.MapFrom(p => p.User.LastName))
                .ForMember(p => p.OperationClaimName, p => p.MapFrom(p => p.OperationClaim.Name)).ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>()
                .ForMember(p => p.UserFirstName, p => p.MapFrom(p => p.User.FirstName))
                .ForMember(p => p.UserLastName, p => p.MapFrom(p => p.User.LastName))
                .ForMember(p => p.OperationClaimName, p => p.MapFrom(p => p.OperationClaim.Name)).ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();

            CreateMap<UserOperationClaim, GetListUserOperationClaimDto>()
                .ForMember(p => p.UserFirstName, p => p.MapFrom(p => p.User.FirstName))
                .ForMember(p => p.UserLastName, p => p.MapFrom(p => p.User.LastName))
                .ForMember(p => p.OperationClaimName, p => p.MapFrom(p => p.OperationClaim.Name)).ReverseMap();
            CreateMap<UserOperationClaim, GetByIdUserOperationClaimDto>()
                .ForMember(p => p.UserFirstName, p => p.MapFrom(p => p.User.FirstName))
                .ForMember(p => p.UserLastName, p => p.MapFrom(p => p.User.LastName))
                .ForMember(p => p.OperationClaimName, p => p.MapFrom(p => p.OperationClaim.Name)).ReverseMap();
        }
    }
}
