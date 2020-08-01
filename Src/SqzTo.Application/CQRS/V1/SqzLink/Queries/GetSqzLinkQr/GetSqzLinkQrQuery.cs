using MediatR;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkQr
{
    public class GetSqzLinkQrQuery : IRequest<GetSqzLinkQrDto>
    {
        public string Link { get; set; }
    }
}
