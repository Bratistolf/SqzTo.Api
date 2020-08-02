using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.NavigateSqzLink
{
    public class NavigateSqzLinkDto
    {
        [JsonPropertyName("destination_url")]
        public string DestinationUrl { get; set; }
    }
}
