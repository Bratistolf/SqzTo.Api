using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.Link.Queries.GetSqzLinkDetails
{
    public class GetDetailsRequest : IRequest<GetDetailsResponse>
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
