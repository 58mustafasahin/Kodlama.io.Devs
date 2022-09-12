using Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguageTechnology, CreatedProgrammingLanguageTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologyListModel>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, GetListProgrammingLanguageTechnologyDto>().ForMember(p => p.ProgrammingLanguageName, p => p.MapFrom(p => p.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, GetByIdProgrammingLanguageTechnologyDto>().ForMember(p => p.ProgrammingLanguageName, p => p.MapFrom(p => p.ProgrammingLanguage.Name)).ReverseMap();
        }
    }
}

