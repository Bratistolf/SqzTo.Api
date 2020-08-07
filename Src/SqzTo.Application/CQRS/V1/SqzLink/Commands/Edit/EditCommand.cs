using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Edit
{
    public class EditCommand : IRequest
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }

        public PropertyToPatch[] PropertiesToPatch;

        public class PropertyToPatch
        {
            [JsonPropertyName("property")]
            public string Property { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
        }
    }
}
