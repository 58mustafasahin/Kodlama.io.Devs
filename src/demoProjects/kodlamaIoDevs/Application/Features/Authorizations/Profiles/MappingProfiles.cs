using Application.Features.Authorizations.Commands.LoginUser;
using Application.Features.Authorizations.Commands.RegisterUser;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Authorizations.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, LoginUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
        }
    }
}