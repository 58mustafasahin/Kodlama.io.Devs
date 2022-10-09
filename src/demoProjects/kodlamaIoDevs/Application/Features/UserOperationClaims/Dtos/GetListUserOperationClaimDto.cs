namespace Application.Features.UserOperationClaims.Dtos
{
    public class GetListUserOperationClaimDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
    }
}
