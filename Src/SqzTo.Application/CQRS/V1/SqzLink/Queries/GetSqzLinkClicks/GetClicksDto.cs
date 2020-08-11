using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetClicks
{
    public class GetClicksResponce
    {
        [JsonPropertyName("clicks")]
        public int Clicks { get; set; }

        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
