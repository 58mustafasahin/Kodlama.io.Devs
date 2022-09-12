using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{
    public class GetListProgrammingLanguageTechnologyQuery : IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageTechnology> programmingLanguageTechnologies = await _programmingLanguageTechnologyRepository.GetListAsync(include: p => p.Include(p => p.ProgrammingLanguage), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ProgrammingLanguageTechnologyListModel mappedProgrammingLanguageTechnologyListModel = _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);

                return mappedProgrammingLanguageTechnologyListModel;
            }
        }
    }
}
