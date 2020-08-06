using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.CreateSqzLink
{
    public class CreateSqzLinkDto
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
