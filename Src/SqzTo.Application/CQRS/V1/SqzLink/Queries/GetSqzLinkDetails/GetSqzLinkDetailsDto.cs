using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkDetails
{
    public class GetSqzLinkDetailsDto
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
