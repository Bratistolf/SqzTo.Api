using MediatR;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkDetails
{
    public class GetSqzLinkDetailsQuery : IRequest<GetSqzLinkDetailsDto>
    {
        public string Link { get; set; }
    }
}
