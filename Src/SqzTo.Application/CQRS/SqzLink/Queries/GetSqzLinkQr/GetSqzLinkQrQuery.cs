using MediatR;

namespace SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkQr
{
    public class GetSqzLinkQrQuery : IRequest<GetSqzLinkQrDto>
    {
        public string Route { get; set; }
    }
}
