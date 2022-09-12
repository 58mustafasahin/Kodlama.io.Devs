using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologyByDynamic
{
    public class GetListProgrammingLanguageTechnologyByDynamicQuery : IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetListProgrammingLanguageTechnologyByDynamicQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyByDynamicQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageTechnologyByDynamicQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageTechnology> programmingLanguageTechnologies = await _programmingLanguageTechnologyRepository.GetListByDynamicAsync(request.Dynamic, include: p => p.Include(p => p.ProgrammingLanguage), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ProgrammingLanguageTechnologyListModel mappedProgrammingLanguageTechnologyListModel = _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);

                return mappedProgrammingLanguageTechnologyListModel;
            }
        }
    }
}

