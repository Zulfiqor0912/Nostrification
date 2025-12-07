using MediatR;
using Nostrification.Application.Claims.Dtos;

namespace Nostrification.Application.Claims.Queries.GetClaimById;

public class GetClaimByIdQuery(int id) : IRequest<ClaimDto>
{
    public int Id { get; set; } = id;
}
