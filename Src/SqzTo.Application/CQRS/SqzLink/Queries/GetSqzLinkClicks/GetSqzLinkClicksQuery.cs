using MediatR;

namespace SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkClicks
{
    public class GetSqzLinkClicksQuery : IRequest<GetSqzLinkClicksDto>
    {
        public string Route { get; set; }
    }
}