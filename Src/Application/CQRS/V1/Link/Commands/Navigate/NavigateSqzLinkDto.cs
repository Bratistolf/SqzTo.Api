using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.Link.Commands.Navigate
{
    public class NavigateResponse
    {
        [JsonPropertyName("destination_url")]
        public string DestinationUrl { get; set; }
    }
}
