namespace Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    public class GetByIdProgrammingLanguageTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
