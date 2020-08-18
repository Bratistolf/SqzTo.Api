using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetClicks
{
    public class GetClicksRequest : IRequest<GetClicksResponce>
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}