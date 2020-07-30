using MediatR;

namespace SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkDetails
{
    public class GetSqzLinkDetailsQuery : IRequest<GetSqzLinkDetailsDto>
    {
        public string Route { get; set; }
    }
}
