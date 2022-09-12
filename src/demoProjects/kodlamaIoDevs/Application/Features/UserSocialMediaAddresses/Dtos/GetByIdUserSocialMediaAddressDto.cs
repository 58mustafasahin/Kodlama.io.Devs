namespace Application.Features.UserSocialMediaAddresses.Dtos
{
    public class GetByIdUserSocialMediaAddressDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
    }
}
