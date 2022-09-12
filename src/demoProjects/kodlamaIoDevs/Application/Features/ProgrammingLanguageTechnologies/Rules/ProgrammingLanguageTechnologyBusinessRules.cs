using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguageTechnologies.Rules
{
    public class ProgrammingLanguageTechnologyBusinessRules
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

        public ProgrammingLanguageTechnologyBusinessRules(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
        }

        public async Task ProgrammingLanguageTechnologyNameCanNotBeDuplicated(string name)
        {
            IPaginate<ProgrammingLanguageTechnology> result = await _programmingLanguageTechnologyRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Language Technology name exists.");
        }

        public async Task ProgrammingLanguageTechnologyIdShouldBeExist(int id)
        {
            IPaginate<ProgrammingLanguageTechnology> result = await _programmingLanguageTechnologyRepository.GetListAsync(p => p.Id == id);
            if (!result.Items.Any()) throw new BusinessException("Programming Language Technology not found.");
        }

        public void ProgrammingLanguageTechnologyShouldExistWhenRequested(ProgrammingLanguageTechnology programmingLanguageTechnology)
        {
            if (programmingLanguageTechnology == null) throw new BusinessException("Requested Programming Language Technology does not exist.");
        }
    }
}
