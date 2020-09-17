using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.Link.Queries.GetSqzLinkQr
{
    public class GetSqzLinkQrQuery : IRequest<GetSqzLinkQrDto>
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
