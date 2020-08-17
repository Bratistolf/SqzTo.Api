using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Create
{
    public class CreateResponse
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }
    }
}
