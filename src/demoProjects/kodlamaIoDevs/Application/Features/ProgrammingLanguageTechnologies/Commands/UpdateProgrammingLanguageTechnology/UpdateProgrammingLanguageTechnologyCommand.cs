using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommand : IRequest<UpdatedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommand, UpdatedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public UpdateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageTechnologyDto> Handle(UpdateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyIdShouldBeExist(request.Id);
                await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyNameCanNotBeDuplicated(request.Name);

                ProgrammingLanguageTechnology mappedProgrammingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
                ProgrammingLanguageTechnology updatedProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.UpdateAsync(mappedProgrammingLanguageTechnology);
                UpdatedProgrammingLanguageTechnologyDto updatedProgrammingLanguageTechnologyDto = _mapper.Map<UpdatedProgrammingLanguageTechnologyDto>(updatedProgrammingLanguageTechnology);

                return updatedProgrammingLanguageTechnologyDto;
            }
        }
    }
}
