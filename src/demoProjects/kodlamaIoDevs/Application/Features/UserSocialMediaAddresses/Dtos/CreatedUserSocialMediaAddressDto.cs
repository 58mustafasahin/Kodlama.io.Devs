namespace Application.Features.UserSocialMediaAddresses.Dtos
{
    public class CreatedUserSocialMediaAddressDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
