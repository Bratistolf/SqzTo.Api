using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.Link.Queries.GetSqzLinkDetails
{
    public class GetDetailsResponse
    {
        [JsonPropertyName("sqzlink")]
        public string Link { get; set; }

        [JsonPropertyName("destination_url")]
        public string Url { get; set; }

        [JsonPropertyName("clicks")]
        public int Clicks { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }
    }
}
