using Application.Features.UserSocialMediaAddresses.Dtos;

namespace Application.Features.UserSocialMediaAddresses.Models
{
    public class UserSocialMediaAddressListModel
    {
        public IList<GetListUserSocialMediaAddressDto> Items { get; set; }
    }
}
