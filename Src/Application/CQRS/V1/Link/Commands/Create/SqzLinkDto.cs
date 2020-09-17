using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.Link.Commands.Create
{
    public class SqzLinkDto
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
