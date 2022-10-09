using Application.Features.UserOperationClaims.Dtos;

namespace Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimListModel
    {
        public ICollection<GetListUserOperationClaimDto> Items { get; set; }
    }
}
