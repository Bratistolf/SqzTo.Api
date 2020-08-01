using MediatR;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkClicks
{
    public class GetSqzLinkClicksQuery : IRequest<GetSqzLinkClicksDto>
    {
        public string SqzLink { get; set; }
    }
}