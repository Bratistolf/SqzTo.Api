using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkClicks
{
    public class GetSqzLinkClicksDto
    {
        [JsonPropertyName("clicks")]
        public int Clicks { get; set; }

        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
