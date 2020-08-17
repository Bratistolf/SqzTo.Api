using MediatR;
using System.Text.Json.Serialization;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Edit
{
    public class EditRequest : IRequest
    {
        [JsonPropertyName("sqzlink")]
        public string SqzLink { get; set; }

        /// <summary>
        /// Body of the request.
        /// </summary>
        public EditRequestBody Body { get; set; }
    }
}
