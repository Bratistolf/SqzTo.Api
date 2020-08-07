using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.EditDescription
{
    public class EditDescriptionCommand : IRequest
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
