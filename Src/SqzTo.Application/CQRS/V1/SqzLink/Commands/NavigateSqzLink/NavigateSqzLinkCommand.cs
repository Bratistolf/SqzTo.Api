using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.NavigateSqzLink
{
    public class NavigateSqzLinkCommand : IRequest<NavigateSqzLinkDto>
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
