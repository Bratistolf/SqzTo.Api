using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetClicks
{
    public class GetClicksResponce
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }

        [JsonPropertyName("clicks")]
        public int Clicks { get; set; }
    }
}
