﻿using Application.Features.OperationClaims.Dtos;

namespace Application.Features.OperationClaims.Models
{
    public class OperationClaimListModel
    {
        public ICollection<GetListOperationClaimDto> Items { get; set; }
    }
}
