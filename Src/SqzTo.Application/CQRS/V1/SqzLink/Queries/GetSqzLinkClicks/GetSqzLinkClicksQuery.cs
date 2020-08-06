using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkClicks
{
    public class GetSqzLinkClicksQuery : IRequest<GetSqzLinkClicksDto>
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}