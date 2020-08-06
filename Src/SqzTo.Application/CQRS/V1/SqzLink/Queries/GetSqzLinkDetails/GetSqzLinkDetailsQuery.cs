using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkDetails
{
    public class GetSqzLinkDetailsQuery : IRequest<GetSqzLinkDetailsDto>
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
